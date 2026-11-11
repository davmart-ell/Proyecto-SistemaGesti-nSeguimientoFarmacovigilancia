# SANNA · Sistema de farmacovigilancia (C# Windows Forms + SQL Server)

## Puesta en marcha
1. Abra `Database/01_FarmacovigilanciaSANNA.sql` en SQL Server Management Studio y ejecútelo (crea la BD, 20 tablas, datos de prueba y procedimientos).
2. Abra `SANNA.sln` en Visual Studio 2022 (carga «Desarrollo de escritorio .NET», SDK .NET 8).
3. Ajuste el servidor en `SANNA.Datos/Conexion.cs` (por defecto `localhost`; SQL Express: `.\SQLEXPRESS`).
4. Proyecto de inicio: `SANNA.Presentacion`. Ejecute con F5.

Usuarios de prueba: admin, admision, medico, enfermera, quimico, comite — contraseña = usuario + `123`.

## Arquitectura (Tabla 43 del informe)
Presentacion (WinForms) → Negocio (reglas) → Datos (SQL Server, procedimientos) → Entidades.

## Ya implementado
Login con hash+sal y roles · mantenedor de pacientes (CUS02) · consulta de lotes (CUS06) · bloqueo de lotes · cálculo de plazos 24/72 h · acceso a datos de sospechas · procedimientos de todo el flujo CORE y de la consulta de expuestos (CUS17).

## Pendiente (patrón: copiar FrmPacientes + sp_* + capas Datos/Negocio)
CUS03/04/05/07 mantenedores · CUS08–CUS15 formularios CORE · CUS16–CUS19 consultas y reportes.
