/*
   miércoles, 20 de marzo de 201922:15:21
   Usuario: sa
   Servidor: DESKTOP-SQU6PUC\SQLEXPRESS
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
EXECUTE sp_rename N'dbo.LiquidacionPergamino.PrecioBase', N'Tmp_PrecioAutoriza_1', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.LiquidacionPergamino.Tmp_PrecioAutoriza_1', N'PrecioAutoriza', 'COLUMN' 
GO
ALTER TABLE dbo.LiquidacionPergamino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.LiquidacionPergamino', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.LiquidacionPergamino', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.LiquidacionPergamino', 'Object', 'CONTROL') as Contr_Per 