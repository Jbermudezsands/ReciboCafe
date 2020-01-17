/*
   jueves, 07 de febrero de 201903:32:49 p.m.
   Usuario: sa
   Servidor: SOPORTESANDS-PC\SOPORTE2018
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
	IdLocalidadRegistro int NULL
GO
ALTER TABLE dbo.ReciboCafePergamino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
