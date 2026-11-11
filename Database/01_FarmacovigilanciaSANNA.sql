/* ===================================================================
   FarmacovigilanciaSANNA - Script de base de datos (SQL Server)
   Modelo en 3FN: 20 tablas | Incluye datos de prueba y procedimientos
   =================================================================== */
IF DB_ID(N'FarmacovigilanciaSANNA') IS NULL CREATE DATABASE FarmacovigilanciaSANNA;
GO
USE FarmacovigilanciaSANNA;
GO
/* ---------- SEGURIDAD Y PERSONAL ---------- */
CREATE TABLE Rol(
  IdRol INT IDENTITY(1,1) PRIMARY KEY,
  Nombre VARCHAR(30) NOT NULL UNIQUE);
CREATE TABLE Especialidad(
  IdEspecialidad INT IDENTITY(1,1) PRIMARY KEY,
  Nombre VARCHAR(60) NOT NULL UNIQUE,
  Activo BIT NOT NULL DEFAULT 1);
CREATE TABLE Personal(
  IdPersonal INT IDENTITY(1,1) PRIMARY KEY,
  TipoPersonal VARCHAR(25) NOT NULL CHECK (TipoPersonal IN ('Médico','Enfermero/a','Químico farmacéutico','Admisión')),
  NroDocumento VARCHAR(15) NOT NULL UNIQUE,
  Apellidos VARCHAR(80) NOT NULL,
  Nombres VARCHAR(80) NOT NULL,
  Colegiatura VARCHAR(20) NULL,
  IdEspecialidad INT NULL REFERENCES Especialidad(IdEspecialidad),
  Activo BIT NOT NULL DEFAULT 1,
  CONSTRAINT CK_Personal_Esp CHECK (IdEspecialidad IS NULL OR TipoPersonal='Médico'));
CREATE TABLE Usuario(
  IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
  NombreUsuario VARCHAR(30) NOT NULL UNIQUE,
  ClaveHash VARBINARY(32) NOT NULL,   -- SHA2-256(sal + clave en UTF-16LE)
  ClaveSal  VARBINARY(16) NOT NULL,
  IdRol INT NOT NULL REFERENCES Rol(IdRol),
  IdPersonal INT NULL REFERENCES Personal(IdPersonal),
  Activo BIT NOT NULL DEFAULT 1);
CREATE TABLE ParametroSistema(
  Clave VARCHAR(40) PRIMARY KEY,
  Valor VARCHAR(40) NOT NULL,
  Descripcion VARCHAR(150) NULL);
/* ---------- ATENCIÓN AL PACIENTE ---------- */
CREATE TABLE Paciente(
  IdPaciente INT IDENTITY(1,1) PRIMARY KEY,
  NroDocumento VARCHAR(15) NOT NULL UNIQUE,
  Apellidos VARCHAR(80) NOT NULL,
  Nombres VARCHAR(80) NOT NULL,
  FechaNacimiento DATE NOT NULL,
  Sexo CHAR(1) NOT NULL CHECK (Sexo IN ('M','F')),
  Telefono VARCHAR(15) NULL,
  Activo BIT NOT NULL DEFAULT 1);
CREATE TABLE Cita(
  IdCita INT IDENTITY(1,1) PRIMARY KEY,
  IdPaciente INT NOT NULL REFERENCES Paciente(IdPaciente),
  IdPersonal INT NOT NULL REFERENCES Personal(IdPersonal),
  IdEspecialidad INT NULL REFERENCES Especialidad(IdEspecialidad),
  FechaHora DATETIME2(0) NOT NULL,
  Motivo VARCHAR(200) NOT NULL,
  Estado VARCHAR(15) NOT NULL DEFAULT 'Programada' CHECK (Estado IN ('Programada','Atendida','Cancelada')));
