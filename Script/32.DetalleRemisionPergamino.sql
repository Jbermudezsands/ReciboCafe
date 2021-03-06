/*
   viernes, 23 de agosto de 201910:08:01 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2014
   Base de datos: TRANSPORTE1
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
ALTER TABLE dbo.DetalleRemisionPergamino ADD
	PesoBruto2 decimal(38, 20) NULL,
	Tara2 decimal(38, 20) NULL
GO
ALTER TABLE dbo.DetalleRemisionPergamino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.DetalleRemisionPergamino', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DetalleRemisionPergamino', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DetalleRemisionPergamino', 'Object', 'CONTROL') as Contr_Per 