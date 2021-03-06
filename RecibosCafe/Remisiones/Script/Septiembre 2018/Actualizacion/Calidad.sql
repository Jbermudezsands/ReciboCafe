/*
   lunes, 24 de septiembre de 201804:52:49 p.m.
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
CREATE TABLE dbo.Tmp_Calidad
	(
	IdCalidad int NOT NULL IDENTITY (1, 1),
	CodCalidad varchar(20) NULL,
	NomCalidad varchar(20) NULL,
	NomCompleto varchar(50) NULL,
	MinImperfeccion decimal(38, 2) NULL,
	MaxImperfeccion decimal(38, 2) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Calidad SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Calidad ON
GO
IF EXISTS(SELECT * FROM dbo.Calidad)
	 EXEC('INSERT INTO dbo.Tmp_Calidad (IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion)
		SELECT IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion FROM dbo.Calidad WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Calidad OFF
GO
DROP TABLE dbo.Calidad
GO
EXECUTE sp_rename N'dbo.Tmp_Calidad', N'Calidad', 'OBJECT' 
GO
ALTER TABLE dbo.Calidad ADD CONSTRAINT
	PK_Calidad PRIMARY KEY CLUSTERED 
	(
	IdCalidad
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Calidad', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Calidad', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Calidad', 'Object', 'CONTROL') as Contr_Per 