CREATE UNIQUE INDEX UX_Cita_Medico_Hora ON Cita(IdPersonal, FechaHora) WHERE Estado='Programada';
CREATE TABLE Atencion(
  IdAtencion INT IDENTITY(1,1) PRIMARY KEY,
  IdPaciente INT NOT NULL REFERENCES Paciente(IdPaciente),
  IdPersonal INT NOT NULL REFERENCES Personal(IdPersonal),
  IdCita INT NULL REFERENCES Cita(IdCita),
  TipoIngreso VARCHAR(15) NOT NULL CHECK (TipoIngreso IN ('Con cita','Emergencia')),
  FechaHora DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
  Evaluacion VARCHAR(500) NULL,
  Diagnostico VARCHAR(200) NULL,
  Indicaciones VARCHAR(500) NULL,
  Estado VARCHAR(15) NOT NULL DEFAULT 'Abierta' CHECK (Estado IN ('Abierta','Registrada')));
/* ---------- PRODUCTOS Y LOTES ---------- */
CREATE TABLE Laboratorio(
  IdLaboratorio INT IDENTITY(1,1) PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL UNIQUE,
  Activo BIT NOT NULL DEFAULT 1);
CREATE TABLE ProductoFarmaceutico(
  IdProducto INT IDENTITY(1,1) PRIMARY KEY,
  NombreComercial VARCHAR(100) NOT NULL,
  PrincipioActivo VARCHAR(100) NOT NULL,
  FormaFarmaceutica VARCHAR(50) NULL,
  Concentracion VARCHAR(30) NULL,
  IdLaboratorio INT NOT NULL REFERENCES Laboratorio(IdLaboratorio),
  RegistroSanitario VARCHAR(30) NOT NULL UNIQUE,
  Activo BIT NOT NULL DEFAULT 1);
CREATE TABLE LoteProducto(
  IdLote INT IDENTITY(1,1) NOT NULL,
  IdProducto INT NOT NULL,
  NroLote VARCHAR(30) NOT NULL,
  FechaVencimiento DATE NOT NULL,
  Estado VARCHAR(15) NOT NULL DEFAULT 'Vigente' CHECK (Estado IN ('Vigente','Inmovilizado','Vencido')),
  Activo BIT NOT NULL DEFAULT 1,
  CONSTRAINT PK_LoteProducto PRIMARY KEY (IdLote),
  CONSTRAINT FK_LoteProducto_IdProducto FOREIGN KEY (IdProducto) REFERENCES ProductoFarmaceutico(IdProducto));
CREATE UNIQUE INDEX UX_LoteProducto_Producto_Nro ON LoteProducto(IdProducto, NroLote);
CREATE TABLE Administracion(
  IdAdministracion INT IDENTITY(1,1) PRIMARY KEY,
  IdAtencion INT NOT NULL REFERENCES Atencion(IdAtencion),
  IdLote INT NOT NULL REFERENCES LoteProducto(IdLote),
  IdPersonal INT NOT NULL REFERENCES Personal(IdPersonal),
  Dosis VARCHAR(50) NOT NULL,
  Via VARCHAR(20) NOT NULL,
  FechaHora DATETIME2(0) NOT NULL DEFAULT SYSDATETIME());
CREATE INDEX IX_Administracion_Lote ON Administracion(IdLote);
/* ---------- FARMACOVIGILANCIA ---------- */
CREATE TABLE SospechaRAM(
  IdSospecha INT IDENTITY(1,1) PRIMARY KEY,
  CodigoCaso VARCHAR(20) NOT NULL UNIQUE,
  IdPaciente INT NOT NULL REFERENCES Paciente(IdPaciente),
  IdAtencion INT NOT NULL REFERENCES Atencion(IdAtencion),
  FechaHoraDeteccion DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),  -- día cero
  FechaLimite DATETIME2(0) NOT NULL,
  Descripcion VARCHAR(500) NOT NULL,
  Estado VARCHAR(20) NOT NULL DEFAULT 'Registrada' CHECK (Estado IN ('Registrada','Evaluada','En seguimiento','Notificada','Cerrada')),
  IdPersonalRegistra INT NOT NULL REFERENCES Personal(IdPersonal));
CREATE INDEX IX_Sospecha_Estado_Limite ON SospechaRAM(Estado, FechaLimite);
CREATE TABLE SospechaProducto(
  IdSospechaProducto INT IDENTITY(1,1) PRIMARY KEY,
  IdSospecha INT NOT NULL REFERENCES SospechaRAM(IdSospecha),
  IdAdministracion INT NOT NULL REFERENCES Administracion(IdAdministracion),
  RolProducto VARCHAR(15) NOT NULL CHECK (RolProducto IN ('Sospechoso','Concomitante')));
