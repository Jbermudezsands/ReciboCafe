
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
CREATE TABLE dbo.Proveedor
	(
	Cod_Proveedor nvarchar(50) NOT NULL,
	Nombre_Proveedor nvarchar(100) NULL,
	Apellido_Proveedor nvarchar(100) NULL,
	Direccion_Proveedor nvarchar(250) NULL,
	Telefono nvarchar(50) NULL,
	Cod_Cuenta_Proveedor nvarchar(50) NULL,
	Cod_Cuenta_Pagar nvarchar(50) NULL,
	Cod_Cuenta_Cobrar nvarchar(50) NULL,
	Merma nvarchar(50) NULL,
	Reintegro bit NULL,
	Exonerado bit NULL,
	Exclusivo bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Proveedor ADD CONSTRAINT
	DF_Proveedor_Reintegro DEFAULT 0 FOR Reintegro
GO
ALTER TABLE dbo.Proveedor ADD CONSTRAINT
	DF_Proveedor_Exonerado DEFAULT 0 FOR Exonerado
GO
ALTER TABLE dbo.Proveedor ADD CONSTRAINT
	DF_Proveedor_Exclusivo DEFAULT 0 FOR Exclusivo
GO
ALTER TABLE dbo.Proveedor ADD CONSTRAINT
	PK_Proveedor PRIMARY KEY CLUSTERED 
	(
	Cod_Proveedor
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
