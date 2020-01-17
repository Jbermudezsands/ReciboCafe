
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Consecutivos](
	[Factura] [float] NULL,
	[Cotizacion] [float] NULL CONSTRAINT [DF_Consecutivos_Cotizacion]  DEFAULT ((0)),
	[Transferencia_Enviada] [float] NULL CONSTRAINT [DF_Consecutivos_Transferencia_Enviada]  DEFAULT ((0)),
	[DevFactura] [float] NULL,
	[Compra] [float] NULL,
	[Orden_Compra] [float] NULL CONSTRAINT [DF_Consecutivos_Orden_Compra]  DEFAULT ((0)),
	[Transferecia_Recibida] [float] NULL CONSTRAINT [DF_Consecutivos_Transferecia_Recibida]  DEFAULT ((0)),
	[DevCompra] [float] NULL,
	[Ensamble_Recibido] [float] NULL,
	[Ensamble_Contrato] [float] NULL,
	[Orden_Ensamble] [float] NULL,
	[Deshacer_Ensamble] [float] NULL,
	[Pago_Proveedor] [float] NULL,
	[Recibo_Caja] [float] NULL,
	[Componente] [float] NULL,
	[Arqueo] [float] NULL,
	[Plantilla] [float] NULL,
	[Liquidacion_Productos] [float] NULL,
	[SalidaBodega] [float] NULL CONSTRAINT [DF_Consecutivos_SalidaBodega]  DEFAULT ((0)),
	[Recepcion] [float] NULL,
	[Transformacion] [float] NULL,
	[Procesos] [float] NULL,
	[Pedido] [float] NULL,
	[RecepcionBin] [float] NULL,
	[Lote] [float] NULL,
	[Maquila] [float] NULL,
	[LoteMaquila] [float] NULL CONSTRAINT [DF_Consecutivos_LoteMaquila]  DEFAULT ((0))
) ON [PRIMARY]

GO


