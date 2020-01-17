
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Productos](
	[Cod_Productos] [nvarchar](50) NOT NULL,
	[Descripcion_Producto] [nvarchar](250) NULL,
	[Ubicacion] [nvarchar](100) NULL,
	[Cod_Linea] [nchar](10) NULL,
	[Tipo_Producto] [nvarchar](50) NULL,
	[Cod_Cuenta_Inventario] [nvarchar](50) NULL,
	[Cod_Cuenta_Costo] [nvarchar](50) NULL,
	[Cod_Cuenta_Ventas] [nvarchar](50) NULL,
	[Cod_Cuenta_GastoAjuste] [nvarchar](50) NULL,
	[Cod_Cuenta_IngresoAjuste] [nvarchar](50) NULL,
	[Unidad_Medida] [nvarchar](50) NULL,
	[Precio_Venta] [float] NULL CONSTRAINT [DF_Productos_Precio_Venta]  DEFAULT ((0)),
	[Precio_Lista] [float] NULL CONSTRAINT [DF_Productos_Precio_Lista]  DEFAULT ((0)),
	[Precio_Compra] [float] NULL CONSTRAINT [DF_Productos_Precio_Compra]  DEFAULT ((0)),
	[Descuento] [float] NULL CONSTRAINT [DF_Productos_Descuento]  DEFAULT ((0)),
	[Existencia_Negativa] [nvarchar](2) NULL,
	[Cod_Iva] [nvarchar](50) NULL,
	[Activo] [nvarchar](10) NULL,
	[Costo_Promedio] [float] NULL CONSTRAINT [DF_Productos_Costo_Promedio]  DEFAULT ((0)),
	[Costo_Promedio_Dolar] [float] NULL CONSTRAINT [DF_Productos_Costo_Promedio_Dolar]  DEFAULT ((0)),
	[Ultimo_Precio_Venta] [float] NULL CONSTRAINT [DF_Productos_Ultimo_Precio_Venta]  DEFAULT ((0)),
	[Ultimo_Precio_Compra] [float] NULL CONSTRAINT [DF_Productos_Ultimo_Precio_Compra]  DEFAULT ((0)),
	[Existencia_Dinero] [float] NULL CONSTRAINT [DF_Productos_Existencia_Dinero]  DEFAULT ((0)),
	[Existencia_Unidades] [float] NULL CONSTRAINT [DF_Productos_Existencia_Unidades]  DEFAULT ((0)),
	[Existencia_DineroDolar] [float] NULL CONSTRAINT [DF_Productos_Existencia_DineroDolar]  DEFAULT ((0)),
	[Minimo] [float] NULL CONSTRAINT [DF_Productos_Minimo]  DEFAULT ((0)),
	[Reorden] [float] NULL CONSTRAINT [DF_Productos_Reorden]  DEFAULT ((0)),
	[Nota] [nvarchar](max) NULL,
	[CodComponente] [float] NULL CONSTRAINT [DF_Productos_CodComponente]  DEFAULT ((0)),
	[Cod_Rubro] [nvarchar](50) NULL,
	[Reintegro] [bit] NULL CONSTRAINT [DF_Productos_Reintegro]  DEFAULT ((0)),
	[Grupo] [nvarchar](50) NULL,
	[Talla] [nvarchar](50) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Cod_Productos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


