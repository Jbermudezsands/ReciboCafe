/*
   viernes, 01 de noviembre de 201910:33:46 a.m.
   Usuario: sa
   Servidor: JUANBERMUDEZ-PC\SQL2014
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
ALTER TABLE dbo.ReciboCafePergamino ADD
	Remisionado bit NULL
GO
ALTER TABLE dbo.ReciboCafePergamino ADD CONSTRAINT
	DF_ReciboCafePergamino_Remisionado DEFAULT 0 FOR Remisionado
GO
ALTER TABLE dbo.ReciboCafePergamino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
