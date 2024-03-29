USE [master]
GO
/****** Object:  Database [CadastroClientes]    Script Date: 7/17/2022 10:12:56 AM ******/
CREATE DATABASE [CadastroClientes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CadastroClientes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CadastroClientes.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CadastroClientes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CadastroClientes_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CadastroClientes] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CadastroClientes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CadastroClientes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CadastroClientes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CadastroClientes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CadastroClientes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CadastroClientes] SET ARITHABORT OFF 
GO
ALTER DATABASE [CadastroClientes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CadastroClientes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CadastroClientes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CadastroClientes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CadastroClientes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CadastroClientes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CadastroClientes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CadastroClientes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CadastroClientes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CadastroClientes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CadastroClientes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CadastroClientes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CadastroClientes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CadastroClientes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CadastroClientes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CadastroClientes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CadastroClientes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CadastroClientes] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CadastroClientes] SET  MULTI_USER 
GO
ALTER DATABASE [CadastroClientes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CadastroClientes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CadastroClientes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CadastroClientes] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CadastroClientes] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CadastroClientes]
GO
/****** Object:  Table [dbo].[cliente_para_endereco]    Script Date: 7/17/2022 10:12:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente_para_endereco](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[id_endereco] [int] NOT NULL,
 CONSTRAINT [PK_cliente_para_endereco] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cliente_para_telefone]    Script Date: 7/17/2022 10:12:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente_para_telefone](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[id_telefone] [int] NOT NULL,
 CONSTRAINT [PK_cliente_para_telefone] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_cliente]    Script Date: 7/17/2022 10:12:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[data_nascimento] [date] NOT NULL,
	[cpf] [varchar](11) NOT NULL,
	[rg] [varchar](10) NOT NULL,
	[facebook] [varchar](50) NULL,
	[linkedin] [varchar](50) NULL,
	[twitter] [varchar](50) NULL,
	[instagram] [varchar](50) NULL,
 CONSTRAINT [PK_tb_cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_endereco]    Script Date: 7/17/2022 10:12:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_endereco](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[logradouro] [varchar](50) NOT NULL,
	[tipo_logradouro] [varchar](3) NOT NULL,
	[bairro] [varchar](50) NOT NULL,
	[cidade] [varchar](50) NOT NULL,
	[estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tb_endereco] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_telefone]    Script Date: 7/17/2022 10:12:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_telefone](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[identificacao] [varchar](50) NOT NULL,
	[telefone] [varchar](11) NOT NULL,
 CONSTRAINT [PK_tb_telefone] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 7/17/2022 10:12:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](150) NULL,
	[Login] [varchar](50) NOT NULL,
	[Senha] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[cliente_para_endereco]  WITH CHECK ADD  CONSTRAINT [fk_cliente_endereco] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[tb_cliente] ([id])
GO
ALTER TABLE [dbo].[cliente_para_endereco] CHECK CONSTRAINT [fk_cliente_endereco]
GO
ALTER TABLE [dbo].[cliente_para_endereco]  WITH CHECK ADD  CONSTRAINT [fk_endereco_cliente] FOREIGN KEY([id_endereco])
REFERENCES [dbo].[tb_endereco] ([id])
GO
ALTER TABLE [dbo].[cliente_para_endereco] CHECK CONSTRAINT [fk_endereco_cliente]
GO
ALTER TABLE [dbo].[cliente_para_telefone]  WITH CHECK ADD  CONSTRAINT [fk_cliente_telefone] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[tb_cliente] ([id])
GO
ALTER TABLE [dbo].[cliente_para_telefone] CHECK CONSTRAINT [fk_cliente_telefone]
GO
ALTER TABLE [dbo].[cliente_para_telefone]  WITH CHECK ADD  CONSTRAINT [fk_telefone_cliente] FOREIGN KEY([id_telefone])
REFERENCES [dbo].[tb_telefone] ([id])
GO
ALTER TABLE [dbo].[cliente_para_telefone] CHECK CONSTRAINT [fk_telefone_cliente]
GO
USE [master]
GO
ALTER DATABASE [CadastroClientes] SET  READ_WRITE 
GO
