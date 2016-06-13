USE [ProyectoWeb]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [varchar](35) NOT NULL,
	[contraseña] [char](50) NOT NULL,
	[nombre] [varchar](35) NOT NULL,
	[apellido] [varchar](35) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoProducto](
	[idTipoProducto] [int] NOT NULL,
	[descripcion] [varchar](35) NOT NULL,
 CONSTRAINT [PK_TipoProducto] PRIMARY KEY CLUSTERED 
(
	[idTipoProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoDoc]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoDoc](
	[idTipoDoc] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](35) NOT NULL,
 CONSTRAINT [PK_TipoDoc] PRIMARY KEY CLUSTERED 
(
	[idTipoDoc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rol](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](35) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FormaPago]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FormaPago](
	[idFormaPago] [int] NOT NULL,
	[nombre] [varchar](35) NOT NULL,
 CONSTRAINT [PK_FormaPago] PRIMARY KEY CLUSTERED 
(
	[idFormaPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AmbitoEstado]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AmbitoEstado](
	[idAmbitoEstado] [int] NOT NULL,
	[nombre] [varchar](35) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AmbitoEstado] PRIMARY KEY CLUSTERED 
(
	[idAmbitoEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pais](
	[idPais] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](70) NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioXRol]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioXRol](
	[idUsuario] [int] NOT NULL,
	[idRol] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioXRol] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC,
	[idRol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](35) NULL,
	[apellido] [varchar](35) NULL,
	[razonSocial] [varchar](35) NULL,
	[telefono] [bigint] NOT NULL,
	[email] [varchar](255) NOT NULL,
	[cuit] [varchar](15) NOT NULL,
	[sexo] [bit] NOT NULL,
	[direccion] [varchar](35) NOT NULL,
	[idLocalidad] [int] NOT NULL,
	[numeroDoc] [int] NOT NULL,
	[idTipoDoc] [int] NOT NULL,
	[fechaAlta] [date] NOT NULL,
	[saldo] [money] NOT NULL,
	[borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente_idCliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Cliente_cuit] UNIQUE NONCLUSTERED 
