/*
   martes, 18 de septiembre de 201810:42:00 a.m.
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
CREATE TABLE dbo.Intermedio
	(
	IdIntermedio int NOT NULL,
	CatidadSacosOrigen int NULL,
	PesoBrutoOrigen decimal(38, 20) NULL,
	CantidadSacosDestino int NULL,
	PesoBrutoDestino int NULL,
	Fecha datetime NULL,
	FechaSalida datetime NULL,
	Cancelada bit NULL,
	IdRemisionPergamino int NULL,
	IdEmpresaTransporte int NULL,
	IdOrigen int NULL,
	IdDestino int NULL,
	IdConductor int NULL,
	IdVehiculo int NULL,
	IdUsuario int NULL,
	FechaCarga datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Intermedio ADD CONSTRAINT
	PK_Intermedio PRIMARY KEY CLUSTERED 
	(
	IdIntermedio
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Intermedio SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Intermedio', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Intermedio', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Intermedio', 'Object', 'CONTROL') as Contr_Per 