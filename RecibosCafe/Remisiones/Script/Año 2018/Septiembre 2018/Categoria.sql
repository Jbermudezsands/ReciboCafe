/*
   martes, 18 de septiembre de 201801:46:00 p.m.
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
CREATE TABLE dbo.Categoria
	(
	IdCategoriaCAfe int NOT NULL IDENTITY (1, 1),
	Categoria nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Categoria ADD CONSTRAINT
	PK_Categoria PRIMARY KEY CLUSTERED 
	(
	IdCategoriaCAfe
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Categoria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Categoria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Categoria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Categoria', 'Object', 'CONTROL') as Contr_Per 