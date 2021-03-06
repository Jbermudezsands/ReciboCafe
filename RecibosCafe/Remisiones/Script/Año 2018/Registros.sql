/*
   domingo, 17 de septiembre de 201711:54:07 a.m.
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
CREATE TABLE dbo.Registros
	(
	IdRegistro nvarchar(50) NOT NULL,
	TipoRegistro nvarchar(50) NOT NULL,
	IdConductor int NULL,
	IdLugarAcopio int NULL,
	Fecha datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Registros ADD CONSTRAINT
	PK_Registros PRIMARY KEY CLUSTERED 
	(
	IdRegistro,
	TipoRegistro
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Registros', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Registros', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Registros', 'Object', 'CONTROL') as Contr_Per 