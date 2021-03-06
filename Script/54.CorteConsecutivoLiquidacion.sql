/*
   lunes, 20 de julio de 202003:41:30 p.m.
   Usuario: 
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
CREATE TABLE dbo.CorteConsecutivoLiquidacion
	(
	IdCosecha float(53) NOT NULL,
	IdLocalidad float(53) NOT NULL,
	Consecutivo float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.CorteConsecutivoLiquidacion ADD CONSTRAINT
	DF_CorteConsecutivoLiquidacion_Consecutivo DEFAULT 0 FOR Consecutivo
GO
ALTER TABLE dbo.CorteConsecutivoLiquidacion ADD CONSTRAINT
	PK_CorteConsecutivoLiquidacion PRIMARY KEY CLUSTERED 
	(
	IdCosecha,
	IdLocalidad
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.CorteConsecutivoLiquidacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
