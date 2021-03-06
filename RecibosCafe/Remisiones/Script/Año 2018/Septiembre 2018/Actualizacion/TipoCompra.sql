/*
   lunes, 24 de septiembre de 201804:00:52 p.m.
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
CREATE TABLE dbo.Tmp_TipoCompra
	(
	IdTipoCompra int NOT NULL IDENTITY (1, 1),
	Codigo varchar(50) NOT NULL,
	Nombre varchar(200) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_TipoCompra SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_TipoCompra ON
GO
IF EXISTS(SELECT * FROM dbo.TipoCompra)
	 EXEC('INSERT INTO dbo.Tmp_TipoCompra (IdTipoCompra, Codigo, Nombre)
		SELECT IdTipoCompra, Codigo, Nombre FROM dbo.TipoCompra WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_TipoCompra OFF
GO
DROP TABLE dbo.TipoCompra
GO
EXECUTE sp_rename N'dbo.Tmp_TipoCompra', N'TipoCompra', 'OBJECT' 
GO
ALTER TABLE dbo.TipoCompra ADD CONSTRAINT
	PK_TipoCompra PRIMARY KEY CLUSTERED 
	(
	IdTipoCompra
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.TipoCompra', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TipoCompra', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TipoCompra', 'Object', 'CONTROL') as Contr_Per 