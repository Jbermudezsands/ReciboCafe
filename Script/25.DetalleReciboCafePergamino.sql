/*
   martes, 18 de junio de 201909:12:24 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2014
   Base de datos: TRANSPORTE_AGRANCHOGRANDE
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
	CantidadSacos2 int NULL
GO
ALTER TABLE dbo.DetalleRemisionPergamino ADD CONSTRAINT
	DF_DetalleRemisionPergamino_CantidadSacos2 DEFAULT 0 FOR CantidadSacos2
GO
ALTER TABLE dbo.DetalleRemisionPergamino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