CREATE TABLE Reaccion(
  IdReaccion INT IDENTITY(1,1) PRIMARY KEY,
  IdSospecha INT NOT NULL REFERENCES SospechaRAM(IdSospecha),
  Descripcion VARCHAR(200) NOT NULL,
  FechaInicio DATE NOT NULL);
CREATE TABLE EvaluacionSospecha(
  IdEvaluacion INT IDENTITY(1,1) PRIMARY KEY,
  IdSospecha INT NOT NULL UNIQUE REFERENCES SospechaRAM(IdSospecha),
  Gravedad VARCHAR(10) NOT NULL CHECK (Gravedad IN ('Leve','Moderada','Grave')),
  Causalidad VARCHAR(15) NOT NULL CHECK (Causalidad IN ('Definida','Probable','Posible','Improbable')),
  RequiereNotificacion BIT NOT NULL,
  FechaHora DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
  IdUsuario INT NOT NULL REFERENCES Usuario(IdUsuario));
CREATE TABLE Autoridad(
  IdAutoridad INT IDENTITY(1,1) PRIMARY KEY,
  Nombre VARCHAR(80) NOT NULL UNIQUE,
  Tipo VARCHAR(20) NOT NULL);
CREATE TABLE Notificacion(
  IdNotificacion INT IDENTITY(1,1) PRIMARY KEY,
  IdSospecha INT NOT NULL REFERENCES SospechaRAM(IdSospecha),
  IdAutoridad INT NOT NULL REFERENCES Autoridad(IdAutoridad),
  TipoNotificacion VARCHAR(15) NOT NULL DEFAULT 'Inicial' CHECK (TipoNotificacion IN ('Inicial','Seguimiento')),
  Medio VARCHAR(20) NOT NULL CHECK (Medio IN ('NotiMED','VigiFlow','Mesa de partes')),
  NroExterno VARCHAR(40) NOT NULL,
  FechaHoraEnvio DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
  CumplioPlazo BIT NOT NULL,
  IdUsuario INT NOT NULL REFERENCES Usuario(IdUsuario));
CREATE TABLE Seguimiento(
  IdSeguimiento INT IDENTITY(1,1) PRIMARY KEY,
  IdSospecha INT NOT NULL REFERENCES SospechaRAM(IdSospecha),
  FechaHora DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
  Actuacion VARCHAR(500) NOT NULL,
  Desenlace VARCHAR(20) NOT NULL CHECK (Desenlace IN ('Recuperado','En recuperación','Con secuelas','Fallecido','Desconocido')),
  Cierre BIT NOT NULL DEFAULT 0,
  IdUsuario INT NOT NULL REFERENCES Usuario(IdUsuario));
CREATE TABLE AuditoriaAccion(
  IdAuditoria BIGINT IDENTITY(1,1) PRIMARY KEY,
  IdUsuario INT NULL REFERENCES Usuario(IdUsuario),
  Tabla VARCHAR(40) NOT NULL,
  IdRegistro INT NULL,
  Accion VARCHAR(30) NOT NULL,
  FechaHora DATETIME2(0) NOT NULL DEFAULT SYSDATETIME());
