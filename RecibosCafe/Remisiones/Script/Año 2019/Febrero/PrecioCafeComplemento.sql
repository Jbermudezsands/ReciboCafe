
GO

/****** Object:  Table [dbo].[PrecioCafe]    Script Date: 27/02/2019 07:37:25 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PrecioCafe](
	[IdPrecioCafe] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[IdCalidad] [int] NOT NULL,
	[IdRangoImperfeccion] [int] NOT NULL,
	[Precio] [decimal](38, 2) NOT NULL,
	[FechaActualizacion] [datetime] NOT NULL,
 CONSTRAINT [PK_PrecioCafe] PRIMARY KEY CLUSTERED 
(
	[IdPrecioCafe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


