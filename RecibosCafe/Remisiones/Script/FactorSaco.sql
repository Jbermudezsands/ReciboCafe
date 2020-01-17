USE [TRANSPORTE]
GO

/****** Object:  Table [dbo].[FactorSaco]    Script Date: 29/11/2018 14:47:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FactorSaco](
	[IdFactorSaco] [int] IDENTITY(1,1) NOT NULL,
	[IdSaco] [int] NOT NULL,
	[IdTipoLugarAcopio] [int] NOT NULL,
	[FactorTara] [decimal](38, 20) NULL,
	[IdClaseCafe] [int] NULL,
	[IdUMedida] [int] NULL,
	[IdEdoFisico] [int] NULL,
	[IdUsuario] [int] NULL,
	[IdCompany] [int] NULL,
	[IdCalidad] [int] NULL,
 CONSTRAINT [PK_FactorSaco] PRIMARY KEY CLUSTERED 
(
	[IdFactorSaco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


