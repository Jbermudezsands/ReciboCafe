/*
   sábado, 07 de abril de 201810:49:55 a.m.
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
ALTER TABLE dbo.Recepcion ADD
	Reportada bit NULL
GO
ALTER TABLE dbo.Recepcion ADD CONSTRAINT
	DF_Recepcion_Reportada DEFAULT 0 FOR Reportada
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Recepcion', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Recepcion', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Recepcion', 'Object', 'CONTROL') as Contr_Per 