GO
/* ===================== DATOS INICIALES ===================== */
INSERT Rol(Nombre) VALUES('Administrador'),('Admisión'),('Médico'),('Enfermero'),('Químico'),('Comité');
INSERT ParametroSistema VALUES('PlazoGraveHoras','24','Plazo de notificación para sospechas graves'),('PlazoLeveModeradaHoras','72','Plazo para leves o moderadas');
INSERT Autoridad(Nombre,Tipo) VALUES('DIGEMID','Nacional'),('GERESA La Libertad','Regional');
INSERT Especialidad(Nombre) VALUES('Medicina interna'),('Pediatría'),('Cardiología');
INSERT Personal(TipoPersonal,NroDocumento,Apellidos,Nombres,Colegiatura,IdEspecialidad) VALUES
('Médico','40111111','Salazar','Elena','CMP 31245',1),('Médico','40222222','Paredes','Marco','CMP 28771',3),
('Enfermero/a','41333333','Medina','Rosa','CEP 55123',NULL),('Químico farmacéutico','42444444','Cueva','Andrés','CQFP 9876',NULL),
('Admisión','43555555','León','Patricia',NULL,NULL);
-- Usuarios de prueba: contraseña = usuario + '123'
DECLARE @s VARBINARY(16)=0x0102030405060708090A0B0C0D0E0F10;
INSERT Usuario(NombreUsuario,ClaveHash,ClaveSal,IdRol,IdPersonal)
SELECT u,HASHBYTES('SHA2_256',@s+CAST(CONCAT(u,N'123') AS VARBINARY(100))),@s,r,p FROM (VALUES
(N'admin',1,5),(N'admision',2,5),(N'medico',3,1),(N'enfermera',4,3),(N'quimico',5,4),(N'comite',6,2)) v(u,r,p);
INSERT Paciente(NroDocumento,Apellidos,Nombres,FechaNacimiento,Sexo,Telefono) VALUES
('45872136','Quispe Ramos','Luis','1985-03-12','M','944111222'),('70321458','Vega Lozano','Carmen','1992-07-30','F','955333444'),('18204455','Torres Díaz','Julio','1958-11-02','M','966555666');
INSERT Laboratorio(Nombre) VALUES('Lab. Demo S.A.'),('Farma Norte');
INSERT ProductoFarmaceutico(NombreComercial,PrincipioActivo,FormaFarmaceutica,Concentracion,IdLaboratorio,RegistroSanitario) VALUES
('Suero fisiológico 0,9 %','Cloruro de sodio','Solución inyectable','0,9 %',1,'EE-01234'),('Amoxicilina 500 mg','Amoxicilina','Cápsula','500 mg',2,'EE-05678');
INSERT LoteProducto(IdProducto,NroLote,FechaVencimiento,Estado) VALUES
(1,'2123624','2027-06-30','Inmovilizado'),(1,'2200117','2027-12-31','Vigente'),(2,'A-778','2027-03-31','Vigente');
GO
/* ===================== PROCEDIMIENTOS ===================== */
CREATE PROC sp_Auditoria_Registrar @IdUsuario INT,@Tabla VARCHAR(40),@IdRegistro INT,@Accion VARCHAR(30) AS
  INSERT AuditoriaAccion(IdUsuario,Tabla,IdRegistro,Accion) VALUES(@IdUsuario,@Tabla,@IdRegistro,@Accion);
GO
CREATE PROC sp_Usuario_Obtener @NombreUsuario VARCHAR(30) AS
  SELECT u.IdUsuario,u.NombreUsuario,u.ClaveHash,u.ClaveSal,r.Nombre AS Rol,u.Activo
  FROM Usuario u JOIN Rol r ON r.IdRol=u.IdRol WHERE u.NombreUsuario=@NombreUsuario;
GO
CREATE PROC sp_Paciente_Listar @Filtro VARCHAR(80)='' AS
  SELECT * FROM Paciente WHERE @Filtro='' OR NroDocumento LIKE @Filtro+'%' OR Apellidos LIKE '%'+@Filtro+'%' OR Nombres LIKE '%'+@Filtro+'%' ORDER BY Apellidos,Nombres;
GO
CREATE PROC sp_Paciente_Guardar @IdPaciente INT,@NroDocumento VARCHAR(15),@Apellidos VARCHAR(80),@Nombres VARCHAR(80),
  @FechaNacimiento DATE,@Sexo CHAR(1),@Telefono VARCHAR(15),@IdUsuario INT AS
BEGIN
  SET NOCOUNT ON;
  IF EXISTS(SELECT 1 FROM Paciente WHERE NroDocumento=@NroDocumento AND IdPaciente<>@IdPaciente) THROW 50001,'El documento ya está registrado.',1;
  IF @IdPaciente=0 BEGIN
    INSERT Paciente(NroDocumento,Apellidos,Nombres,FechaNacimiento,Sexo,Telefono) VALUES(@NroDocumento,@Apellidos,@Nombres,@FechaNacimiento,@Sexo,@Telefono);
    SET @IdPaciente=SCOPE_IDENTITY(); EXEC sp_Auditoria_Registrar @IdUsuario,'Paciente',@IdPaciente,'Crear';
  END ELSE BEGIN
    UPDATE Paciente SET NroDocumento=@NroDocumento,Apellidos=@Apellidos,Nombres=@Nombres,FechaNacimiento=@FechaNacimiento,Sexo=@Sexo,Telefono=@Telefono WHERE IdPaciente=@IdPaciente;
    EXEC sp_Auditoria_Registrar @IdUsuario,'Paciente',@IdPaciente,'Modificar';
  END
  SELECT @IdPaciente AS IdPaciente;
