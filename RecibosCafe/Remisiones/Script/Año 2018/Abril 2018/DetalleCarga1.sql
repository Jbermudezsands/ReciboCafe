/*
   martes, 03 de abril de 201807:19:47 p.m.
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
ALTER TABLE dbo.DetalleCarga
	DROP CONSTRAINT DF_DetalleCarga_Marca
GO
CREATE TABLE dbo.Tmp_DetalleCarga
	(
	IdDetalleCarga int NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION,
	CodCarga nvarchar(50) NOT NULL,
	IdLugarAcopio int NOT NULL,
	NumeroRecepcion nvarchar(50) NULL,
	FechaRecepcion smalldatetime NULL,
	TipoRecepcion nvarchar(50) NOT NULL,
	Marca bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_DetalleCarga SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_DetalleCarga ADD CONSTRAINT
	DF_DetalleCarga_Marca DEFAULT ((0)) FOR Marca
GO
SET IDENTITY_INSERT dbo.Tmp_DetalleCarga ON
GO
IF EXISTS(SELECT * FROM dbo.DetalleCarga)
	 EXEC('INSERT INTO dbo.Tmp_DetalleCarga (IdDetalleCarga, CodCarga, IdLugarAcopio, NumeroRecepcion, FechaRecepcion, TipoRecepcion, Marca)
		SELECT IdDetalleCarga, CodCarga, IdLugarAcopio, NumeroRecepcion, FechaRecepcion, TipoRecepcion, Marca FROM dbo.DetalleCarga WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_DetalleCarga OFF
GO
DROP TABLE dbo.DetalleCarga
GO
EXECUTE sp_rename N'dbo.Tmp_DetalleCarga', N'DetalleCarga', 'OBJECT' 
GO
ALTER TABLE dbo.DetalleCarga ADD CONSTRAINT
	PK_DetalleCarga PRIMARY KEY CLUSTERED 
	(
	IdDetalleCarga,
	CodCarga,
	IdLugarAcopio
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
