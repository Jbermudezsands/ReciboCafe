/*
   sábado, 06 de octubre de 201802:33:52 p.m.
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
CREATE TABLE dbo.FactorSaco
	(
	IdFactorSaco int NOT NULL IDENTITY (1, 1),
	IdSaco int NOT NULL,
	IdTipoLugarAcopio int NOT NULL,
	FactorTara decimal(38, 20) NULL,
	IdClaseCafe int NULL,
	IdUMedida int NULL,
	IdEdoFisico int NULL,
	IdUsuario int NULL,
	IdCompany int NULL,
	IdCalidad int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.FactorSaco ADD CONSTRAINT
	PK_FactorSaco PRIMARY KEY CLUSTERED 
	(
	IdFactorSaco
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.FactorSaco SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.FactorSaco', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.FactorSaco', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.FactorSaco', 'Object', 'CONTROL') as Contr_Per 