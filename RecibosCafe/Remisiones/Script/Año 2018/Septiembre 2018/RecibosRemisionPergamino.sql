/*
   martes, 18 de septiembre de 201810:23:56 a.m.
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2014
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
CREATE TABLE dbo.RecibosRemisionPergamino
	(
	IdReciboRemisionPergamino int NOT NULL,
	PesoNeto decimal(38, 20) NULL,
	IdDetalleReciboPergamino int NULL,
	IdDetalleRemsionPergamino int NULL,
	IdUsuario int NULL,
	Orden int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.RecibosRemisionPergamino ADD CONSTRAINT
	PK_RecibosRemisionPergamino PRIMARY KEY CLUSTERED 
	(
	IdReciboRemisionPergamino
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.RecibosRemisionPergamino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.RecibosRemisionPergamino', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.RecibosRemisionPergamino', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.RecibosRemisionPergamino', 'Object', 'CONTROL') as Contr_Per 