/*
   martes, 03 de abril de 201806:53:02 p.m.
   Usuario: 
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
ALTER TABLE dbo.IndiceCarga
	DROP CONSTRAINT DF_IndiceCarga_Cerrado
GO
CREATE TABLE dbo.Tmp_IndiceCarga
	(
	CodCarga nvarchar(50) NOT NULL,
	IdLugarAcopio int NOT NULL,
	IdConductor int NULL,
	Fecha datetime NULL,
	Hora datetime NULL,
	Placa nvarchar(50) NULL,
	Cerrado bit NULL,
	NumeroAtencion float(53) NULL,
	IdTransporte nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_IndiceCarga SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_IndiceCarga ADD CONSTRAINT
	DF_IndiceCarga_Cerrado DEFAULT ((0)) FOR Cerrado
GO
IF EXISTS(SELECT * FROM dbo.IndiceCarga)
	 EXEC('INSERT INTO dbo.Tmp_IndiceCarga (CodCarga, IdLugarAcopio, IdConductor, Fecha, Hora, Placa, Cerrado, NumeroAtencion, IdTransporte)
		SELECT CodCarga, IdLugarAcopio, IdConductor, Fecha, Hora, Placa, Cerrado, NumeroAtencion, IdTransporte FROM dbo.IndiceCarga WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.IndiceCarga
GO
EXECUTE sp_rename N'dbo.Tmp_IndiceCarga', N'IndiceCarga', 'OBJECT' 
GO
ALTER TABLE dbo.IndiceCarga ADD CONSTRAINT
	PK_IndiceCarga PRIMARY KEY CLUSTERED 
	(
	CodCarga,
	IdLugarAcopio
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
