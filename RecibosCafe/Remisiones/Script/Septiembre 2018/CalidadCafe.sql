/*
   martes, 18 de septiembre de 201801:43:41 p.m.
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2014
   Base de datos: TRANSPORTE
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
CREATE TABLE dbo.CalidadCafe
	(
	IdCalidad int NOT NULL IDENTITY (1, 1),
	Calidad nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.CalidadCafe ADD CONSTRAINT
	PK_CalidadCafe PRIMARY KEY CLUSTERED 
	(
	IdCalidad
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.CalidadCafe SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CalidadCafe', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CalidadCafe', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CalidadCafe', 'Object', 'CONTROL') as Contr_Per 