END
GO
CREATE PROC sp_Paciente_CambiarEstado @IdPaciente INT,@Activo BIT,@IdUsuario INT AS
  UPDATE Paciente SET Activo=@Activo WHERE IdPaciente=@IdPaciente;
  EXEC sp_Auditoria_Registrar @IdUsuario,'Paciente',@IdPaciente,'CambiarEstado';
GO
CREATE PROC sp_Lote_Listar AS
  SELECT l.IdLote,l.IdProducto,p.NombreComercial,l.NroLote,l.FechaVencimiento,l.Estado,l.Activo
  FROM LoteProducto l JOIN ProductoFarmaceutico p ON p.IdProducto=l.IdProducto ORDER BY p.NombreComercial,l.NroLote;
GO
CREATE PROC sp_Lote_Obtener @IdLote INT AS
  SELECT l.IdLote,l.IdProducto,p.NombreComercial,l.NroLote,l.FechaVencimiento,l.Estado,l.Activo
  FROM LoteProducto l JOIN ProductoFarmaceutico p ON p.IdProducto=l.IdProducto WHERE l.IdLote=@IdLote;
GO
CREATE PROC sp_Administracion_Registrar @IdAtencion INT,@IdLote INT,@IdPersonal INT,@Dosis VARCHAR(50),@Via VARCHAR(20) AS
BEGIN
  SET NOCOUNT ON;
  IF EXISTS(SELECT 1 FROM LoteProducto WHERE IdLote=@IdLote AND (Estado<>'Vigente' OR FechaVencimiento<CAST(GETDATE() AS DATE)))
    THROW 50002,'Lote inmovilizado o vencido: administración bloqueada.',1;
  INSERT Administracion(IdAtencion,IdLote,IdPersonal,Dosis,Via) VALUES(@IdAtencion,@IdLote,@IdPersonal,@Dosis,@Via);
  SELECT SCOPE_IDENTITY() AS IdAdministracion;
END
GO
CREATE PROC sp_Sospecha_Registrar @IdAtencion INT,@IdAdministracion INT,@RolProducto VARCHAR(15),@Reaccion VARCHAR(200),
  @FechaInicio DATE,@Descripcion VARCHAR(500),@IdPersonal INT AS
BEGIN
  SET NOCOUNT ON; SET XACT_ABORT ON; BEGIN TRAN;
  DECLARE @pac INT=(SELECT IdPaciente FROM Atencion WHERE IdAtencion=@IdAtencion),
          @h INT=(SELECT CAST(Valor AS INT) FROM ParametroSistema WHERE Clave='PlazoGraveHoras'),
          @n INT=(SELECT COUNT(*)+1 FROM SospechaRAM WHERE YEAR(FechaHoraDeteccion)=YEAR(GETDATE())),
          @det DATETIME2(0)=SYSDATETIME(), @id INT;
  INSERT SospechaRAM(CodigoCaso,IdPaciente,IdAtencion,FechaHoraDeteccion,FechaLimite,Descripcion,IdPersonalRegistra)
  VALUES(CONCAT('RAM-',YEAR(@det),'-',RIGHT('000'+CAST(@n AS VARCHAR(5)),3)),@pac,@IdAtencion,@det,DATEADD(HOUR,@h,@det),@Descripcion,@IdPersonal);
  SET @id=SCOPE_IDENTITY();
  INSERT SospechaProducto(IdSospecha,IdAdministracion,RolProducto) VALUES(@id,@IdAdministracion,@RolProducto);
  INSERT Reaccion(IdSospecha,Descripcion,FechaInicio) VALUES(@id,@Reaccion,@FechaInicio);
  COMMIT;
  SELECT IdSospecha,CodigoCaso,FechaLimite FROM SospechaRAM WHERE IdSospecha=@id;
