/*
   domingo, 26 de mayo de 201908:54:23 p.m.
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
ALTER TABLE dbo.ReciboCafePergamino ADD
	SeleccionRemision bit NULL,
	AplicarRemision bit NULL
GO
ALTER TABLE dbo.ReciboCafePergamino ADD CONSTRAINT
	DF_ReciboCafePergamino_SeleccionRemision DEFAULT 0 FOR SeleccionRemision
GO
ALTER TABLE dbo.ReciboCafePergamino ADD CONSTRAINT
	DF_ReciboCafePergamino_AplicarRemision DEFAULT 0 FOR AplicarRemision
GO
ALTER TABLE dbo.ReciboCafePergamino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
