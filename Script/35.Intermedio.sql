/*
   domingo, 01 de septiembre de 20199:37:55
   Usuario: 
   Servidor: WIN-M13RQ730J8P\SQL2014
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
ALTER TABLE dbo.Intermedio ADD
	PesoBrutoEntrada decimal(38, 20) NULL
GO
ALTER TABLE dbo.Intermedio SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
