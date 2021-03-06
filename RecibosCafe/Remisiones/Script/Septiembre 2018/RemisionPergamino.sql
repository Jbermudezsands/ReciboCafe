/*
   martes, 18 de septiembre de 201810:30:00 a.m.
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
CREATE TABLE dbo.RemisionPergamino
	(
	IdRemisionPergamino int NOT NULL,
	Codigo varchar(6) NULL,
	FechaCarga datetime NULL,
	Fecha datetime NULL,
	HoraSalida datetime NULL,
	Observacion varchar(500) NULL,
	IdCosecha int NULL,
	IdLugarAcopio int NULL,
	IdCalidad int NULL,
	IdEstadoDocumento int NULL,
	IdConductor int NULL,
	IdEmpresaTransporte int NULL,
	IdVehiculo int NULL,
	IdDestino int NULL,
	IdTipoCafe int NULL,
	IdTipoIngreso int NULL,
	IdUMedida int NULL,
	IdElaboradorPor int NULL,
	IdUsuario int NULL,
	IdCompany int NULL,
	FechaModificacion datetime NULL,
	Serie varchar(1) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.RemisionPergamino ADD CONSTRAINT
	PK_RemisionPergamino PRIMARY KEY CLUSTERED 
	(
	IdRemisionPergamino
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.RemisionPergamino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.RemisionPergamino', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.RemisionPergamino', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.RemisionPergamino', 'Object', 'CONTROL') as Contr_Per 