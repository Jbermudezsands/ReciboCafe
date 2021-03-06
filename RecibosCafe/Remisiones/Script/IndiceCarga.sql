/*
   martes, 12 de septiembre de 201704:06:30 p.m.
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
CREATE TABLE dbo.IndiceCarga
	(
	CodCarga nvarchar(50) NOT NULL,
	IdConductor int NULL,
	IdLugarAcopio int NULL,
	Fecha datetime NULL,
	Hora datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.IndiceCarga ADD CONSTRAINT
	PK_IndiceCarga PRIMARY KEY CLUSTERED 
	(
	CodCarga
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
