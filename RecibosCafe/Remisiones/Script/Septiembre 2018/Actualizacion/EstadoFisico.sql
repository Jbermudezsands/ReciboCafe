/*
   lunes, 24 de septiembre de 201804:07:09 p.m.
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
CREATE TABLE dbo.Tmp_EstadoFisico
	(
	EstadoFisico int NOT NULL IDENTITY (1, 1),
	Codigo varchar(20) NOT NULL,
	Descripcion varchar(200) NOT NULL,
	HumedadInicial decimal(38, 2) NULL,
	HumedadFinal decimal(38, 2) NULL,
	HumedadXDefecto decimal(38, 2) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_EstadoFisico SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_EstadoFisico ON
GO
IF EXISTS(SELECT * FROM dbo.EstadoFisico)
	 EXEC('INSERT INTO dbo.Tmp_EstadoFisico (EstadoFisico, Codigo, Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto)
		SELECT EstadoFisico, Codigo, Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto FROM dbo.EstadoFisico WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_EstadoFisico OFF
GO
DROP TABLE dbo.EstadoFisico
GO
EXECUTE sp_rename N'dbo.Tmp_EstadoFisico', N'EstadoFisico', 'OBJECT' 
GO
ALTER TABLE dbo.EstadoFisico ADD CONSTRAINT
	PK_EstadoFisico PRIMARY KEY CLUSTERED 
	(
	EstadoFisico
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.EstadoFisico', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.EstadoFisico', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.EstadoFisico', 'Object', 'CONTROL') as Contr_Per 