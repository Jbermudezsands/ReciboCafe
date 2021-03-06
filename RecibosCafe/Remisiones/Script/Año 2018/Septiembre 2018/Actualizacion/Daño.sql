/*
   lunes, 24 de septiembre de 201802:59:57 p.m.
   Usuario: sa
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
CREATE TABLE dbo.Tmp_Dano
	(
	IdDano int NOT NULL IDENTITY (1, 1),
	Codigo nvarchar(50) NOT NULL,
	Nombre nvarchar(200) NOT NULL,
	Activo bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Dano SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Daño ON
GO
IF EXISTS(SELECT * FROM dbo.Dano)
	 EXEC('INSERT INTO dbo.Tmp_Daño (IdDaño, Codigo, Nombre, Activo)
		SELECT IdDaño, Codigo, Nombre, Activo FROM dbo.Daño WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Daño OFF
GO
DROP TABLE dbo.Dano
GO
EXECUTE sp_rename N'dbo.Tmp_Daño', N'Daño', 'OBJECT' 
GO
COMMIT
