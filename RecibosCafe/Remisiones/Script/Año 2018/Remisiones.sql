USE [REMISION]
GO
/****** Object:  Table [dbo].[ChequeoPlanta]    Script Date: 31/08/2017 08:41:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChequeoPlanta](
	[CodigoLectura] [nvarchar](100) NULL,
	[Fecha] [smalldatetime] NULL,
	[TipoLectura] [nvarchar](50) NULL,
	[IdLugarAcopio] [int] NULL,
	[CodigoRemision] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Conductor]    Script Date: 31/08/2017 08:41:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conductor](
	[IdConductor] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](500) NULL,
	[Cedula] [varchar](20) NULL,
	[Licencia] [varchar](20) NULL,
	[Estado] [bit] NULL,
	[ListaNegra] [bit] NULL,
	[RazonListaNegra] [varchar](2000) NULL,
	[IdUsuario] [int] NULL,
	[IdCompany] [int] NULL,
 CONSTRAINT [PK_Conductor] PRIMARY KEY CLUSTERED 
(
	[IdConductor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ConductorEmpresaTransporte]    Script Date: 31/08/2017 08:41:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConductorEmpresaTransporte](
	[IdConductorEmpresaTransporte] [int] IDENTITY(1,1) NOT NULL,
	[Activo] [bit] NOT NULL,
	[IdEmpresaTransporte] [int] NOT NULL,
	[IdConductor] [int] NOT NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [PK_ConductorEmpresaTransporte] PRIMARY KEY CLUSTERED 
(
	[IdConductorEmpresaTransporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cosecha]    Script Date: 31/08/2017 08:41:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cosecha](
	[IdCosecha] [int] IDENTITY(1,1) NOT NULL,
	[CodCosecha] [varchar](2) NOT NULL,
	[FechaInicial] [datetime] NOT NULL,
	[FechaFinal] [datetime] NOT NULL,
	[IdCompany] [int] NULL,
	[IdUsuario] [int] NULL,
	[FechaInicioFinanciamiento] [datetime] NULL,
	[FechaInicioCompra] [datetime] NULL,
 CONSTRAINT [PK_Cosecha] PRIMARY KEY CLUSTERED 
(
	[IdCosecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DatosEmpresa]    Script Date: 31/08/2017 08:41:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatosEmpresa](
	[Nombre_Empresa] [nvarchar](max) NULL,
	[Direccion_Empresa] [nvarchar](max) NULL,
	[Numero_Ruc] [nvarchar](max) NULL,
	[Telefono] [nvarchar](max) NULL,
	[Ruta_Logo] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmpresaTransporte]    Script Date: 31/08/2017 08:41:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmpresaTransporte](
	[IdEmpresaTransporte] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](4) NOT NULL,
	[NombreEmpresa] [varchar](75) NOT NULL,
	[CedulaEmpresa] [varchar](20) NULL,
	[NombreRepresentante] [varchar](75) NULL,
	[CedulaRepresentante] [varchar](20) NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](50) NULL,
	[IdTipoPersoneria] [int] NULL,
	[Activo] [bit] NULL,
	[IdTipoEmpresaTransporte] [int] NOT NULL,
	[IdUsuario] [int] NULL,
	[IdCompany] [int] NULL,
 CONSTRAINT [PK_EmpresaTransporte] PRIMARY KEY CLUSTERED 
(
	[IdEmpresaTransporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LugarAcopio]    Script Date: 31/08/2017 08:41:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LugarAcopio](
	[IdLugarAcopio] [int] IDENTITY(1,1) NOT NULL,
	[CodLugarAcopio] [varchar](3) NULL,
	[NomLugarAcopio] [varchar](50) NULL,
	[IdPadre] [int] NULL,
	[IdRegion] [int] NULL,
	[TipoLugarAcopio] [int] NULL,
	[FDA] [varchar](20) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [varchar](15) NULL,
	[PPCDefecto] [int] NULL,
	[CapacidadRecep] [decimal](38, 20) NULL,
	[IdUMedidaRecep] [int] NULL,
	[CapacidadSecado] [decimal](38, 20) NULL,
	[IdUMedidaSecado] [int] NULL,
	[BultosMaxSecado] [int] NULL,
	[IdUsuario] [int] NULL,
	[IdCompany] [int] NULL,
	[NombreCorto] [varchar](20) NULL,
	[Fax] [varchar](15) NOT NULL,
	[Activo] [bit] NOT NULL,
	[CapacidadAlmacenamiento] [decimal](38, 20) NULL,
	[IdUMedidaAlmacenamiento] [int] NULL,
 CONSTRAINT [PK_LugarAcopio] PRIMARY KEY CLUSTERED 
(
	[IdLugarAcopio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PuntoRevision]    Script Date: 31/08/2017 08:41:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PuntoRevision](
	[CodigoRemision] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[IdLugarAcopio] [int] NULL,
	[NumeroBoleta] [nvarchar](6) NULL,
	[IdEmpresaTransporte] [int] NULL,
	[Placa] [varchar](20) NULL,
	[IdLugarAcopioChequeo] [int] NULL,
	[IdCosecha] [int] NULL,
	[IdLocalidadChequeo] [int] NULL,
	[IdVehiculo] [int] NULL,
 CONSTRAINT [PK_Remision_1] PRIMARY KEY CLUSTERED 
(
	[CodigoRemision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 31/08/2017 08:41:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Usuario] [nvarchar](50) NULL,
	[Contraseña] [nvarchar](50) NULL,
	[Tipo] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 31/08/2017 08:41:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[IdVehiculo] [int] IDENTITY(1,1) NOT NULL,
	[Placa] [varchar](20) NULL,
	[IdMarca] [int] NULL,
	[IdTipoVehiculo] [int] NULL,
	[IdUsuario] [int] NULL,
	[IdCompany] [int] NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[IdVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehiculoEmpresaTransporte]    Script Date: 31/08/2017 08:41:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiculoEmpresaTransporte](
	[IdVehiculoEmpresaTransporte] [int] IDENTITY(1,1) NOT NULL,
	[Activo] [bit] NULL,
	[IdEmpresaTransporte] [int] NOT NULL,
	[IdVehiculo] [int] NOT NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [PK_VehiculoEmpresaTransporte] PRIMARY KEY CLUSTERED 
(
	[IdVehiculoEmpresaTransporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'456454545', CAST(N'2014-10-02 12:55:00' AS SmallDateTime), N'ENTRADA', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'67676767', CAST(N'2014-10-02 12:57:00' AS SmallDateTime), N'SALIDA', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'567565656', CAST(N'2014-10-02 12:57:00' AS SmallDateTime), N'ENTRADA', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'988899877', CAST(N'2014-10-02 12:58:00' AS SmallDateTime), N'SALIDA', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'565656565', CAST(N'2014-10-02 12:58:00' AS SmallDateTime), N'ENTRADA', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'202000001001M023987', CAST(N'2014-10-02 12:58:00' AS SmallDateTime), N'SALIDA', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'202000001001M023987', CAST(N'2014-10-02 05:57:00' AS SmallDateTime), N'ENTRADA', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'202000001001M023987', CAST(N'2014-10-02 06:13:00' AS SmallDateTime), N'Entrada', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'202000001001M023987', CAST(N'2014-10-02 06:13:00' AS SmallDateTime), N'Salida', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'202000001', CAST(N'2014-10-08 10:22:00' AS SmallDateTime), N'Entrada', NULL, 19)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'202000001', CAST(N'2014-10-08 10:23:00' AS SmallDateTime), N'Entrada', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'202000001', CAST(N'2014-10-08 10:24:00' AS SmallDateTime), N'Entrada', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'202000001', CAST(N'2014-10-08 10:24:00' AS SmallDateTime), N'Salida', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'202000001', CAST(N'2014-10-08 10:26:00' AS SmallDateTime), N'Entrada', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'202000001', CAST(N'2014-10-10 02:42:00' AS SmallDateTime), N'Entrada', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'202000001', CAST(N'2014-10-10 02:43:00' AS SmallDateTime), N'Salida', NULL, NULL)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'203000045', CAST(N'2014-10-13 11:26:00' AS SmallDateTime), N'Entrada', 203, 10)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'202000045', CAST(N'2014-10-13 11:27:00' AS SmallDateTime), N'Entrada', 203, 10)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'203456123', CAST(N'2014-10-22 08:12:00' AS SmallDateTime), N'Entrada', 202, 48)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'203456982', CAST(N'2014-10-22 08:43:00' AS SmallDateTime), N'Entrada', 202, 49)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'203088393', CAST(N'2014-10-22 05:07:00' AS SmallDateTime), N'Entrada', 3, 53)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'203088393', CAST(N'2014-10-22 05:10:00' AS SmallDateTime), N'Salida', 3, 53)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'203000001', CAST(N'2014-10-24 08:47:00' AS SmallDateTime), N'Entrada', 3, 26)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'203995885', CAST(N'2014-10-24 08:49:00' AS SmallDateTime), N'Entrada', 3, 0)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'203094804', CAST(N'2014-10-25 09:26:00' AS SmallDateTime), N'Entrada', 3, 68)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'203555555', CAST(N'2014-10-28 07:48:00' AS SmallDateTime), N'Entrada', 3, 69)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'203555555', CAST(N'2014-10-28 07:49:00' AS SmallDateTime), N'Salida', 3, 69)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'2020001', CAST(N'2014-11-18 08:34:00' AS SmallDateTime), N'Entrada', 3, 1)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'203023984', CAST(N'2014-10-22 06:15:00' AS SmallDateTime), N'Entrada', 3, 66)
INSERT [dbo].[ChequeoPlanta] ([CodigoLectura], [Fecha], [TipoLectura], [IdLugarAcopio], [CodigoRemision]) VALUES (N'203049387', CAST(N'2014-10-22 06:20:00' AS SmallDateTime), N'Entrada', 3, 67)
SET IDENTITY_INSERT [dbo].[Conductor] ON 

INSERT [dbo].[Conductor] ([IdConductor], [Codigo], [Nombre], [Cedula], [Licencia], [Estado], [ListaNegra], [RazonListaNegra], [IdUsuario], [IdCompany]) VALUES (1, N'001', N'JUAN GABRIEL BERMUDEZ HERNANDEZ', N'001-150877-0016B', N'09833', 1, 0, N'NINGUNO', 1, 1)
INSERT [dbo].[Conductor] ([IdConductor], [Codigo], [Nombre], [Cedula], [Licencia], [Estado], [ListaNegra], [RazonListaNegra], [IdUsuario], [IdCompany]) VALUES (2, N'002', N'ARTURO ENOC AYALA', N'001-210878-0023C', N'08444', 1, 0, N'NINGUNO', 2, 1)
INSERT [dbo].[Conductor] ([IdConductor], [Codigo], [Nombre], [Cedula], [Licencia], [Estado], [ListaNegra], [RazonListaNegra], [IdUsuario], [IdCompany]) VALUES (3, N'003', N'RICARDO VALVERDE', N'001-345677-0909B', N'345455', 1, 0, N'-', 2, 1)
INSERT [dbo].[Conductor] ([IdConductor], [Codigo], [Nombre], [Cedula], [Licencia], [Estado], [ListaNegra], [RazonListaNegra], [IdUsuario], [IdCompany]) VALUES (4, N'004', N'XIOMARA TERESA LEIVA', N'001-084004-9844N', N'899999', 1, 0, N'-', 2, 2)
INSERT [dbo].[Conductor] ([IdConductor], [Codigo], [Nombre], [Cedula], [Licencia], [Estado], [ListaNegra], [RazonListaNegra], [IdUsuario], [IdCompany]) VALUES (5, N'005', N'OMARA LEIVA', N'001-098333-09333', N'34555', 1, 0, NULL, 1, 1)
INSERT [dbo].[Conductor] ([IdConductor], [Codigo], [Nombre], [Cedula], [Licencia], [Estado], [ListaNegra], [RazonListaNegra], [IdUsuario], [IdCompany]) VALUES (6, N'006', N'MARIA LEIVA', N'001-098333-09333', N'67777', 1, 0, NULL, 1, 1)
INSERT [dbo].[Conductor] ([IdConductor], [Codigo], [Nombre], [Cedula], [Licencia], [Estado], [ListaNegra], [RazonListaNegra], [IdUsuario], [IdCompany]) VALUES (7, N'007', N'NASSELY GABRIELA', N'001-098333-09333', N'790900', 1, 0, NULL, 1, 1)
INSERT [dbo].[Conductor] ([IdConductor], [Codigo], [Nombre], [Cedula], [Licencia], [Estado], [ListaNegra], [RazonListaNegra], [IdUsuario], [IdCompany]) VALUES (8, N'008', N'CARLOS CASTILLO', N'001-098333-09333', N'989999', 1, 0, N'1', 1, 1)
INSERT [dbo].[Conductor] ([IdConductor], [Codigo], [Nombre], [Cedula], [Licencia], [Estado], [ListaNegra], [RazonListaNegra], [IdUsuario], [IdCompany]) VALUES (9, N'009', N'MARIA ALFARO', N'001-098333-09333', N'8999', 1, 0, N'1', 1, 1)
INSERT [dbo].[Conductor] ([IdConductor], [Codigo], [Nombre], [Cedula], [Licencia], [Estado], [ListaNegra], [RazonListaNegra], [IdUsuario], [IdCompany]) VALUES (10, N'010', N'CARLOS CASTILLO', N'001-098333-09333', N'7888', 1, 0, N'1', 1, 1)
SET IDENTITY_INSERT [dbo].[Conductor] OFF
SET IDENTITY_INSERT [dbo].[ConductorEmpresaTransporte] ON 

INSERT [dbo].[ConductorEmpresaTransporte] ([IdConductorEmpresaTransporte], [Activo], [IdEmpresaTransporte], [IdConductor], [IdUsuario]) VALUES (1, 1, 1, 1, 1)
INSERT [dbo].[ConductorEmpresaTransporte] ([IdConductorEmpresaTransporte], [Activo], [IdEmpresaTransporte], [IdConductor], [IdUsuario]) VALUES (2, 1, 6, 1, 1)
INSERT [dbo].[ConductorEmpresaTransporte] ([IdConductorEmpresaTransporte], [Activo], [IdEmpresaTransporte], [IdConductor], [IdUsuario]) VALUES (3, 1, 6, 3, 1)
SET IDENTITY_INSERT [dbo].[ConductorEmpresaTransporte] OFF
SET IDENTITY_INSERT [dbo].[Cosecha] ON 

INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (1, N'01', CAST(N'2013-01-01 00:00:00.000' AS DateTime), CAST(N'2014-12-31 00:00:00.000' AS DateTime), 1, 1, CAST(N'2014-01-01 00:00:00.000' AS DateTime), CAST(N'2014-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (2, N'15', CAST(N'2002-10-01 00:00:00.000' AS DateTime), CAST(N'2003-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2002-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (3, N'01', CAST(N'2015-12-31 00:00:00.000' AS DateTime), CAST(N'2016-12-31 00:00:00.000' AS DateTime), 1, 1, NULL, NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (4, N'17', CAST(N'2004-10-01 00:00:00.000' AS DateTime), CAST(N'2005-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2004-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (5, N'18', CAST(N'2005-10-01 00:00:00.000' AS DateTime), CAST(N'2006-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2005-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (6, N'19', CAST(N'2006-10-01 00:00:00.000' AS DateTime), CAST(N'2007-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2006-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (7, N'20', CAST(N'2007-10-01 00:00:00.000' AS DateTime), CAST(N'2008-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2007-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (8, N'21', CAST(N'2008-10-01 00:00:00.000' AS DateTime), CAST(N'2009-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2008-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (9, N'22', CAST(N'2009-10-01 00:00:00.000' AS DateTime), CAST(N'2010-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2009-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (10, N'23', CAST(N'2010-10-01 00:00:00.000' AS DateTime), CAST(N'2011-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2010-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (11, N'24', CAST(N'2011-10-01 00:00:00.000' AS DateTime), CAST(N'2012-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2011-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (12, N'25', CAST(N'2012-10-01 00:00:00.000' AS DateTime), CAST(N'2013-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2012-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (13, N'26', CAST(N'2013-10-01 00:00:00.000' AS DateTime), CAST(N'2014-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2013-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (14, N'27', CAST(N'2014-10-01 00:00:00.000' AS DateTime), CAST(N'2015-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2014-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (15, N'28', CAST(N'2015-09-01 00:00:00.000' AS DateTime), CAST(N'2016-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2015-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (16, N'28', CAST(N'2015-10-01 00:00:00.000' AS DateTime), CAST(N'2016-09-30 00:00:00.000' AS DateTime), 2, NULL, CAST(N'2015-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (17, N'28', CAST(N'2015-10-01 00:00:00.000' AS DateTime), CAST(N'2016-09-30 00:00:00.000' AS DateTime), 3, NULL, CAST(N'2015-02-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Cosecha] ([IdCosecha], [CodCosecha], [FechaInicial], [FechaFinal], [IdCompany], [IdUsuario], [FechaInicioFinanciamiento], [FechaInicioCompra]) VALUES (18, N'29', CAST(N'2016-10-01 00:00:00.000' AS DateTime), CAST(N'2017-09-30 00:00:00.000' AS DateTime), 1, NULL, CAST(N'2015-02-01 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Cosecha] OFF
INSERT [dbo].[DatosEmpresa] ([Nombre_Empresa], [Direccion_Empresa], [Numero_Ruc], [Telefono], [Ruta_Logo]) VALUES (N'SYSTEMS AND SOLUTIONS', N'Managua', N'000000', N'22234544', N'C:\Users\Juan Bermudez\Pictures\Queque Mateo\4545.png')
SET IDENTITY_INSERT [dbo].[EmpresaTransporte] ON 

INSERT [dbo].[EmpresaTransporte] ([IdEmpresaTransporte], [Codigo], [NombreEmpresa], [CedulaEmpresa], [NombreRepresentante], [CedulaRepresentante], [Direccion], [Telefono], [IdTipoPersoneria], [Activo], [IdTipoEmpresaTransporte], [IdUsuario], [IdCompany]) VALUES (1, N'001', N'SYSTEMS AND SOLUTIONS', N'J031000345', N'JUAN', N'0039939003', N'MANAGUA', N'22567788', 1, 1, 1, 1, NULL)
INSERT [dbo].[EmpresaTransporte] ([IdEmpresaTransporte], [Codigo], [NombreEmpresa], [CedulaEmpresa], [NombreRepresentante], [CedulaRepresentante], [Direccion], [Telefono], [IdTipoPersoneria], [Activo], [IdTipoEmpresaTransporte], [IdUsuario], [IdCompany]) VALUES (6, N'001', N'Exportadora Atlantic', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1)
INSERT [dbo].[EmpresaTransporte] ([IdEmpresaTransporte], [Codigo], [NombreEmpresa], [CedulaEmpresa], [NombreRepresentante], [CedulaRepresentante], [Direccion], [Telefono], [IdTipoPersoneria], [Activo], [IdTipoEmpresaTransporte], [IdUsuario], [IdCompany]) VALUES (7, N'002', N'Privado', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[EmpresaTransporte] OFF
SET IDENTITY_INSERT [dbo].[LugarAcopio] ON 

INSERT [dbo].[LugarAcopio] ([IdLugarAcopio], [CodLugarAcopio], [NomLugarAcopio], [IdPadre], [IdRegion], [TipoLugarAcopio], [FDA], [Direccion], [Telefono], [PPCDefecto], [CapacidadRecep], [IdUMedidaRecep], [CapacidadSecado], [IdUMedidaSecado], [BultosMaxSecado], [IdUsuario], [IdCompany], [NombreCorto], [Fax], [Activo], [CapacidadAlmacenamiento], [IdUMedidaAlmacenamiento]) VALUES (3, N'202', N'Sucursal Jinotega', 1, 1, 1, N'1', N'Jinotega', N'3203344', 1, CAST(1.00000000000000000000 AS Decimal(38, 20)), 1, CAST(1.00000000000000000000 AS Decimal(38, 20)), 1, 1, 1, 1, N'1', N'33333', 1, CAST(300.00000000000000000000 AS Decimal(38, 20)), 1)
INSERT [dbo].[LugarAcopio] ([IdLugarAcopio], [CodLugarAcopio], [NomLugarAcopio], [IdPadre], [IdRegion], [TipoLugarAcopio], [FDA], [Direccion], [Telefono], [PPCDefecto], [CapacidadRecep], [IdUMedidaRecep], [CapacidadSecado], [IdUMedidaSecado], [BultosMaxSecado], [IdUsuario], [IdCompany], [NombreCorto], [Fax], [Activo], [CapacidadAlmacenamiento], [IdUMedidaAlmacenamiento]) VALUES (4, N'203', N'SUCURSAL MANAGUA', 1, 1, 1, N'1', N'JINOTEGA', N'56777777', 1, CAST(1.00000000000000000000 AS Decimal(38, 20)), 1, CAST(1.00000000000000000000 AS Decimal(38, 20)), 1, 1, 1, 1, N'1', N'1', 1, CAST(1.00000000000000000000 AS Decimal(38, 20)), 1)
INSERT [dbo].[LugarAcopio] ([IdLugarAcopio], [CodLugarAcopio], [NomLugarAcopio], [IdPadre], [IdRegion], [TipoLugarAcopio], [FDA], [Direccion], [Telefono], [PPCDefecto], [CapacidadRecep], [IdUMedidaRecep], [CapacidadSecado], [IdUMedidaSecado], [BultosMaxSecado], [IdUsuario], [IdCompany], [NombreCorto], [Fax], [Activo], [CapacidadAlmacenamiento], [IdUMedidaAlmacenamiento]) VALUES (5, N'204', N'EJEMPLO', 1, 1, 1, N'1', N'JINIOGO', N'233', 1, CAST(1.00000000000000000000 AS Decimal(38, 20)), 1, CAST(1.00000000000000000000 AS Decimal(38, 20)), 1, 1, 1, 1, N'1', N'1', 1, CAST(1.00000000000000000000 AS Decimal(38, 20)), 1)
SET IDENTITY_INSERT [dbo].[LugarAcopio] OFF
SET IDENTITY_INSERT [dbo].[PuntoRevision] ON 

INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (1, CAST(N'2014-10-01 11:21:00' AS SmallDateTime), 3, N'0001', 1, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (3, CAST(N'2014-10-02 12:34:00' AS SmallDateTime), 3, N'6255', 1, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (4, CAST(N'2014-10-02 12:37:00' AS SmallDateTime), 3, N'2355', 2, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (5, CAST(N'2014-10-02 01:00:00' AS SmallDateTime), 3, N'56996', 3, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (6, CAST(N'2014-10-02 01:02:00' AS SmallDateTime), 3, N'255', 5, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (7, CAST(N'2014-10-02 03:44:00' AS SmallDateTime), 3, N'0001', 3, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (8, CAST(N'2014-10-02 03:48:00' AS SmallDateTime), 3, N'00001', 2, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (9, CAST(N'2014-10-02 04:26:00' AS SmallDateTime), 3, N'0001', 2, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (10, CAST(N'2014-10-02 04:30:00' AS SmallDateTime), 3, N'001', 1, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (11, CAST(N'2014-10-02 04:40:00' AS SmallDateTime), 3, N'0001', 2, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (12, CAST(N'2014-10-02 05:17:00' AS SmallDateTime), 3, N'0001', 2, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (13, CAST(N'2014-10-02 05:26:00' AS SmallDateTime), 3, N'0001', 2, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (14, CAST(N'2014-10-02 05:30:00' AS SmallDateTime), 3, N'0001', 1, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (15, CAST(N'2014-10-02 05:38:00' AS SmallDateTime), 3, N'0001', 1, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (16, CAST(N'2014-10-02 05:44:00' AS SmallDateTime), 3, N'0001', 1, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (17, CAST(N'2014-10-02 05:46:00' AS SmallDateTime), 3, N'001', 1, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (19, CAST(N'2014-10-02 05:55:00' AS SmallDateTime), 3, N'000001', 1, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (20, CAST(N'2014-10-08 08:02:00' AS SmallDateTime), 3, N'0000', 1, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (21, CAST(N'2014-10-08 08:43:00' AS SmallDateTime), 3, N'00001', 1, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (22, CAST(N'2014-10-08 08:56:00' AS SmallDateTime), 3, N'785885', 1, N'M02398', NULL, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (23, CAST(N'2014-10-13 10:33:00' AS SmallDateTime), 3, N'000007', 1, N'M02398', 203, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (24, CAST(N'2014-10-13 10:35:00' AS SmallDateTime), 3, N'000005', 2, N'M02398', 203, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (25, CAST(N'2014-10-13 10:36:00' AS SmallDateTime), 3, N'000008', 1, N'M02398', 203, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (26, CAST(N'2014-10-13 10:50:00' AS SmallDateTime), 4, N'000001', 1, N'M02398', 203, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (27, CAST(N'2014-10-13 10:53:00' AS SmallDateTime), 4, N'000009', 1, N'M02398', 203, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (29, CAST(N'2014-10-13 10:58:00' AS SmallDateTime), 4, N'000045', 1, N'M02398', 203, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (31, CAST(N'2014-10-13 11:12:00' AS SmallDateTime), 3, N'000045', 1, N'JJJJJJ', 203, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (34, CAST(N'2014-10-15 05:57:00' AS SmallDateTime), 3, N'000078', 1, N'M02398', 203, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (35, CAST(N'2014-10-18 08:22:00' AS SmallDateTime), 3, N'000012', 1, N'M02398', 203, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (36, CAST(N'2014-10-18 08:44:00' AS SmallDateTime), 0, N'000099', 1, N'M02398', 203, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (37, CAST(N'2014-10-18 08:46:00' AS SmallDateTime), 0, N'000098', 1, N'M02398', 203, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (38, CAST(N'2014-10-18 08:47:00' AS SmallDateTime), 0, N'000097', 1, N'M02398', 203, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (39, CAST(N'2014-10-18 08:49:00' AS SmallDateTime), 5, N'000067', 1, N'M02398', 202, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (40, CAST(N'2014-10-20 10:36:00' AS SmallDateTime), 3, N'000010', 1, N'M02398', 202, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (41, CAST(N'2014-10-20 10:53:00' AS SmallDateTime), 4, N'000005', 1, N'M02398', 202, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (42, CAST(N'2014-10-20 11:00:00' AS SmallDateTime), 4, N'000089', 1, N'M02398', 202, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (43, CAST(N'2014-10-21 12:04:00' AS SmallDateTime), 3, N'123458', 1, N'031-207', 202, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (44, CAST(N'2014-10-21 12:50:00' AS SmallDateTime), 4, N'123459', 1, N'031-207', 202, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (45, CAST(N'2014-10-21 04:21:00' AS SmallDateTime), 4, N'123456', 1, N'031-207', 202, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (46, CAST(N'2014-10-21 05:26:00' AS SmallDateTime), 3, N'123789', 1, N'031-207', 202, NULL, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (47, CAST(N'2014-10-22 07:49:00' AS SmallDateTime), 4, N'789456', 7, N'031-207', 202, 1, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (48, CAST(N'2014-10-22 08:11:00' AS SmallDateTime), 4, N'456123', 7, N'031-207', 202, 1, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (49, CAST(N'2014-10-22 08:42:00' AS SmallDateTime), 4, N'456982', 7, N'031-207', 202, 1, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (50, CAST(N'2014-10-22 01:37:00' AS SmallDateTime), 4, N'445632', 1, N'0001', 202, 1, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (51, CAST(N'2014-10-22 01:48:00' AS SmallDateTime), 4, N'888888', 1, N'0001', 202, 1, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (52, CAST(N'2014-10-22 04:24:00' AS SmallDateTime), 4, N'309384', 1, N'0001', 202, 1, NULL, NULL)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (53, CAST(N'2014-10-22 05:00:00' AS SmallDateTime), 4, N'088393', 1, N'0001', 202, 1, 3, 1)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (54, CAST(N'2014-10-22 05:17:00' AS SmallDateTime), 4, N'487464', 7, N'031-207', 202, 1, 3, 2)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (55, CAST(N'2014-10-22 05:19:00' AS SmallDateTime), 4, N'938748', 7, N'031-207', 202, 1, 3, 2)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (63, CAST(N'2014-10-22 00:00:00' AS SmallDateTime), 4, N'904380', 7, N'031-207', 202, 1, 3, 2)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (64, CAST(N'2014-10-22 20:45:00' AS SmallDateTime), 4, N'904380', 7, N'031-207', 202, 1, 3, 2)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (65, CAST(N'2014-10-22 17:49:00' AS SmallDateTime), 4, N'983487', 7, N'031-207', 202, 1, 3, 2)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (66, CAST(N'2014-10-22 18:15:00' AS SmallDateTime), 4, N'023984', 7, N'031-207', 202, 1, 3, 2)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (67, CAST(N'2014-10-22 18:19:00' AS SmallDateTime), 4, N'049387', 1, N'0001', 202, 1, 3, 1)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (68, CAST(N'2014-10-24 20:41:00' AS SmallDateTime), 4, N'094804', 1, N'0001', 202, 1, 3, 1)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (69, CAST(N'2014-10-28 07:45:00' AS SmallDateTime), 4, N'555555', 1, N'0001', 202, 1, 3, 1)
INSERT [dbo].[PuntoRevision] ([CodigoRemision], [Fecha], [IdLugarAcopio], [NumeroBoleta], [IdEmpresaTransporte], [Placa], [IdLugarAcopioChequeo], [IdCosecha], [IdLocalidadChequeo], [IdVehiculo]) VALUES (70, CAST(N'2015-09-02 07:07:00' AS SmallDateTime), 4, N'088288', 1, N'0001', 202, 2, 3, 1)
SET IDENTITY_INSERT [dbo].[PuntoRevision] OFF
SET IDENTITY_INSERT [dbo].[Vehiculo] ON 

INSERT [dbo].[Vehiculo] ([IdVehiculo], [Placa], [IdMarca], [IdTipoVehiculo], [IdUsuario], [IdCompany]) VALUES (1, N'0001', 3, 4, 1, 1)
INSERT [dbo].[Vehiculo] ([IdVehiculo], [Placa], [IdMarca], [IdTipoVehiculo], [IdUsuario], [IdCompany]) VALUES (2, N'031-207', 3, 4, 1, 1)
SET IDENTITY_INSERT [dbo].[Vehiculo] OFF
SET IDENTITY_INSERT [dbo].[VehiculoEmpresaTransporte] ON 

INSERT [dbo].[VehiculoEmpresaTransporte] ([IdVehiculoEmpresaTransporte], [Activo], [IdEmpresaTransporte], [IdVehiculo], [IdUsuario]) VALUES (1, 1, 6, 1, 1)
INSERT [dbo].[VehiculoEmpresaTransporte] ([IdVehiculoEmpresaTransporte], [Activo], [IdEmpresaTransporte], [IdVehiculo], [IdUsuario]) VALUES (2, 1, 7, 2, 1)
SET IDENTITY_INSERT [dbo].[VehiculoEmpresaTransporte] OFF
