/*
   lunes, 26 de agosto de 201905:46:53 p.m.
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
ALTER TABLE dbo.DetalleIntermadio ADD
	PesoBrutoEntrada decimal(38, 20) NULL
GO
ALTER TABLE dbo.DetalleIntermadio SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
