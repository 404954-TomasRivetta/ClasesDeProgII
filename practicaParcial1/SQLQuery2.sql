create database [db_carpinteria]

USE [db_carpinteria]
GO
/****** Object:  Table [dbo].[T_PRODUCTOS]    Script Date: 09/11/2022 01:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_PRODUCTOS](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[n_producto] [varchar](255) NOT NULL,
	[precio] [numeric](8, 2) NOT NULL,
	[activo] [varchar](1) NOT NULL,
 CONSTRAINT [PK__T_PRODUC__FF341C0D7F60ED59] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[T_PRODUCTOS] ON
INSERT [dbo].[T_PRODUCTOS] ([id_producto], [n_producto], [precio], [activo]) VALUES (1, N'VENTANA CORREDIZA', CAST(11000.00 AS Numeric(8, 2)), N'S')
INSERT [dbo].[T_PRODUCTOS] ([id_producto], [n_producto], [precio], [activo]) VALUES (2, N'PUERTA 1 HOJA', CAST(13700.00 AS Numeric(8, 2)), N'S')
SET IDENTITY_INSERT [dbo].[T_PRODUCTOS] OFF
/****** Object:  Table [dbo].[T_PRESUPUESTOS]    Script Date: 09/11/2022 01:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_PRESUPUESTOS](
	[presupuesto_nro] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[cliente] [varchar](255) NULL,
	[descuento] [numeric](5, 2) NULL,
	[fecha_baja] [date] NULL,
	[total] [numeric](8, 2) NOT NULL,
 CONSTRAINT [PK__T_PRESUP__33BEB70E03317E3D] PRIMARY KEY CLUSTERED 
(
	[presupuesto_nro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[T_PRESUPUESTOS] ON
INSERT [dbo].[T_PRESUPUESTOS] ([presupuesto_nro], [fecha], [cliente], [descuento], [fecha_baja], [total]) VALUES (2, CAST(0x80420B00 AS Date), N'CONSUMIDOR FINAL', CAST(0.00 AS Numeric(5, 2)), CAST(0x62440B00 AS Date), CAST(11000.00 AS Numeric(8, 2)))
INSERT [dbo].[T_PRESUPUESTOS] ([presupuesto_nro], [fecha], [cliente], [descuento], [fecha_baja], [total]) VALUES (3, CAST(0x80420B00 AS Date), N'CONSUMIDOR FINAL', CAST(0.00 AS Numeric(5, 2)), CAST(0x63440B00 AS Date), CAST(24700.00 AS Numeric(8, 2)))
INSERT [dbo].[T_PRESUPUESTOS] ([presupuesto_nro], [fecha], [cliente], [descuento], [fecha_baja], [total]) VALUES (4, CAST(0x91420B00 AS Date), N'CONSUMIDOR FINAL', CAST(10.00 AS Numeric(5, 2)), CAST(0x64440B00 AS Date), CAST(12330.00 AS Numeric(8, 2)))
INSERT [dbo].[T_PRESUPUESTOS] ([presupuesto_nro], [fecha], [cliente], [descuento], [fecha_baja], [total]) VALUES (5, CAST(0x64440B00 AS Date), N'CONSUMIDOR FINAL', CAST(0.00 AS Numeric(5, 2)), NULL, CAST(11000.00 AS Numeric(8, 2)))
SET IDENTITY_INSERT [dbo].[T_PRESUPUESTOS] OFF
/****** Object:  Table [dbo].[T_DETALLES_PRESUPUESTO]    Script Date: 09/11/2022 01:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_DETALLES_PRESUPUESTO](
	[presupuesto_nro] [int] NOT NULL,
	[detalle_nro] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[presupuesto_nro] ASC,
	[detalle_nro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (2, 0, 1, 1)
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (3, 1, 1, 1)
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (3, 2, 2, 1)
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (4, 1, 2, 1)
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (5, 1, 1, 1)
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_PRESUPUESTO]    Script Date: 09/11/2022 01:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_PRESUPUESTO] 
	@presupuesto_nro int
AS
BEGIN
	UPDATE T_PRESUPUESTOS SET fecha_baja = GETDATE()
	WHERE presupuesto_nro = @presupuesto_nro;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_PRODUCTOS]    Script Date: 09/11/2022 01:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_PRODUCTOS]
AS
BEGIN
	
	SELECT * from T_PRODUCTOS;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_PRESUPUESTOS]    Script Date: 09/11/2022 01:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_PRESUPUESTOS]
	@fecha_desde Datetime,
	@fecha_hasta Datetime,
	@cliente varchar(255)
AS
BEGIN
	SELECT * 
	FROM T_PRESUPUESTOS
	WHERE (@fecha_desde is null OR fecha >= @fecha_desde)
	AND (@fecha_hasta is null OR fecha <= @fecha_hasta)
	AND (@cliente is null OR cliente LIKE '%' + @cliente + '%')
	AND fecha_baja is null;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MAESTRO]    Script Date: 09/11/2022 01:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_MAESTRO] 
	@cliente varchar(255), 
	@dto numeric(5,2),
	@total numeric(8,2),
	@presupuesto_nro int OUTPUT
AS
BEGIN
	INSERT INTO T_PRESUPUESTOS(fecha, cliente, descuento, total)
    VALUES (GETDATE(), @cliente, @dto, @total);
    --Asignamos el valor del último ID autogenerado (obtenido --  
    --mediante la función SCOPE_IDENTITY() de SQLServer)	
    SET @presupuesto_nro = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[SP_PROXIMO_ID]    Script Date: 09/11/2022 01:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_PROXIMO_ID]
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(presupuesto_nro)+1  FROM T_PRESUPUESTOS);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MODIFICAR_MAESTRO]    Script Date: 09/11/2022 01:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MODIFICAR_MAESTRO] 
	@cliente varchar(255), 
	@dto numeric(5,2),
	@total numeric(8,2), 
	@presupuesto_nro int
AS
BEGIN
	UPDATE T_PRESUPUESTOS SET cliente = @cliente, descuento = @dto, total = @total
	WHERE presupuesto_nro = @presupuesto_nro;
	
	DELETE T_DETALLES_PRESUPUESTO
	WHERE presupuesto_nro = @presupuesto_nro;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 09/11/2022 01:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE] 
	@presupuesto_nro int,
	@detalle int, 
	@id_producto int, 
	@cantidad int
AS
BEGIN
	INSERT INTO T_DETALLES_PRESUPUESTO(presupuesto_nro,detalle_nro, id_producto, cantidad)
    VALUES (@presupuesto_nro, @detalle, @id_producto, @cantidad);
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_DETALLES_PRESUPUESTO]    Script Date: 09/11/2022 01:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_DETALLES_PRESUPUESTO] 
	@presupuesto_nro int
AS
BEGIN
	SELECT t.*, t2.n_producto, t2.precio, t3.cliente, t3.fecha, t3.total, t3.descuento
	FROM T_DETALLES_PRESUPUESTO t, T_PRODUCTOS t2, T_PRESUPUESTOS t3
	WHERE t.id_producto = t2.id_producto
	AND t.presupuesto_nro = t3.presupuesto_nro
	AND t.presupuesto_nro = @presupuesto_nro; 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REPORTE_PRODUCTOS]    Script Date: 09/11/2022 01:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_REPORTE_PRODUCTOS]
@fecha_desde datetime, 
@fecha_hasta datetime 

AS
BEGIN
	SELECT t2.n_producto as producto, SUM(t.cantidad) as cantidad
	FROM T_DETALLES_PRESUPUESTO t, T_PRODUCTOS t2, T_PRESUPUESTOS t3
	WHERE t.id_producto = t2.id_producto
	AND t.presupuesto_nro = t3.presupuesto_nro
	AND t3.fecha between @fecha_desde and @fecha_hasta
	GROUP BY t2.n_producto;
END
GO
/****** Object:  ForeignKey [fk_presupuesto]    Script Date: 09/11/2022 01:13:47 ******/
ALTER TABLE [dbo].[T_DETALLES_PRESUPUESTO]  WITH CHECK ADD  CONSTRAINT [fk_presupuesto] FOREIGN KEY([presupuesto_nro])
REFERENCES [dbo].[T_PRESUPUESTOS] ([presupuesto_nro])
GO
ALTER TABLE [dbo].[T_DETALLES_PRESUPUESTO] CHECK CONSTRAINT [fk_presupuesto]
GO
/****** Object:  ForeignKey [fk_producto]    Script Date: 09/11/2022 01:13:47 ******/
ALTER TABLE [dbo].[T_DETALLES_PRESUPUESTO]  WITH CHECK ADD  CONSTRAINT [fk_producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[T_PRODUCTOS] ([id_producto])
GO
ALTER TABLE [dbo].[T_DETALLES_PRESUPUESTO] CHECK CONSTRAINT [fk_producto]
GO