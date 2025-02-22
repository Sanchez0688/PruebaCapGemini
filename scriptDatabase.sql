USE [master]
GO
/****** Object:  Database [prueba_capgemini]    Script Date: 11/10/2024 23:47:35 ******/
CREATE DATABASE [prueba_capgemini]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'prueba_capgemini', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\prueba_capgemini.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'prueba_capgemini_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\prueba_capgemini_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [prueba_capgemini] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [prueba_capgemini].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [prueba_capgemini] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [prueba_capgemini] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [prueba_capgemini] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [prueba_capgemini] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [prueba_capgemini] SET ARITHABORT OFF 
GO
ALTER DATABASE [prueba_capgemini] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [prueba_capgemini] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [prueba_capgemini] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [prueba_capgemini] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [prueba_capgemini] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [prueba_capgemini] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [prueba_capgemini] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [prueba_capgemini] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [prueba_capgemini] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [prueba_capgemini] SET  DISABLE_BROKER 
GO
ALTER DATABASE [prueba_capgemini] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [prueba_capgemini] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [prueba_capgemini] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [prueba_capgemini] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [prueba_capgemini] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [prueba_capgemini] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [prueba_capgemini] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [prueba_capgemini] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [prueba_capgemini] SET  MULTI_USER 
GO
ALTER DATABASE [prueba_capgemini] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [prueba_capgemini] SET DB_CHAINING OFF 
GO
ALTER DATABASE [prueba_capgemini] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [prueba_capgemini] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [prueba_capgemini] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [prueba_capgemini] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [prueba_capgemini] SET QUERY_STORE = ON
GO
ALTER DATABASE [prueba_capgemini] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [prueba_capgemini]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/10/2024 23:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (9, N'Mi producto ', N'DFD', CAST(850000 AS Decimal(18, 0)), 15)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (11, N'jHgiyPPHdm', N'Test', CAST(5000 AS Decimal(18, 0)), 52)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (13, N'strin', N'string', CAST(560 AS Decimal(18, 0)), 890)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (14, N'striSn', N'string', CAST(560 AS Decimal(18, 0)), 890)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (15, N'stringSDS', N'string', CAST(2313210 AS Decimal(18, 0)), 120)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (16, N'Mi bebesote', N'DFD', CAST(540000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (17, N'Test', N'Test', CAST(5000 AS Decimal(18, 0)), 52)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (18, N'Testx', N'Test', CAST(5000 AS Decimal(18, 0)), 52)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (19, N'8XnqpMKsKJ', N'Test', CAST(5000 AS Decimal(18, 0)), 52)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (20, N'nGhLiNaWjE', N'Test', CAST(5000 AS Decimal(18, 0)), 52)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (21, N'JwbmgxMiLK', N'Test', CAST(5000 AS Decimal(18, 0)), 52)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (22, N'0ylc1QI2Ma', N'Test', CAST(5000 AS Decimal(18, 0)), 52)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_CREATE_PRODUCT]    Script Date: 11/10/2024 23:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anderson Sanchez>
-- Create date: <11 Oct 2024>
-- Description:	<Procedimiento Creacion Productos>
-- =============================================
CREATE PROCEDURE [dbo].[SP_CREATE_PRODUCT]

	@Name Varchar(100),
	@Description Varchar(500),
	@Price Decimal,
	@Stock Int,
	@Message varchar(4000) OUTPUT,
	@Value int OUTPUT

AS
BEGIN
	
	SET @Value = -1;
    BEGIN TRANSACTION;

    BEGIN TRY

        INSERT INTO [dbo].[Product] (Name, Description, Price, Stock)
        VALUES (@Name, @Description, @Price, @Stock);

        COMMIT TRANSACTION;

        SET @Message = 'El producto fue guardado exitosamente.';
		SET @Value = SCOPE_IDENTITY();
	
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        SET @Message = 'Error al guardar el producto: ' + ERROR_MESSAGE();
		SET @Value = -1;
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_PRODUCT]    Script Date: 11/10/2024 23:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anderson Sanchez>
-- Create date: <11 Oct 2024>
-- Description:	<Procedimiento Eliminacion Producto>
CREATE PROCEDURE [dbo].[SP_DELETE_PRODUCT]
    @Id INT,
    @Message NVARCHAR(4000) OUTPUT,
    @Value int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Value = -1;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        DELETE FROM [dbo].[Product] WHERE Id = @Id;
        
        IF @@ROWCOUNT = 0
        BEGIN
            SET @Message = 'No se encontró el producto con el ID proporcionado.';
            ROLLBACK TRANSACTION;
            SET @Value = -1;
        END
        ELSE
        BEGIN
            COMMIT TRANSACTION;
            SET @Message = 'Producto eliminado exitosamente.';
			SET @Value = 0;
        END
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @Message = 'Error al eliminar producto: ' + ERROR_MESSAGE();
		SET @Value = -1;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_READ_PRODUCT]    Script Date: 11/10/2024 23:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anderson Sanchez>
-- Create date: <11 Oct 2024>
-- Description:	<Procedimiento Obtener Producto por id>
CREATE PROCEDURE [dbo].[SP_READ_PRODUCT]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT Id,Name,Description,Price,Stock FROM [dbo].[Product] WHERE Id = @Id;
        
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_PRODUCT]    Script Date: 11/10/2024 23:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anderson Sanchez>
-- Create date: <11 Oct 2024>
-- Description:	<Procedimiento Actualizar Producto>
CREATE PROCEDURE [dbo].[SP_UPDATE_PRODUCT]
    @Id INT,
    @Name NVARCHAR(100),
    @Description NVARCHAR(255),
    @Price DECIMAL(18, 2),
    @Stock INT,
    @Message NVARCHAR(4000) OUTPUT,
    @Value int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Value = -1;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        UPDATE [dbo].[Product]
        SET Name = @Name, Description = @Description, Price = @Price, Stock = @Stock
        WHERE Id = @Id;
        
        IF @@ROWCOUNT = 0
        BEGIN
            SET @Message = 'No se encontró el producto con el ID proporcionado.';
            ROLLBACK TRANSACTION;
			SET @Value = -1;
        END
        ELSE
        BEGIN
            COMMIT TRANSACTION;
            SET @Message = 'Producto actualizado exitosamente.';
			SET @Value = @Id;
        END
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @Message = 'Error al actualizar producto: ' + ERROR_MESSAGE();
		SET @Value = -1;
    END CATCH
END;
GO
USE [master]
GO
ALTER DATABASE [prueba_capgemini] SET  READ_WRITE 
GO
