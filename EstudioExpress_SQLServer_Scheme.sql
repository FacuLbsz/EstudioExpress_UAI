USE [master]
GO
--/****** Object:  Database [EstudioExpress]    Script Date: 26/11/2018 7:46:35 ******/
CREATE DATABASE [EstudioExpress]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'EstudioExpress3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EstudioExpress3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'EstudioExpress3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EstudioExpress3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
--GO
ALTER DATABASE [EstudioExpress] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EstudioExpress].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EstudioExpress] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EstudioExpress] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EstudioExpress] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EstudioExpress] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EstudioExpress] SET ARITHABORT OFF 
GO
ALTER DATABASE [EstudioExpress] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EstudioExpress] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EstudioExpress] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EstudioExpress] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EstudioExpress] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EstudioExpress] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EstudioExpress] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EstudioExpress] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EstudioExpress] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EstudioExpress] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EstudioExpress] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EstudioExpress] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EstudioExpress] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EstudioExpress] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EstudioExpress] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EstudioExpress] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EstudioExpress] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EstudioExpress] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EstudioExpress] SET  MULTI_USER 
GO
ALTER DATABASE [EstudioExpress] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EstudioExpress] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EstudioExpress] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EstudioExpress] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EstudioExpress] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EstudioExpress] SET QUERY_STORE = OFF
GO
USE [EstudioExpress]
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 26/11/2018 7:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bitacora](
	[idBitacora] [int] IDENTITY(1,1) NOT NULL,
	[criticidad] [int] NOT NULL,
	[descripcion] [nvarchar](256) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[funcionalidad] [nvarchar](45) NOT NULL,
	[Usuario_idUsuario] [int] NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_bitacora_idBitacora] PRIMARY KEY CLUSTERED 
