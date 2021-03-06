/*
   martes, 12 de septiembre de 201704:13:13 p.m.
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
CREATE TABLE dbo.DetalleCarga
	(
	IdDetalleCarga int NOT NULL IDENTITY (1, 1),
	CodCarga nvarchar(50) NOT NULL,
	NumeroRecepcion nvarchar(50) NULL,
	FechaRecepcion smalldatetime NULL,
	TipoRecepcion nvarchar(50) NOT NULL,
	Marca bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.DetalleCarga ADD CONSTRAINT
	DF_DetalleCarga_Marca DEFAULT 0 FOR Marca
GO
ALTER TABLE dbo.DetalleCarga ADD CONSTRAINT
	PK_DetalleCarga PRIMARY KEY CLUSTERED 
	(
	IdDetalleCarga,
	CodCarga
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
