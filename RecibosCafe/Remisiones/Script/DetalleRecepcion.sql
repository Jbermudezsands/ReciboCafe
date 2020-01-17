
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Detalle_Recepcion](
	[id_Eventos] [float] NOT NULL,
	[NumeroRecepcion] [nvarchar](50) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[TipoRecepcion] [nvarchar](50) NOT NULL,
	[Cod_Productos] [nvarchar](50) NULL,
	[Descripcion_Producto] [nvarchar](250) NULL,
	[Codigo_Beams] [nvarchar](50) NULL,
	[Cantidad] [float] NULL,
	[Unidad_Medida] [nvarchar](50) NULL,
	[Liquidado] [bit] NULL CONSTRAINT [DF_Detalle_Recepcion_Liquidacion]  DEFAULT ((0)),
	[Codigo_BeamsOrigen] [nvarchar](50) NULL,
	[RecepcionBin] [nvarchar](50) NULL,
	[Transferido] [bit] NULL CONSTRAINT [DF_Detalle_Recepcion_Transferido]  DEFAULT ((0)),
 CONSTRAINT [PK_Detalle_Recepcion] PRIMARY KEY CLUSTERED 
(
	[id_Eventos] ASC,
	[NumeroRecepcion] ASC,
	[Fecha] ASC,
	[TipoRecepcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Detalle_Recepcion]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Recepcion_Productos] FOREIGN KEY([Cod_Productos])
REFERENCES [dbo].[Productos] ([Cod_Productos])
GO

ALTER TABLE [dbo].[Detalle_Recepcion] CHECK CONSTRAINT [FK_Detalle_Recepcion_Productos]
GO


