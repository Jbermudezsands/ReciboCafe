/*
   martes, 18 de septiembre de 201810:12:51 a.m.
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
CREATE TABLE dbo.DetalleReciboCafePergamino
	(
	IdDetalleReciboPergamino int NOT NULL,
	CantidadSacos int NULL,
	Humedad decimal(38, 20) NULL,
	Tara decimal(38, 20) NULL,
	Imperfeccion decimal(38, 20) NULL,
	IdReciboPergamino int NULL,
	IdTipoSaco int NULL,
	IdEdoFisico int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.DetalleReciboCafePergamino ADD CONSTRAINT
	PK_DetalleReciboCafePergamino PRIMARY KEY CLUSTERED 
	(
	IdDetalleReciboPergamino
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.DetalleReciboCafePergamino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.DetalleReciboCafePergamino', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DetalleReciboCafePergamino', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DetalleReciboCafePergamino', 'Object', 'CONTROL') as Contr_Per 