(
	[cuit] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Cliente_numeroDoc] UNIQUE NONCLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estado](
	[idEstado] [int] NOT NULL,
	[nombre] [varchar](35) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[idAmbitoEstado] [int] NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincia](
	[idProvincia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](35) NOT NULL,
	[idPais] [int] NOT NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[idProvincia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [int] NOT NULL,
	[nombre] [varchar](35) NOT NULL,
	[precio] [money] NOT NULL,
	[idTipoProducto] [int] NOT NULL,
	[imagen] [varchar](50) NOT NULL,
	[fechaAlta] [date] NOT NULL,
	[borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Producto_idProducto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Producto_nombre] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[idPedido] [int] NOT NULL,
	[fechaGeneracion] [date] NOT NULL,
	[fechaEntrega] [date] NOT NULL,
	[idEstado] [int] NOT NULL,
	[idCliente] [int] NOT NULL,
	[total] [money] NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[idPedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidad]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Localidad](
	[idLocalidad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](35) NOT NULL,
	[idProvincia] [int] NOT NULL,
 CONSTRAINT [PK_Localidad] PRIMARY KEY CLUSTERED 
(
	[idLocalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[idPago] [int] NOT NULL,
	[idPedido] [int] NOT NULL,
	[fechaPago] [date] NOT NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[idPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedido](
	[idDetalle] [int] NOT NULL,
	[idPedido] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [money] NOT NULL,
 CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[idDetalle] ASC,
	[idPedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePago]    Script Date: 06/05/2016 13:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePago](
	[idDetallePago] [int] NOT NULL,
	[idPago] [int] NOT NULL,
	[idFormaPago] [int] NOT NULL,
	[cantidad] [money] NULL,
 CONSTRAINT [PK_DetallePago] PRIMARY KEY CLUSTERED 
(
	[idDetallePago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Cliente_TipoDoc]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_TipoDoc] FOREIGN KEY([idTipoDoc])
REFERENCES [dbo].[TipoDoc] ([idTipoDoc])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_TipoDoc]
GO
/****** Object:  ForeignKey [FK_DetallePago_FormaPago]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[DetallePago]  WITH CHECK ADD  CONSTRAINT [FK_DetallePago_FormaPago] FOREIGN KEY([idFormaPago])
REFERENCES [dbo].[FormaPago] ([idFormaPago])
GO
ALTER TABLE [dbo].[DetallePago] CHECK CONSTRAINT [FK_DetallePago_FormaPago]
GO
/****** Object:  ForeignKey [FK_DetallePago_Pago]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[DetallePago]  WITH CHECK ADD  CONSTRAINT [FK_DetallePago_Pago] FOREIGN KEY([idPago])
REFERENCES [dbo].[Pago] ([idPago])
GO
ALTER TABLE [dbo].[DetallePago] CHECK CONSTRAINT [FK_DetallePago_Pago]
GO
/****** Object:  ForeignKey [FK_DetallePedido_Pedido]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Pedido] FOREIGN KEY([idPedido])
REFERENCES [dbo].[Pedido] ([idPedido])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Pedido]
GO
/****** Object:  ForeignKey [FK_DetallePedido_Producto]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Producto]
GO
/****** Object:  ForeignKey [FK_Estado_AmbitoEstado]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[Estado]  WITH CHECK ADD  CONSTRAINT [FK_Estado_AmbitoEstado] FOREIGN KEY([idAmbitoEstado])
REFERENCES [dbo].[AmbitoEstado] ([idAmbitoEstado])
GO
ALTER TABLE [dbo].[Estado] CHECK CONSTRAINT [FK_Estado_AmbitoEstado]
GO
/****** Object:  ForeignKey [FK_Localidad_Provincia]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[Localidad]  WITH CHECK ADD  CONSTRAINT [FK_Localidad_Provincia] FOREIGN KEY([idProvincia])
REFERENCES [dbo].[Provincia] ([idProvincia])
GO
ALTER TABLE [dbo].[Localidad] CHECK CONSTRAINT [FK_Localidad_Provincia]
GO
/****** Object:  ForeignKey [FK_Pago_Pedido]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Pedido] FOREIGN KEY([idPedido])
REFERENCES [dbo].[Pedido] ([idPedido])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_Pedido]
GO
/****** Object:  ForeignKey [FK_Pedido_Cliente]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
/****** Object:  ForeignKey [FK_Pedido_Estado]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Estado] FOREIGN KEY([idEstado])
REFERENCES [dbo].[Estado] ([idEstado])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Estado]
GO
/****** Object:  ForeignKey [FK_Producto_TipoProducto]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_TipoProducto] FOREIGN KEY([idTipoProducto])
REFERENCES [dbo].[TipoProducto] ([idTipoProducto])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_TipoProducto]
GO
/****** Object:  ForeignKey [FK_Provincia_Pais1]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[Provincia]  WITH CHECK ADD  CONSTRAINT [FK_Provincia_Pais1] FOREIGN KEY([idPais])
REFERENCES [dbo].[Pais] ([idPais])
GO
ALTER TABLE [dbo].[Provincia] CHECK CONSTRAINT [FK_Provincia_Pais1]
GO
/****** Object:  ForeignKey [FK_UsuarioXRol_Rol]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[UsuarioXRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioXRol_Rol] FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([idRol])
GO
ALTER TABLE [dbo].[UsuarioXRol] CHECK CONSTRAINT [FK_UsuarioXRol_Rol]
GO
/****** Object:  ForeignKey [FK_UsuarioXRol_Usuario]    Script Date: 06/05/2016 13:56:30 ******/
ALTER TABLE [dbo].[UsuarioXRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioXRol_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[UsuarioXRol] CHECK CONSTRAINT [FK_UsuarioXRol_Usuario]
GO
