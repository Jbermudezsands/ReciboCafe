/*
   sábado, 07 de abril de 201810:22:50 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2005
   Base de datos: Remisiones
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Reporta
	(
	IdReportaExistencia int NOT NULL IDENTITY (1, 1),
	ReportaExistencia nvarchar(50) NULL,
	FechaReporta datetime NULL,
	IdLugarAcopio int NULL,
	NumeroBoleta nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Reporta ADD CONSTRAINT
	PK_Reporta PRIMARY KEY CLUSTERED 
	(
	IdReportaExistencia
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
