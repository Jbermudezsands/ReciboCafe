USE [TRANSPORTE]
GO

/****** Object:  Table [dbo].[DetalleIntermadio]    Script Date: 29/11/2018 10:52:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DetalleIntermadio](
	[IdDetalleIntermedio] [int] IDENTITY(1,1) NOT NULL,
	[PesoBrutoOrigen] [decimal](38, 20) NOT NULL,
	[CantidadSacosOrigen] [decimal](38, 20) NOT NULL,
	[PesoBrutoDestino] [decimal](38, 20) NOT NULL,
	[CantidadSacosDestino] [decimal](38, 20) NOT NULL,
	[IdIntermedio] [int] NOT NULL,
	[IdReciboRemisionPergamino] [int] NOT NULL,
 CONSTRAINT [PK_DetalleIntermadio] PRIMARY KEY CLUSTERED 
(
	[IdDetalleIntermedio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


