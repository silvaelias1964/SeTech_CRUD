USE [master]
GO
/****** Object:  Database [Viajes]    Script Date: 12/09/2019 03:44:24 p. m. ******/
CREATE DATABASE [Viajes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Viajes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.ELIASS\MSSQL\DATA\Viajes.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Viajes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.ELIASS\MSSQL\DATA\Viajes_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Viajes] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Viajes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Viajes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Viajes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Viajes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Viajes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Viajes] SET ARITHABORT OFF 
GO
ALTER DATABASE [Viajes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Viajes] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Viajes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Viajes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Viajes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Viajes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Viajes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Viajes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Viajes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Viajes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Viajes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Viajes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Viajes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Viajes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Viajes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Viajes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Viajes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Viajes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Viajes] SET RECOVERY FULL 
GO
ALTER DATABASE [Viajes] SET  MULTI_USER 
GO
ALTER DATABASE [Viajes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Viajes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Viajes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Viajes] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Viajes]
GO
/****** Object:  Table [dbo].[Destinos]    Script Date: 12/09/2019 03:44:24 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinos](
	[IdDestino] [int] IDENTITY(1,1) NOT NULL,
	[Destino] [nvarchar](50) NOT NULL,
	[Precio] [money] NOT NULL,
	[Plazas] [int] NOT NULL,
 CONSTRAINT [PK_Destinos] PRIMARY KEY CLUSTERED 
(
	[IdDestino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 12/09/2019 03:44:24 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[IdViajero] [int] NOT NULL,
	[IdDestino] [int] NOT NULL,
	[PlazasReserva] [int] NOT NULL,
	[LugarOrigen] [nvarchar](50) NULL,
	[FechaReserva] [date] NULL,
 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Viajeros]    Script Date: 12/09/2019 03:44:24 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viajeros](
	[IdViajero] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [nvarchar](20) NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](200) NULL,
	[Telefonos] [nvarchar](50) NOT NULL,
	[CorreoE] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Viajeros] PRIMARY KEY CLUSTERED 
(
	[IdViajero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Destinos] FOREIGN KEY([IdDestino])
REFERENCES [dbo].[Destinos] ([IdDestino])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Destinos]
GO
ALTER TABLE [dbo].[Reservas]  WITH NOCHECK ADD  CONSTRAINT [FK_Reservas_Viajeros] FOREIGN KEY([IdViajero])
REFERENCES [dbo].[Viajeros] ([IdViajero])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Viajeros]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Destinos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Reservas', @level2type=N'CONSTRAINT',@level2name=N'FK_Reservas_Destinos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Viajeros' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Reservas', @level2type=N'CONSTRAINT',@level2name=N'FK_Reservas_Viajeros'
GO
USE [master]
GO
ALTER DATABASE [Viajes] SET  READ_WRITE 
GO
