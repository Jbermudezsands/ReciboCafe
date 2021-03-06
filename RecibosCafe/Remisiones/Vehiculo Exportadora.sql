/*
   lunes, 4 de diciembre de 201702:26:01
   Usuario: 
   Servidor: DESKTOP-E2SQPU1\SQL2005
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
ALTER TABLE dbo.Vehiculo ADD
	Posicion varchar(50) NULL
GO
ALTER TABLE dbo.Vehiculo ADD CONSTRAINT
	DF_Vehiculo_Posicion DEFAULT 'Disponible' FOR Posicion
GO
COMMIT
