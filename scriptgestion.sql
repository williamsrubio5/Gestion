USE [Jenner]
GO
/****** Object:  User [EIPG2019]    Script Date: 09/12/2020 19:39:52 ******/
CREATE USER [EIPG2019] FOR LOGIN [EIPG2019] WITH DEFAULT_SCHEMA=[EIPG2019]
GO
ALTER ROLE [db_owner] ADD MEMBER [EIPG2019]
GO
/****** Object:  Schema [EIPG2019]    Script Date: 09/12/2020 19:39:52 ******/
CREATE SCHEMA [EIPG2019]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[IdBit] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](15) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[IdBit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cai]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cai](
	[CaiNum] [nvarchar](40) NOT NULL,
	[RangoInicial] [nvarchar](20) NOT NULL,
	[RangoFinal] [nvarchar](20) NOT NULL,
	[FechaLimite] [date] NOT NULL,
	[EstadoCai] [bit] NOT NULL,
 CONSTRAINT [PK_Cai] PRIMARY KEY CLUSTERED 
(
	[CaiNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Examenes]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Examenes](
	[IdExamen] [int] IDENTITY(1,1) NOT NULL,
	[NombreExamen] [nvarchar](80) NOT NULL,
	[EstadoExamen] [bit] NOT NULL,
	[PrecioExamen] [decimal](6, 3) NOT NULL,
	[RangoExamen] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_Examenes] PRIMARY KEY CLUSTERED 
(
	[IdExamen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Factura]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[FacNum] [nvarchar](20) NOT NULL,
	[IdentidadPa] [nvarchar](15) NOT NULL,
	[FacFecha] [date] NOT NULL,
	[FacTipo] [bit] NOT NULL,
	[FacDesc] [float] NOT NULL,
	[FacEstado] [bit] NOT NULL,
	[FacCai] [nvarchar](40) NOT NULL,
	[IdentidadMe] [nvarchar](13) NOT NULL,
 CONSTRAINT [PK__Factura__4D9180AAEC212F84] PRIMARY KEY CLUSTERED 
(
	[FacNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FacturaDetalle]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaDetalle](
	[iddetalle] [int] IDENTITY(1,1) NOT NULL,
	[FacNum] [nvarchar](20) NOT NULL,
	[IdExamen] [int] NOT NULL,
	[Resultado] [nvarchar](100) NOT NULL,
	[FacEstadoDe] [bit] NOT NULL,
	[PrecioExamen] [decimal](6, 3) NOT NULL,
 CONSTRAINT [PK_FacturaDetalle] PRIMARY KEY CLUSTERED 
(
	[iddetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[IdentidadMe] [nvarchar](13) NOT NULL,
	[NombreMe] [nvarchar](80) NULL,
	[TelefonoMe] [int] NULL,
	[EmailMe] [nvarchar](100) NULL,
	[NombreClinicaMe] [nvarchar](80) NULL,
	[EstadoMe] [bit] NULL,
 CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED 
(
	[IdentidadMe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[IdentidadPa] [nvarchar](15) NOT NULL,
	[NombrePa] [nvarchar](70) NOT NULL,
	[EmailPa] [nvarchar](100) NOT NULL,
	[TelefonoPa] [int] NOT NULL,
	[SexoPa] [bit] NOT NULL,
	[FechaNacPa] [date] NOT NULL,
	[EstadoPa] [bit] NULL,
 CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED 
(
	[IdentidadPa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[DescripRol] [nvarchar](20) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UserName] [nvarchar](15) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Estado] [bit] NOT NULL,
	[IdRol] [int] NOT NULL,
	[EmailUsu] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_Usuarios] FOREIGN KEY([UserName])
REFERENCES [dbo].[Usuarios] ([UserName])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_Usuarios]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cai] FOREIGN KEY([FacCai])
REFERENCES [dbo].[Cai] ([CaiNum])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cai]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Medicos] FOREIGN KEY([IdentidadMe])
REFERENCES [dbo].[Medicos] ([IdentidadMe])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Medicos]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Pacientes] FOREIGN KEY([IdentidadPa])
REFERENCES [dbo].[Pacientes] ([IdentidadPa])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Pacientes]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalle_Examenes] FOREIGN KEY([IdExamen])
REFERENCES [dbo].[Examenes] ([IdExamen])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_FacturaDetalle_Examenes]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FacturaDetalle_Factura] FOREIGN KEY([FacNum])
REFERENCES [dbo].[Factura] ([FacNum])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_FacturaDetalle_Factura]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Rol]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCai]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarCai]
	-- Add the parameters for the stored procedure here
	@CaiNum nvarchar(40),
	@RangoInicial nvarchar(20),
	@RangoFinal nvarchar(20),
	@FechaLimite date,
	@EstadoCai bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT * FROM Cai WHERE CaiNum = @CaiNum)
		update Cai
		set CaiNum = @CaiNum, RangoInicial = @RangoInicial, RangoFinal = @RangoFinal, FechaLimite = @FechaLimite, EstadoCai = @EstadoCai
		where CaiNum = @CaiNum
	Else
		Insert into Cai values (@CaiNum,@RangoInicial,@RangoFinal,@FechaLimite,@EstadoCai)
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarExamen]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarExamen]
	-- Add the parameters for the stored procedure here
	@IdExamen int,
	@NombreExamen nvarchar(80),
	@EstadoExamen bit,
	@PrecioExamen decimal(6,3),
	@RangoExamen nvarchar(80)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT * FROM Examenes WHERE IdExamen = @IdExamen)
		update Examenes
		set NombreExamen = @NombreExamen, EstadoExamen = @EstadoExamen, PrecioExamen = @PrecioExamen, RangoExamen = @RangoExamen
		where IdExamen = @IdExamen
	Else
		insert into Examenes values (@NombreExamen,@EstadoExamen,@PrecioExamen,@RangoExamen)
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarPacientee]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarPacientee]
	-- Add the parameters for the stored procedure here
	@IdentidadPa nvarchar(13),
	@NombrePa nvarchar(70),
	@EmailPa nvarchar(100),
	@TelefonoPa int,
	@SexoPa bit,
	@FechaNacPa date,
	@EstadoPa bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT * FROM Pacientes WHERE IdentidadPa = @IdentidadPa)
		update Pacientes
		set IdentidadPa = @IdentidadPa, NombrePa = @NombrePa, EmailPa = @EmailPa, TelefonoPa = @TelefonoPa, SexoPa = @SexoPa, FechaNacPa = @FechaNacPa, EstadoPa = @EstadoPa
		where IdentidadPa = @IdentidadPa
	Else
		Insert into Pacientes values (@IdentidadPa,@NombrePa,@EmailPa,@TelefonoPa,@SexoPa,@FechaNacPa,@EstadoPa)
