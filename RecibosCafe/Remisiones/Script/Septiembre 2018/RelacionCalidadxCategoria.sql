/*
   miércoles, 26 de septiembre de 201809:11:07 a.m.
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
CREATE TABLE dbo.RelacionCalidadxCategoria
	(
	IdCalidad int NULL,
	IdCategoriaCAfe int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.RelacionCalidadxCategoria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.RelacionCalidadxCategoria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.RelacionCalidadxCategoria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.RelacionCalidadxCategoria', 'Object', 'CONTROL') as Contr_Per 