(
	[idBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[digitoverificadorvertical]    Script Date: 26/11/2018 7:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[digitoverificadorvertical](
	[idDigitoVerificadorVertical] [int] IDENTITY(1,1) NOT NULL,
	[tabla] [nvarchar](45) NOT NULL,
	[digitoVerificador] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_digitoverificadorvertical_idDigitoVerificadorVertical] PRIMARY KEY CLUSTERED 
(
	[idDigitoVerificadorVertical] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[familia]    Script Date: 26/11/2018 7:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[familia](
	[idFamilia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](256) NOT NULL,
	[habilitado] [int] NOT NULL,
 CONSTRAINT [PK_familia_idFamilia] PRIMARY KEY CLUSTERED 
(
	[idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[familiapatente]    Script Date: 26/11/2018 7:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[familiapatente](
	[idFamiliaPatente] [int] IDENTITY(1,1) NOT NULL,
	[Patente_idPatente] [int] NOT NULL,
	[Familia_idFamilia] [int] NOT NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_familiapatente_idFamiliaPatente] PRIMARY KEY CLUSTERED 
(
	[idFamiliaPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[familiausuario]    Script Date: 26/11/2018 7:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[familiausuario](
	[idFamiliaUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Familia_idFamilia] [int] NOT NULL,
	[Usuario_idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_familiausuario_idFamiliaUsuario] PRIMARY KEY CLUSTERED 
(
	[idFamiliaUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patente]    Script Date: 26/11/2018 7:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patente](
	[idPatente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_patente_idPatente] PRIMARY KEY CLUSTERED 
(
	[idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patenteusuario]    Script Date: 26/11/2018 7:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patenteusuario](
	[idPatente] [int] IDENTITY(1,1) NOT NULL,
	[esPermisiva] [smallint] NOT NULL,
	[Patente_idPatente] [int] NOT NULL,
	[Usuario_idUsuario] [int] NOT NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_patenteusuario_idPatente] PRIMARY KEY CLUSTERED 
(
	[idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 26/11/2018 7:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [nvarchar](256) NOT NULL,
	[nombre] [nvarchar](45) NOT NULL,
	[apellido] [nvarchar](45) NOT NULL,
	[email] [nvarchar](45) NOT NULL,
	[contrasena] [nvarchar](256) NOT NULL,
	[habilitado] [int] NOT NULL,
	[cantidadDeIntentos] [int] NOT NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_usuario_idUsuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [fk_Bitacora_Usuario1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_Bitacora_Usuario1_idx] ON [dbo].[bitacora]
(
	[Usuario_idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_FamiliaPatente_Familia1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_FamiliaPatente_Familia1_idx] ON [dbo].[familiapatente]
(
	[Familia_idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_FamiliaPatente_Patente_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_FamiliaPatente_Patente_idx] ON [dbo].[familiapatente]
(
	[Patente_idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_FamiliaUsuario_Familia1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_FamiliaUsuario_Familia1_idx] ON [dbo].[familiausuario]
(
	[Familia_idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_FamiliaUsuario_Usuario1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_FamiliaUsuario_Usuario1_idx] ON [dbo].[familiausuario]
(
	[Usuario_idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_PatenteUsuario_Patente1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_PatenteUsuario_Patente1_idx] ON [dbo].[patenteusuario]
(
	[Patente_idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_PatenteUsuario_Usuario1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_PatenteUsuario_Usuario1_idx] ON [dbo].[patenteusuario]
(
	[Usuario_idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT ((0)) FOR [cantidadDeIntentos]
GO
ALTER TABLE [dbo].[bitacora]  WITH CHECK ADD  CONSTRAINT [bitacora$fk_Bitacora_Usuario1] FOREIGN KEY([Usuario_idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[bitacora] CHECK CONSTRAINT [bitacora$fk_Bitacora_Usuario1]
GO
ALTER TABLE [dbo].[familiapatente]  WITH CHECK ADD  CONSTRAINT [familiapatente$fk_FamiliaPatente_Familia1] FOREIGN KEY([Familia_idFamilia])
REFERENCES [dbo].[familia] ([idFamilia])
GO
ALTER TABLE [dbo].[familiapatente] CHECK CONSTRAINT [familiapatente$fk_FamiliaPatente_Familia1]
GO
ALTER TABLE [dbo].[familiapatente]  WITH CHECK ADD  CONSTRAINT [familiapatente$fk_FamiliaPatente_Patente] FOREIGN KEY([Patente_idPatente])
REFERENCES [dbo].[patente] ([idPatente])
GO
ALTER TABLE [dbo].[familiapatente] CHECK CONSTRAINT [familiapatente$fk_FamiliaPatente_Patente]
GO
ALTER TABLE [dbo].[familiausuario]  WITH CHECK ADD  CONSTRAINT [familiausuario$fk_FamiliaUsuario_Familia1] FOREIGN KEY([Familia_idFamilia])
REFERENCES [dbo].[familia] ([idFamilia])
GO
ALTER TABLE [dbo].[familiausuario] CHECK CONSTRAINT [familiausuario$fk_FamiliaUsuario_Familia1]
GO
ALTER TABLE [dbo].[familiausuario]  WITH CHECK ADD  CONSTRAINT [familiausuario$fk_FamiliaUsuario_Usuario1] FOREIGN KEY([Usuario_idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[familiausuario] CHECK CONSTRAINT [familiausuario$fk_FamiliaUsuario_Usuario1]
GO
ALTER TABLE [dbo].[patenteusuario]  WITH CHECK ADD  CONSTRAINT [patenteusuario$fk_PatenteUsuario_Patente1] FOREIGN KEY([Patente_idPatente])
REFERENCES [dbo].[patente] ([idPatente])
GO
ALTER TABLE [dbo].[patenteusuario] CHECK CONSTRAINT [patenteusuario$fk_PatenteUsuario_Patente1]
GO
ALTER TABLE [dbo].[patenteusuario]  WITH CHECK ADD  CONSTRAINT [patenteusuario$fk_PatenteUsuario_Usuario1] FOREIGN KEY([Usuario_idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[patenteusuario] CHECK CONSTRAINT [patenteusuario$fk_PatenteUsuario_Usuario1]
GO
USE [master]
GO
ALTER DATABASE [EstudioExpress] SET  READ_WRITE 
GO
