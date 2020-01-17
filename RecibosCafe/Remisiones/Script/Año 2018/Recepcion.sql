
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Recepcion](
	[NumeroRecepcion] [nvarchar](50) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[TipoRecepcion] [nvarchar](50) NOT NULL,
	[Cod_Proveedor] [nvarchar](50) NULL,
	[Cod_SubProveedor] [nvarchar](50) NULL,
	[Conductor] [nvarchar](100) NULL,
	[Id_identificacion] [nvarchar](50) NULL,
	[Id_Placa] [nvarchar](50) NULL,
	[Cod_Bodega] [nvarchar](50) NULL,
	[Observaciones] [nvarchar](max) NULL,
	[SubTotal] [float] NULL,
	[Telefono] [nvarchar](50) NULL,
	[Cancelar] [bit] NULL CONSTRAINT [DF_Recepcion_Cancelar]  DEFAULT ((0)),
	[Activo] [bit] NULL CONSTRAINT [DF_Recepcion_Activo]  DEFAULT ((1)),
	[Seleccion] [bit] NULL CONSTRAINT [DF_Recepcion_Seleccion]  DEFAULT ((0)),
	[CodigoBin] [nvarchar](50) NULL,
	[Peso] [float] NULL,
	[Lote] [nvarchar](50) NULL,
	[Marca] [bit] NULL CONSTRAINT [DF_Recepcion_Marca]  DEFAULT ((1)),
	[Contabilizado] [bit] NULL CONSTRAINT [DF_Recepcion_Contabilizado]  DEFAULT ((0)),
 CONSTRAINT [PK_Recepcion_1] PRIMARY KEY CLUSTERED 
(
	[NumeroRecepcion] ASC,
	[Fecha] ASC,
	[TipoRecepcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


