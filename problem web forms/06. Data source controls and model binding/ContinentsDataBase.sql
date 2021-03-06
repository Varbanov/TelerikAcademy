USE [master]
GO
/****** Object:  Database [Continents]    Script Date: 24.10.2014 г. 19:49:15 ******/
CREATE DATABASE [Continents]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Continents', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Continents.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Continents_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Continents_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Continents] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Continents].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Continents] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Continents] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Continents] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Continents] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Continents] SET ARITHABORT OFF 
GO
ALTER DATABASE [Continents] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Continents] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Continents] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Continents] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Continents] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Continents] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Continents] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Continents] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Continents] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Continents] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Continents] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Continents] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Continents] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Continents] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Continents] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Continents] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Continents] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Continents] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Continents] SET  MULTI_USER 
GO
ALTER DATABASE [Continents] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Continents] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Continents] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Continents] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Continents] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Continents]
GO
/****** Object:  Table [dbo].[Continents]    Script Date: 24.10.2014 г. 19:49:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 24.10.2014 г. 19:49:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Language] [nvarchar](50) NULL,
	[Population] [int] NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 24.10.2014 г. 19:49:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Population] [nvarchar](50) NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (2, N'Asia')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Population], [ContinentId]) VALUES (1, N'Bulgaria', N'Bulgarian', 6000000, 1)
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Population], [ContinentId]) VALUES (2, N'China', N'Chinese', 2000000000, 2)
INSERT [dbo].[Countries] ([CountryId], [Name], [Language], [Population], [ContinentId]) VALUES (4, N'Germany', N'German', 80000000, 1)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (1, N'Sofia', N'1000000', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (2, N'Beijing', N'15000000', 2)
INSERT [dbo].[Towns] ([TownId], [Name], [Population], [CountryId]) VALUES (3, N'Berlin', N'2000000', 4)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([ContinentId])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [Continents] SET  READ_WRITE 
GO
