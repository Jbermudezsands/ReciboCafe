/*
   martes, 19 de marzo de 201910:39:57
   Usuario: sa
   Servidor: DESKTOP-SQU6PUC\SQLEXPRESS
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
CREATE TABLE dbo.Tmp_PrecioComplemento
	(
	IdPrecioComplemento int NOT NULL IDENTITY (1, 1),
	IdCosecha int NULL,
	IdLocalidad int NOT NULL,
	IdCalidad int NOT NULL,
	IdRangoImperfeccion int NOT NULL,
	Precio decimal(38, 2) NOT NULL,
	Corte int NULL,
	FechaActualizacion datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_PrecioComplemento SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_PrecioComplemento ON
GO
IF EXISTS(SELECT * FROM dbo.PrecioComplemento)
	 EXEC('INSERT INTO dbo.Tmp_PrecioComplemento (IdPrecioComplemento, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, Corte, FechaActualizacion)
		SELECT IdPrecioComplemento, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, Corte, FechaActualizacion FROM dbo.PrecioComplemento WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_PrecioComplemento OFF
GO
DROP TABLE dbo.PrecioComplemento
GO
EXECUTE sp_rename N'dbo.Tmp_PrecioComplemento', N'PrecioComplemento', 'OBJECT' 
GO
ALTER TABLE dbo.PrecioComplemento ADD CONSTRAINT
	PK_PrecioComplemento PRIMARY KEY CLUSTERED 
	(
	IdPrecioComplemento
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
