/*
   viernes, 14 de diciembre de 201809:07:36 a.m.
   Usuario: 
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
ALTER TABLE dbo.IndiceCarga ADD
	NumeroManual bit NULL
GO
ALTER TABLE dbo.IndiceCarga ADD CONSTRAINT
	DF_IndiceCarga_NumeroManual DEFAULT 0 FOR NumeroManual
GO
ALTER TABLE dbo.IndiceCarga SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.IndiceCarga', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.IndiceCarga', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.IndiceCarga', 'Object', 'CONTROL') as Contr_Per 