/*
   martes, 14 de noviembre de 201710:01:25 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2005
   Base de datos: Remisiones
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
CREATE TABLE dbo.TiposPrecios
	(
	IdPreciosCAfe int NOT NULL IDENTITY (1, 1),
	FechaPrecio datetime NULL,
	Cod_Productos nvarchar(50) NULL,
	IdLugarAcopio int NULL,
	CalidadCafe nvarchar(5) NULL,
	PrecioCafe float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TiposPrecios ADD CONSTRAINT
	PK_TiposPrecios PRIMARY KEY CLUSTERED 
	(
	IdPreciosCAfe
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.TiposPrecios', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TiposPrecios', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TiposPrecios', 'Object', 'CONTROL') as Contr_Per 