END


GO
/****** Object:  StoredProcedure [dbo].[ActualizarRol]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarRol]
	-- Add the parameters for the stored procedure here
	@IdRol int,
	@DescripRol nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT * FROM	Rol WHERE IdRol = @IdRol)
		update Rol
		set   DescripRol = @DescripRol
		where IdRol = @IdRol
	Else
		insert into Rol values ( @DescripRol)
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarUsuarios]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarUsuarios] 
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(15),
	@Password nvarchar(20),
	@Estado bit,
	@IdRol int,
	@EmailUsu nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT * FROM Usuarios WHERE	UserName = @UserName)
		update Usuarios
		set UserName = @UserName, Password = @Password, Estado = @Estado, IdRol = @IdRol, EmailUsu = @EmailUsu
		where UserName = @UserName
	Else
		insert into Usuarios values (@UserName,@Password,@Estado,@IdRol,@EmailUsu)
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarCai]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarCai]
	-- Add the parameters for the stored procedure here
	@CaiNum nvarchar(40),
	@EstadoCai bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		update Cai
		set EstadoCai = @EstadoCai
		where CaiNum = @CaiNum

END

GO
/****** Object:  StoredProcedure [dbo].[EliminarExamen]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarExamen]
	-- Add the parameters for the stored procedure here
	@IdExamen int,
	@EstadoExamen bit

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		update Examenes
		set EstadoExamen = @EstadoExamen
		where IdExamen = @IdExamen
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarMedico]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarMedico]
	-- Add the parameters for the stored procedure here
	@IdentidadMed nvarchar(13),
	@EstadoMe bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		update Medicos
		set EstadoMe = @EstadoMe
		where IdentidadMe = @IdentidadMed
	
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarPaciente]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarPaciente]
	-- Add the parameters for the stored procedure here
	@IdentidadPa nvarchar(13),
	@EstadoPa bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		update Pacientes
		set EstadoPa = @EstadoPa
		where IdentidadPa = @IdentidadPa
	
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[EliminarUsuario]
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(13),
	@Estado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		update Usuarios
		set Estado = @Estado
		where UserName = @UserName
	
END

GO
/****** Object:  StoredProcedure [dbo].[IngresarBitacora]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IngresarBitacora]
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(15),
	@Descripcion nvarchar(100),
	@Fecha datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Bitacora values (@UserName,@Descripcion,@Fecha)
	
	
END

GO
/****** Object:  StoredProcedure [dbo].[IngresarCai]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IngresarCai]
	-- Add the parameters for the stored procedure here
	@CaiNum nvarchar(40),
	@RangoInicial nvarchar(20),
	@RangoFinal nvarchar(20),
	@FechaLimite date,
	@EstadoCai bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Cai values (@CaiNum,@RangoInicial,@RangoFinal,@FechaLimite,@EstadoCai)
END

GO
/****** Object:  StoredProcedure [dbo].[IngresarExamen]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IngresarExamen]
	-- Add the parameters for the stored procedure here
	@NombreExamen nvarchar(80),
	@EstadoExamen bit,
	@PrecioExamen decimal(6,3),
	@RangoExamen nvarchar(80)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Examenes values (@NombreExamen,@EstadoExamen,@PrecioExamen,@RangoExamen)
END

GO
/****** Object:  StoredProcedure [dbo].[IngresarFactura]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IngresarFactura]
	-- Add the parameters for the stored procedure here
	@FacNum nvarchar(20),
	@IdentidadPa nvarchar(13),
	@FacFecha date,
	@FacTipo bit,
	@FacDesc float,
	@FacEstado bit,
	@FacCai nvarchar(40),
	@IdentidadMe nvarchar(13)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Factura values (@FacNum,@IdentidadPa,@FacFecha,@FacTipo,@FacDesc,@FacEstado,@FacCai,@IdentidadMe)
END

GO
/****** Object:  StoredProcedure [dbo].[IngresarFacturaDetalle]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IngresarFacturaDetalle]
	-- Add the parameters for the stored procedure here
	@FacNum nvarchar(20),
	@IdExamen int,
	@Resultado nvarchar(100),
	@FacEstadoDe bit,
	@PrecioExamen decimal(6,3)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into FacturaDetalle values (@FacNum,@IdExamen,@Resultado,@FacEstadoDe,@PrecioExamen)
END

GO
/****** Object:  StoredProcedure [dbo].[IngresarMedicos]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IngresarMedicos]
	-- Add the parameters for the stored procedure here
	@IdentidadMed nvarchar(13),
	@NombreMe nvarchar(80),
	@TelefonoMe int,
	@EmailMe nvarchar(100),
	@NombreClinicaMe nvarchar(80),
	@EstadoMe bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Medicos values (@IdentidadMed,@NombreMe,@TelefonoMe,@EmailMe,@NombreClinicaMe,@EstadoMe)
END

GO
/****** Object:  StoredProcedure [dbo].[IngresarPaciente]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IngresarPaciente] 
	-- Add the parameters for the stored procedure here
	@IdentidadPa nvarchar(13),
	@NombrePa nvarchar(80),
	@EmailPa nvarchar(100),
	@TelefonoPa int,
	@SexoPa bit,
	@FechaNacPa date,
	@EstadoPa bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Pacientes values (@IdentidadPa,@NombrePa,@EmailPa,@TelefonoPa,@SexoPa,@FechaNacPa,@EstadoPa)
END

GO
/****** Object:  StoredProcedure [dbo].[IngresarRol]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IngresarRol]
	-- Add the parameters for the stored procedure here

	@DescripRol nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Rol values (@DescripRol)
END

GO
/****** Object:  StoredProcedure [dbo].[IngresarUsuarios]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IngresarUsuarios] 
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(15),
	@Password nvarchar(20),
	@Estado bit,
	@IdRol int,
	@EmailUsu nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Usuarios values (@UserName,@Password,@Estado,@IdRol,@EmailUsu)
END

GO
/****** Object:  StoredProcedure [dbo].[Verificar_Existencia_ID_Doctor]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Verificar_Existencia_ID_Doctor]
@filtro nvarchar(15)
as
select * from [dbo].[Medicos]
where [IdentidadMe] = @filtro



GO
/****** Object:  StoredProcedure [dbo].[Verificar_Existencia_ID_Examen]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Verificar_Existencia_ID_Examen]
@filtro nvarchar(15)
as
select * from [dbo].[Examenes]
where [NombreExamen] = @filtro



GO
/****** Object:  StoredProcedure [dbo].[Verificar_Existencia_ID_Paciente]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Verificar_Existencia_ID_Paciente]
@filtro nvarchar(15)
as
select * from [dbo].[Pacientes]
where [IdentidadPa] = @filtro



GO
/****** Object:  StoredProcedure [dbo].[Verificar_Existencia_ID_Usuario]    Script Date: 09/12/2020 19:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Verificar_Existencia_ID_Usuario]
@filtro nvarchar(15)
as
select * from [dbo].[Usuarios]
where Username = @filtro



GO
