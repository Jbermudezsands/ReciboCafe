/*
   lunes, 10 de junio de 201910:14:59 a.m.
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
ALTER TABLE dbo.DetalleReciboCafePergamino ADD CONSTRAINT
	DF_DetalleReciboCafePergamino_PesoBrutoRemisionado DEFAULT 0 FOR PesoBrutoRemisionado
GO
ALTER TABLE dbo.DetalleReciboCafePergamino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