END
GO
CREATE PROC sp_Sospecha_Evaluar @IdSospecha INT,@Gravedad VARCHAR(10),@Causalidad VARCHAR(15),@Requiere BIT,@IdUsuario INT AS
BEGIN
  SET NOCOUNT ON; SET XACT_ABORT ON; BEGIN TRAN;
  DECLARE @h INT=(SELECT CAST(Valor AS INT) FROM ParametroSistema WHERE Clave=IIF(@Gravedad='Grave','PlazoGraveHoras','PlazoLeveModeradaHoras'));
  INSERT EvaluacionSospecha(IdSospecha,Gravedad,Causalidad,RequiereNotificacion,IdUsuario) VALUES(@IdSospecha,@Gravedad,@Causalidad,@Requiere,@IdUsuario);
  UPDATE SospechaRAM SET FechaLimite=DATEADD(HOUR,@h,FechaHoraDeteccion),Estado=IIF(@Requiere=1,'Evaluada','En seguimiento') WHERE IdSospecha=@IdSospecha;
  EXEC sp_Auditoria_Registrar @IdUsuario,'SospechaRAM',@IdSospecha,'Evaluar';
  COMMIT;
END
GO
CREATE PROC sp_Notificacion_Registrar @IdSospecha INT,@IdAutoridad INT,@Medio VARCHAR(20),@NroExterno VARCHAR(40),@IdUsuario INT AS
BEGIN
  SET NOCOUNT ON; SET XACT_ABORT ON; BEGIN TRAN;
  DECLARE @ok BIT=IIF(SYSDATETIME()<=(SELECT FechaLimite FROM SospechaRAM WHERE IdSospecha=@IdSospecha),1,0);
  INSERT Notificacion(IdSospecha,IdAutoridad,Medio,NroExterno,CumplioPlazo,IdUsuario) VALUES(@IdSospecha,@IdAutoridad,@Medio,@NroExterno,@ok,@IdUsuario);
  UPDATE SospechaRAM SET Estado='Notificada' WHERE IdSospecha=@IdSospecha;
  EXEC sp_Auditoria_Registrar @IdUsuario,'Notificacion',@IdSospecha,'Notificar';
  COMMIT; SELECT @ok AS CumplioPlazo;
END
GO
CREATE PROC sp_Seguimiento_Registrar @IdSospecha INT,@Actuacion VARCHAR(500),@Desenlace VARCHAR(20),@Cierre BIT,@IdUsuario INT AS
BEGIN
  SET NOCOUNT ON; SET XACT_ABORT ON; BEGIN TRAN;
  INSERT Seguimiento(IdSospecha,Actuacion,Desenlace,Cierre,IdUsuario) VALUES(@IdSospecha,@Actuacion,@Desenlace,@Cierre,@IdUsuario);
  IF @Cierre=1 UPDATE SospechaRAM SET Estado='Cerrada' WHERE IdSospecha=@IdSospecha;
  COMMIT;
END
GO
CREATE PROC sp_Sospecha_Listar @Estado VARCHAR(20)='' AS
  SELECT s.IdSospecha,s.CodigoCaso,p.Apellidos+', '+p.Nombres AS Paciente,e.Gravedad,s.FechaHoraDeteccion,s.FechaLimite,s.Estado,
         DATEDIFF(MINUTE,SYSDATETIME(),s.FechaLimite) AS MinutosRestantes
  FROM SospechaRAM s JOIN Paciente p ON p.IdPaciente=s.IdPaciente LEFT JOIN EvaluacionSospecha e ON e.IdSospecha=s.IdSospecha
  WHERE @Estado='' OR s.Estado=@Estado ORDER BY s.FechaLimite;
GO
CREATE PROC sp_Consulta_ExpuestosPorLote @IdProducto INT,@NroLote VARCHAR(30) AS
  SELECT p.NroDocumento,p.Apellidos,p.Nombres,a.FechaHora,a.IdAtencion
  FROM Administracion a JOIN Atencion t ON t.IdAtencion=a.IdAtencion JOIN Paciente p ON p.IdPaciente=t.IdPaciente
  JOIN LoteProducto l ON l.IdLote=a.IdLote WHERE l.IdProducto=@IdProducto AND l.NroLote=@NroLote ORDER BY a.FechaHora DESC;
GO
PRINT 'Base FarmacovigilanciaSANNA creada correctamente.';
