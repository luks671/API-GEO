USE [master]
GO
/****** Object:  Database [Geolocalizacion]    Script Date: 26/1/2022 23:34:35 ******/
CREATE DATABASE [Geolocalizacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Geolocalizacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Geolocalizacion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Geolocalizacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Geolocalizacion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Geolocalizacion] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Geolocalizacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Geolocalizacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Geolocalizacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Geolocalizacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Geolocalizacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Geolocalizacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [Geolocalizacion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Geolocalizacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Geolocalizacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Geolocalizacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Geolocalizacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Geolocalizacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Geolocalizacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Geolocalizacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Geolocalizacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Geolocalizacion] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Geolocalizacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Geolocalizacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Geolocalizacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Geolocalizacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Geolocalizacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Geolocalizacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Geolocalizacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Geolocalizacion] SET RECOVERY FULL 
GO
ALTER DATABASE [Geolocalizacion] SET  MULTI_USER 
GO
ALTER DATABASE [Geolocalizacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Geolocalizacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Geolocalizacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Geolocalizacion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Geolocalizacion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Geolocalizacion] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Geolocalizacion', N'ON'
GO
ALTER DATABASE [Geolocalizacion] SET QUERY_STORE = OFF
GO
USE [Geolocalizacion]
GO
/****** Object:  User [test]    Script Date: 26/1/2022 23:34:36 ******/
CREATE USER [test] FOR LOGIN [test] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[geolocalizar]    Script Date: 26/1/2022 23:34:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[geolocalizar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[calle] [varchar](50) NULL,
	[numero] [int] NULL,
	[ciudad] [varchar](50) NULL,
	[codigo_postal] [varchar](50) NULL,
	[provincia] [varchar](50) NULL,
	[pais] [varchar](50) NULL,
	[latitud] [varchar](50) NULL,
	[longitud] [varchar](50) NULL,
	[estado] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[geolocalizar] ADD  DEFAULT ('') FOR [estado]
GO
USE [master]
GO
ALTER DATABASE [Geolocalizacion] SET  READ_WRITE 
GO
