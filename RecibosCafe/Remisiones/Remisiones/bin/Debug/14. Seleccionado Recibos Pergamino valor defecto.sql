/*
   viernes, 26 de abril de 201917:31:55
   Usuario: sa
   Servidor: DESKTOP-SQU6PUC\SQLEXPRESS
   Base de datos: TRANSPORTE_AGRANCHOGRANDE
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
ALTER TABLE dbo.ReciboCafePergamino
	DROP CONSTRAINT DF_ReciboCafePergamino_Seleccion
GO
ALTER TABLE dbo.ReciboCafePergamino
	DROP CONSTRAINT DF_ReciboCafePergamino_Liquidado_1
GO
CREATE TABLE dbo.Tmp_ReciboCafePergamino
	(
	IdReciboPergamino int NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION,
	Codigo varchar(10) NULL,
	Fecha datetime NULL,
	Observacion varchar(500) NULL,
	IdTipoCafe int NULL,
	IdCosecha int NULL,
	IdLocalidad int NULL,
	IdDano int NULL,
	IdFinca int NULL,
	IdTipoCompra int NULL,
	IdEstadoDocumento int NULL,
	IdProductor int NULL,
	IdUnidadMedida int NULL,
	IdUsuario int NULL,
	IdLocalidadLiquidacion int NULL,
	SincronizadoECS bit NULL,
	FechaSincronizacion datetime NULL,
	FechaIngresoSistemas datetime NULL,
	Imei varchar(50) NULL,
	IdPignorado int NULL,
	EsProductorManual int NULL,
	CedulaManual varchar(50) NULL,
	ProductorManual varchar(50) NULL,
	FincaManual varchar(300) NULL,
	IdTipoIngreso int NULL,
	IdRangoImperfeccion int NULL,
	IdCalidad int NULL,
	Seleccion bit NULL,
	Serie nchar(2) NULL,
	IdLocalidadRegistro int NULL,
	Liquidado bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_ReciboCafePergamino SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_ReciboCafePergamino ADD CONSTRAINT
	DF_ReciboCafePergamino_Seleccion_1 DEFAULT 0 FOR Seleccion
GO
ALTER TABLE dbo.Tmp_ReciboCafePergamino ADD CONSTRAINT
	DF_ReciboCafePergamino_Liquidado_1 DEFAULT ((0)) FOR Liquidado
GO
SET IDENTITY_INSERT dbo.Tmp_ReciboCafePergamino ON
GO
IF EXISTS(SELECT * FROM dbo.ReciboCafePergamino)
	 EXEC('INSERT INTO dbo.Tmp_ReciboCafePergamino (IdReciboPergamino, Codigo, Fecha, Observacion, IdTipoCafe, IdCosecha, IdLocalidad, IdDano, IdFinca, IdTipoCompra, IdEstadoDocumento, IdProductor, IdUnidadMedida, IdUsuario, IdLocalidadLiquidacion, SincronizadoECS, FechaSincronizacion, FechaIngresoSistemas, Imei, IdPignorado, EsProductorManual, CedulaManual, ProductorManual, FincaManual, IdTipoIngreso, IdRangoImperfeccion, IdCalidad, Serie, IdLocalidadRegistro, Liquidado)
		SELECT IdReciboPergamino, Codigo, Fecha, Observacion, IdTipoCafe, IdCosecha, IdLocalidad, IdDano, IdFinca, IdTipoCompra, IdEstadoDocumento, IdProductor, IdUnidadMedida, IdUsuario, IdLocalidadLiquidacion, SincronizadoECS, FechaSincronizacion, FechaIngresoSistemas, Imei, IdPignorado, EsProductorManual, CedulaManual, ProductorManual, FincaManual, IdTipoIngreso, IdRangoImperfeccion, IdCalidad, Serie, IdLocalidadRegistro, Liquidado FROM dbo.ReciboCafePergamino WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_ReciboCafePergamino OFF
GO
DROP TABLE dbo.ReciboCafePergamino
GO
EXECUTE sp_rename N'dbo.Tmp_ReciboCafePergamino', N'ReciboCafePergamino', 'OBJECT' 
GO
ALTER TABLE dbo.ReciboCafePergamino ADD CONSTRAINT
	PK_ReciboCafePergamino PRIMARY KEY CLUSTERED 
	(
	IdReciboPergamino
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.ReciboCafePergamino', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ReciboCafePergamino', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ReciboCafePergamino', 'Object', 'CONTROL') as Contr_Per 