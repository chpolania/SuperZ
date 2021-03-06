USE [master]
GO
/****** Object:  Database [SuperZapatos]    Script Date: 21/02/2017 8:42:55 a. m. ******/
CREATE DATABASE [SuperZapatos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SuperZapatos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SuperZapatos.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SuperZapatos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SuperZapatos_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SuperZapatos] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SuperZapatos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SuperZapatos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SuperZapatos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SuperZapatos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SuperZapatos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SuperZapatos] SET ARITHABORT OFF 
GO
ALTER DATABASE [SuperZapatos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SuperZapatos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SuperZapatos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SuperZapatos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SuperZapatos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SuperZapatos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SuperZapatos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SuperZapatos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SuperZapatos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SuperZapatos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SuperZapatos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SuperZapatos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SuperZapatos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SuperZapatos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SuperZapatos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SuperZapatos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SuperZapatos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SuperZapatos] SET RECOVERY FULL 
GO
ALTER DATABASE [SuperZapatos] SET  MULTI_USER 
GO
ALTER DATABASE [SuperZapatos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SuperZapatos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SuperZapatos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SuperZapatos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SuperZapatos', N'ON'
GO
USE [SuperZapatos]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 21/02/2017 8:42:56 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[id] [int] NOT NULL,
	[name] [varchar](255) NULL,
	[description] [text] NULL,
	[price] [int] NULL,
	[total_in_shelf] [int] NULL,
	[total_in_vault] [int] NULL,
	[store_id] [int] NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stores]    Script Date: 21/02/2017 8:42:56 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stores](
	[id] [int] NOT NULL,
	[name] [varchar](255) NULL,
	[address] [varchar](255) NULL,
 CONSTRAINT [PK_stores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Articles] ([id], [name], [description], [price], [total_in_shelf], [total_in_vault], [store_id]) VALUES (1, N'1', N'store 1', 100, 1, 1, 2)
INSERT [dbo].[Articles] ([id], [name], [description], [price], [total_in_shelf], [total_in_vault], [store_id]) VALUES (33, N'33', N'33', 33, 33, 33, 1)
INSERT [dbo].[Stores] ([id], [name], [address]) VALUES (1, N'store one', N'fake adress1')
INSERT [dbo].[Stores] ([id], [name], [address]) VALUES (2, N'2', N'2')
INSERT [dbo].[Stores] ([id], [name], [address]) VALUES (3, N'2', N'2')
USE [master]
GO
ALTER DATABASE [SuperZapatos] SET  READ_WRITE 
GO
