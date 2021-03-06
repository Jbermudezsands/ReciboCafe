/*
   jueves, 28 de marzo de 201913:04:28
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
ALTER TABLE dbo.LiquidacionPergamino ADD
	TotalDeducciones float(53) NULL,
	ChkRentDef bit NULL,
	ChkRent2 bit NULL,
	ChkRent3 bit NULL,
	ChkMuncipal bit NULL
GO
ALTER TABLE dbo.LiquidacionPergamino ADD CONSTRAINT
	DF_LiquidacionPergamino_TotalDeducciones DEFAULT 0 FOR TotalDeducciones
GO
ALTER TABLE dbo.LiquidacionPergamino ADD CONSTRAINT
	DF_LiquidacionPergamino_ChkRentDef DEFAULT 0 FOR ChkRentDef
GO
ALTER TABLE dbo.LiquidacionPergamino ADD CONSTRAINT
	DF_LiquidacionPergamino_ChkRent2 DEFAULT 0 FOR ChkRent2
GO
ALTER TABLE dbo.LiquidacionPergamino ADD CONSTRAINT
	DF_LiquidacionPergamino_ChkRent3 DEFAULT 0 FOR ChkRent3
GO
ALTER TABLE dbo.LiquidacionPergamino ADD CONSTRAINT
	DF_LiquidacionPergamino_ChkMuncImp DEFAULT 0 FOR ChkMuncipal
GO
ALTER TABLE dbo.LiquidacionPergamino SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
