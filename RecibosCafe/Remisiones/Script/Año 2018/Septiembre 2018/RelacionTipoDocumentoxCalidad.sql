/*
   miércoles, 03 de octubre de 201809:47:22 a.m.
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
CREATE TABLE dbo.RelacionTipoDocumentoxCalidad
	(
	IdtipoDocumento int NOT NULL,
	IdCalidad int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.RelacionTipoDocumentoxCalidad ADD CONSTRAINT
	PK_RelacionTipoDocumentoxCalidad PRIMARY KEY CLUSTERED 
	(
	IdtipoDocumento,
	IdCalidad
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.RelacionTipoDocumentoxCalidad SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.RelacionTipoDocumentoxCalidad', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.RelacionTipoDocumentoxCalidad', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.RelacionTipoDocumentoxCalidad', 'Object', 'CONTROL') as Contr_Per 