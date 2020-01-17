

CREATE TABLE [dbo].[PrecioComplemento](
	IdPrecioComplemento int NOT NULL IDENTITY (1, 1),
	[IdLocalidad] [int] NOT NULL,
	[IdCalidad] [int] NOT NULL,
	[IdRangoImperfeccion] [int] NOT NULL,
	[Precio] [decimal](38, 2) NOT NULL,
	[Corte] [int] NULL,
	[FechaActualizacion] [datetime] NOT NULL,
 CONSTRAINT [PK_PrecioComplemento] PRIMARY KEY CLUSTERED 
(
	[IdPrecioComplemento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



