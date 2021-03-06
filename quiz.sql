USE [master]
GO
/****** Object:  Database [mobi96_Quizproject]    Script Date: 2/7/2018 6:46:53 PM ******/
CREATE DATABASE [mobi96_Quizproject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mobi96_Quizproject', FILENAME = N'E:\MSSQL.MSSQLSERVER\DATA\mobi96_Quizproject.mdf' , SIZE = 25920KB , MAXSIZE = 204800KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'mobi96_Quizproject_log', FILENAME = N'D:\MSSQL.MSSQLSERVER\DATA\mobi96_Quizproject_log.ldf' , SIZE = 45056KB , MAXSIZE = 102400KB , FILEGROWTH = 1024KB )
GO
ALTER DATABASE [mobi96_Quizproject] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mobi96_Quizproject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mobi96_Quizproject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET ARITHABORT OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mobi96_Quizproject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mobi96_Quizproject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET  ENABLE_BROKER 
GO
ALTER DATABASE [mobi96_Quizproject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mobi96_Quizproject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [mobi96_Quizproject] SET  MULTI_USER 
GO
ALTER DATABASE [mobi96_Quizproject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mobi96_Quizproject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mobi96_Quizproject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mobi96_Quizproject] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [mobi96_Quizproject] SET DELAYED_DURABILITY = DISABLED 
GO
USE [mobi96_Quizproject]
GO
/****** Object:  User [QuizprojectUser123]    Script Date: 2/7/2018 6:46:55 PM ******/
CREATE USER [QuizprojectUser123] FOR LOGIN [QuizprojectUser123] WITH DEFAULT_SCHEMA=[QuizprojectUser123]
GO
/****** Object:  DatabaseRole [gd_execprocs]    Script Date: 2/7/2018 6:46:56 PM ******/
CREATE ROLE [gd_execprocs]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [QuizprojectUser123]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [QuizprojectUser123]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [QuizprojectUser123]
GO
ALTER ROLE [db_datareader] ADD MEMBER [QuizprojectUser123]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [QuizprojectUser123]
GO
/****** Object:  Schema [QuizprojectUser123]    Script Date: 2/7/2018 6:46:57 PM ******/
CREATE SCHEMA [QuizprojectUser123]
GO
/****** Object:  UserDefinedFunction [dbo].[GetCanvasValueORReturnASIT]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetCanvasValueORReturnASIT] (@sep char(1), @s varchar(Max),@type int)

RETURNS varchar(100)
AS BEGIN 

   return(
    SELECT 
	CASE
    WHEN @type=5
	Then
	[dbo].[GetCanvasValueWithSplit] (@sep ,@s) 
	 ELSE @s
    END
	)

End
GO
/****** Object:  UserDefinedFunction [dbo].[GetCanvasValueWithSplit]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetCanvasValueWithSplit] (@sep char(1), @s varchar(Max))

RETURNS varchar(100)


AS
BEGIN
			 DECLARE @Left varchar(max), @Top varchar(max), @Right varchar(max), @Bottom varchar(max),@width varchar(max),@hight varchar(max),@value varchar(max);

			 SELECT @Left=s FROM [dbo].[Split] (@sep ,@s) where pn=1
			 SELECT @Top=s FROM [dbo].[Split] (@sep ,@s) where pn=2
			 SELECT @Right=s FROM [dbo].[Split] (@sep ,@s) where pn=3
			 SELECT @Bottom=s FROM [dbo].[Split] (@sep ,@s) where pn=4

			 SET @width = CAST(@Right AS INT) -CAST(@Left AS INT)

			 SET @hight = CAST(@Bottom AS INT) -CAST(@Top AS INT)

			 SET @value = @Left+','+@Top+' ' +@width+','+@hight; 

			-- SET @value = (SELECT s FROM [dbo].[Split] (@sep ,@s) where pn=1)+','+(SELECT s FROM [dbo].[Split] (@sep ,@s) where pn=2)+' ' +CAST((SELECT s FROM [dbo].[Split] (@sep ,@s) where pn=3) AS INT) -CAST((SELECT s FROM [dbo].[Split] (@sep ,@s) where pn=1) AS INT)+','+(CAST((SELECT s FROM [dbo].[Split] (@sep ,@s) where pn=4) AS INT) -CAST((SELECT s FROM [dbo].[Split] (@sep ,@s) where pn=2) AS INT)); 

			 RETURN  @value
End


--SELECT [dbo].[GetCanvasValueWithSplit] (',' ,'33,84,175,235') 

GO
/****** Object:  UserDefinedFunction [dbo].[HtmlToPlainText]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[HtmlToPlainText] (@HTMLText VARCHAR(MAX))
RETURNS VARCHAR(MAX) AS
BEGIN
    DECLARE @Start INT
    DECLARE @End INT
    DECLARE @Length INT
    SET @Start = CHARINDEX('<',@HTMLText)
    SET @End = CHARINDEX('>',@HTMLText,CHARINDEX('<',@HTMLText))
    SET @Length = (@End - @Start) + 1
    WHILE @Start > 0 AND @End > 0 AND @Length > 0
    BEGIN
        SET @HTMLText = STUFF(@HTMLText,@Start,@Length,'')
        SET @Start = CHARINDEX('<',@HTMLText)
        SET @End = CHARINDEX('>',@HTMLText,CHARINDEX('<',@HTMLText))
        SET @Length = (@End - @Start) + 1
    END
    RETURN LTRIM(RTRIM(@HTMLText))
END

GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LevelMaster]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LevelMaster](
	[level_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[lname] [nvarchar](max) NULL,
	[status] [nvarchar](50) NULL,
	[created_by] [int] NULL,
	[created_date] [datetime] NULL,
	[isdeleted] [int] NULL,
	[updated_by] [int] NULL,
	[updated_date] [datetime] NULL,
	[cust_id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[new_plans]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[new_plans](
	[plan_id] [int] IDENTITY(1,1) NOT NULL,
	[cust_id] [int] NULL,
	[plans] [nvarchar](max) NULL,
	[duration] [int] NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [int] NULL,
	[created_by] [nvarchar](50) NULL,
	[updated_by] [nvarchar](50) NULL,
	[status] [nvarchar](10) NULL,
	[amnt] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_AdminLogin]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_AdminLogin](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_AdminLogin] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_booking_master]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_booking_master](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[cust_id] [int] NULL,
	[gid] [int] NULL,
	[use_id] [int] NULL,
	[tid] [int] NULL,
	[booking_date] [datetime] NULL,
	[booking_time] [time](7) NULL,
	[no_person] [nvarchar](20) NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [int] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL,
	[level_id] [int] NULL,
	[todatetime] [datetime] NULL,
	[timestamp] [nvarchar](50) NULL,
	[duration] [nvarchar](50) NULL,
	[hold_status] [int] NULL,
	[booking_status] [int] NULL,
	[map] [nvarchar](max) NULL,
	[additional] [nvarchar](max) NULL,
	[comments] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_category_master]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_category_master](
	[cat_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[cust_id] [int] NULL,
	[cat_name] [nvarchar](100) NULL,
	[cat_imgurl] [nvarchar](max) NULL,
	[cat_desc] [nvarchar](max) NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [bit] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL,
 CONSTRAINT [PK_tbl_cat_master] PRIMARY KEY CLUSTERED 
(
	[cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_check_out]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_check_out](
	[check_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[fk_order_id] [int] NOT NULL,
	[kot_id] [int] NULL,
	[table_id] [int] NULL,
	[guest_id] [int] NULL,
	[transaction_Id] [varchar](50) NULL,
	[payMode] [varchar](50) NULL,
	[paidAmt] [int] NULL,
	[remainingAmt] [int] NULL,
	[totalAmt] [int] NULL,
	[paidStatus] [bit] NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [int] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[check_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_currency]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_currency](
	[currency_id] [int] IDENTITY(1,1) NOT NULL,
	[country] [nvarchar](200) NULL,
	[country_code] [nvarchar](10) NULL,
	[currency] [nvarchar](100) NULL,
	[code_ISO] [nvarchar](10) NULL,
	[is_active] [bit] NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [bit] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL,
 CONSTRAINT [PK_tbl_currency] PRIMARY KEY CLUSTERED 
(
	[currency_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_customer]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_customer](
	[cust_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[plan_id] [int] NULL,
	[reg_date] [datetime] NULL,
	[valid_date] [datetime] NULL,
	[oname] [nvarchar](100) NULL,
	[cname] [nvarchar](100) NULL,
	[dob] [datetime] NULL,
	[email] [nvarchar](100) NULL,
	[cno] [nvarchar](100) NULL,
	[mno] [nvarchar](100) NULL,
	[address] [nvarchar](max) NULL,
	[country] [nvarchar](100) NULL,
	[city] [nvarchar](100) NULL,
	[zip] [int] NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [int] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL,
	[bkimg] [nvarchar](max) NULL,
	[logoimg] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_ExamConfig]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ExamConfig](
	[ExamCodeId] [int] IDENTITY(1,1) NOT NULL,
	[ExamCode] [nvarchar](50) NULL,
	[ExamTitle] [nvarchar](50) NULL,
	[SecondCategoryId] [int] NULL,
	[PassingPercentage] [decimal](18, 2) NULL,
	[TestTime] [int] NULL,
	[TestOption] [nvarchar](50) NULL,
	[ValidDate] [datetime] NULL,
	[MerchantId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Price] [decimal](18, 2) NULL,
	[ExamSimulator] [bit] NULL,
	[ExamSimulatorDemo] [bit] NULL,
	[OnlyTestOnce] [bit] NULL,
	[AllowPrint] [bit] NULL,
	[AllowSales] [bit] NULL,
 CONSTRAINT [PK_tbl_ExamConfig] PRIMARY KEY CLUSTERED 
(
	[ExamCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_guest_master]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_guest_master](
	[gid] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[cust_id] [int] NULL,
	[fname] [nvarchar](200) NULL,
	[lname] [nvarchar](200) NULL,
	[email] [nvarchar](200) NULL,
	[cno] [nvarchar](200) NULL,
	[address] [nvarchar](200) NULL,
	[city] [nvarchar](200) NULL,
	[zip] [nvarchar](200) NULL,
	[company_name] [nvarchar](300) NULL,
	[vat_code] [nvarchar](50) NULL,
	[status] [varchar](200) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [int] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_kot_details]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_kot_details](
	[kot_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[kot_id] [int] NULL,
	[cat_id] [int] NULL,
	[subcat_id] [int] NULL,
	[pid] [int] NULL,
	[rate] [int] NULL,
	[quantity] [nvarchar](50) NULL,
	[total_amnt] [nvarchar](50) NULL,
	[remark] [nvarchar](max) NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [int] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL,
	[discount] [nvarchar](50) NULL,
	[weight] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_kot_master]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_kot_master](
	[kot_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[cust_id] [int] NULL,
	[order_id] [int] NULL,
	[gid] [int] NULL,
	[order_date] [date] NULL,
	[total_item] [int] NULL,
	[sub_total] [float] NULL,
	[discount_per] [float] NULL,
	[discount_amnt] [float] NULL,
	[special_discount_amnt] [float] NULL,
	[vat_per] [real] NULL,
	[vat_amnt] [real] NULL,
	[Tip_amnt] [real] NULL,
	[total_amnt] [real] NULL,
	[paid_amnt] [real] NULL,
	[due_amnt] [real] NULL,
	[par_mode] [nvarchar](20) NULL,
	[void_reason] [nchar](1000) NULL,
	[remark] [nvarchar](100) NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [int] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_MasterCountry]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MasterCountry](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](150) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_MstCountry] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_MasterState]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MasterState](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NULL,
	[State] [nvarchar](150) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_MstState] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_MerchantFeeRate]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MerchantFeeRate](
	[MerchantFeeRateId] [int] IDENTITY(1,1) NOT NULL,
	[MerchantFeeRate] [int] NULL,
	[MerchantLevelId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[Updateby] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_MerchantFeeRate] PRIMARY KEY CLUSTERED 
(
	[MerchantFeeRateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_MerchantInfo]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MerchantInfo](
	[MerchantId] [int] IDENTITY(1,1) NOT NULL,
	[MerchantName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[StateId] [int] NULL,
	[Telephone] [nvarchar](50) NULL,
	[MerchantLevelId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[ActiveStatus] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[EmailId] [nvarchar](50) NULL,
	[Brand] [nvarchar](50) NULL,
	[Picture] [nvarchar](200) NULL,
	[About] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_MerchantInfo] PRIMARY KEY CLUSTERED 
(
	[MerchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_MerchantLevel]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MerchantLevel](
	[MerchantLevelId] [int] IDENTITY(1,1) NOT NULL,
	[MerchantLevel] [nvarchar](50) NULL,
	[AnnualFee] [decimal](18, 2) NULL,
	[ExamCount] [int] NULL,
	[StudentCount] [int] NULL,
	[ShopperFee] [decimal](18, 2) NULL,
	[QuestionType] [nvarchar](max) NULL,
	[ExtraPermission] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_MerchantLevel] PRIMARY KEY CLUSTERED 
(
	[MerchantLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_MerchantMyUser]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MerchantMyUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[AccessPassword] [nvarchar](50) NULL,
	[MerchantId] [int] NULL,
	[ExamId] [nvarchar](50) NULL,
	[ExamCode] [nvarchar](50) NULL,
	[ValidTime] [datetime] NULL,
	[AccessOption] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[Createdby] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[ValidTimeTo] [datetime] NULL,
	[EmailId] [nvarchar](200) NULL,
	[GroupId] [int] NULL,
	[GroupStatus] [bit] NULL,
 CONSTRAINT [PK__tbl_Merc__3214EC079AEEAB51] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_payment_details]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_payment_details](
	[pay_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[cust_id] [int] NULL,
	[pay_date] [datetime] NULL,
	[amnt] [int] NULL,
	[pay_mode] [nvarchar](100) NULL,
	[pay_rem] [nvarchar](100) NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [int] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_PaymentOption]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PaymentOption](
	[PaymentOptionId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentOption] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_PaymentOption] PRIMARY KEY CLUSTERED 
(
	[PaymentOptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_petty_cash]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_petty_cash](
	[petty_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[fk_cust_id] [int] NOT NULL,
	[fk_user_id] [int] NULL,
	[Supplier_id] [int] NULL,
	[Staff_id] [int] NULL,
	[receipt_No] [varchar](100) NULL,
	[payMode] [varchar](50) NULL,
	[paidAmt] [int] NULL,
	[receipt_description] [varchar](50) NULL,
	[signature_img] [varchar](250) NULL,
	[status] [varchar](10) NULL,
	[is_deleted] [bit] NULL,
	[created_date] [datetime] NULL,
	[created_by] [int] NULL,
	[updated_date] [datetime] NULL,
	[update_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[petty_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_plans]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_plans](
	[plan_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[cust_id] [int] NULL,
	[plans] [nvarchar](max) NULL,
	[duration] [int] NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [int] NULL,
	[created_by] [nvarchar](50) NULL,
	[updated_by] [nvarchar](50) NULL,
	[status] [nvarchar](10) NULL,
	[amnt] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_product_master]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_product_master](
	[pid] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[cust_id] [int] NULL,
	[cat_id] [int] NULL,
	[subcat_id] [int] NULL,
	[pname] [nvarchar](max) NULL,
	[imgurl] [nvarchar](max) NULL,
	[price] [int] NULL,
	[pro_desc] [nvarchar](max) NULL,
	[qr_code] [nvarchar](1000) NULL,
	[bar_code] [nvarchar](50) NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [bit] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL,
 CONSTRAINT [PK_tbl_product_master] PRIMARY KEY CLUSTERED 
(
	[pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_QuestionType]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_QuestionType](
	[QuestionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionType] [nvarchar](50) NULL,
	[DefaultPermission] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_QuestionType] PRIMARY KEY CLUSTERED 
(
	[QuestionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_roles]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_roles](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[cust_id] [int] NULL,
	[rolename] [nvarchar](100) NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [int] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_SalesReports]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SalesReports](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](50) NULL,
	[ExamCodeId] [int] NULL,
	[ExamCode] [nvarchar](50) NULL,
	[SecondCategoryId] [int] NULL,
	[MerchantId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[Price] [decimal](18, 2) NULL,
	[FeeRateId] [int] NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[OrderStatus] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[ExamSimulator] [bit] NULL,
	[ExamSimulatorDemo] [bit] NULL,
	[OnlyTestOnce] [bit] NULL,
	[AllowPrint] [bit] NULL,
	[AllowSales] [bit] NULL,
 CONSTRAINT [PK_tbl_SalesReports] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_SecondCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SecondCategory](
	[SecondCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[SecondCategoryName] [nvarchar](50) NULL,
	[TopCategoryId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_SecondCategory] PRIMARY KEY CLUSTERED 
(
	[SecondCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_store_configuration]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_store_configuration](
	[config_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[fk_currency_id] [int] NULL,
	[is_active] [bit] NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [bit] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[config_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_store_info]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_store_info](
	[Store_Unique_id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Store_id] [int] IDENTITY(1,1) NOT NULL,
	[Owner_Name] [nvarchar](350) NULL,
	[Store_Name] [nvarchar](350) NULL,
	[Contact_No] [int] NULL,
	[Alternative_Contact_No] [int] NULL,
	[Email] [nvarchar](350) NULL,
	[Address] [nvarchar](350) NULL,
	[City] [nvarchar](70) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](30) NULL,
	[Zip_Code] [nvarchar](8) NULL,
	[Store_imgurl] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[Store_Is_Active] [bit] NULL,
	[Is_Active] [bit] NULL,
	[Is_Deleted] [bit] NULL,
	[Created_Date] [datetime] NULL,
	[Updated_Date] [datetime] NULL,
	[Created_By] [int] NULL,
	[Update_By] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Store_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_store_POSuser]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_store_POSuser](
	[POSLogin_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[cust_id] [int] NULL,
	[POS_User_role_id] [int] NULL,
	[fname] [nvarchar](100) NULL,
	[lname] [nvarchar](100) NULL,
	[contact_no] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[city] [nvarchar](100) NULL,
	[POS_username] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[POSLoginPIN] [int] NULL,
	[is_active] [bit] NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [bit] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[POSLogin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_subcategory_master]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_subcategory_master](
	[subcat_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[cat_id] [int] NULL,
	[cust_id] [int] NULL,
	[subcat_name] [nvarchar](50) NULL,
	[subcat_imgurl] [nvarchar](max) NULL,
	[subcat_desc] [nvarchar](max) NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [bit] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL,
 CONSTRAINT [PK_tbl_subcat_master] PRIMARY KEY CLUSTERED 
(
	[subcat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_superadmin]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_superadmin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[cno] [nchar](10) NULL,
	[pass] [nvarchar](50) NULL,
	[status] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_table_master]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_table_master](
	[tid] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[cust_id] [int] NULL,
	[tableno] [nvarchar](max) NULL,
	[capacity] [nvarchar](20) NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [int] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL,
	[level_id] [int] NULL,
	[bookingtime] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_ThirdCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ThirdCategory](
	[ThirdCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ThirdCategoryName] [nvarchar](50) NULL,
	[SecondCategoryId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_ThirdCategory] PRIMARY KEY CLUSTERED 
(
	[ThirdCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_TopCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TopCategory](
	[TopCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[TopCategoryName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_TopCategory] PRIMARY KEY CLUSTERED 
(
	[TopCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_userlogin]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_userlogin](
	[use_id] [int] IDENTITY(1,1) NOT NULL,
	[cust_id] [int] NULL,
	[role_id] [int] NULL,
	[fname] [nvarchar](100) NULL,
	[lname] [nvarchar](100) NULL,
	[cno] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[city] [nvarchar](100) NULL,
	[username] [nvarchar](100) NULL,
	[pass] [nvarchar](100) NULL,
	[PIN] [int] NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [int] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_vat]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_vat](
	[vat_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_Store_id] [int] NULL,
	[fk_Store_Unique_id] [uniqueidentifier] NULL,
	[vat_type] [nvarchar](50) NULL,
	[vat_per] [float] NULL,
	[cust_id] [int] NULL,
	[is_active] [bit] NULL,
	[status] [varchar](10) NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[is_deleted] [bit] NULL,
	[created_by] [int] NULL,
	[update_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[vat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_WithDrawOrder]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_WithDrawOrder](
	[WithDrawOrderId] [int] IDENTITY(1001,1) NOT NULL,
	[WithDrawOrderNo] [nvarchar](50) NULL,
	[Amount] [decimal](18, 2) NULL,
	[MerchantId] [int] NULL,
	[OrderStatus] [bit] NULL,
	[OrderDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_WithDrawOrder] PRIMARY KEY CLUSTERED 
(
	[WithDrawOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransactionMaster]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionMaster](
	[T_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[gid] [int] NULL,
	[kot_id] [int] NULL,
	[paid_amnt] [float] NULL,
	[due_amnt] [float] NULL,
	[pay_mode] [nvarchar](max) NULL,
	[remark] [nvarchar](max) NULL,
	[created_by] [int] NULL,
	[created_date] [datetime] NULL,
	[isdeleted] [int] NULL,
	[updated_by] [int] NULL,
	[updated_date] [datetime] NULL,
	[cust_id] [int] NULL,
	[transaction_id] [nvarchar](max) NULL,
	[payment_status] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_BundleExam]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_BundleExam](
	[BundleId] [int] IDENTITY(1,1) NOT NULL,
	[BundleContent] [nvarchar](100) NULL,
	[Price] [decimal](18, 2) NULL,
	[FeaturedSelfsEstore] [bit] NULL,
	[MerchantId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblBundleExam] PRIMARY KEY CLUSTERED 
(
	[BundleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_ExamReports]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_ExamReports](
	[ExamReportId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CategoryId] [int] NULL,
	[ExamId] [int] NULL,
	[Result] [bit] NULL,
	[Score] [decimal](18, 2) NULL,
	[OutofScore] [decimal](18, 2) NULL,
	[AllowPrint] [bit] NULL,
	[DigitalCertificateId] [int] NULL,
	[CertificationNo] [int] NULL,
	[ExamGivenDate] [datetime] NULL,
	[MerchantId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_ExamReports] PRIMARY KEY CLUSTERED 
(
	[ExamReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_MerchantAllowSales]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_MerchantAllowSales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamId] [int] NULL,
	[NoofQuestion] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[SelfDescription] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_MerchantAllowSales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_MerchantBalance]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_MerchantBalance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MerchantId] [int] NULL,
	[Balance] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tbl_MerchantBalance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_MerchantCertificate]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_MerchantCertificate](
	[CertificateId] [int] IDENTITY(1,1) NOT NULL,
	[CertificateTitle] [nvarchar](200) NULL,
	[CertificatePic] [nvarchar](400) NULL,
	[NameBox] [nvarchar](400) NULL,
	[DateBox] [nvarchar](400) NULL,
	[SampleUserName] [nvarchar](100) NULL,
	[MerchantId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_MerchantCertificate] PRIMARY KEY CLUSTERED 
(
	[CertificateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_MerchantEstoreConfig]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_MerchantEstoreConfig](
	[EstroeConfigId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionNumber] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[ExamPicture] [nvarchar](200) NULL,
	[ExamDescription] [nvarchar](max) NULL,
	[ExamId] [int] NULL,
	[MerchantId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[Createdby] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_MerchantEstoreConfig] PRIMARY KEY CLUSTERED 
(
	[EstroeConfigId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_MerchantExtraPermission]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_MerchantExtraPermission](
	[ExtraPermissionOptId] [int] IDENTITY(1,1) NOT NULL,
	[ExtraPermissionOpt] [nvarchar](50) NULL,
	[DefaultPermission] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_MerchantExtraPermission] PRIMARY KEY CLUSTERED 
(
	[ExtraPermissionOptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_MerchantFinanceConfig]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_MerchantFinanceConfig](
	[FinanceConfigId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentOptionId] [int] NULL,
	[MerchantId] [int] NULL,
	[AccountEmail] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[BankOfName] [nvarchar](50) NULL,
	[SwiftCode] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_MerchantFinanceConfig] PRIMARY KEY CLUSTERED 
(
	[FinanceConfigId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_MerchantInfoPayment]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_MerchantInfoPayment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[MerchantId] [int] NULL,
	[MerchantOrderNo] [nvarchar](100) NULL,
	[SId] [nvarchar](50) NULL,
	[Key] [nvarchar](50) NULL,
	[Order_Number] [nvarchar](50) NULL,
	[CurrencyCode] [nvarchar](50) NULL,
	[InvoiceId] [nvarchar](50) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[CCProcess] [nchar](10) NULL,
	[PayMethod] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
	[PaymentData] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_tbl_MerchantInfoPayment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_QAManage]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_QAManage](
	[QAId] [int] IDENTITY(1,1) NOT NULL,
	[ExamCodeId] [int] NULL,
	[ExamCode] [nvarchar](50) NULL,
	[QuestionTypeId] [int] NULL,
	[Score] [decimal](18, 2) NULL,
	[Question] [nvarchar](max) NULL,
	[NoofAnswer] [int] NULL,
	[Explanation] [nvarchar](max) NULL,
	[MerchantId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Resource] [nvarchar](max) NULL,
	[Exhibit] [nvarchar](max) NULL,
	[Topology] [nvarchar](max) NULL,
	[Scenario] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_QAManage_1] PRIMARY KEY CLUSTERED 
(
	[QAId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_QAnswer]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_QAnswer](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[Answer] [nvarchar](max) NULL,
	[QuestionId] [int] NULL,
	[RightAnswer] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_QAnswer] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_Template]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_Template](
	[TemplateId] [int] IDENTITY(1,1) NOT NULL,
	[CertificateTitle] [nvarchar](50) NULL,
	[SampleUserName] [nvarchar](50) NULL,
	[TemplatePicture] [nvarchar](200) NULL,
	[MerchantId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_Template] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_UserAccessOption]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_UserAccessOption](
	[AccessOptionId] [int] IDENTITY(1,1) NOT NULL,
	[AccessOption] [nvarchar](100) NULL,
	[DefaultPermission] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_UserAccessOption] PRIMARY KEY CLUSTERED 
(
	[AccessOptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [QuizprojectUser123].[tbl_UserGroup]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuizprojectUser123].[tbl_UserGroup](
	[GroupId] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](100) NULL,
	[MerchantId] [int] NULL,
	[ExamId] [nvarchar](max) NULL,
	[AccessOption] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[Createdby] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_UserGroup] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Split] (@sep char(1), @s varchar(512))
RETURNS table
AS
RETURN (
    WITH Pieces(pn, start, stop) AS (
      SELECT 1, 1, CHARINDEX(@sep, @s)
      UNION ALL
      SELECT pn + 1, stop + 1, CHARINDEX(@sep, @s, stop + 1)
      FROM Pieces
      WHERE stop > 0
    )
    SELECT pn,
      SUBSTRING(@s, start, CASE WHEN stop > 0 THEN stop-start ELSE 512 END) AS s
    FROM Pieces
    
  )
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/****** Object:  StoredProcedure [dbo].[AddCustomer]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddCustomer] 
	-- Add the parameters for the stored procedure here
@plan_id int,
@reg_date datetime,
@valid_date datetime,
@oname nvarchar(200),
@cname nvarchar(200),
@dob datetime,
@email nvarchar(200),
@cno nvarchar(200),
@mno nvarchar(200),
@address nvarchar(200),
@country nvarchar(200),
@city nvarchar(200),
@zip nvarchar(200),
@status nvarchar(20),
@created_by int,
@PIN int,
@username nvarchar(max),
@pass nvarchar(max),
--return values 
@errorCode int output,
@errorMessage nvarchar(max) output


AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF EXISTS(SELECT 1 FROM tbl_customer where @email=email)
	BEGIN
		SET @errorCode = 4004
		SET @errorMessage = 'Email Address Already Exist'
		RETURN
	END

	IF EXISTS(SELECT 1 FROM tbl_customer where @mno=mno)
	BEGIN
		SET @errorCode = 4004
		SET @errorMessage = 'Mobile Number Already Exist'
		RETURN
	END

	INSERT INTO tbl_customer
	(
		plan_id,
		reg_date,
		valid_date,
		oname,
		cname,
		dob,
		email,
		cno,
		mno,
		address,
		country,
		city,
		zip,
		status,
		created_date,
		created_by
	)
	VALUES
	(
		@plan_id,
		@reg_date,
		@valid_date,
		@oname,
		@cname,
		@dob,
		@email,
		@cno,
		@mno,
		@address,
		@country,
		@city,
		@zip,
		@status,
		GETDATE(),
		@created_by

	)

	 IF @@ROWCOUNT > 0 
	BEGIN
	DECLARE @CUST_ID INT
	SET @CUST_ID = @@IDENTITY
		INSERT INTO tbl_userlogin
		(
			cust_id,
			role_id,
			fname,
			--lname,
			cno,
			email,
			city,
			username,
			pass,
			PIN,
			status,
			created_date,
			created_by
		)
		VALUES
		(
			@CUST_ID,
			'1',
			@cname,
			--@lname
			@cno,
			@email,
			@city,
			@username,
			@pass,
			@PIN,
			@status,
			GETDATE(),
			@created_by		
		)
	END
    -- Insert statements for procedure here
	SET @errorCode = 0 
	SET @errorMessage = 'Success'
END TRY
BEGIN CATCH
	SET @errorCode = 2002
	SET @errorMessage = 'Internal Server Error'
END CATCH






GO
/****** Object:  StoredProcedure [dbo].[AddKotItem]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddKotItem]
	-- Add the parameters for the stored procedure here
	@kot_id int ,
	@cat_id int ,
	@subcat_id int,
	@pid int ,
	@rate float ,
	@quantity int ,
	@total_amnt float ,
	@remark nvarchar(200) = NULL ,
	@created_by int ,
	--Return Values
	@retquantity int output,
	@rettotamnt int output,
	@kot_detail_id int output, 
	@errorCode int output,
	@errorMessage nvarchar(200) output,
	@discount nvarchar(50),
	@weight nvarchar(50)

AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS(SELECT 1 FROM tbl_kot_master WHERE @kot_id=kot_id and status = 0)
	BEGIN
		SET @errorCode = 5005
		SET @errorMessage = 'Checkout'
		RETURN
	END

	IF EXISTS(SELECT 1 FROM tbl_kot_details WHERE @kot_id=kot_id and @cat_id=cat_id and @subcat_id=subcat_id and @pid=pid)
	BEGIN
		UPDATE tbl_kot_details SET quantity=quantity+@quantity,total_amnt=total_amnt+@total_amnt WHERE kot_id=@kot_id and cat_id=@cat_id and subcat_id=@subcat_id and pid=@pid
		SET @errorCode = 2001
		SET @errorMessage = 'Update Success'
		SET @kot_detail_id = (SELECT kot_detail_id from tbl_kot_details where kot_id=@kot_id and cat_id=@cat_id and subcat_id=@subcat_id and pid=@pid)
		SET @retquantity = (SELECT quantity from tbl_kot_details where kot_id=@kot_id and cat_id=@cat_id and subcat_id=@subcat_id and pid=@pid)
		SET @rettotamnt = (SELECT total_amnt from tbl_kot_details where kot_id=@kot_id and cat_id=@cat_id and subcat_id=@subcat_id and pid=@pid)
		UPDATE tbl_kot_master SET total_item=total_item+@retquantity,sub_total=sub_total+@rettotamnt WHERE kot_id = @kot_id
		RETURN
	END
    -- Insert statements for procedure here
	INSERT INTO tbl_kot_details
	(
		kot_id,
		cat_id,
		subcat_id,
		pid,
		rate,
		quantity,
		total_amnt,
		remark,
		status,
		created_date,
		created_by,
		is_deleted,
		discount,
		weight	
	)

	VALUES
	(
		@kot_id,
		@cat_id,
		@subcat_id,
		@pid,
		@rate,
		@quantity,
		@total_amnt,
		@remark,
		'1',
		GETDATE(),
		@created_by,
		'0',
		@discount,
		@weight	
	)

	IF @@ROWCOUNT > 0
	BEGIN
		DECLARE @kotdetailid int
		SET @kotdetailid = @@IDENTITY
		SET @kot_detail_id = @kotdetailid
		SET @retquantity = @quantity
		SET @rettotamnt = @total_amnt
		UPDATE tbl_kot_master SET total_item=total_item+@retquantity,sub_total=sub_total+@rettotamnt WHERE kot_id = @kot_id
	END
	SET @errorCode = 2002
	SET @errorMessage = 'SUCCESS'

END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = ERROR_MESSAGE()
END CATCH






GO
/****** Object:  StoredProcedure [dbo].[BookTable]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BookTable]
	-- Add the parameters for the stored procedure here
	@fname nvarchar(20),
	@lname nvarchar(20),
	@email nvarchar(50),
	@cno nvarchar(15),
	@address nvarchar(200),
	@ordertime datetime,
	@tablenoid int,
	@cust_id int,
	@user_id int,
	@level_id int,
	@noofperson int,
	@todatetime datetime,
	--return values
	@kotid int output,
	@guest_id int output,
	@orderid int output,
	@status nvarchar(200) output
	
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF EXISTS (select 1 from tbl_booking_master where booking_Date between @ordertime and @todatetime and todatetime between @ordertime and @todatetime and @level_id=level_id and @tablenoid=tid and @cust_id=cust_id)
	BEGIN
		SET @kotid = 0
		SET @guest_id = 0
		SET @orderid = 0
		SET @status = 'Table is Alread Booked'
		return
	END

	IF EXISTS(SELECT 1 FROM tbl_guest_master where cust_id = @cust_id and email = @email)
	BEGIN 

	Update  tbl_guest_master SET
	   fname = @fname,
	   lname = @lname,
	   cno = @cno,
	   address = @address,
	   update_by = @user_id,
	   updated_date = GETDATE()
	where 
		cust_id=@cust_id and 
		email = @email 	
	
	
		DECLARE @gid int
		SET @gid = (SELECT GID FROM TBL_GUEST_MASTER WHERE @cust_id = cust_id and @email=email)
		SET @guest_id = @gid
		INSERT INTO tbl_booking_master
		(
		cust_id,
		gid,
		use_id,
		tid,
		booking_date,
		booking_time,
		status,
		created_date,
		created_by,
		level_id,
		no_person,
		todatetime,
		hold_status,
		booking_status
		)

		VALUES
		(
		@cust_id,
		@gid,
		@user_id,
		@tablenoid,
		@ordertime,
		GETDATE(),
		'1',
		GETDATE(),
		@user_id,
		@level_id,
		@noofperson,
		@todatetime,
		'0',
		'2'
		)
				
	END
	ELSE
	BEGIN
	Insert into tbl_guest_master
	(
	   cust_id,
	   fname,
	   lname,
	   email,
	   cno,
	   address,
	   status,
	   created_date,
	   created_by
	)
	values
	(
	@cust_id,
	@fname,
	@lname,
	@email,
	@cno,
	@address,
	'1',
	GETDATE(),
	@user_id
		
	)


    IF @@ROWCOUNT > 0 
	BEGIN
		DECLARE @gid1 int
		SET @gid1 = @@IDENTITY
		SET @guest_id = @gid1
		INSERT INTO tbl_booking_master
		(
		cust_id,
		gid,
		use_id,
		tid,
		booking_date,
		booking_time,
		status,
		created_date,
		created_by,
		level_id,
		no_person,
		todatetime,
		hold_status,
		booking_status
		)

		VALUES
		(
		@cust_id,
		@gid1,
		@user_id,
		@tablenoid,
		@ordertime,
		GETDATE(),
		'1',
		GETDATE(),
		@user_id,
		@level_id,
		@noofperson,
		@todatetime,
		'0',
		'2'
		)
				
	
	END
	END

	DECLARE @order_id int
	SET @order_id = @@IDENTITY	

	INSERT INTO tbl_kot_master
	(
	 cust_id,
	 order_id,
	 gid,
	 order_date,
	 total_item,
	 sub_total,
	 total_amnt,
	 status,
	 created_date,
	 created_by
	)

	VALUES 
	(
	@cust_id,
	@order_id,
	@guest_id,
	GETDATE(),
	0,
	0,
	0,
	'1',
	GETDATE(),
	@user_id
	)

	DECLARE @kot_id int
	SET @kot_id = @@IDENTITY
	
	DECLARE @FDATE NVARCHAR(MAX)
	DECLARE @TDATE NVARCHAR(MAX)
	SET @FDATE = @ordertime
	SET @TDATE = @todatetime

	UPDATE tbl_table_master set status=1,bookingtime=@FDATE+' - '+@TDATE where tid=@tablenoid
	
	SET @kotid = @kot_id
	SET @guest_id = @gid
	SET @orderid = @order_id
	SET @status = 'Table Booked Successfully'
END TRY
BEGIN CATCH
	SET @kotid = 0
	SET @guest_id = 0
	SET @orderid = 0
	SET @status = ERROR_MESSAGE()
END CATCH






GO
/****** Object:  StoredProcedure [dbo].[CreateCustomer]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateCustomer] 
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@user_id int,
	@fname nvarchar(200),
	@lname nvarchar(200),
	@email nvarchar(200),
	@cno nvarchar(200),
	@address nvarchar(200),
	@city nvarchar(200),
	@zip nvarchar(200),
	--Return Values
	@errorCode int output,
	@errorMessage nvarchar(200) output
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF EXISTS(SELECT 1 FROM tbl_guest_master WHERE @cno=cno AND @cust_id=cust_id)
	BEGIN 
		SET @errorCode = 2001
		SET @errorMessage = 'This Cutomer Mobile is Already Exist'
		RETURN
	END 

	insert into tbl_guest_master
	(
		cust_id,
		fname,
		lname,
		email,
		cno,
		address,
		city,
		zip,
		status,
		created_date,
		created_by
		
	)
	values 
	(
		@cust_id,
		@fname,
		@lname,
		@email,
		@cno,
		@address,
		@city,
		@zip,
		'1',
		GETDATE(),
		@user_id
	)

    SET @errorCode = 0
	SET @errorMessage = 'Success'
END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = ERROR_MESSAGE()
END CATCH






GO
/****** Object:  StoredProcedure [dbo].[CreateLevel]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateLevel]
	-- Add the parameters for the stored procedure here
	@lname nvarchar(200),
	@status nvarchar(50),
	@userid int,
	@custid int,
	--return values
	@errorCode int output,
	@errorMessage nvarchar(max) output
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF EXISTS(SELECT 1 FROM LevelMaster WHERE @lname = lname and @custid = cust_id)
	BEGIN
		SET @errorCode = 2001
		SET @errorMessage = 'Level Name Already Exist'
		RETURN
	END

	INSERT INTO LevelMaster
	(
	lname,
	status,
	created_date,
	created_by,
	cust_id
	)

	VALUES
	(
	@lname,
	@status,
	GETDATE(),
	@userid,
	@custid
	)
    
	SET @errorCode = 0
	SET @errorMessage = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = ERROR_MESSAGE()
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[CreateRoles]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateRoles]
	-- Add the parameters for the stored procedure here
@cust_id int,
@user_id int,
@rname nvarchar(50),
@status nvarchar(50),
--return value
@errorCode int output,
@errorMessage nvarchar(200) output

AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF EXISTS(select 1 from tbl_roles where @cust_id=cust_id and @rname=rolename)
	BEGIN
		SET @errorCode = 2001
		SET @errorMessage = 'Role Name Already Exist'
	return
	END
	INSERT INTO tbl_roles
	(
		cust_id,
		rolename,
		status,
		created_date,
		created_by
	)

	VALUES
	(
	
		@cust_id,
		@rname,
		@status,
		GETDATE(),
		@user_id

	)
    -- Insert statements for procedure here
	SET @errorCode = 0
	SET @errorMessage = 'Success'
	return
END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = 'Internal Server Error'
END CATCH







GO
/****** Object:  StoredProcedure [dbo].[CreateSubCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateSubCategory] 
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@cat_id int,
	@subcatname nvarchar(200),
	@subcatimg nvarchar(200),
	--@subcatdesc nvarchar(200),
	@status nvarchar(200),
	@created_by int,

	--return value

	@errorCode int output,
	@errorMessage nvarchar(200) output

AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS(SELECT 1 FROM tbl_subcat_master where @subcatname=subcat_name and @cat_id = cat_id and @cust_id=cust_id)
	BEGIN 
		SET @errorCode = 2001
		SET @errorMessage = 'Sub Category Already Exist'
		return
	END

	insert into tbl_subcat_master
	(
	cat_id,
	cust_id,
	subcat_name,
	subcat_imgurl,
	--subcat_disc,
	status,
	created_date,
	created_by
	)
	VALUES
	(
	@cat_id,
	@cust_id,
	@subcatname,
	@subcatimg,
	--@subcatdesc,
	@status,
	GETDATE(),
	@created_by
	)
    -- Insert statements for procedure here
	SET @errorCode = 0
	SET @errorMessage = 'Success'
	
END TRY
BEGIN CATCH
	SET @errorCode = 1001
	SET @errorMessage = 'INTERNAL SERVER ERROR'
END CATCH






GO
/****** Object:  StoredProcedure [dbo].[CreateTable]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateTable] 
	-- Add the parameters for the stored procedure here
	@tno nvarchar(100),
	@capacity nvarchar(100),
	@status nvarchar(50),
	@userid int,
	@cust_id int,
	@level_id int,
    --Return Value 
	@errorCode int output,
	@errorMessage nvarchar(100) output
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF EXISTS(SELECT 1 FROM tbl_table_master WHERE @tno=tableno AND @cust_id=cust_id AND @level_id = level_id)
	BEGIN 
		SET @errorCode = 4004
		SET @errorMessage = 'Table Number is Already Exist'
		RETURN
	END 
	INSERT INTO tbl_table_master
	(
	tableno,
	capacity,
	status,
	created_by,
	created_date,
	cust_id,
	level_id
	)
	VALUES
	(
	@tno,
	@capacity,
	@status,
	@userid,
	GETDATE(),
	@cust_id,
	@level_id
	)
	SET @errorCode = 0
	SET @errorMessage = 'SUCCESS' 
END TRY
BEGIN CATCH
	SET @errorCode = 2002
	SET @errorMessage = ERROR_MESSAGE()
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser] 
	-- Add the parameters for the stored procedure here
	@user_id int,
	@cust_id int,
	@role_id int,
	@fname nvarchar(200),
	@lname nvarchar(200),
	@cno nvarchar(200),
	@email nvarchar(200),
	@city nvarchar(200),
	@username nvarchar(200),
	@pass nvarchar(200),
	@PIN nvarchar(100),
	@status nvarchar(100),
	-- Return Value 
	@errorCode int output,
	@errorMessage nvarchar(200) output
	
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--IF EXISTS(SELECT 1 FROM tbl_userlogin WHERE @cust_id=cust_id and @cno=cno)
	--BEGIN
		--SET @errorCode = 2001
		--SET @errorMessage='Mobile Number Already Exist'
	--RETURN  
	--END 
	/*IF EXISTS(SELECT 1 FROM tbl_userlogin WHERE @cust_id=cust_id and @email=email)
	BEGIN
		SET @errorCode = 2002
		SET @errorMessage='Email Already Exist'
	RETURN  
	END
	IF EXISTS(SELECT 1 FROM tbl_userlogin WHERE @cust_id=cust_id and @username=username)
	BEGIN
		SET @errorCode = 2003
		SET @errorMessage='UserName Already Exist'
	RETURN  
	END*/
	IF EXISTS(SELECT 1 FROM tbl_userlogin WHERE @cust_id=cust_id and @PIN=PIN)
	BEGIN
		SET @errorCode = 2004
		SET @errorMessage='PIN Already Exist'
	RETURN  
	END
	INSERT INTO tbl_userlogin
	(
		cust_id,
		role_id,
		fname,
		lname,
		cno,
		email,
		city,
		username,
		pass,
		PIN,
		status,
		created_date,
		created_by
	)
	VALUES
	(
		@cust_id,
		@role_id,
		@fname,
		@lname,
		@cno,
		@email,
		@city,
		@username,
		@pass,
		@PIN,
		@status,
		GETDATE(),
		@user_id
	)
	SET @errorCode = 0
	SET @errorMessage = 'Success'
END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = 'Internal Server Error'
END CATCH






GO
/****** Object:  StoredProcedure [dbo].[CreateVatType]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateVatType] 
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@user_id int,
	@vattype nvarchar(100),
	@vatper float,
	@status nvarchar(100),
	--Return Value
	@errorCode int output,
	@errorMessage nvarchar(100) output
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF EXISTS(select 1 from tbl_vat where @cust_id=cust_id and @vattype=vat_type)
	BEGIN
		SET @errorCode = 2001
		SET @errorMessage = 'Vat Type Already Exist'
		RETURN
	END
    -- Insert statements for procedure here
	INSERT INTO tbl_vat
	(
		cust_id,
		vat_type,
		vat_per,
		status,
		created_date,
		created_by,
		is_deleted
	)
	VALUES
	(
		@cust_id,
		@vattype,
		@vatper,
		@status,
		GETDATE(),
		@user_id,
		'0'
	)

	SET @errorCode = 0
	SET @errorMessage = 'Success'
END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = ERROR_MESSAGE()
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[CurrentOrder]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CurrentOrder] 
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select a.cust_id,a.order_id,a.tid,b.kot_id,a.gid,a.booking_date,a.booking_time,a.no_person,a.level_id,a.todatetime,b.status as 'checkoutstatus',a.gid,a.tid,a.level_id,isnull(a.hold_status,0) as 'hold_status' from tbl_booking_master a,tbl_kot_master b where  b.order_id=a.order_id and a.created_by=@user_id and a.cust_id=@cust_id and a.status = 1
END





GO
/****** Object:  StoredProcedure [dbo].[CurrentOrder1]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CurrentOrder1] 
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select a.cust_id,a.order_id,a.tid,b.kot_id,a.gid,a.booking_date,a.booking_time,a.no_person,a.level_id,a.todatetime,b.status as 'checkoutstatus',a.gid,a.tid,a.level_id,isnull(a.hold_status,0) as 'hold_status',a.booking_date,a.booking_time,a.booking_status,a.timestamp from tbl_booking_master a,tbl_kot_master b where  b.order_id=a.order_id and a.created_by=@user_id and a.cust_id=@cust_id and a.status = 1
END





GO
/****** Object:  StoredProcedure [dbo].[deletekotitems]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[deletekotitems]
	-- Add the parameters for the stored procedure here
	@kot_id int,
	@kot_detail_id int,
	--Return Values 
	@errorCode int output,
	@errorMessage nvarchar(max) output
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF NOT EXISTS(SELECT 1 FROM tbl_kot_details where @kot_id=kot_id and @kot_detail_id=kot_detail_id)
	BEGIN
		SET @errorCode = 4004
		SET @errorMessage = 'Record Not Found'
		RETURN
	END

	DECLARE @qnty int 
	DECLARE @rate float
	DECLARE @total_amnt float

	SET @qnty = (SELECT quantity FROM tbl_kot_details where @kot_id=kot_id and @kot_detail_id=kot_detail_id)
	SET @rate = (SELECT rate FROM tbl_kot_details where @kot_id=kot_id and @kot_detail_id=kot_detail_id)
	SET @total_amnt = (SELECT total_amnt from tbl_kot_details where @kot_id=kot_id and @kot_detail_id=kot_detail_id)

	delete from tbl_kot_details where kot_id=@kot_id and kot_detail_id=@kot_detail_id

	Update tbl_kot_master SET
	total_item = total_item - @qnty,
	sub_total = sub_total - @total_amnt
	where 
	kot_id=@kot_id

    -- Insert statements for procedure here
	SET @errorCode = 0
	SET @errorMessage = 'Success'
END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = 'Internal Server Error'
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[EditKotItem]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditKotItem]
	-- Add the parameters for the stored procedure here
	@kot_id int,
	@kot_detail_id int,
	@rate float,
	@qnty int,
	@remark nvarchar(max)=NULL,
	@updated_by int,
	-- Return values 
	@errorCode int output,
	@errorMessage nvarchar(max) output,
	@discount nvarchar(50),
	@weight nvarchar(50)
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF NOT EXISTS(SELECT 1 FROM tbl_kot_details where @kot_id=kot_id and @kot_detail_id=kot_detail_id)
	BEGIN
		SET @errorCode = 2002
		SET @errorMessage = 'Not Found'
		RETURN
	END
	
	DECLARE @oldqnty int
	DECLARE @oldrate float
	DECLARE @oldtotal_amnt float
	
	SET @oldqnty = (SELECT quantity FROM tbl_kot_details WHERE @kot_id=kot_id and @kot_detail_id=kot_detail_id)
	SET @oldrate = (SELECT rate FROM tbl_kot_details WHERE @kot_id=kot_id and @kot_detail_id=kot_detail_id)
	SET @oldtotal_amnt = (SELECT total_amnt FROM tbl_kot_details WHERE @kot_id=kot_id and @kot_detail_id=kot_detail_id)
	
	DECLARE @total_amnt float
	SET @total_amnt = @qnty * @rate
	
	Update tbl_kot_details SET	
	rate = @rate,
	quantity= @qnty,
	total_amnt = @total_amnt,
	updated_date = GETDATE(),
	update_by = @updated_by,
	discount = @discount,
	weight = @weight	
	WHERE 
	kot_id=@kot_id and 
	kot_detail_id=@kot_detail_id

	DECLARE @remainqnty int
	DECLARE @remaintotalamnt float

	IF @qnty > @oldqnty
	BEGIN
		SET @remainqnty = @qnty - @oldqnty
		SET @remaintotalamnt = @remainqnty * @rate
		Update tbl_kot_master SET
		total_item = total_item + @remainqnty,
		sub_total = sub_total + @remaintotalamnt,
		updated_date = GETDATE(),
		update_by = @updated_by
		WHERE 
		kot_id = @kot_id
	END
	ELSE
	BEGIN
		SET @remainqnty = @oldqnty - @qnty
		SET @remaintotalamnt = @remainqnty * @rate

		Update tbl_kot_master SET
		total_item = total_item - @remainqnty,
		sub_total = sub_total - @remaintotalamnt,
		updated_date = GETDATE(),
		update_by = @updated_by
		WHERE 
		kot_id = @kot_id
	END

	SET @errorCode = 0
	SET @errorMessage  = 'Success'
	
END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = 'Internal Server Error'
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[GetAllCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllCategory]
	-- Add the parameters for the stored procedure here
	@cust_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_category_master where cust_id = @cust_id 
	--select * from tbl_cat_master where cust_id = @cust_id 
	
END





GO
/****** Object:  StoredProcedure [dbo].[getAllCustomers]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getAllCustomers]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM tbl_customer ORDER BY cust_id
END





GO
/****** Object:  StoredProcedure [dbo].[GetAllGuest]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllGuest]
	-- Add the parameters for the stored procedure here
@cust_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM tbl_guest_master WHERE cust_id = @cust_id ORDER BY gid DESC
END





GO
/****** Object:  StoredProcedure [dbo].[GetAllLevels]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllLevels]
	-- Add the parameters for the stored procedure here
	@custid int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM LevelMaster WHERE CUST_ID = @custid ORDER BY lname
END





GO
/****** Object:  StoredProcedure [dbo].[getAllProduct]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getAllProduct]
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@cat_id int,
	@sub_catid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [pid]
      ,[cust_id]
      ,[cat_id]
      ,[subcat_id]
      ,[pname]
      ,[imgurl]
      ,[price]
      ,[pro_desc]
      ,ISNULL([qr_code],'') as [qr_code]
      ,ISNULL([bar_code],'') as [bar_code]
      ,[status]
      ,[created_date]
      ,[updated_date]
      ,[is_deleted]
      ,[created_by]
      ,[update_by]

	 From tbl_product_master 
	 
	 where subcat_id=ISNULL(@sub_catid,subcat_id) and cat_id = ISNULL(@cat_id,cat_id) and cust_id= ISNULL(@cust_id,cust_id) and is_deleted=0
END





GO
/****** Object:  StoredProcedure [dbo].[GetAllRoles]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllRoles] 
	-- Add the parameters for the stored procedure here
	@cust_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM tbl_roles WHERE cust_id=@cust_id
END





GO
/****** Object:  StoredProcedure [dbo].[GetAllSubCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllSubCategory] 
	-- Add the parameters for the stored procedure here
	@cust_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_subcat_master where cust_id = @cust_id order by subcat_id
END





GO
/****** Object:  StoredProcedure [dbo].[GetAllTables]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllTables]
	-- Add the parameters for the stored procedure here
	@cust_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_table_master  where cust_id=@cust_id order by tableno
END





GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllUsers] 
	-- Add the parameters for the stored procedure here
	@cust_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.*,b.rolename FROM tbl_userlogin a,tbl_roles b WHERE b.role_id=a.role_id and a.cust_id = @cust_id order by a.use_id
END





GO
/****** Object:  StoredProcedure [dbo].[getBookingData]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getBookingData] 
	-- Add the parameters for the stored procedure here

@cust_id int


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT b.fname,b.lname,b.cno,c.tableno,d.lname as 'levelname',a.booking_date,a.todatetime,a.no_person From tbl_booking_master a,tbl_guest_master b,tbl_table_master c,LevelMaster d where d.level_id=a.level_id and c.tid=a.tid and b.gid=a.gid and a.cust_id=@cust_id
END





GO
/****** Object:  StoredProcedure [dbo].[getbookingdetail]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getbookingdetail] 
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@order_id int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT b.fname,b.lname,b.cno,b.email,b.address,c.tableno,d.lname as 'levelname',a.booking_date,a.todatetime,a.no_person From tbl_booking_master a,tbl_guest_master b,tbl_table_master c,LevelMaster d where d.level_id=a.level_id and c.tid=a.tid and b.gid=a.gid and a.cust_id=@cust_id and a.order_id = @order_id
END





GO
/****** Object:  StoredProcedure [dbo].[GetBookingList]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBookingList]
 
	-- Add the parameters for the stored procedure here
@cust_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select a.cust_id,a.order_id,a.tid,b.kot_id,a.gid,c.fname,c.lname,c.email,c.cno,c.address,a.booking_date,a.booking_time,a.no_person,a.level_id,a.todatetime from tbl_booking_master a,tbl_kot_master b,tbl_guest_master c where c.gid=a.gid and b.order_id=a.order_id and  a.cust_id=@cust_id and a.status = 1
END





GO
/****** Object:  StoredProcedure [dbo].[getCategoryDetail]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getCategoryDetail]
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@cat_id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_cat_master where cat_id = @cat_id and cust_id = @cust_id
END





GO
/****** Object:  StoredProcedure [dbo].[GetConfiguration]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetConfiguration](@StoreId int)
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
   declare @fk_currency_id int
   set @fk_currency_id = (SELECT [fk_currency_id]  FROM [tbl_store_configuration] where [fk_Store_id]=@StoreId)
  
IF  (@fk_currency_id > 0)
    BEGIN
       SELECT [currency_id],[country],[country_code],[currency],[code_ISO ]  FROM [tbl_currency] where currency_id=@fk_currency_id
    END
	Else
	BEGIN
	SELECT [currency_id],[country],[country_code],[currency],[code_ISO ]  FROM [tbl_currency] where [currency_id]=50
END

IF EXISTS (SELECT [vat_per]  FROM [dbo].[tbl_vat]  where fk_store_id=@StoreId and  is_active=1)
    BEGIN
    SELECT [vat_type] ,[vat_per]  FROM [dbo].[tbl_vat]  where  fk_store_id=@StoreId and is_active=1
    END
	Else
	BEGIN
	SELECT [vat_type] ,[vat_per]  FROM [dbo].[tbl_vat]  where vat_id=1
END

END



GO
/****** Object:  StoredProcedure [dbo].[GetCurrentBookingList]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCurrentBookingList] 
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Select a.cust_id,a.order_id,a.tid,b.kot_id,a.gid,c.fname,c.lname,c.email,c.cno,c.address,a.booking_date,a.booking_time,a.no_person,a.level_id,a.todatetime,d.lname as 'LevelName',e.tableno,b.status as 'checkoutstatus' from tbl_booking_master a,tbl_kot_master b,tbl_guest_master c,levelmaster d,tbl_table_master e where e.tid=a.tid and d.level_id=a.level_id and c.gid=a.gid and b.order_id=a.order_id and a.created_by=@user_id and a.cust_id=@cust_id and a.status = 1
END





GO
/****** Object:  StoredProcedure [dbo].[getCustomerDetail]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getCustomerDetail]
	-- Add the parameters for the stored procedure here
	@cust_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select a.*,b.PIN from tbl_customer a,tbl_userlogin b where b.cust_id=a.cust_id and a.cust_id=@cust_id
END





GO
/****** Object:  StoredProcedure [dbo].[GetGuestByName]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetGuestByName]
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@cname nvarchar(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	 IF ISNULL(@cname, '') <> ''
	
	SELECT * FROM tbl_guest_master WHERE cust_id=@cust_id and  fname  LIKE CONCAT('%', @cname , '%')
	
	else
	
		SELECT * FROM tbl_guest_master WHERE cust_id=@cust_id order by fname
	
END 





GO
/****** Object:  StoredProcedure [dbo].[GetHoldOrder]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetHoldOrder] 
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Select a.timestamp,a.cust_id,a.order_id,a.tid,b.kot_id,a.gid,a.booking_date,a.booking_time,a.no_person,a.level_id,a.todatetime,b.status as 'checkoutstatus',a.gid,a.tid,a.level_id,a.hold_status from tbl_booking_master a,tbl_kot_master b where  b.order_id=a.order_id and a.created_by=@user_id and a.cust_id=@cust_id and a.status = 1 and a.hold_status=1

END





GO
/****** Object:  StoredProcedure [dbo].[GetKotItem]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetKotItem] 
	-- Add the parameters for the stored procedure here
	@kot_detail_id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_kot_details where kot_detail_id = @kot_detail_id
END





GO
/****** Object:  StoredProcedure [dbo].[GetKotItems]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetKotItems]
	-- Add the parameters for the stored procedure here
	@kot_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.*,b.pname,b.imgurl,c.status as 'checkoutstatus' FROM tbl_kot_details a,tbl_product_master b,tbl_kot_master c WHERE c.kot_id=@kot_id and b.pid=a.pid and a.kot_id = @kot_id order by a.kot_detail_id
END





GO
/****** Object:  StoredProcedure [dbo].[GetOrderHistry]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetOrderHistry]
	-- Add the parameters for the stored procedure here
	@gid int
AS
BEGIN
	SELECT 
       [order_id]
      ,[gid]
      ,[order_date]
      ,[total_item]
      ,[sub_total]
      ,isnull([discount_amnt],0) as [discount_amnt]
      ,isnull([special_discount_amnt],0) as [special_discount_amnt]
      ,isnull([vat_amnt],0 ) as [vat_amnt]
      ,isnull([Tip_amnt],0) as [Tip_amnt]
      ,isnull([total_amnt],0) as [total_amnt]
      ,isnull([created_date],0) as [created_date],
      [created_by]
  FROM [PointOfSale].[dbo].[tbl_kot_master] where gid=@gid
	
	
END 





GO
/****** Object:  StoredProcedure [dbo].[GetPettyCash]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetPettyCash]
	-- Add the parameters for the stored procedure here
	@cust_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
      [fk_cust_id]
      ,[fk_user_id]
      ,[Supplier_id]
      ,[Staff_id]
      ,[receipt_No]
      ,[payMode]
      ,[paidAmt]
      ,[receipt_description]
      ,[signature_img]
  FROM [PointOfSale].[dbo].[tbl_petty_cash] where fk_cust_id=@cust_id
END





GO
/****** Object:  StoredProcedure [dbo].[GetProductDetail]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProductDetail]
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@cat_id int,
	@sub_catid int,
	@pid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_product_master where pid=@pid and cust_id = @cust_id and cat_id=@cat_id and subcat_id=@sub_catid
END





GO
/****** Object:  StoredProcedure [dbo].[GetProducts]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProducts]
	-- Add the parameters for the stored procedure here
	@cust_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM tbl_product_master WHERE cust_id=@cust_id ORDER BY pid
END





GO
/****** Object:  StoredProcedure [dbo].[GetSubCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSubCategory]
	-- Add the parameters for the stored procedure here
	@cat_id int,
	@cust_id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_subcategory_master where cat_id = @cat_id and cust_id=@cust_id
	--select * from tbl_subcat_master where cat_id = @cat_id and cust_id=@cust_id
END





GO
/****** Object:  StoredProcedure [dbo].[getsubcategorydetail]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getsubcategorydetail]
	-- Add the parameters for the stored procedure here
@cust_id int,
@cat_id int,
@subcat_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM tbl_subcat_master WHERE cust_id=@cust_id AND cat_id = @cat_id AND subcat_id=@subcat_id
END





GO
/****** Object:  StoredProcedure [dbo].[GetTable]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTable]
	-- Add the parameters for the stored procedure here
@cust_id int,
@tid int,
@level_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM tbl_table_master WHERE cust_id = @cust_id AND tid = @tid and level_id=@level_id
END





GO
/****** Object:  StoredProcedure [dbo].[GetTableDetail]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTableDetail]
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@level_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_table_master where cust_id = @cust_id and level_id=@level_id order by tableno
END





GO
/****** Object:  StoredProcedure [dbo].[GetTransationDetail]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[GetTransationDetail]
	-- Add the parameters for the stored procedure here
 @tid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from transactionMaster where t_id = @tid
END





GO
/****** Object:  StoredProcedure [dbo].[GetVatType]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetVatType] 
	-- Add the parameters for the stored procedure here
	@cust_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM tbl_vat WHERE cust_id = @cust_id ORDER BY vat_id
END





GO
/****** Object:  StoredProcedure [dbo].[KotCheckOut]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KotCheckOut] 
 -- Add the parameters for the stored procedure here
 @cust_id int,
 @kot_id int,
 @user_id int,
 @tip float,
 @vat float,
 @discount float,
 @total_amnt float,
 --return values 
 @errorCode int output,
 @errorMessage nvarchar(max) output
AS
BEGIN TRY
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 IF  EXISTS(SELECT 1 FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id and status = 0)
 BEGIN
  SET @errorCode = 4004
  SET @errorMessage = 'Already Checkout'
  RETURN 
 END 

 IF NOT EXISTS(SELECT 1 FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id)
 BEGIN
  SET @errorCode = 2001
  SET @errorMessage = 'Not Available'
  return
 END 
 DECLARE @orderid int
 DECLARE @tableid int 
 DECLARE @levelid int
 SET @orderid = (SELECT order_id FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id)
 SET @tableid = (SELECT tid from tbl_booking_master where @orderid = order_id)
 SET @levelid = (SELECT level_id from tbl_booking_master where @orderid = order_id)
 
 


 UPDATE TBL_KOT_MASTER SET 
  discount_amnt = @discount, 
  tip_amnt=@tip , 
  vat_amnt = @vat,
  total_amnt = @total_amnt
  --,status = 0
    WHERE 
  KOT_ID = @kot_id and 
  cust_id = @cust_id and 
  created_by = @user_id 

    UPDATE tbl_table_master SET
  status = 0
 WHERE 
  tid=@tableid and
  level_id=@levelid and
  cust_id=@cust_id
 

 UPDATE tbl_booking_master SET
  status=0,hold_status=0
  where order_id=1218

 SET @errorCode = 0 
 SET @errorMessage = 'Success'
END TRY
BEGIN CATCH
 SET @errorCode = 5001
 SET @errorMessage = 'Internal Server Error'
END CATCH


/****** Object:  StoredProcedure [dbo].[KotPayBill]    Script Date: 12/31/2016 5:12:44 PM ******/
SET ANSI_NULLS ON






GO
/****** Object:  StoredProcedure [dbo].[KotCheckOutNew]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KotCheckOutNew] 
 -- Add the parameters for the stored procedure here
( @cust_id int,
 @kot_id int,
 @user_id int,
 @tip float,
 @vat float,
 @discount float,
 @special_discount float,
 @total_amnt float,
 --return values 
 @errorCode int output,
 @errorMessage nvarchar(max) output)
AS
BEGIN TRY
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 IF  EXISTS(SELECT 1 FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id and status = 0)
 BEGIN
  SET @errorCode = 4004
  SET @errorMessage = 'Already Checkout'
  RETURN 
 END 

 IF NOT EXISTS(SELECT 1 FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id)
 BEGIN
  SET @errorCode = 2001
  SET @errorMessage = 'Not Available'
  return
 END 
 DECLARE @orderid int
 DECLARE @tableid int 
 DECLARE @levelid int
 SET @orderid = (SELECT order_id FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id)
 SET @tableid = (SELECT tid from tbl_booking_master where @orderid = order_id)
 SET @levelid = (SELECT level_id from tbl_booking_master where @orderid = order_id)
 
 


 UPDATE TBL_KOT_MASTER SET 
  discount_amnt = @discount, 
  special_discount_amnt  = @special_discount, 
  tip_amnt=@tip , 
  vat_amnt = @vat,
  total_amnt = @total_amnt
  --,status = 0
    WHERE 
  KOT_ID = @kot_id and 
  cust_id = @cust_id and 
  created_by = @user_id 

    UPDATE tbl_table_master SET
  status = 0
 WHERE 
  tid=@tableid and
  level_id=@levelid and
  cust_id=@cust_id
 

 UPDATE tbl_booking_master SET
  status=0,hold_status=0
  where order_id=1218

 SET @errorCode = 0 
 SET @errorMessage = 'Success'
END TRY
BEGIN CATCH
 SET @errorCode = 5001
 SET @errorMessage = 'Internal Server Error'
END CATCH


/****** Object:  StoredProcedure [dbo].[KotPayBill]    Script Date: 12/31/2016 5:12:44 PM ******/
SET ANSI_NULLS ON






GO
/****** Object:  StoredProcedure [dbo].[KotCheckOutOld]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KotCheckOutOld] 
 -- Add the parameters for the stored procedure here
 @cust_id int,
 @kot_id int,
 @user_id int,
 @tip float,
 @vat float,
 @discount float,
 @total_amnt float,
 --return values 
 @errorCode int output,
 @errorMessage nvarchar(max) output
AS
BEGIN TRY
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 IF  EXISTS(SELECT 1 FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id and status = 0)
 BEGIN
  SET @errorCode = 4004
  SET @errorMessage = 'Already Checkout'
  RETURN 
 END 

 IF NOT EXISTS(SELECT 1 FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id)
 BEGIN
  SET @errorCode = 2001
  SET @errorMessage = 'Not Available'
  return
 END 
 DECLARE @orderid int
 DECLARE @tableid int 
 DECLARE @levelid int
 SET @orderid = (SELECT order_id FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id)
 SET @tableid = (SELECT tid from tbl_booking_master where @orderid = order_id)
 SET @levelid = (SELECT level_id from tbl_booking_master where @orderid = order_id)
 
 


 UPDATE TBL_KOT_MASTER SET 
  discount_amnt = @discount, 
  tip_amnt=@tip , 
  vat_amnt = @vat,
  total_amnt = @total_amnt,
  status = 0
    WHERE 
  KOT_ID = @kot_id and 
  cust_id = @cust_id and 
  created_by = @user_id 

    UPDATE tbl_table_master SET
  status = 0
 WHERE 
  tid=@tableid and
  level_id=@levelid and
  cust_id=@cust_id
 

 UPDATE tbl_booking_master SET
  status=0,hold_status=0
  where order_id=1218

 SET @errorCode = 0 
 SET @errorMessage = 'Success'
END TRY
BEGIN CATCH
 SET @errorCode = 5001
 SET @errorMessage = 'Internal Server Error'
END CATCH


/****** Object:  StoredProcedure [dbo].[KotCheckOutTest]    Script Date: 12/31/2016 5:11:52 PM ******/
SET ANSI_NULLS ON





GO
/****** Object:  StoredProcedure [dbo].[KotPayBill]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[KotPayBill]( @order_id int,@cust_id int,	@transaction_Id nvarchar(50),@payMode nvarchar(50),	@paidAmt float, @remainingAmt float output,@errorCode int output,@errorMessage nvarchar(max) output)
AS
BEGIN TRY
 
 Declare @total_amt float Declare @rem_Amt float
 SET @total_amt = (select total_amnt from tbl_kot_master where order_id=@order_id)
 SET @rem_Amt = @total_amt - ((SELECT CASE WHEN (select sum(paidAmt) from [tbl_check_out] where fk_order_id = @order_id)IS NOT NULL THEN (select sum(paidAmt) from [tbl_check_out] where fk_order_id = @order_id) + @paidAmt  ELSE @paidAmt END ))


		   IF ((SELECT top 1  remainingAmt FROM [tbl_check_out] where [fk_order_id] =  @order_id ORDER BY check_id DESC)< @paidAmt)
				BEGIN
					SET @errorCode = 2001
					SET @remainingAmt = (SELECT top 1  remainingAmt FROM [tbl_check_out] where [fk_order_id] =  @order_id ORDER BY check_id DESC)
					SET @errorMessage = 'Pay More Money'
					return
				END 
			ELSE
			   BEGIN
			   INSERT INTO [dbo].[tbl_check_out] ([fk_order_id] ,[kot_id],  [guest_id], [transaction_Id]
					  ,[payMode]       ,[paidAmt]   ,[remainingAmt]   ,[totalAmt]  ,[paidStatus]
					,[status]  ,[created_date] ,[updated_date]   ,[is_deleted]  ,[created_by] ,[update_by])
			   VALUES
				   ( @order_id, (SELECT kot_id FROM tbl_kot_master where order_id=@order_id),  (SELECT gid FROM tbl_kot_master where order_id=@order_id),@transaction_Id,@payMode,@paidAmt
				, @rem_Amt  , @total_amt, CASE  WHEN @remainingAmt < 0 THEN 1 ELSE 0 END ,1, getDATE(),getDATE(),0,1,1)
         
				SET @remainingAmt = @total_amt-(select sum(paidAmt) from [dbo].[tbl_check_out] where fk_order_id= @order_id)
				if(@remainingAmt = 0) begin UPDATE tbl_kot_master SET status = 0  WHERE order_id=@order_id 
				 UPDATE tbl_booking_master SET  status=0,hold_status=0 where order_id=@order_id		End
		
			END 
			

	SET @errorCode = 0 
	SET @errorMessage = 'Success'

	

END TRY
BEGIN CATCH
	SET @errorCode = 5001
	SET @errorMessage = 'Internal Server Error'
END CATCH




GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Login]
	-- Add the parameters for the stored procedure here
	@uname as nvarchar(100),
	@pass as nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_userlogin where username = @uname and pass = @pass and status = 1
END





GO
/****** Object:  StoredProcedure [dbo].[OrderDelivery]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[OrderDelivery]
	-- Add the parameters for the stored procedure here
	@fname nvarchar(200),
	@lname nvarchar(200),
	@email nvarchar(50),
	@cno nvarchar(25),
	@address nvarchar(250)=NULL,
	@area nvarchar(250)=NULL,
	@zipcode nvarchar(250)=NULL,
	@map nvarchar(250)=NULL,
	@additional nvarchar(250)=NULL,
	@comments nvarchar(250)=NULL,
	@timestamp nvarchar(200),
	@cust_id int,
	@user_id int,
	--return values
	@kotid int output,
	@guest_id int output,
	@orderid int output,
	@status nvarchar(200) output
	
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	IF EXISTS(SELECT 1 FROM tbl_guest_master where cust_id = @cust_id and email = @email)
	BEGIN 

	Update  tbl_guest_master SET
	   fname = @fname,
	   lname = @lname,
	   cno = @cno,
	   city=@area,
	   zip=@zipcode,
	   address = @address,
	   update_by = @user_id,
	   updated_date = GETDATE()
	where 
		cust_id=@cust_id and 
		email = @email 	
	
	
		DECLARE @gid int
		SET @gid = (SELECT GID FROM TBL_GUEST_MASTER WHERE @cust_id = cust_id and @email=email)
		SET @guest_id = @gid
		INSERT INTO tbl_booking_master
		(
		cust_id,
		gid,
		use_id,
		status,
		booking_date,
		created_date,
		created_by,
		hold_status,
		booking_status,
		map,
		additional,
		comments,
		timestamp
		)

		VALUES
		(
		@cust_id,
		@gid,
		@user_id,
		
		'1',
		GETDATE(),
		GETDATE(),
		@user_id,
		'0',
		'0',
		@map,
		@additional,
		@comments,
		@timestamp
		)
				
	END
	ELSE
	BEGIN
	Insert into tbl_guest_master
	(
	   cust_id,
	   fname,
	   lname,
	   email,
	   cno,
	   address,
	   city,
	   zip,
	   status,
	   created_date,
	   created_by
	)
	values
	(
	@cust_id,
	@fname,
	@lname,
	@email,
	@cno,
	@address,
	@area,
	@zipcode,
	'1',
	GETDATE(),
	@user_id
		
	)


    IF @@ROWCOUNT > 0 
	BEGIN
		DECLARE @gid1 int
		SET @gid1 = @@IDENTITY
		SET @guest_id = @gid1
		INSERT INTO tbl_booking_master
		(
		cust_id,
		gid,
		use_id,
		booking_date,
		status,
		created_date,
		created_by,
		hold_status,
		booking_status,
		map,
		additional,
		comments,
		timestamp
		)

		VALUES
		(
		@cust_id,
		@gid1,
		@user_id,
		GETDATE(),
		'1',
		GETDATE(),
		@user_id,
		'0',
		'0',
		@map,
		@additional,
		@comments,
		@timestamp
		)
				
	
	END
	END

	DECLARE @order_id int
	SET @order_id = @@IDENTITY	

	INSERT INTO tbl_kot_master
	(
	 cust_id,
	 order_id,
	 gid,
	 order_date,
	 total_item,
	 sub_total,
	 total_amnt,
	 status,
	 created_date,
	 created_by
	)

	VALUES 
	(
	@cust_id,
	@order_id,
	@guest_id,
	GETDATE(),
	0,
	0,
	0,
	'1',
	GETDATE(),
	@user_id
	)

	DECLARE @kot_id int
	SET @kot_id = @@IDENTITY
	
	
	
	SET @kotid = @kot_id
	SET @guest_id = @gid
	SET @orderid = @order_id
	SET @status = '1'
END TRY
BEGIN CATCH
	SET @kotid = 0
	SET @guest_id = 0
	SET @orderid = 0
	SET @status = ERROR_MESSAGE()
END CATCH






GO
/****** Object:  StoredProcedure [dbo].[OrderHistory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[OrderHistory]
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@user_id int
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Select a.cust_id,a.order_id,a.tid,b.kot_id,a.gid,c.fname,c.lname,c.email,c.cno,c.address,a.booking_date,a.booking_time,a.no_person,a.level_id,a.todatetime,d.lname as 'LevelName',e.tableno,b.status as 'checkoutstatus' from tbl_booking_master a,tbl_kot_master b,tbl_guest_master c,levelmaster d,tbl_table_master e where e.tid=a.tid and d.level_id=a.level_id and c.gid=a.gid and b.order_id=a.order_id and a.created_by=@user_id and a.cust_id=@cust_id and a.status = 0
END 





GO
/****** Object:  StoredProcedure [dbo].[OrderHistoryNew]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[OrderHistoryNew] 
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select a.cust_id,a.order_id,a.tid,b.kot_id,a.gid,a.booking_date,a.booking_time,a.no_person,a.level_id,a.todatetime,b.status as 'checkoutstatus',a.gid,a.tid,a.level_id,isnull(a.hold_status,0) as 'hold_status',a.booking_date,a.booking_time,a.booking_status,a.timestamp from tbl_booking_master a,tbl_kot_master b where  b.order_id=a.order_id and a.created_by=@user_id and a.cust_id=@cust_id and a.status = 0
END





GO
/****** Object:  StoredProcedure [dbo].[PaymentDone]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PaymentDone]
	-- Add the parameters for the stored procedure here
@cust_id int,
@user_id int,
@kot_id int,
@paid_amnt float,
@due_amnt float,
@pay_mode nvarchar(max),
@remark nvarchar(max) = NULL,
@transaction_id nvarchar(max) = NULL,
@payment_status nvarchar(max) = NULL,
--return values 
@trasaction_id int output,
@gid int output,
@order_id int output,
@errorCode int output,
@errorMessage nvarchar(max) output


AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	
	-- interfering with SELECT statements.
	IF EXISTS(SELECT 1 FROM TransactionMaster where @kot_id=kot_id)
	BEGIN
		SET @trasaction_id = 0 
		SET @gid = 0
		SET @order_id = 0
		SET @errorCode = 4005
		SET @errorMessage = 'Bill Already Paid'
		RETURN
	END

	IF NOT EXISTS(SELECT 1 FROM tbl_kot_master where @kot_id = kot_id and @user_id = created_by and @cust_id = cust_id)
	BEGIN
		SET @trasaction_id = 0 
		SET @gid = 0
		SET @order_id = 0
		SET @errorCode = 4004
		SET @errorMessage = 'Record Not Found'
		RETURN 
	END 
    
	UPDATE tbl_kot_master SET
	paid_amnt = @paid_amnt,
	due_amnt = @due_amnt,
	par_mode = @pay_mode,
	remark = @remark
	WHERE 
	kot_id = @kot_id and
	created_by = @user_id and
	cust_id = @cust_id

	DECLARE @lastorder_id int
	DECLARE @guest_id int  
	SET @lastorder_id = (SELECT order_id FROM tbl_kot_master where @kot_id = kot_id and @user_id = created_by and @cust_id = cust_id)
	SET @order_id = @lastorder_id
	SET @guest_id = (SELECT gid FROM tbl_kot_master where @kot_id = kot_id and @user_id = created_by and @cust_id = cust_id)
	SET @gid = @guest_id
	
	UPDATE tbl_booking_master SET 
	status = 0
	WHERE 
	order_id = @order_id

	INSERT INTO TransactionMaster 
	(
		order_id,
		gid,
		kot_id,
		paid_amnt,
		due_amnt,
		pay_mode,
		remark,
		created_by,
		created_date,
		cust_id,
		transaction_id,
		payment_status
	)
	VALUES
	(
		@order_id,
		@gid,
		@kot_id,
		@paid_amnt,
		@due_amnt,
		@pay_mode,
		@remark,
		@user_id,
		GETDATE(),
		@cust_id,
		@transaction_id,
		@payment_status
	)

	IF @@ROWCOUNT > 0
	BEGIN
	
		DECLARE @tid int
		SET @tid = @@IDENTITY
		SET @trasaction_id = @tid
	END 

	SET @errorCode = 0 
	SET @errorMessage = 'Success'
		
END TRY
BEGIN CATCH
	SET @errorCode = 5004
	SET @errorMessage = 'Internal Server Error'
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[poslogin]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[poslogin]
	-- Add the parameters for the stored procedure here
	@pin as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_userlogin where pin = @pin and status = 1
END





GO
/****** Object:  StoredProcedure [dbo].[SearchAllGuest]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchAllGuest]
	-- Add the parameters for the stored procedure here
	@Searchword nvarchar(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- SELECT * FROM tbl_guest_master WHERE fname  LIKE CONCAT('%', @Searchword , '%')

	SELECT gid,fname,lname,email,cno,address,city,zip FROM tbl_guest_master WHERE fname  LIKE CONCAT('%', @Searchword , '%') or lname  
	LIKE CONCAT('%', @Searchword , '%') or email  LIKE CONCAT('%', @Searchword , '%') or cno  LIKE CONCAT('%', @Searchword , '%') 
	
	
END 





GO
/****** Object:  StoredProcedure [dbo].[ServeProduct]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ServeProduct] 
	-- Add the parameters for the stored procedure here
	@kot_id int,
	@kot_detail_id int,
	@qnty int,
	--return values
	@errorCode int output,
	@errorMessage nvarchar(max) output
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF NOT EXISTS (SELECT 1 FROM tbl_kot_details where  @kot_id=kot_id and kot_detail_id=@kot_detail_id)
	BEGIN
		SET @errorCode = 5005
		SET @errorMessage = 'Record Not Found'
		RETURN
	END

	IF EXISTS(SELECT 1 FROM tbl_kot_details where status = 1 and kot_detail_id=@kot_detail_id and kot_id=@kot_id)
	BEGIN
	UPDATE tbl_kot_details SET
		status = 0,
		is_deleted = is_deleted + @qnty
	WHERE
		kot_detail_id = @kot_detail_id and 
		kot_id = @kot_id
	END
	ELSE
	BEGIN
	UPDATE tbl_kot_details SET
		status = 0 ,
		is_deleted = is_deleted + @qnty
	WHERE
		kot_detail_id = @kot_detail_id and 
		kot_id = @kot_id
	END

	

		
	SET @errorCode = 0
	SET @errorMessage = 'Success'
END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = 'Internal Server Error'
END CATCH






GO
/****** Object:  StoredProcedure [dbo].[SetHold]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================= 
-- Author:     
-- Create date:  
-- Description:   
-- ============================================= 
CREATE PROCEDURE [dbo].[SetHold] 
-- Add the parameters for the stored procedure here 
(@cust_id          INT, 
 @user_id          INT, 
 @booking_id       INT, 
 @kot_id           INT, 
 @tip              FLOAT, 
 @vat              FLOAT, 
 @discount         FLOAT, 
 @special_discount FLOAT, 
 @total_amnt       FLOAT, 

 --return values  
 @errorCode        INT output, 
 @errorMessage     NVARCHAR(max) output) 
AS 
  BEGIN try 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 
      SET nocount ON; 

      IF NOT EXISTS(SELECT 1 
                    FROM   tbl_kot_master 
                    WHERE  @kot_id = kot_id 
                           AND @user_id = created_by 
                           AND @cust_id = cust_id) 
        BEGIN 
            SET @errorCode = 2001 
            SET @errorMessage = 'Not Available' 

            RETURN 
        END 

      UPDATE tbl_booking_master 
      SET    hold_status = 1 
      WHERE  cust_id = @cust_id 
             AND use_id = @user_id 
             AND order_id = @booking_id 

      UPDATE tbl_kot_master 
      SET    discount_amnt = @discount, 
             special_discount_amnt = @special_discount, 
             tip_amnt = @tip, 
             vat_amnt = @vat, 
             total_amnt = @total_amnt 
      --,status = 0 
      WHERE  kot_id = @kot_id 
             AND cust_id = @cust_id 
             AND created_by = @user_id 

      SET @errorCode = 2000 
      SET @errorMessage = 'Success' 
  END try 

  BEGIN catch 
      SET @errorCode = 5001 
      SET @errorMessage = 'Internal Server Error' 
  END catch 


GO
/****** Object:  StoredProcedure [dbo].[SetPettyCash]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SetPettyCash]( @cust_id int, @fk_user_id int,@Supplier_id int,@Staff_id int, @receipt_No nvarchar(50),@payMode nvarchar(50),
	@paidAmt float, @receipt_description nvarchar(500) , @signature_img nvarchar(250) , @errorCode int output,@errorMessage nvarchar(max) output)
AS
BEGIN TRY
 
 BEGIN
 INSERT INTO [dbo].[tbl_petty_cash]
           ([fk_cust_id]
           ,[fk_user_id]
           ,[Supplier_id]
           ,[Staff_id]
           ,[receipt_No]
           ,[payMode]
           ,[paidAmt]
           ,[receipt_description]
           ,[signature_img]
           ,[status]
           ,[is_deleted]
           ,[created_date]
           ,[created_by]
          )
		        VALUES
           (@cust_id
           ,@fk_user_id
           ,@Supplier_id
           ,@Staff_id
           ,@receipt_No
           ,@payMode 
		   ,@paidAmt
           ,@receipt_description
           ,@signature_img
		   ,1
           ,0
           ,GETDATE()
           ,1)

		
 END 
			

	SET @errorCode = 0 
	SET @errorMessage = 'Success'

	

END TRY
BEGIN CATCH
	SET @errorCode = 5001
	SET @errorMessage = 'Internal Server Error'
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[SP_AdminLogin]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_AdminLogin]
(
@UserName nvarchar(50),
@Password nvarchar(50),
@Event nvarchar(20)
)
as
IF @Event = 'GETALL'
Begin
Select * from tbl_AdminLogin where UserName=@UserName COLLATE SQL_Latin1_General_Cp1_CS_AS and Password=@Password COLLATE SQL_Latin1_General_Cp1_CS_AS
end

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllowSales]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllowSales] 
	-- Add the parameters for the stored procedure here
	(
	@Id int=0,
	@ExamId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GetwithId'
	BEGIN
		SELECT  * From [QuizprojectUser123].[tbl_MerchantAllowSales]
		WHERE ExamId=@ExamId And IsDelete=0 ORDER BY Id DESC
	END

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetBundle]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetBundle] 
	-- Add the parameters for the stored procedure here
	(
	@MerchantId int=0,
	@BundleId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	IF @Event = 'GETALL'
	BEGIN
	SELECT   * FROM   QuizprojectUser123.tbl_BundleExam where MerchantId=@MerchantId And IsDelete=0
	END

	IF @Event = 'GetBundleWithId'
	BEGIN
	SELECT   * FROM   QuizprojectUser123.tbl_BundleExam where BundleId=@BundleId And IsDelete=0
	END

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCountry]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_GetCountry] 
	-- Add the parameters for the stored procedure here
	(
	@ContryId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT     CountryId, Country
		FROM         tbl_MasterCountry 
		WHERE       IsDelete=0
	END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetExamManage]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetExamManage] 
	-- Add the parameters for the stored procedure here
	(	
	@ExamCodeId int=0,
	@MerchantId int=0,
	@UserId int=0,
	@Searchtext nvarchar(100)=null,
	@Event nvarchar(50)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON; 
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT        dbo.tbl_ExamConfig.ExamCodeId, dbo.tbl_ExamConfig.ExamCode, dbo.tbl_ExamConfig.ExamTitle, dbo.tbl_ExamConfig.SecondCategoryId, 
								 dbo.tbl_ExamConfig.PassingPercentage, dbo.tbl_ExamConfig.TestTime, dbo.tbl_ExamConfig.TestOption, dbo.tbl_ExamConfig.ValidDate, dbo.tbl_ExamConfig.MerchantId, dbo.tbl_ExamConfig.IsActive, 
								 dbo.tbl_TopCategory.TopCategoryName, dbo.tbl_SecondCategory.SecondCategoryName, dbo.tbl_MerchantInfo.MerchantName, dbo.tbl_MerchantLevel.MerchantLevel
		FROM            dbo.tbl_ExamConfig INNER JOIN
								 dbo.tbl_SecondCategory ON dbo.tbl_ExamConfig.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId INNER JOIN
								 dbo.tbl_TopCategory ON dbo.tbl_SecondCategory.TopCategoryId = dbo.tbl_TopCategory.TopCategoryId INNER JOIN
								 dbo.tbl_MerchantInfo ON dbo.tbl_ExamConfig.MerchantId = dbo.tbl_MerchantInfo.MerchantId INNER JOIN
								 dbo.tbl_MerchantLevel ON dbo.tbl_MerchantInfo.MerchantLevelId = dbo.tbl_MerchantLevel.MerchantLevelId
		WHERE dbo.tbl_ExamConfig.IsDelete=0 ORDER BY dbo.tbl_ExamConfig.ExamCodeId DESC
	END

	IF @Event = 'GetExamWithId'
	BEGIN
			SELECT       dbo.tbl_ExamConfig.*,dbo.tbl_SecondCategory.SecondCategoryName,dbo.tbl_TopCategory.TopCategoryId,dbo.tbl_TopCategory.TopCategoryName
			FROM            dbo.tbl_ExamConfig INNER JOIN
								 dbo.tbl_SecondCategory ON dbo.tbl_ExamConfig.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId INNER JOIN
								 dbo.tbl_TopCategory ON dbo.tbl_SecondCategory.TopCategoryId = dbo.tbl_TopCategory.TopCategoryId
								  WHERE dbo.tbl_ExamConfig.ExamCodeId=@ExamCodeId AND dbo.tbl_ExamConfig.IsDelete=0
	END

	IF @Event = 'GetExamWithMId'
	BEGIN
				Declare @SQLQuery AS NVarchar(4000)
			  Declare @ParamDefinition AS NVarchar(2000) 
			  Set @SQLQuery ='SELECT        dbo.tbl_ExamConfig.ExamCodeId, dbo.tbl_ExamConfig.ExamCode, 
									  dbo.tbl_ExamConfig.ExamTitle, dbo.tbl_ExamConfig.PassingPercentage, 
									  dbo.tbl_ExamConfig.TestTime, dbo.tbl_ExamConfig.ValidDate, 
									  dbo.tbl_ExamConfig.TestOption,dbo.tbl_ExamConfig.Price,dbo.tbl_ExamConfig.ExamSimulator,
									  dbo.tbl_ExamConfig.ExamSimulatorDemo,dbo.tbl_ExamConfig.OnlyTestOnce,dbo.tbl_ExamConfig.AllowPrint,
									  dbo.tbl_ExamConfig.AllowSales,dbo.tbl_SecondCategory.SecondCategoryId,
									  dbo.tbl_SecondCategory.SecondCategoryName, dbo.tbl_TopCategory.TopCategoryName
						FROM            dbo.tbl_ExamConfig INNER JOIN
												 dbo.tbl_SecondCategory ON dbo.tbl_ExamConfig.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId INNER JOIN
												 dbo.tbl_TopCategory ON dbo.tbl_SecondCategory.TopCategoryId = dbo.tbl_TopCategory.TopCategoryId
						WHERE       (dbo.tbl_ExamConfig.MerchantId='+ Convert(Varchar(100),@MerchantId)+') AND(dbo.tbl_ExamConfig.IsDelete = 0) AND (dbo.tbl_ExamConfig.IsActive = 1)
						'

				 If @SearchText Is Not Null 
				 Set @SQLQuery = @SQLQuery + ' And (dbo.tbl_ExamConfig.ExamCode like ''%''+@SearchText+''%'' 
				 OR dbo.tbl_ExamConfig.ExamTitle LIKE ''%''+@Searchtext+''%'' OR 
				 dbo.tbl_SecondCategory.SecondCategoryName LIKE ''%''+@Searchtext+''%'' OR 
				 dbo.tbl_ExamConfig.TestTime LIKE ''%''+@Searchtext+''%'')'
				  Set @ParamDefinition =      ' @SearchText NVarchar(100)'
				   Set @SQLQuery = @SQLQuery + ' ORDER BY dbo.tbl_ExamConfig.ExamCodeId DESC'
				   
				  Execute sp_Executesql     @SQLQuery, @ParamDefinition, @SearchText 
	END

	--IF @Event = 'GetExamWithMIdandCatId'
	--BEGIN
	--       if @CatId !=0
	--	     Begin
	--			SELECT        dbo.tbl_ExamConfig.ExamCodeId, dbo.tbl_ExamConfig.ExamCode, 
	--						  dbo.tbl_ExamConfig.ExamTitle, dbo.tbl_ExamConfig.PassingPercentage, 
	--						  dbo.tbl_ExamConfig.TestTime, dbo.tbl_ExamConfig.ValidDate, 
	--						  dbo.tbl_ExamConfig.TestOption,dbo.tbl_ExamConfig.Price,dbo.tbl_ExamConfig.ExamSimulator,
	--						  dbo.tbl_ExamConfig.ExamSimulatorDemo,dbo.tbl_ExamConfig.OnlyTestOnce,dbo.tbl_ExamConfig.AllowPrint,
	--						  dbo.tbl_ExamConfig.AllowSales,
	--						  dbo.tbl_SecondCategory.SecondCategoryName, dbo.tbl_TopCategory.TopCategoryName
	--			FROM            dbo.tbl_ExamConfig INNER JOIN
	--									 dbo.tbl_SecondCategory ON dbo.tbl_ExamConfig.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId INNER JOIN
	--									 dbo.tbl_TopCategory ON dbo.tbl_SecondCategory.TopCategoryId = dbo.tbl_TopCategory.TopCategoryId
	--			WHERE       (dbo.tbl_ExamConfig.MerchantId=@MerchantId) AND (dbo.tbl_ExamConfig.SecondCategoryId=@CatId) AND (dbo.tbl_ExamConfig.IsDelete = 0) AND (dbo.tbl_ExamConfig.IsActive = 1)
	--			ORDER BY dbo.tbl_ExamConfig.ExamCodeId DESC
 --            end
	--	   else
	--	     begin
 --                  SELECT        dbo.tbl_ExamConfig.ExamCodeId, dbo.tbl_ExamConfig.ExamCode, 
	--						  dbo.tbl_ExamConfig.ExamTitle, dbo.tbl_ExamConfig.PassingPercentage, 
	--						  dbo.tbl_ExamConfig.TestTime, dbo.tbl_ExamConfig.ValidDate, 
	--						  dbo.tbl_ExamConfig.TestOption,dbo.tbl_ExamConfig.Price,dbo.tbl_ExamConfig.ExamSimulator,
	--						  dbo.tbl_ExamConfig.ExamSimulatorDemo,dbo.tbl_ExamConfig.OnlyTestOnce,dbo.tbl_ExamConfig.AllowPrint,
	--						  dbo.tbl_ExamConfig.AllowSales,
	--						  dbo.tbl_SecondCategory.SecondCategoryName, dbo.tbl_TopCategory.TopCategoryName
	--			FROM            dbo.tbl_ExamConfig INNER JOIN
	--									 dbo.tbl_SecondCategory ON dbo.tbl_ExamConfig.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId INNER JOIN
	--									 dbo.tbl_TopCategory ON dbo.tbl_SecondCategory.TopCategoryId = dbo.tbl_TopCategory.TopCategoryId
	--			WHERE       (dbo.tbl_ExamConfig.MerchantId=@MerchantId) AND (dbo.tbl_ExamConfig.IsDelete = 0) AND (dbo.tbl_ExamConfig.IsActive = 1)
	--			ORDER BY dbo.tbl_ExamConfig.ExamCodeId DESC
	--		 end
			  
	--END

	IF @Event = 'GetExWithUid'
	BEGIN
		--SELECT        dbo.tbl_MerchantMyUser.UserId,dbo.tbl_ExamConfig.ExamCodeId, dbo.tbl_ExamConfig.ExamCode, dbo.tbl_ExamConfig.ExamTitle,
		--              dbo.tbl_SecondCategory.SecondCategoryId,dbo.tbl_SecondCategory.SecondCategoryName, dbo.tbl_ExamConfig.TestTime, 
		--			  dbo.tbl_ExamConfig.ValidDate, 
  --                    dbo.tbl_ExamConfig.OnlyTestOnce,(select count(QuizprojectUser123.tbl_QAManage.QAId) From QuizprojectUser123.tbl_QAManage Where QuizprojectUser123.tbl_QAManage.ExamCodeId=dbo.tbl_ExamConfig.ExamCodeId) AS QuestionCount
  --      FROM          dbo.tbl_SecondCategory INNER JOIN
  --                    dbo.tbl_MerchantMyUser  CROSS APPLY dbo.Split(',', dbo.tbl_MerchantMyUser.ExamId) split ON dbo.tbl_SecondCategory.SecondCategoryId = dbo.tbl_MerchantMyUser.SecondCategory INNER JOIN
  --                    dbo.tbl_ExamConfig ON split.s = dbo.tbl_ExamConfig.ExamCodeId	Where dbo.tbl_MerchantMyUser.UserId=@UserId
		--			   ORDER BY dbo.tbl_ExamConfig.ExamCodeId DESC

		    Declare @grupsratus as bit
			Declare @exmid as Nvarchar(4000)
			select @grupsratus=dbo.tbl_MerchantMyUser.GroupStatus from dbo.tbl_MerchantMyUser Where dbo.tbl_MerchantMyUser.UserId=@UserId
			if(@grupsratus=1)
			  SELECT @exmid=QuizprojectUser123.tbl_UserGroup.ExamId FROM  dbo.tbl_MerchantMyUser INNER JOIN
                         QuizprojectUser123.tbl_UserGroup ON dbo.tbl_MerchantMyUser.GroupId = QuizprojectUser123.tbl_UserGroup.GroupId
                      WHERE   (dbo.tbl_MerchantMyUser.UserId = @UserId)
		    else
			  select @exmid=ExamId from dbo.tbl_MerchantMyUser Where UserId=@UserId

			Declare @SQLQueryu AS NVarchar(4000)
			Declare @ParamDefinitionu AS NVarchar(2000) 

				Set @SQLQueryu =' SELECT   dbo.tbl_MerchantMyUser.UserId, dbo.tbl_ExamConfig.ExamCodeId, dbo.tbl_ExamConfig.ExamCode,
				  dbo.tbl_ExamConfig.ExamTitle,dbo.tbl_ExamConfig.SecondCategoryId,dbo.tbl_SecondCategory.SecondCategoryName,
				  dbo.tbl_ExamConfig.TestTime, dbo.tbl_ExamConfig.ValidDate,dbo.tbl_ExamConfig.OnlyTestOnce,
				  (select count(QuizprojectUser123.tbl_QAManage.QAId) From QuizprojectUser123.tbl_QAManage 
				  Where QuizprojectUser123.tbl_QAManage.ExamCodeId=dbo.tbl_ExamConfig.ExamCodeId) AS QuestionCount
				  FROM   dbo.tbl_SecondCategory INNER JOIN dbo.tbl_ExamConfig ON dbo.tbl_SecondCategory.SecondCategoryId = dbo.tbl_ExamConfig.SecondCategoryId CROSS JOIN
					 dbo.tbl_MerchantMyUser Where dbo.tbl_MerchantMyUser.UserId='+ Convert(Varchar(100),@UserId)+' AND dbo.tbl_ExamConfig.ExamCodeId IN(
				SELECT CAST(s AS INTEGER) FROM [Split] ('','' ,'''+@exmid+'''))'

				 If @SearchText Is Not Null 
				 Set @SQLQueryu = @SQLQueryu + ' And (dbo.tbl_ExamConfig.ExamCode like ''%''+@Searchtext+''%'')'
				  Set @ParamDefinitionu =      ' @SearchText NVarchar(100)'

				Set @SQLQueryu = @SQLQueryu + ' ORDER BY dbo.tbl_ExamConfig.ExamCodeId DESC'
				print @SQLQueryu
				 Execute sp_Executesql     @SQLQueryu, @ParamDefinitionu, @SearchText 
	END

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetExamQuestionAnswer]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetExamQuestionAnswer] 
	-- Add the parameters for the stored procedure here
	(	
	@ExamCodeId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GetEQAWithQId'
	BEGIN
		SELECT       dbo.tbl_ExamConfig.ExamCodeId, dbo.tbl_ExamConfig.ExamCode, dbo.tbl_ExamConfig.ExamTitle, dbo.tbl_ExamConfig.SecondCategoryId, 
                         dbo.tbl_ExamConfig.PassingPercentage, dbo.tbl_ExamConfig.TestTime, QuizprojectUser123.tbl_QAManage.QAId, QuizprojectUser123.tbl_QAManage.QuestionTypeId, QuizprojectUser123.tbl_QAManage.Score, 
                         QuizprojectUser123.tbl_QAManage.Question, QuizprojectUser123.tbl_QAManage.NoofAnswer, QuizprojectUser123.tbl_QAManage.Explanation,QuizprojectUser123.tbl_QAManage.Resource,
						 QuizprojectUser123.tbl_QAManage.Exhibit,QuizprojectUser123.tbl_QAManage.Topology,QuizprojectUser123.tbl_QAManage.Scenario, QuizprojectUser123.tbl_QAnswer.AnswerId, 
                         QuizprojectUser123.tbl_QAnswer.Answer, QuizprojectUser123.tbl_QAnswer.RightAnswer,dbo.tbl_QuestionType.QuestionType,
						 dbo.tbl_SecondCategory.SecondCategoryName
        FROM             dbo.tbl_ExamConfig INNER JOIN
                         QuizprojectUser123.tbl_QAManage ON dbo.tbl_ExamConfig.ExamCodeId = QuizprojectUser123.tbl_QAManage.ExamCodeId INNER JOIN
                         QuizprojectUser123.tbl_QAnswer ON QuizprojectUser123.tbl_QAManage.QAId = QuizprojectUser123.tbl_QAnswer.QuestionId
						 INNER JOIN dbo.tbl_QuestionType ON dbo.tbl_QuestionType.QuestionTypeId=QuizprojectUser123.tbl_QAManage.QuestionTypeId
						  INNER JOIN dbo.tbl_SecondCategory ON dbo.tbl_ExamConfig.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId
		WHERE            dbo.tbl_ExamConfig.ExamCodeId=@ExamCodeId  AND dbo.tbl_ExamConfig.IsDelete=0 And dbo.tbl_ExamConfig.IsActive=1 AND QuizprojectUser123.tbl_QAManage.IsDelete=0 And QuizprojectUser123.tbl_QAManage.IsActive=1  

		               -- And  QuizprojectUser123.tbl_QAManage.QuestionTypeId=5 OR QuizprojectUser123.tbl_QAManage.QuestionTypeId=3

		                 AND QuizprojectUser123.tbl_QAnswer.IsDelete=0 And QuizprojectUser123.tbl_QAnswer.IsActive=1 ORDER BY dbo.tbl_ExamConfig.ExamCodeId,QuizprojectUser123.tbl_QAManage.QAId,QuizprojectUser123.tbl_QAnswer.AnswerId
	END

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetExamQuestionAnswerForOffLineSimultor]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetExamQuestionAnswerForOffLineSimultor] 
	-- Add the parameters for the stored procedure here
	(	
	@ExamCodeId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GetEQAWithQId'
	BEGIN
		SELECT       dbo.tbl_ExamConfig.ExamCodeId, dbo.tbl_ExamConfig.ExamCode, dbo.tbl_ExamConfig.ExamTitle, dbo.tbl_ExamConfig.SecondCategoryId, 
                         dbo.tbl_ExamConfig.PassingPercentage, dbo.tbl_ExamConfig.TestTime, QuizprojectUser123.tbl_QAManage.QAId, QuizprojectUser123.tbl_QAManage.QuestionTypeId, QuizprojectUser123.tbl_QAManage.Score, 
                         [dbo].[HtmlToPlainText](QuizprojectUser123.tbl_QAManage.Question) AS Question, QuizprojectUser123.tbl_QAManage.NoofAnswer, QuizprojectUser123.tbl_QAManage.Explanation,QuizprojectUser123.tbl_QAManage.Resource,
						 QuizprojectUser123.tbl_QAManage.Exhibit,QuizprojectUser123.tbl_QAManage.Topology,QuizprojectUser123.tbl_QAManage.Scenario, QuizprojectUser123.tbl_QAnswer.AnswerId, 
                         [dbo].[HtmlToPlainText]([dbo].[GetCanvasValueORReturnASIT] (',' ,QuizprojectUser123.tbl_QAnswer.Answer,tbl_QAManage.QuestionTypeId)) AS Answer, QuizprojectUser123.tbl_QAnswer.RightAnswer,dbo.tbl_QuestionType.QuestionType,
						 dbo.tbl_SecondCategory.SecondCategoryName

        FROM             dbo.tbl_ExamConfig INNER JOIN
                         QuizprojectUser123.tbl_QAManage ON dbo.tbl_ExamConfig.ExamCodeId = QuizprojectUser123.tbl_QAManage.ExamCodeId INNER JOIN
                         QuizprojectUser123.tbl_QAnswer ON QuizprojectUser123.tbl_QAManage.QAId = QuizprojectUser123.tbl_QAnswer.QuestionId
						 INNER JOIN dbo.tbl_QuestionType ON dbo.tbl_QuestionType.QuestionTypeId=QuizprojectUser123.tbl_QAManage.QuestionTypeId
						 INNER JOIN dbo.tbl_SecondCategory ON dbo.tbl_ExamConfig.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId
		WHERE            dbo.tbl_ExamConfig.ExamCodeId=@ExamCodeId  AND dbo.tbl_ExamConfig.IsDelete=0 And dbo.tbl_ExamConfig.IsActive=1 AND QuizprojectUser123.tbl_QAManage.IsDelete=0 And QuizprojectUser123.tbl_QAManage.IsActive=1  

		               -- And  QuizprojectUser123.tbl_QAManage.QuestionTypeId=5 OR QuizprojectUser123.tbl_QAManage.QuestionTypeId=3

		                 AND QuizprojectUser123.tbl_QAnswer.IsDelete=0 And QuizprojectUser123.tbl_QAnswer.IsActive=1 ORDER BY dbo.tbl_ExamConfig.ExamCodeId,QuizprojectUser123.tbl_QAManage.QAId,QuizprojectUser123.tbl_QAnswer.AnswerId
	END

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetExtraPermission]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetExtraPermission] 
	-- Add the parameters for the stored procedure here
	(
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT     ExtraPermissionOptId, ExtraPermissionOpt,DefaultPermission
		FROM          QuizprojectUser123.tbl_MerchantExtraPermission 
		WHERE IsDelete=0
	END

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetGroup]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetGroup] 
	-- Add the parameters for the stored procedure here
	(	
	@GroupId int=0,
	@MerchantId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT * from QuizprojectUser123.tbl_UserGroup WHERE (QuizprojectUser123.tbl_UserGroup.IsDelete = 0) AND (QuizprojectUser123.tbl_UserGroup.IsActive = 1)  ORDER BY  QuizprojectUser123.tbl_UserGroup.GroupId DESC
	END

	IF @Event = 'GetGroupWithMId'
	BEGIN
		SELECT        *
    FROM          QuizprojectUser123.tbl_UserGroup
		WHERE       ( QuizprojectUser123.tbl_UserGroup.MerchantId=@MerchantId) AND( QuizprojectUser123.tbl_UserGroup.IsDelete = 0) AND ( QuizprojectUser123.tbl_UserGroup.IsActive = 1) 
		ORDER BY   QuizprojectUser123.tbl_UserGroup.GroupId DESC
	END

	IF @Event = 'GetGroupWithGId'
	BEGIN
		SELECT * FROM   QuizprojectUser123.tbl_UserGroup 
		WHERE       (QuizprojectUser123.tbl_UserGroup.GroupId=@GroupId) AND(QuizprojectUser123.tbl_UserGroup.IsDelete = 0) AND (QuizprojectUser123.tbl_UserGroup.IsActive = 1) 
		ORDER BY  QuizprojectUser123.tbl_UserGroup.GroupId DESC
	END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetMerchantBalance]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetMerchantBalance] 
	-- Add the parameters for the stored procedure here
	(	
	@Id int=0,
	@MerchantId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GetBalanceWithMId'
	BEGIN
		SELECT        Balance
          FROM            QuizprojectUser123.tbl_MerchantBalance Where MerchantId=@MerchantId
	END


END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetMerchantFeeRate]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetMerchantFeeRate] 
	-- Add the parameters for the stored procedure here
	(
	@MerchantFeeRateId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT        dbo.tbl_MerchantFeeRate.MerchantFeeRateId, dbo.tbl_MerchantFeeRate.MerchantFeeRate, dbo.tbl_MerchantFeeRate.MerchantLevelId, dbo.tbl_MerchantFeeRate.IsActive, dbo.tbl_MerchantFeeRate.IsDelete, 
                         dbo.tbl_MerchantFeeRate.CreatedBy, dbo.tbl_MerchantFeeRate.CreatedDate, dbo.tbl_MerchantFeeRate.Updateby, dbo.tbl_MerchantFeeRate.UpdateDate, dbo.tbl_MerchantLevel.MerchantLevel
FROM            dbo.tbl_MerchantFeeRate INNER JOIN
                         dbo.tbl_MerchantLevel ON dbo.tbl_MerchantFeeRate.MerchantLevelId = dbo.tbl_MerchantLevel.MerchantLevelId
       WHERE dbo.tbl_MerchantFeeRate.IsDelete=0 ORDER BY dbo.tbl_MerchantFeeRate.MerchantFeeRateId DESC
	END

	IF @Event = 'GetWithFeeRateId'
	BEGIN
		SELECT        dbo.tbl_MerchantFeeRate.MerchantFeeRateId, dbo.tbl_MerchantFeeRate.MerchantFeeRate, dbo.tbl_MerchantFeeRate.MerchantLevelId, dbo.tbl_MerchantFeeRate.IsActive, dbo.tbl_MerchantFeeRate.IsDelete, 
                         dbo.tbl_MerchantFeeRate.CreatedBy, dbo.tbl_MerchantFeeRate.CreatedDate, dbo.tbl_MerchantFeeRate.Updateby, dbo.tbl_MerchantFeeRate.UpdateDate, dbo.tbl_MerchantLevel.MerchantLevel
FROM            dbo.tbl_MerchantFeeRate INNER JOIN
                         dbo.tbl_MerchantLevel ON dbo.tbl_MerchantFeeRate.MerchantLevelId = dbo.tbl_MerchantLevel.MerchantLevelId
       WHERE dbo.tbl_MerchantFeeRate.MerchantFeeRateId=@MerchantFeeRateId AND dbo.tbl_MerchantFeeRate.IsDelete=0
	END

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetMerchantLevel]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetMerchantLevel] 
	-- Add the parameters for the stored procedure here
	(
	@MerchantLevelId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT     MerchantLevelId, MerchantLevel,AnnualFee,ExamCount,StudentCount,ShopperFee,QuestionType,ExtraPermission
		FROM         tbl_MerchantLevel 
		WHERE       IsDelete=0 ORDER BY MerchantLevelId DESC
	END

	IF @Event = 'GetMLevelwithId'
	BEGIN
		SELECT     MerchantLevelId, MerchantLevel,AnnualFee,ExamCount,StudentCount,ShopperFee,QuestionType,ExtraPermission
		FROM         tbl_MerchantLevel 
		WHERE    MerchantLevelId=@MerchantLevelId AND  IsDelete=0
	END

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetMerchantManage]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetMerchantManage] 
	-- Add the parameters for the stored procedure here
	(
	@MerchantId int=0,
	@UserName nvarchar(50)=null,
	@emailid nvarchar(100)=null,
	@Password nvarchar(50)=null,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT        dbo.tbl_MerchantInfo.MerchantId, dbo.tbl_MerchantInfo.MerchantName, dbo.tbl_MasterCountry.CountryId, dbo.tbl_MerchantInfo.StateId, dbo.tbl_MerchantInfo.Telephone, dbo.tbl_MerchantInfo.MerchantLevelId, 
                         dbo.tbl_MerchantInfo.StartDate, dbo.tbl_MerchantInfo.EndDate,dbo.tbl_MerchantInfo.ActiveStatus, dbo.tbl_MerchantInfo.IsActive, dbo.tbl_MerchantInfo.IsDelete, dbo.tbl_MerchantInfo.CreatedBy, dbo.tbl_MerchantInfo.CreatedDate, 
                         dbo.tbl_MerchantInfo.UpdatedBy, dbo.tbl_MerchantInfo.UpdatedDate, dbo.tbl_MasterCountry.Country, dbo.tbl_MasterState.State, dbo.tbl_MerchantLevel.MerchantLevel,dbo.tbl_MerchantInfo.EmailId
FROM            dbo.tbl_MerchantInfo Left OUTER JOIN
                         dbo.tbl_MasterState ON dbo.tbl_MerchantInfo.StateId = dbo.tbl_MasterState.StateId Left OUTER JOIN
                         dbo.tbl_MasterCountry ON dbo.tbl_MasterState.CountryId = dbo.tbl_MasterCountry.CountryId Left OUTER JOIN
                         dbo.tbl_MerchantLevel ON dbo.tbl_MerchantInfo.MerchantLevelId = dbo.tbl_MerchantLevel.MerchantLevelId
		WHERE dbo.tbl_MerchantInfo.IsDelete=0 ORDER BY dbo.tbl_MerchantInfo.MerchantId DESC
	END

	IF @Event = 'MerchantLogin'
		Begin
		SELECT tbl_MerchantInfo.*, tbl_MerchantLevel.MerchantLevel, tbl_MerchantLevel.AnnualFee, dbo.tbl_MasterState.CountryId
        FROM tbl_MerchantInfo LEFT OUTER JOIN tbl_MerchantLevel ON tbl_MerchantInfo.MerchantLevelId = tbl_MerchantLevel.MerchantLevelId LEFT OUTER JOIN
                         dbo.tbl_MasterState ON dbo.tbl_MerchantInfo.StateId = dbo.tbl_MasterState.StateId
		 where tbl_MerchantInfo.EmailId=@emailid COLLATE SQL_Latin1_General_Cp1_CS_AS and tbl_MerchantInfo.Password=@Password COLLATE SQL_Latin1_General_Cp1_CS_AS AND (dbo.tbl_MerchantInfo.IsDelete = 0)
	end

	IF @Event = 'GETWITHID'
	BEGIN
		SELECT        dbo.tbl_MerchantInfo.MerchantId, dbo.tbl_MerchantInfo.MerchantName, dbo.tbl_MerchantInfo.MerchantLevelId, dbo.tbl_MerchantInfo.EndDate, dbo.tbl_MerchantLevel.MerchantLevel, 
                         dbo.tbl_MerchantInfo.UserName, dbo.tbl_MerchantInfo.Password,dbo.tbl_MerchantInfo.StartDate,tbl_MerchantInfo.Telephone,dbo.tbl_MerchantInfo.ActiveStatus,dbo.tbl_MerchantInfo.EmailId
FROM            dbo.tbl_MerchantInfo INNER JOIN
                         dbo.tbl_MerchantLevel ON dbo.tbl_MerchantInfo.MerchantLevelId = dbo.tbl_MerchantLevel.MerchantLevelId
WHERE       (dbo.tbl_MerchantInfo.MerchantId=@MerchantId) AND (dbo.tbl_MerchantInfo.IsDelete = 0) AND (dbo.tbl_MerchantInfo.IsActive = 1)
	END


	IF @Event = 'GetValidDate'
		Begin
		Select EndDate from tbl_MerchantInfo where MerchantId=@MerchantId 
	end

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetMyUser]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetMyUser] 
	-- Add the parameters for the stored procedure here
	(	
	@UserId int=0,
	@UserName nvarchar(50)=null,
	@AccessPassword nvarchar(50)=null,
	@MerchantId int=0,
	@EmailId nvarchar(50)=null,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT    * from    dbo.tbl_MerchantMyUser ORDER BY  dbo.tbl_MerchantMyUser.UserId DESC
	END

	IF @Event = 'GetUserWithMId'
	BEGIN
		--SELECT        dbo.tbl_MerchantMyUser.UserId, dbo.tbl_MerchantMyUser.UserName, 
		--              dbo.tbl_MerchantMyUser.AccessPassword, dbo.tbl_MerchantMyUser.ValidTime, 
		--			  dbo.tbl_MerchantMyUser.AccessOption, dbo.tbl_MerchantMyUser.ExamCode,dbo.tbl_MerchantMyUser.ValidTimeTo
  --  FROM            dbo.tbl_MerchantMyUser 
       SELECT        dbo.tbl_MerchantMyUser.UserId, dbo.tbl_MerchantMyUser.UserName, dbo.tbl_MerchantMyUser.AccessPassword, dbo.tbl_MerchantMyUser.ValidTime,dbo.tbl_MerchantMyUser.AccessOption,(Select (Stuff((Select ', ' + AccessOption From QuizprojectUser123.tbl_UserAccessOption Where AccessOptionId In (SELECT s FROM dbo.Split(',', dbo.tbl_MerchantMyUser.AccessOption) ) FOR XML PATH('')),1,2,'')) ) As AccsessOptionval, 
                         dbo.tbl_MerchantMyUser.ExamCode, dbo.tbl_MerchantMyUser.ValidTimeTo, QuizprojectUser123.tbl_UserGroup.GroupName, dbo.tbl_MerchantMyUser.EmailId, dbo.tbl_MerchantMyUser.GroupId, 
                         dbo.tbl_MerchantMyUser.GroupStatus
FROM            dbo.tbl_MerchantMyUser LEFT OUTER JOIN
                         QuizprojectUser123.tbl_UserGroup ON dbo.tbl_MerchantMyUser.GroupId = QuizprojectUser123.tbl_UserGroup.GroupId
		WHERE       (dbo.tbl_MerchantMyUser.MerchantId=@MerchantId) AND(dbo.tbl_MerchantMyUser.IsDelete = 0) AND (dbo.tbl_MerchantMyUser.IsActive = 1) 
		ORDER BY  dbo.tbl_MerchantMyUser.UserId DESC
	END

	IF @Event = 'GetUserWithUId'
	BEGIN
		SELECT        dbo.tbl_MerchantMyUser.UserId, dbo.tbl_MerchantMyUser.UserName, 
		              dbo.tbl_MerchantMyUser.AccessPassword,
					  dbo.tbl_MerchantMyUser.ExamId, dbo.tbl_MerchantMyUser.ValidTime, 
					  dbo.tbl_MerchantMyUser.AccessOption, dbo.tbl_MerchantMyUser.ExamCode,
					  dbo.tbl_MerchantMyUser.ValidTimeTo,dbo.tbl_MerchantMyUser.EmailId,
					  dbo.tbl_MerchantMyUser.GroupId,dbo.tbl_MerchantMyUser.GroupStatus
                         
    FROM            dbo.tbl_MerchantMyUser 
		WHERE       (dbo.tbl_MerchantMyUser.UserId=@UserId) AND(dbo.tbl_MerchantMyUser.IsDelete = 0) AND (dbo.tbl_MerchantMyUser.IsActive = 1) 
		ORDER BY  dbo.tbl_MerchantMyUser.UserId DESC
	END

	IF @Event = 'GetUserDetail'
	BEGIN
		SELECT  dbo.tbl_MerchantMyUser.UserId, dbo.tbl_MerchantMyUser.UserName, 
		        dbo.tbl_MerchantMyUser.AccessPassword,dbo.tbl_MerchantMyUser.MerchantId,
				dbo.tbl_MerchantMyUser.ExamId, dbo.tbl_MerchantMyUser.ValidTime, 
				dbo.tbl_MerchantMyUser.AccessOption, dbo.tbl_MerchantMyUser.ExamCode,
				dbo.tbl_MerchantMyUser.IsActive, dbo.tbl_MerchantMyUser.IsDelete,
				dbo.tbl_MerchantMyUser.ValidTimeTo,dbo.tbl_MerchantMyUser.EmailId,
				dbo.tbl_MerchantMyUser.GroupId,dbo.tbl_MerchantMyUser.GroupStatus,
				(Select QuizprojectUser123.tbl_UserGroup.ExamId from QuizprojectUser123.tbl_UserGroup where  QuizprojectUser123.tbl_UserGroup.GroupId=dbo.tbl_MerchantMyUser.GroupId AND (QuizprojectUser123.tbl_UserGroup.IsDelete = 0) AND (QuizprojectUser123.tbl_UserGroup.IsActive = 1)) as UGExamId,
				(Select QuizprojectUser123.tbl_UserGroup.AccessOption from QuizprojectUser123.tbl_UserGroup where  QuizprojectUser123.tbl_UserGroup.GroupId=dbo.tbl_MerchantMyUser.GroupId AND (QuizprojectUser123.tbl_UserGroup.IsDelete = 0) AND (QuizprojectUser123.tbl_UserGroup.IsActive = 1)) as UGAccessOption
                         
    FROM            dbo.tbl_MerchantMyUser 
		WHERE       dbo.tbl_MerchantMyUser.EmailId=@EmailId COLLATE SQL_Latin1_General_Cp1_CS_AS AND dbo.tbl_MerchantMyUser.AccessPassword=@AccessPassword COLLATE SQL_Latin1_General_Cp1_CS_AS  AND (dbo.tbl_MerchantMyUser.IsDelete = 0) AND (dbo.tbl_MerchantMyUser.IsActive = 1)
	END

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetPaymentOption]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetPaymentOption] 
	-- Add the parameters for the stored procedure here
	(
	@PaymentOptionId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT     PaymentOptionId, PaymentOption,IsActive,IsDelete,CreatedBy,CreatedDate,UpdateBy,UpdateDate
		FROM         tbl_PaymentOption Where IsDelete=0 ORDER BY PaymentOptionId DESC
	END


	IF @Event = 'GETMerchantOption'
	BEGIN
		SELECT     PaymentOptionId, PaymentOption
		FROM         tbl_PaymentOption Where IsDelete=0 AND IsActive=1 ORDER BY PaymentOptionId DESC
	END

	IF @Event = 'GETPOptWithId'
	BEGIN
		SELECT     PaymentOptionId, PaymentOption
		FROM         tbl_PaymentOption Where PaymentOptionId=@PaymentOptionId AND IsDelete=0 AND IsActive=1
	END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetQuestionType]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetQuestionType] 
	-- Add the parameters for the stored procedure here
	(
	@QuestionTypeId int=0,
	@MerchantLevelId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT     QuestionTypeId, QuestionType,DefaultPermission
		FROM         tbl_QuestionType 
		WHERE IsDelete=0
	END

	IF @Event = 'GetQtypewithId'
	BEGIN
		SELECT     QuestionTypeId, QuestionType
		FROM         tbl_QuestionType 
		WHERE QuestionTypeId=@QuestionTypeId  AND IsDelete=0
	END

	IF @Event = 'GetQTypeWithMLevel'
	BEGIN
		--SELECT     QuestionTypeId, QuestionType,MerchantLevelId
		--FROM         tbl_QuestionType CROSS APPLY dbo.Split(',', MerchantLevelId) split
		--WHERE split.s=@MerchantLevelId And IsDelete=0

		SELECT c.[QuestionTypeId]  AS QuestionTypeId,c.[QuestionType] AS QuestionType, O.[MerchantLevelId] AS MerchantLevelId
                FROM tbl_MerchantLevel AS O outer apply [dbo].[Split](',',O.[QuestionType] ) spl
               left join tbl_QuestionType as C on c.QuestionTypeId = spl.s
               Where  O.[MerchantLevelId]=@MerchantLevelId And c.IsDelete=0

		SELECT c.[ExtraPermissionOptId]  AS ExtraPermissionOptId,c.[ExtraPermissionOpt] AS ExtraPermissionOpt, O.[MerchantLevelId] AS MerchantLevelId
                FROM tbl_MerchantLevel AS O outer apply [dbo].[Split](',',O.[ExtraPermission] ) spl
               left join QuizprojectUser123.tbl_MerchantExtraPermission as C on c.ExtraPermissionOptId = spl.s
               Where  O.[MerchantLevelId]=@MerchantLevelId And c.IsDelete=0

	END

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetSalesReports]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetSalesReports] 
	-- Add the parameters for the stored procedure here
	(
	@OrderId int=0,
	@MerchantId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT        dbo.tbl_SalesReports.OrderId, dbo.tbl_SalesReports.OrderNo, dbo.tbl_SalesReports.ExamCodeId, dbo.tbl_SalesReports.ExamCode, dbo.tbl_SalesReports.SecondCategoryId, dbo.tbl_SalesReports.MerchantId, 
                         dbo.tbl_SalesReports.OrderDate, dbo.tbl_SalesReports.Price, dbo.tbl_SalesReports.FeeRateId, dbo.tbl_SalesReports.NetAmount, dbo.tbl_SalesReports.OrderStatus, 
                         dbo.tbl_SecondCategory.SecondCategoryName, dbo.tbl_MerchantInfo.MerchantName, dbo.tbl_ExamConfig.ExamCode AS Expr1, dbo.tbl_MerchantFeeRate.MerchantFeeRate, dbo.tbl_MerchantInfo.EmailId
FROM            dbo.tbl_SalesReports INNER JOIN
                         dbo.tbl_ExamConfig ON dbo.tbl_SalesReports.ExamCodeId = dbo.tbl_ExamConfig.ExamCodeId INNER JOIN
                         dbo.tbl_SecondCategory ON dbo.tbl_SalesReports.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId INNER JOIN
                         dbo.tbl_MerchantInfo ON dbo.tbl_SalesReports.MerchantId = dbo.tbl_MerchantInfo.MerchantId INNER JOIN
                         dbo.tbl_MerchantFeeRate ON dbo.tbl_SalesReports.FeeRateId = dbo.tbl_MerchantFeeRate.MerchantFeeRateId
	   WHERE dbo.tbl_SalesReports.IsDelete=0 ORDER BY dbo.tbl_SalesReports.OrderId DESC
	END


	IF @Event = 'GetReportWithMrID'
	BEGIN
		SELECT        dbo.tbl_SalesReports.OrderId, dbo.tbl_SalesReports.OrderNo, dbo.tbl_SalesReports.ExamCodeId, dbo.tbl_SalesReports.ExamCode, dbo.tbl_SalesReports.SecondCategoryId, dbo.tbl_SalesReports.OrderDate, 
                         dbo.tbl_SalesReports.Price, dbo.tbl_SalesReports.FeeRateId, dbo.tbl_SalesReports.NetAmount, dbo.tbl_SalesReports.OrderStatus, dbo.tbl_SecondCategory.SecondCategoryName, 
                         dbo.tbl_MerchantFeeRate.MerchantFeeRate, dbo.tbl_SalesReports.ExamSimulator, dbo.tbl_SalesReports.ExamSimulatorDemo, dbo.tbl_SalesReports.OnlyTestOnce, dbo.tbl_SalesReports.AllowPrint, 
                         dbo.tbl_SalesReports.AllowSales, dbo.tbl_ExamConfig.TestTime, dbo.tbl_ExamConfig.ValidDate
FROM            dbo.tbl_SalesReports INNER JOIN
                         dbo.tbl_SecondCategory ON dbo.tbl_SalesReports.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId INNER JOIN
                         dbo.tbl_MerchantFeeRate ON dbo.tbl_SalesReports.FeeRateId = dbo.tbl_MerchantFeeRate.MerchantFeeRateId INNER JOIN
                         dbo.tbl_ExamConfig ON dbo.tbl_SalesReports.ExamCodeId = dbo.tbl_ExamConfig.ExamCodeId
	   WHERE  dbo.tbl_SalesReports.MerchantId=@MerchantId AND dbo.tbl_SalesReports.IsDelete=0
	          AND Month(dbo.tbl_SalesReports.OrderDate)=Month(CURRENT_TIMESTAMP) ORDER BY dbo.tbl_SalesReports.OrderId DESC
	END


END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetSecondCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetSecondCategory] 
	-- Add the parameters for the stored procedure here
	(
	@SecondCategoryId int=0,
	@TopCategoryId int=0,
	@Searchtext nvarchar(100)=null,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
	 Declare @SQLQuery AS NVarchar(4000)
	  Declare @ParamDefinition AS NVarchar(2000) 
	  Set @SQLQuery ='SELECT        dbo.tbl_SecondCategory.SecondCategoryId, dbo.tbl_SecondCategory.SecondCategoryName, dbo.tbl_SecondCategory.TopCategoryId, dbo.tbl_TopCategory.TopCategoryName
        FROM            dbo.tbl_SecondCategory INNER JOIN
                         dbo.tbl_TopCategory ON dbo.tbl_SecondCategory.TopCategoryId = dbo.tbl_TopCategory.TopCategoryId
		WHERE tbl_SecondCategory.IsDelete=0	'

		 If @SearchText Is Not Null 
         Set @SQLQuery = @SQLQuery + ' And (tbl_SecondCategory.SecondCategoryName like ''%''+@SearchText+''%'' OR dbo.tbl_TopCategory.TopCategoryName LIKE ''%''+@Searchtext+''%'')'
		  Set @ParamDefinition =      ' @SearchText NVarchar(100)'
		 
		  Execute sp_Executesql     @SQLQuery, @ParamDefinition, @SearchText 
				

		--SELECT        dbo.tbl_SecondCategory.SecondCategoryId, dbo.tbl_SecondCategory.SecondCategoryName, dbo.tbl_SecondCategory.TopCategoryId, dbo.tbl_TopCategory.TopCategoryName
  --      FROM            dbo.tbl_SecondCategory INNER JOIN
  --                       dbo.tbl_TopCategory ON dbo.tbl_SecondCategory.TopCategoryId = dbo.tbl_TopCategory.TopCategoryId
		--WHERE tbl_SecondCategory.IsDelete=0
	END

	IF @Event = 'GetWithSecCatId'
	BEGIN
		SELECT        dbo.tbl_SecondCategory.SecondCategoryId, dbo.tbl_SecondCategory.SecondCategoryName, dbo.tbl_SecondCategory.TopCategoryId, dbo.tbl_TopCategory.TopCategoryName
        FROM            dbo.tbl_SecondCategory INNER JOIN
                         dbo.tbl_TopCategory ON dbo.tbl_SecondCategory.TopCategoryId = dbo.tbl_TopCategory.TopCategoryId
		WHERE tbl_SecondCategory.SecondCategoryId=@SecondCategoryId AND tbl_SecondCategory.IsDelete=0
	END

	IF @Event = 'GETALLwithSearch'
	BEGIN
		SELECT        dbo.tbl_SecondCategory.SecondCategoryId, dbo.tbl_SecondCategory.SecondCategoryName, dbo.tbl_SecondCategory.TopCategoryId, dbo.tbl_TopCategory.TopCategoryName
        FROM            dbo.tbl_SecondCategory INNER JOIN
                         dbo.tbl_TopCategory ON dbo.tbl_SecondCategory.TopCategoryId = dbo.tbl_TopCategory.TopCategoryId
		WHERE (tbl_SecondCategory.SecondCategoryName LIKE '%'+@Searchtext+'%' OR dbo.tbl_TopCategory.TopCategoryName LIKE '%'+@Searchtext+'%') AND tbl_SecondCategory.IsDelete=0
	END

	IF @Event = 'GetWithTopCatId'
	BEGIN
		SELECT        dbo.tbl_SecondCategory.SecondCategoryId, dbo.tbl_SecondCategory.SecondCategoryName
        FROM            dbo.tbl_SecondCategory
		WHERE tbl_SecondCategory.TopCategoryId=@TopCategoryId AND tbl_SecondCategory.IsDelete=0
	END

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetState]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetState] 
	-- Add the parameters for the stored procedure here
	(
	@StateId int=0,
	@CountryId int=0,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETStateWithCouid'
	BEGIN
		SELECT     StateId, State,CountryId
		FROM         tbl_MasterState 
		WHERE     CountryId=@CountryId AND IsDelete=0
	END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetThirdCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_GetThirdCategory]
(
	@ThirdCategoryId int=0,
	@SecondCategoryId int=0,
	@Searchtext nvarchar(100)=null,
	@Event nvarchar(20)
	)
AS
Begin
    IF @Event = 'GETALL'
	BEGIN
	 Declare @SQLQuery AS NVarchar(4000)
	  Declare @ParamDefinition AS NVarchar(2000) 
	  Set @SQLQuery =' SELECT        dbo.tbl_ThirdCategory.ThirdCategoryId, dbo.tbl_ThirdCategory.ThirdCategoryName, dbo.tbl_ThirdCategory.SecondCategoryId, dbo.tbl_SecondCategory.SecondCategoryName
	   FROM            dbo.tbl_ThirdCategory INNER JOIN
							 dbo.tbl_SecondCategory ON dbo.tbl_ThirdCategory.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId

	   WHERE        dbo.tbl_ThirdCategory.IsDelete=0'

	    If @SearchText Is Not Null 
         Set @SQLQuery = @SQLQuery + ' And (dbo.tbl_ThirdCategory.ThirdCategoryName like ''%''+@SearchText+''%'' OR dbo.tbl_SecondCategory.SecondCategoryName LIKE ''%''+@Searchtext+''%'')'
		  Set @ParamDefinition =      ' @SearchText NVarchar(100)'
		  Execute sp_Executesql     @SQLQuery, @ParamDefinition, 
                @SearchText

	   --SELECT        dbo.tbl_ThirdCategory.ThirdCategoryId, dbo.tbl_ThirdCategory.ThirdCategoryName, dbo.tbl_ThirdCategory.SecondCategoryId, dbo.tbl_SecondCategory.SecondCategoryName
	   --FROM            dbo.tbl_ThirdCategory INNER JOIN
				--			 dbo.tbl_SecondCategory ON dbo.tbl_ThirdCategory.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId

	   --WHERE        dbo.tbl_ThirdCategory.IsDelete=0
   END

   IF @Event = 'GetWithThirdCatId'
	BEGIN
	   SELECT        dbo.tbl_ThirdCategory.ThirdCategoryId, dbo.tbl_ThirdCategory.ThirdCategoryName, dbo.tbl_ThirdCategory.SecondCategoryId, dbo.tbl_SecondCategory.SecondCategoryName
	   FROM            dbo.tbl_ThirdCategory INNER JOIN
							 dbo.tbl_SecondCategory ON dbo.tbl_ThirdCategory.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId

	   WHERE       tbl_ThirdCategory.ThirdCategoryId=@ThirdCategoryId and dbo.tbl_ThirdCategory.IsDelete=0
   END

End

GO
/****** Object:  StoredProcedure [dbo].[SP_GetTopCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetTopCategory] 
	-- Add the parameters for the stored procedure here
	(
	@TopCategoryId int=0,
	@SearchText nvarchar(100)=null,
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN

	 Declare @SQLQuery AS NVarchar(4000)
	  Declare @ParamDefinition AS NVarchar(2000) 
	  Set @SQLQuery = 'SELECT     TopCategoryId, TopCategoryName
		FROM         tbl_TopCategory
		WHERE IsDelete=0 ' 

		 If @SearchText Is Not Null 
         Set @SQLQuery = @SQLQuery + ' And (TopCategoryName like ''%''+@SearchText+''%'')'
		  Set @ParamDefinition =      ' @SearchText NVarchar(100)'
		  Execute sp_Executesql     @SQLQuery, @ParamDefinition, 
                @SearchText 

		--SELECT     TopCategoryId, TopCategoryName
		--FROM         tbl_TopCategory
		--WHERE IsDelete=0

	END

	IF @Event = 'GetCatwithId'
	BEGIN
		SELECT     TopCategoryId, TopCategoryName
		FROM         tbl_TopCategory
		WHERE TopCategoryId=@TopCategoryId AND IsDelete=0
	END

	IF @Event = 'GETALLwithSearch'
	BEGIN
		SELECT     TopCategoryId, TopCategoryName
		FROM         tbl_TopCategory
		WHERE TopCategoryName like '%'+@SearchText+'%' AND IsDelete=0
	END

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetUserAccess]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetUserAccess] 
	-- Add the parameters for the stored procedure here
	(
	@Event nvarchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT     AccessOptionId, AccessOption,DefaultPermission
		FROM          QuizprojectUser123.tbl_UserAccessOption
		WHERE IsDelete=0
	END

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetWithDrawOrder]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetWithDrawOrder] 
	-- Add the parameters for the stored procedure here
	(
	@WithDrawOrderId int=0,
	@MerchantId int=0,
	@Event nvarchar(50)
	)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'GETALL'
	BEGIN
		SELECT        dbo.tbl_WithDrawOrder.WithDrawOrderId, dbo.tbl_WithDrawOrder.WithDrawOrderNo, dbo.tbl_WithDrawOrder.Amount, dbo.tbl_WithDrawOrder.MerchantId, dbo.tbl_MerchantInfo.MerchantName,
		dbo.tbl_WithDrawOrder.OrderStatus,dbo.tbl_MerchantInfo.EmailId
FROM            dbo.tbl_WithDrawOrder INNER JOIN
                         dbo.tbl_MerchantInfo ON dbo.tbl_WithDrawOrder.MerchantId = dbo.tbl_MerchantInfo.MerchantId
	    WHERE dbo.tbl_WithDrawOrder.IsDelete=0 ORDER by dbo.tbl_WithDrawOrder.WithDrawOrderId DESC
	END

	IF @Event = 'Getorderno'
	BEGIN
		SELECT TOP(1) dbo.tbl_WithDrawOrder.WithDrawOrderId FROM tbl_WithDrawOrder ORDER BY WithDrawOrderId DESC
	END

	IF @Event = 'GetWithDrawRecordWithMId'
	BEGIN
		SELECT        dbo.tbl_WithDrawOrder.WithDrawOrderId, dbo.tbl_WithDrawOrder.WithDrawOrderNo,dbo.tbl_WithDrawOrder.OrderDate, dbo.tbl_WithDrawOrder.Amount,
		dbo.tbl_WithDrawOrder.OrderStatus
FROM            dbo.tbl_WithDrawOrder 
	   WHERE tbl_WithDrawOrder.MerchantId=@MerchantId AND tbl_WithDrawOrder.IsDelete=0 ORDER by dbo.tbl_WithDrawOrder.WithDrawOrderId DESC
	END

END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDAllowSales]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDAllowSales] 
	-- Add the parameters for the stored procedure here
	(
		@Id	int =0           ,       
		@ExamId	int =0,
		@NoofQuestion int =0,
		@Price decimal(18,2)=0,
		@SelfDescription nvarchar(MAX)=null,
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdatedBy int=0,
		@UpdatedDate datetime =null,
		@Event      nvarchar(20)  =null,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
	BEGIN
		INSERT INTO [QuizprojectUser123].[tbl_MerchantAllowSales] (ExamId,NoofQuestion,Price,SelfDescription,IsActive,IsDelete,CreatedBy,CreatedDate)
							VALUES (@ExamId,@NoofQuestion,@Price,@SelfDescription,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)
		SET @returnValue = 1 --Records Inserted
	END

	IF @Event = 'Update'
		BEGIN
			
			SET @returnValue = 2 --Records Updated
		END

	IF @Event = 'Delete'
		BEGIN
			
			SET @returnValue = 3 --Records Deleted
		END

	
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDBundle]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDBundle] 
	(
	@BundleId int=0,   
		@BundleContent	nvarchar(50)=null,
		@Price decimal(18,2)=0, 
		@FeaturedSelfsEstore bit=0,
		@MerchantId	int =0           ,   
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdatedBy int=0,
		@UpdatedDate datetime =null,
		@Event      nvarchar(100)  =null,
		@returnValue  int output         
	)
AS
BEGIN
	SET NOCOUNT ON;
	IF @Event = 'Insert'
	BEGIN
	   
						INSERT INTO QuizprojectUser123.tbl_BundleExam
									(BundleContent,Price,FeaturedSelfsEstore,MerchantId,IsActive,IsDelete,CreatedBy,CreatedDate)
						VALUES     (@BundleContent,@Price,@FeaturedSelfsEstore,@MerchantId,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)
						SET @returnValue = SCOPE_IDENTITY(); ---Insert Record
					
	END
	IF @Event = 'Update'
		BEGIN
			UPDATE QuizprojectUser123.tbl_BundleExam
			SET   BundleContent=@BundleContent,Price=@Price,FeaturedSelfsEstore=@FeaturedSelfsEstore,MerchantId=@MerchantId,
			       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  BundleId = @BundleId
			  SET @returnValue = 2 --Records Updated
		END

		IF @Event = 'Delete'
		BEGIN
			UPDATE QuizprojectUser123.tbl_BundleExam
			SET   IsDelete=@IsDelete, UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  BundleId = @BundleId
			  SET @returnValue = 3 --Records Updated
		END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDEstoreConfig]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_IUDEstoreConfig] 
	(
	@EstroeConfigId int=0,   
		@QuestionNumber	int=0,
		@Price decimal(18,2)=0, 
		@ExamPicture nvarchar(200)=null,
		@ExamDescription nvarchar(Max)=null,
		@ExamId	int =0 ,
		@MerchantId	int =0           ,   
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdatedBy int=0,
		@UpdatedDate datetime =null,
		@Event      nvarchar(100)  =null,
		@returnValue  int output         
	)
AS
BEGIN
	SET NOCOUNT ON;
	IF @Event = 'Insert'
	BEGIN
	   
						--INSERT INTO QuizprojectUser123.tbl_MerchantEstoreConfig
						--			(QuestionNumber,Price,ExamPicture,ExamDescription,ExamId,MerchantId,IsActive,IsDelete,CreatedBy,CreatedDate)
						--VALUES     (@QuestionNumber,@Price,@ExamPicture,@ExamDescription,@ExamId,@MerchantId,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)
						SET @returnValue = 1;--SCOPE_IDENTITY(); ---Insert Record
					
	END
	--IF @Event = 'Update'
	--	BEGIN
	--		UPDATE QuizprojectUser123.tbl_MerchantEstoreConfig
	--		SET   BundleContent=@BundleContent,Price=@Price,FeaturedSelfsEstore=@FeaturedSelfsEstore,MerchantId=@MerchantId,
	--		       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
	--		WHERE  BundleId = @BundleId
	--		  SET @returnValue = 2 --Records Updated
	--	END

	--	IF @Event = 'Delete'
	--	BEGIN
	--		UPDATE QuizprojectUser123.tbl_MerchantEstoreConfig
	--		SET   IsDelete=@IsDelete, UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
	--		WHERE  BundleId = @BundleId
	--		  SET @returnValue = 3 --Records Updated
	--	END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDExamManage]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDExamManage] 
	-- Add the parameters for the stored procedure here
	(
		@ExamCodeId	int =0           ,       
		@ExamCode	nvarchar(50)=null,
		@ExamTitle nvarchar(50)=null,
		@TopCategoryId int=0,
		@SecondCategoryId int=0,
		@PassingPercentage decimal(18,2)=0,
		@TestTime int=0,
		@TestOption nvarchar(50)=null,
		@ValidDate datetime=null,
		@MerchantId int=0,
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdatedBy int=0,
		@UpdatedDate datetime =null,
		@Price decimal(18,2)=0,
		@ExamSimulator bit=0,
		@ExamSimulatorDemo bit=0,
		@OnlyTestOnce bit=0,
		@AllowPrint bit=0,
		@AllowSales bit=0,
		@Event      nvarchar(20)  =null,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
		BEGIN
			 If Not Exists (SELECT ExamCode FROM tbl_ExamConfig WHERE  MerchantId =@MerchantId)
			 BEGIN
				INSERT INTO tbl_ExamConfig (ExamCode,ExamTitle,SecondCategoryId,PassingPercentage,
											TestTime,TestOption,ValidDate,MerchantId,IsActive,IsDelete,CreatedBy,CreatedDate,
											Price,ExamSimulator,ExamSimulatorDemo,OnlyTestOnce,AllowPrint,AllowSales)
									VALUES (@ExamCode,@ExamTitle,@SecondCategoryId,@PassingPercentage,
											@TestTime,@TestOption,@ValidDate,@MerchantId,@IsActive,@IsDelete,@CreatedBy,@CreatedDate,
											@Price,@ExamSimulator,@ExamSimulatorDemo,@OnlyTestOnce,@AllowPrint,@AllowSales)
				SET @returnValue = 1 --Records Inserted
			 End
			 else  
				   SET @returnValue = -1 --UserName Already Exist
	  END

	IF @Event = 'Update'
		BEGIN
			UPDATE tbl_ExamConfig
			SET    ExamCode=@ExamCode,ExamTitle=@ExamTitle,
			       SecondCategoryId=@SecondCategoryId,PassingPercentage=@PassingPercentage,
				   TestTime=@TestTime,TestOption=@TestOption,ValidDate=@ValidDate,IsActive = @IsActive,
			       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  ExamCodeId = @ExamCodeId
			SET @returnValue = 2 --Records Updated
		END

	IF @Event = 'Delete'
		BEGIN
		     IF NOT EXISTS (SELECT CAST(ExamCodeId as nvarchar) AS ExamId FROM QuizprojectUser123.tbl_QAManage WHERE ExamCodeId = @ExamCodeId AND IsDelete=0 Union SELECT ExamId FROM tbl_MerchantMyUser CROSS APPLY dbo.Split(',', dbo.tbl_MerchantMyUser.ExamId) split Where split.s = @ExamCodeId)
		     BEGIN
				UPDATE tbl_ExamConfig SET IsDelete=@IsDelete, UpdatedBy=@Updatedby,
				UpdatedDate=@UpdatedDate WHERE  ExamCodeId = @ExamCodeId
				SET @returnValue = 3 --Records Deleted
             END
			  ELSE
		     SET @returnValue = 5 --Used In Another Table
		END

	IF @Event = 'UpdateActive'
		BEGIN
			UPDATE tbl_ExamConfig
			SET    IsActive = @IsActive,
			       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  ExamCodeId = @ExamCodeId
			   IF @IsActive=1
				  SET @returnValue = 6 --Status Active
			   ELSE
				  SET @returnValue = 7 --Status Non-Active
		END

		IF @Event = 'UpdateOnlyTestOnce'
		BEGIN
			UPDATE tbl_ExamConfig
			SET    OnlyTestOnce = @OnlyTestOnce,
			       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  ExamCodeId = @ExamCodeId
				  SET @returnValue = 11 --Status Active
		END
		IF @Event = 'UpdateAllowPrint'
		BEGIN
			UPDATE tbl_ExamConfig
			SET    AllowPrint = @AllowPrint,
			       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  ExamCodeId = @ExamCodeId
				  SET @returnValue = 12 --Status Active
		END

		IF @Event = 'UpdateAllowSales'
		BEGIN
			UPDATE tbl_ExamConfig
			SET    AllowSales = @AllowSales,
			       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  ExamCodeId = @ExamCodeId
				  SET @returnValue = 13--Status Active
		END

		-----15/11/2017 User by Testonce Update--------
		IF @Event = 'UpdateByUser'
		BEGIN
			UPDATE tbl_ExamConfig
			SET    OnlyTestOnce = @OnlyTestOnce,
			       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  ExamCodeId = @ExamCodeId
				  SET @returnValue = 999 --Status Active
		END
	
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDGroup]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDGroup]
   (
		@GroupId int = 0,
		@GroupName nvarchar(50)=null,
		@MerchantId int=0,
		@ExamId nvarchar(50)=null,
		@AccessOption nvarchar(Max)=null,
		@IsActive bit=0,
		@IsDelete bit=0,
		@Createdby int=0,
		@CreatedDate datetime=null,
		@UpdatedBy int=0,
		@UpdatedDate datetime=null,
		@Event      nvarchar(20)  ,
		@returnValue  int output   
	)
AS
BEGIN
   IF @Event = 'Insert'

   BEGIN
		 
			 INSERT INTO QuizprojectUser123.tbl_UserGroup (GroupName,MerchantId,ExamId,AccessOption,IsActive,IsDelete,
											  Createdby,CreatedDate)
									  VALUES (@GroupName,@MerchantId,@ExamId,@AccessOption,@IsActive,@IsDelete,
											  @Createdby,@CreatedDate)
			  SET @returnValue = 1 --Records Inserted
          
   END
    IF @Event = 'Update'
   BEGIN
    
		    UPDATE QuizprojectUser123.tbl_UserGroup SET GroupName=@GroupName,MerchantId=@MerchantId,
										ExamId=@ExamId,AccessOption=@AccessOption,IsActive=@IsActive,
										IsDelete=@IsDelete,UpdatedBy=@UpdatedBy,
										UpdatedDate=@UpdatedDate
								  WHERE GroupId=@GroupId
		  SET @returnValue = 2 --Records Updated
          
     
   END

   IF @Event = 'Delete'
   BEGIN
       UPDATE QuizprojectUser123.tbl_UserGroup SET
									IsDelete=@IsDelete,UpdatedBy=@UpdatedBy,
									UpdatedDate=@UpdatedDate
						      WHERE GroupId=@GroupId
	  SET @returnValue = 3 --Records Deleted
   END
END	

RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDMerchantFeeRate]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDMerchantFeeRate] 
	-- Add the parameters for the stored procedure here
	(
		@MerchantFeeRateId	int   =0            ,       
		@MerchantFeeRate	int=0,
		@MerchantLevelId int=0,
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdateBy int=0,
		@UpdateDate datetime=null,
		@Event      nvarchar(20)  ,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
	BEGIN
		INSERT INTO tbl_MerchantFeeRate
							  (MerchantFeeRate,MerchantLevelId,IsActive,IsDelete,CreatedBy,CreatedDate)
		VALUES     (@MerchantFeeRate,@MerchantLevelId,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)
		SET @returnValue = 1 --Records Inserted
	END
	IF @Event = 'Update'
		BEGIN
			UPDATE tbl_MerchantFeeRate
			SET    MerchantFeeRate = @MerchantFeeRate,MerchantLevelId=@MerchantLevelId,IsActive=@IsActive,IsDelete=@IsDelete,
			       Updateby=@Updateby,UpdateDate=@UpdateDate
			WHERE  MerchantFeeRateId = @MerchantFeeRateId
			SET @returnValue = 2 --Records Updated
		END
	IF @Event = 'Delete'
		BEGIN
		   IF NOT EXISTS (SELECT FeeRateId FROM tbl_SalesReports WHERE FeeRateId = @MerchantFeeRateId AND IsDelete=0)
		   	 BEGIN
				UPDATE tbl_MerchantFeeRate SET IsDelete=@IsDelete, Updateby=@Updateby,UpdateDate=@UpdateDate
				 WHERE  MerchantFeeRateId = @MerchantFeeRateId
				SET @returnValue = 3 --Records Deleted
			 END
		   ELSE
		        SET @returnValue = 5 --Used In Another Table
		END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDMerchantLevel]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDMerchantLevel] 
	-- Add the parameters for the stored procedure here
	(
		@MerchantLevelId	int    =0           ,       
		@MerchantLevel	nvarchar(50)=null,
		@AnnualFee decimal (18,2)=0,
		@ExamCount int=0,
		@StudentCount int=0,
		@ShopperFee decimal (18,2)=0,
		@QuestionType nvarchar(Max)=null,
		@ExtraPermission nvarchar(Max)=null,
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdateBy int=0,
		@UpdateDate datetime=null,
		@Event      nvarchar(20)=null  ,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
	BEGIN
		INSERT INTO tbl_MerchantLevel
							  (MerchantLevel,AnnualFee,ExamCount,StudentCount,ShopperFee,QuestionType,ExtraPermission,IsActive,IsDelete,CreatedBy,CreatedDate)
		VALUES     (@MerchantLevel,@AnnualFee,@ExamCount,@StudentCount,@ShopperFee,@QuestionType,@ExtraPermission,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)
		SET @returnValue = 1 --Records Inserted
	END
	IF @Event = 'Update'
		BEGIN
			UPDATE tbl_MerchantLevel
			SET    MerchantLevel = @MerchantLevel,AnnualFee=@AnnualFee,ExamCount=@ExamCount,StudentCount=@StudentCount,
			       ShopperFee=@ShopperFee,QuestionType=@QuestionType,ExtraPermission=@ExtraPermission,
			       IsActive=@IsActive,UpdateBy=@UpdateBy,UpdateDate=@UpdateDate
			WHERE  MerchantLevelId = @MerchantLevelId
			SET @returnValue = 2 --Records Updated
		END
	IF @Event = 'Delete'
		BEGIN
		   IF NOT EXISTS (SELECT MerchantLevelId FROM tbl_MerchantFeeRate WHERE MerchantLevelId = @MerchantLevelId AND IsDelete=0)
		   	 BEGIN
				UPDATE tbl_MerchantLevel SET
				 IsDelete=@IsDelete,UpdateBy=@UpdateBy,UpdateDate=@UpdateDate
				 WHERE  MerchantLevelId = @MerchantLevelId
				SET @returnValue = 3 --Records Deleted
			  END
		   ELSE
		        SET @returnValue = 5 --Used In Another Table
		END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDMerchantManage]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDMerchantManage] 
	-- Add the parameters for the stored procedure here
	(
		@MerchantId	int =0           ,       
		@MerchantName	nvarchar(50)=null,
		@UserName nvarchar(50)=null,
		@Password nvarchar(50)=null,
		@StateId int=0,
		@Telephone nvarchar(50)=null,
		@MerchantLevelId int=0,
		@EmailId nvarchar(50)=null,
		@StartDate datetime=null,
		@EndDate datetime=null,
		@ActiveStatus bit=0,
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdatedBy int=0,
		@UpdatedDate datetime =null,
		@Brand nvarchar(50)=null,
		@Picture nvarchar(200)=null,
		@About nvarchar(max)=null,
		@Event      nvarchar(100)  =null,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
	BEGIN
		 IF NOT EXISTS(SELECT EmailId FROM tbl_MerchantInfo WHERE EmailId=@EmailId)
			BEGIN
				--INSERT INTO tbl_MerchantInfo
				--			(MerchantName,UserName,Password,StateId,Telephone,MerchantLevelId,
				--			 EmailId,StartDate,EndDate,ActiveStatus,IsActive,IsDelete,CreatedBy,CreatedDate)
				--VALUES     (@MerchantName,@UserName,@Password,@StateId,@Telephone,@MerchantLevelId,
				--			@EmailId,@StartDate,@EndDate,@ActiveStatus,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)
				INSERT INTO tbl_MerchantInfo
							(Password,EmailId,StartDate,EndDate,ActiveStatus,IsActive,IsDelete,CreatedBy,CreatedDate)
				VALUES     (@Password,@EmailId,@StartDate,@EndDate,@ActiveStatus,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)
				SET @returnValue = SCOPE_IDENTITY(); ---Insert Record
				return
			END
		  SET @returnValue = -1 --Email Id Already Exist
	END
	IF @Event = 'Update'
		BEGIN
			UPDATE tbl_MerchantInfo
			SET   MerchantName=@MerchantName,Password=@Password,Telephone=@Telephone,MerchantLevelId=@MerchantLevelId,ActiveStatus=@ActiveStatus,StartDate=@StartDate,EndDate = @EndDate,
			       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  MerchantId = @MerchantId
			  SET @returnValue = 2 --Records Updated
		END
	IF @Event = 'UpdateStatus'
		BEGIN
			UPDATE tbl_MerchantInfo
			SET    ActiveStatus = @ActiveStatus,
			       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  MerchantId = @MerchantId
			  IF @ActiveStatus=1
			  SET @returnValue = 6 --Status Active
             ELSE IF @ActiveStatus=0
			  SET @returnValue = 7 --Status Non-Active
		END

		IF @Event = 'UpdateLevel'
		BEGIN
			UPDATE tbl_MerchantInfo
			SET    MerchantLevelId = @MerchantLevelId,
			       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  MerchantId = @MerchantId
			  SET @returnValue = 8 --Update Level
		END

	IF @Event = 'Delete'
		BEGIN
			--UPDATE tbl_MerchantFeeRate SET IsDelete=@IsDelete WHERE  MerchantFeeRateId = @MerchantFeeRateId
			SET @returnValue = 3 --Records Deleted
		END

		-- Create on 12-Dec-2017
		
		IF @Event = 'UpdateBySelf'
		BEGIN
		DECLARE @myusername varchar(200);
		      SELECT @myusername=UserName FROM tbl_MerchantInfo WHERE UserName=@UserName And MerchantId !=@MerchantId
			  If Not Exists (SELECT UserName FROM tbl_MerchantInfo WHERE UserName=@UserName And MerchantId !=@MerchantId)
		        BEGIN
			
					UPDATE tbl_MerchantInfo
					SET   MerchantName=@MerchantName,Password=@Password,StateId=@StateId,
						  Telephone=@Telephone,Brand=@Brand,Picture=@Picture,About=@About,UserName=@UserName,
						   UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
					WHERE  MerchantId = @MerchantId
					  SET @returnValue = 2 --Records Updated
               END
			  else  If (@myusername!=@UserName OR @myusername!='')
			   SET @returnValue = -2 --UserName Already Exist
		END

		IF @Event = 'UpdateLevelAfterRegistrer'
		BEGIN
		UPDATE tbl_MerchantInfo SET   MerchantLevelId=@MerchantLevelId WHERE  MerchantId = @MerchantId
		End
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDMerchantPayment]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDMerchantPayment] 
	-- Add the parameters for the stored procedure here
	(
		@PaymentId	int =0           ,       
		@MerchantId	int =0  ,
		@MerchantOrderNo nvarchar(50)=null,
		@SId nvarchar(50)=null,
		@Key nvarchar(50)=null,
		@Order_Number nvarchar(50)=null,
		@CurrencyCode nvarchar(50)=null,
		@InvoiceId nvarchar(50)=null,
		@TotalAmount decimal(18,2)=0,
		@CCProcess nvarchar(50)=null,
		@PayMethod nvarchar(50)=null,
		@Date datetime=null,
		@PaymentData nvarchar(MAX)=null,
		@IsActive bit=0,
		@IsDelete bit=0,
		@Event      nvarchar(20)  =null,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
	BEGIN
		INSERT INTO QuizprojectUser123.tbl_MerchantInfoPayment (MerchantId,MerchantOrderNo,SId,[Key],Order_Number,CurrencyCode,
		                            InvoiceId,TotalAmount,CCProcess,PayMethod,Date,PaymentData,IsActive,IsDelete)
							VALUES (@MerchantId,@MerchantOrderNo,@SId,@Key,@Order_Number,@CurrencyCode,
							        @InvoiceId,@TotalAmount,@CCProcess,@PayMethod,@Date,@PaymentData,@IsActive,@IsDelete)
		SET @returnValue = 1 --Records Inserted
	END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDMyUser]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDMyUser]
   (
		@UserId int = 0,
		@UserName nvarchar(50)=null,
		@AccessPassword nvarchar(50)=null,
		@EmailId nvarchar(50)=null,
		@MerchantId int=0,
		@ExamId nvarchar(50)=null,
		@ExamCode nvarchar(50)=null,
		@ValidTime datetime=null,
		@AccessOption nvarchar(50)=null,
		@IsActive bit=0,
		@IsDelete bit=0,
		@Createdby int=0,
		@CreatedDate datetime=null,
		@UpdatedBy int=0,
		@UpdatedDate datetime=null,
		@Event      nvarchar(20)  ,
		@ValidTimeTo datetime=null,
		@GroupId int=0,
		@GroupStatus bit=0,
		@returnValue  int output   
	)
AS
BEGIN
   IF @Event = 'Insert'

   BEGIN
		  IF NOT EXISTS(SELECT EmailId FROM tbl_MerchantMyUser WHERE MerchantId = @MerchantId AND EmailId=@EmailId)
		    BEGIN
			 INSERT INTO tbl_MerchantMyUser (UserName,AccessPassword,EmailId,MerchantId,ExamId,
											  ExamCode,ValidTime,AccessOption,IsActive,IsDelete,
											  Createdby,CreatedDate,ValidTimeTo,GroupId,GroupStatus)
									  VALUES (@UserName,@AccessPassword,@EmailId,@MerchantId,@ExamId,
											  @ExamCode,@ValidTime,@AccessOption,@IsActive,@IsDelete,
											  @Createdby,@CreatedDate,@ValidTimeTo,@GroupId,@GroupStatus)
			  SET @returnValue = 1 --Records Inserted
            END
          ELSE
		   BEGIN
	        SET @returnValue = 4 --EmailId Name Already Exists
		   END
   END
    IF @Event = 'Update'
   BEGIN
    
		    UPDATE tbl_MerchantMyUser SET UserName=@UserName,AccessPassword=@AccessPassword,
										EmailId=@EmailId,MerchantId=@MerchantId,
										ExamId=@ExamId,ExamCode=@ExamCode,ValidTime=@ValidTime,
										AccessOption=@AccessOption,IsActive=@IsActive,
										IsDelete=@IsDelete,UpdatedBy=@UpdatedBy,
										UpdatedDate=@UpdatedDate,ValidTimeTo=@ValidTimeTo,
										GroupId=@GroupId,GroupStatus=@GroupStatus
								  WHERE UserId=@UserId
		  SET @returnValue = 2 --Records Updated
          
     
   END

   IF @Event = 'Delete'
   BEGIN
       UPDATE tbl_MerchantMyUser SET
									IsDelete=@IsDelete,UpdatedBy=@UpdatedBy,
									UpdatedDate=@UpdatedDate
						      WHERE UserId=@UserId
	  SET @returnValue = 3 --Records Deleted
   END
END	

RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDPaymentOption]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDPaymentOption] 
	-- Add the parameters for the stored procedure here
	(
		@PaymentOptionId	int     =0          ,       
		@PaymentOption	nvarchar(50)=null,
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdateBy int=0,
		@UpdateDate datetime=null,
		@Event      nvarchar(20)=null  ,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
	BEGIN
	   IF NOT EXISTS (SELECT PaymentOption From tbl_PaymentOption WHERE PaymentOption = @PaymentOption)
	    BEGIN
		INSERT INTO tbl_PaymentOption
							  (PaymentOption,IsActive,IsDelete,CreatedBy,CreatedDate)
		VALUES     (@PaymentOption,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)
		SET @returnValue = 1 --Records Inserted
		END
       ELSE
	    BEGIN
		SET @returnValue = 4 --Already Exist
		END
	END
	IF @Event = 'Update'
		BEGIN
			UPDATE tbl_PaymentOption
			SET    PaymentOption = @PaymentOption,IsActive=@IsActive,
			       IsDelete=@IsDelete,UpdateBy=@UpdateBy,UpdateDate=@UpdateDate
			WHERE  PaymentOptionId = @PaymentOptionId 
			SET @returnValue = 2 --Records Updated
		END
	IF @Event = 'Delete'
		BEGIN
			UPDATE tbl_PaymentOption 
			SET IsDelete=@IsDelete ,UpdateBy=@UpdateBy,UpdateDate=@UpdateDate
		 WHERE  PaymentOptionId = @PaymentOptionId
			SET @returnValue = 3 --Records Deleted
		END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDQuestionType]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDQuestionType] 
	-- Add the parameters for the stored procedure here
	(
		@QuestionTypeId	int=0               ,       
		@QuestionType	nvarchar(50)=null,
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdateBy int=0,
		@UpdateDate datetime=null,
		@Event      nvarchar(20) =null ,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
	BEGIN
		INSERT INTO tbl_QuestionType
							  (QuestionType,IsActive,IsDelete,CreatedBy,CreatedDate)
		VALUES     (@QuestionType,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)
		SET @returnValue = 1 --Records Inserted
	END
	IF @Event = 'Update'
		BEGIN
			UPDATE tbl_QuestionType
			SET    QuestionType = @QuestionType,IsActive=@IsActive,
			       IsDelete=@IsDelete,UpdateBy=@UpdateBy,UpdateDate=@UpdateDate
			WHERE  QuestionTypeId = @QuestionTypeId 
			SET @returnValue = 2 --Records Updated
		END
	IF @Event = 'Delete'
		BEGIN
			UPDATE tbl_QuestionType SET
			IsDelete=@IsDelete,UpdateBy=@UpdateBy,UpdateDate=@UpdateDate
			 WHERE  QuestionTypeId = @QuestionTypeId
			SET @returnValue = 3 --Records Deleted
		END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDSalesReports]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDSalesReports] 
	-- Add the parameters for the stored procedure here
	(
		@OrderId	int =0           ,       
		@OrderNo	nvarchar(50)=null,
		@ExamCodeId int=0,
		@ExamCode nvarchar(50)=null,
		@SecondCategoryId int=0,
		@MerchantId int=0,
		@OrderDate datetime=null,
		@Price decimal(18,2)=0,
		@FeeRateId int=0,
		@NetAmount decimal(18,2)=0,
		@OrderStatus nvarchar(50)=null,
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdatedBy int=0,
		@UpdatedDate datetime =null,
		@Event      nvarchar(20)  =null,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
	BEGIN
		

		SET @returnValue = 1 --Records Inserted
	END
	IF @Event = 'UpdateStatus'
		BEGIN
			UPDATE tbl_SalesReports
			SET    OrderStatus = @OrderStatus,
			       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  OrderId = @OrderId
			SET @returnValue = 8 --Records Updated
		END
	IF @Event = 'Delete'
		BEGIN
			
			SET @returnValue = 3 --Records Deleted
		END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDSecondCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDSecondCategory] 
	-- Add the parameters for the stored procedure here
	(
		@SecondCategoryId	int   =0            ,       
		@SecondCategoryName	nvarchar(50) =null,
		@TopCategoryId	int=0,     
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdatedBy int=0,
		@UpdatedDate datetime=null,     
		@Event      nvarchar(20)=null  ,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
	BEGIN
		INSERT INTO tbl_SecondCategory
							  (SecondCategoryName,TopCategoryId,IsActive,IsDelete,CreatedBy,CreatedDate)
		VALUES     (@SecondCategoryName,@TopCategoryId,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)
		SET @returnValue = 1 --Records Inserted
	END
	IF @Event = 'Update'
		BEGIN
			UPDATE tbl_SecondCategory
			SET    SecondCategoryName = @SecondCategoryName, TopCategoryId=@TopCategoryId,
			       IsActive=@IsActive,IsDelete=@IsDelete,UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate
			WHERE  SecondCategoryId = @SecondCategoryId 
			SET @returnValue = 2 --Records Updated
		END
	IF @Event = 'Delete'
		BEGIN
		   IF NOT EXISTS (SELECT SecondCategoryId FROM tbl_ExamConfig WHERE SecondCategoryId = @SecondCategoryId AND IsDelete=0 Union SELECT SecondCategoryId FROM tbl_ThirdCategory WHERE SecondCategoryId = @SecondCategoryId AND IsDelete=0)
		   	 BEGIN
				UPDATE tbl_SecondCategory SET
					  IsDelete=@IsDelete,UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate
				 WHERE  SecondCategoryId = @SecondCategoryId
				SET @returnValue = 3 --Records Deleted
			 END
		   ELSE
		        SET @returnValue = 5 --Used In Another Table
		END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDThirdCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDThirdCategory] 
	-- Add the parameters for the stored procedure here
	(
		@ThirdCategoryId	int  =0             ,       
		@ThirdCategoryName	nvarchar(50)=null,
		@SecondCategoryId	int=0, 
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=1,
		@CreatedDate datetime=null,
		@UpdatedBy int=1,
		@UpdatedDate datetime=null,         
		@Event      nvarchar(20)=null  ,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
	BEGIN
		INSERT INTO tbl_ThirdCategory
							  (ThirdCategoryName,SecondCategoryId,IsActive,IsDelete,CreatedBy,CreatedDate)
		VALUES     (@ThirdCategoryName,@SecondCategoryId,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)
		SET @returnValue = 1 --Records Inserted
	END
	IF @Event = 'Update'
		BEGIN
			UPDATE tbl_ThirdCategory
			SET    ThirdCategoryName = @ThirdCategoryName, SecondCategoryId=@SecondCategoryId,
			       IsActive=@IsActive,UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate
			WHERE  ThirdCategoryId = @ThirdCategoryId 
			SET @returnValue = 2 --Records Updated
		END
	IF @Event = 'Delete'
		BEGIN
			UPDATE tbl_ThirdCategory SET
			        IsDelete=@IsDelete,UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate
		    WHERE  ThirdCategoryId = @ThirdCategoryId
			SET @returnValue = 3 --Records Deleted
		END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDTopCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDTopCategory] 
	-- Add the parameters for the stored procedure here
	(
		@TopCategoryId	int =0              ,       
		@TopCategoryName	nvarchar(50)=null,
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdatedBy int=0,
		@UpdatedDate datetime=null,
		@Event      nvarchar(20) =null ,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
	BEGIN
		INSERT INTO tbl_TopCategory
							  (TopCategoryName,IsActive,IsDelete,CreatedBy,CreatedDate)
		VALUES     (@TopCategoryName,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)
		SET @returnValue = 1 --Records Inserted
	END
	IF @Event = 'Update'
		BEGIN
			UPDATE tbl_TopCategory
			SET    TopCategoryName = @TopCategoryName,IsActive=@IsActive,
			UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate
			WHERE  TopCategoryId = @TopCategoryId 
			SET @returnValue = 2 --Records Updated
		END
	IF @Event = 'Delete'
		BEGIN
		   IF NOT EXISTS (SELECT TopCategoryId FROM tbl_SecondCategory WHERE TopCategoryId = @TopCategoryId AND IsDelete=0)
		     BEGIN
				Update tbl_TopCategory SET
				IsDelete=@IsDelete,UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate
				 WHERE  TopCategoryId = @TopCategoryId
				SET @returnValue = 3 --Records Deleted
			 END
		   ELSE
		     SET @returnValue = 5 --Used In Another Table
		END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_IUDWithDrawOrderManage]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IUDWithDrawOrderManage] 
	-- Add the parameters for the stored procedure here
	(
		@WithDrawOrderId	int =0           ,       
		@WithDrawOrderNo	nvarchar(50)=null,
		@Amount decimal(18,2)=0,
		@MerchantId int=0,
		@OrderStatus bit=0,
		@OrderDate datetime=null,
		@IsActive bit=1,
		@IsDelete bit=0,
		@CreatedBy int=0,
		@CreatedDate datetime=null,
		@UpdatedBy int=0,
		@UpdatedDate datetime =null,
		@Event      nvarchar(20)  =null,
		@returnValue  int output         
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	IF @Event = 'Insert'
	BEGIN
		INSERT INTO tbl_WithDrawOrder (WithDrawOrderNo,Amount,MerchantId,
		OrderStatus,OrderDate,IsActive,IsDelete,CreatedBy,CreatedDate)
		 Values(@WithDrawOrderNo,@Amount,@MerchantId,@OrderStatus,@OrderDate,
		 @IsActive,@IsDelete,@CreatedBy,@CreatedDate)

		 DECLARE @Balance decimal(18,2)

		 SELECT      @Balance = Balance
          FROM        QuizprojectUser123.tbl_MerchantBalance Where MerchantId=@MerchantId

		UPDATE QuizprojectUser123.tbl_MerchantBalance Set Balance=@Balance-@Amount Where MerchantId=@MerchantId

		SET @returnValue = 1 --Records Inserted
	END
	IF @Event = 'UpdateStatus'
		BEGIN
			UPDATE tbl_WithDrawOrder
			SET    OrderStatus = @OrderStatus,
			       UpdatedBy=@Updatedby,UpdatedDate=@UpdatedDate
			WHERE  WithDrawOrderId = @WithDrawOrderId
			SET @returnValue = 8 --Records Updated
		END
END


GO
/****** Object:  StoredProcedure [dbo].[System_Login]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[System_Login] 
	-- Add the parameters for the stored procedure here
@pin as nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from tbl_userlogin where PIN = @pin and status = 1
END





GO
/****** Object:  StoredProcedure [dbo].[TakeOut]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TakeOut]
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@user_id int,
	@timestamp nvarchar(100),
	@duration nvarchar(100),
	--return values
	@kotid int output,
	@guest_id int output,
	@orderid int output,
	@status nvarchar(200) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into tbl_guest_master
	(
	   cust_id,
	   status,
	   created_date,
	   created_by
	)
	values
	(
	@cust_id,
	'1',
	GETDATE(),
	@user_id
	)


    IF @@ROWCOUNT > 0 
	BEGIN
		DECLARE @gid1 int
		SET @gid1 = @@IDENTITY
		SET @guest_id = @gid1
		INSERT INTO tbl_booking_master
		(
		cust_id,
		gid,
		use_id,
		status,
		created_date,
		created_by,
		timestamp,
		duration,
		hold_status,
		booking_status,
		booking_date,
		booking_time
		)

		VALUES
		(
		@cust_id,
		@gid1,
		@user_id,
		'1',
		GETDATE(),
		@user_id,
		@timestamp,
		@duration,
		'0',
		'1',
		GETDATE(),
	CURRENT_TIMESTAMP
		)
				
	
	END
	
	DECLARE @order_id int
	SET @order_id = @@IDENTITY	

	INSERT INTO tbl_kot_master
	(
	 cust_id,
	 order_id,
	 gid,
	 order_date,
	 total_item,
	 sub_total,
	 total_amnt,
	 status,
	 created_date,
	 created_by
	)

	VALUES 
	(
	@cust_id,
	@order_id,
	@guest_id,
	GETDATE(),
	0,
	0,
	0,
	'1',
	GETDATE(),
	@user_id
	)

	DECLARE @kot_id int
	SET @kot_id = @@IDENTITY
	
	--DECLARE @FDATE NVARCHAR(MAX)
	--DECLARE @TDATE NVARCHAR(MAX)
	--SET @FDATE = @ordertime
	--SET @TDATE = @todatetime

	--UPDATE tbl_table_master set status=1,bookingtime=@FDATE+' - '+@TDATE where tid=@tablenoid
	
	SET @kotid = @kot_id
	SET @guest_id = @gid1
	SET @orderid = @order_id
	SET @status = '1'
END





GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomerInfo]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCustomerInfo] 
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@plan_id int,
@reg_date datetime,
@valid_date datetime,
@oname nvarchar(200),
@cname nvarchar(200),
@dob datetime,
@email nvarchar(200),
@cno nvarchar(200),
@mno nvarchar(200),
@address nvarchar(200),
@country nvarchar(200),
@city nvarchar(200),
@zip nvarchar(200),
@status nvarchar(20),
@updated_by int,
@PIN int,
--return values 
@errorCode int output,
@errorMessage nvarchar(max) output
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF EXISTS(SELECT 1 FROM tbl_customer where @cust_id!=cust_id and @mno=mno)
	BEGIN
		SET @errorCode = 2001
		SET @errorMessage = 'Mobile Number Already Exist'
	END

	IF EXISTS(SELECT 1 FROM tbl_customer where @cust_id!=cust_id and @cno=cno)
	BEGIN
		SET @errorCode = 2001
		SET @errorMessage = 'Mobile Number Already Exist'
	END

	IF EXISTS(SELECT 1 FROM tbl_customer where @cust_id!=cust_id and @email=email)
	BEGIN
		SET @errorCode = 2001
		SET @errorMessage = 'Email Address Already Exist'
	END

	UPDATE tbl_customer SET
		plan_id=@plan_id,
		reg_date=@reg_date,
		valid_date=@valid_date,
		oname=@oname,
		cname=@cname,
		dob=@dob,
		email=@email,
		cno=@cno,
		mno=@mno,
		address=@address,
		country=@country,
		city=@city,
		zip=@zip,
		status=@status,
		updated_date=GETDATE(),
		update_by=@updated_by
	WHERE cust_id=@cust_id

		UPDATE  tbl_userlogin SET		
			fname=@cname,
			--lname,
			cno=@cno,
			email=@email,
			city=@city,
			username=@mno,
			pass=@PIN,
			PIN=@PIN,
			status=@status,
			updated_date=GETDATE(),
			update_by = @updated_by
			
		WHERE cust_id=@cust_id and role_id = '1'
			
    -- Insert statements for procedure here
	SET @errorCode = 0
	SET @errorMessage = 'Updated Successfully'
END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = 'Internal Server Error'
END CATCH






GO
/****** Object:  StoredProcedure [dbo].[UpdateGuest]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateGuest] 
	-- Add the parameters for the stored procedure here
	@order_id int,
	@cust_id int,
	@fname nvarchar(200),
	@lname nvarchar(200),
	@email nvarchar(200),
	@cno nvarchar(200),
	@address nvarchar(200),
	@company_name nvarchar(200),
	@country nvarchar(200),
	@vat_code nvarchar(200),
	--Return Values
	@errorCode int output,
	@errorMessage nvarchar(200) output
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Declare @gid int Set @gid = (SELECT top 1 gid FROM tbl_kot_master where order_id=@order_id)
	Declare @kotId int Set @kotId = (SELECT top 1 kot_Id FROM tbl_kot_master where order_id=@order_id)
	 
	IF NOT EXISTS(SELECT 1 FROM tbl_guest_master WHERE gid=@gid)
	BEGIN 
		SET @errorCode = 2002
		SET @errorMessage = 'This Customer is not Exist'
		RETURN
	END 
	IF EXISTS(SELECT 1 FROM tbl_guest_master WHERE cno = @cno)
	BEGIN 
	  
		SET @errorCode = 2003
		SET @errorMessage = 'This Contact No. already Exist'
		RETURN
	END 
	IF EXISTS(SELECT 1 FROM tbl_guest_master WHERE email = @email)
	BEGIN 
	  Declare @gidNew int  Set @gidNew =(SELECT top 1 gid FROM tbl_guest_master where email = @email)

		UPDATE TBL_KOT_MASTER SET gid = @gidNew where kot_id =  @kotId
		SET @gid = @gidNew
		--SET @errorCode = 2002
		--SET @errorMessage = 'This Customer already Exist'
		--RETURN
	END 
	UPDATE  tbl_guest_master
	SET	
		fname = IsNull(@fname,fname),
		lname = IsNull(@lname,lname),
		email=@email,
		cno=IsNull(@cno,cno),
		address=IsNull(@address, address),
		company_name = IsNull(@company_name,company_name),
		vat_code = IsNull(@vat_code,vat_code),
		status=	'1',
		updated_date = getdate(),
		update_by = 1

	WHERE  gid = @gid


    SET @errorCode = 0
	SET @errorMessage = 'Success'
END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = ERROR_MESSAGE()
END CATCH






GO
/****** Object:  StoredProcedure [dbo].[VoidKotCheckOut]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[VoidKotCheckOut] 
 -- Add the parameters for the stored procedure here
(@cust_id int,
 @kot_id int,
 @user_id int,
 @order_id int,
 @void_reason nvarchar(1000),
 
 --return values 
 @errorCode int output,
 @errorMessage nvarchar(max) output)
AS
BEGIN TRY
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 IF  EXISTS(SELECT 1 FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id and status = 0)
 BEGIN
  SET @errorCode = 4004
  SET @errorMessage = 'Already Checkout'
  RETURN 
 END 

 IF NOT EXISTS(SELECT 1 FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id)
 BEGIN
  SET @errorCode = 2001
  SET @errorMessage = 'Not Available'
  return
 END 
 DECLARE @orderid int
 DECLARE @tableid int 
 DECLARE @levelid int
 SET @orderid = (SELECT order_id FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id)
 SET @tableid = (SELECT tid from tbl_booking_master where @orderid = order_id)
 SET @levelid = (SELECT level_id from tbl_booking_master where @orderid = order_id)

 UPDATE TBL_KOT_MASTER SET 
  discount_amnt = 0, 
  special_discount_amnt = 0, 
  tip_amnt=0 , 
  vat_amnt = 0,
  total_amnt = 0,
  void_reason = @void_reason
  ,status = 0
    WHERE 
  KOT_ID = @kot_id and 
  cust_id = @cust_id and 
  created_by = @user_id 

 UPDATE tbl_table_master SET
 status = 0
 WHERE 
  tid=@tableid and
  level_id=@levelid and
  cust_id=@cust_id
 

 UPDATE tbl_booking_master SET
  status=0,hold_status=0
  where order_id=@orderid

 SET @errorCode = 0 
 SET @errorMessage = 'Success'
END TRY
BEGIN CATCH
 SET @errorCode = 5001
 SET @errorMessage = 'Internal Server Error'
END CATCH

/****** Object:  StoredProcedure [dbo].[KotPayBill]    Script Date: 12/31/2016 5:12:44 PM ******/
SET ANSI_NULLS ON






GO
/****** Object:  StoredProcedure [dbo].[VoidKotCheckOutNew]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
Create PROCEDURE [dbo].[VoidKotCheckOutNew] 
 -- Add the parameters for the stored procedure here
(@cust_id int,
 @kot_id int,
 @user_id int,
 @order_id int,
 @void_reason varchar(1000),
 
 --return values 
 @errorCode int output,
 @errorMessage nvarchar(max) output)
AS
BEGIN TRY
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 IF  EXISTS(SELECT 1 FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id and status = 0)
 BEGIN
  SET @errorCode = 4004
  SET @errorMessage = 'Already Checkout'
  RETURN 
 END 

 IF NOT EXISTS(SELECT 1 FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id)
 BEGIN
  SET @errorCode = 2001
  SET @errorMessage = 'Not Available'
  return
 END 
 DECLARE @orderid int
 DECLARE @tableid int 
 DECLARE @levelid int
 SET @orderid = (SELECT order_id FROM tbl_kot_master where @kot_id=kot_id and @user_id = created_by and @cust_id = cust_id)
 SET @tableid = (SELECT tid from tbl_booking_master where @orderid = order_id)
 SET @levelid = (SELECT level_id from tbl_booking_master where @orderid = order_id)

 UPDATE TBL_KOT_MASTER SET 
  discount_amnt = 0, 
  special_discount_amnt = 0, 
  tip_amnt=0 , 
  vat_amnt = 0,
  total_amnt = 0,
  void_reason = @void_reason
  ,status = 0
    WHERE 
  KOT_ID = @kot_id and 
  cust_id = @cust_id and 
  created_by = @user_id 

 UPDATE tbl_table_master SET
 status = 0
 WHERE 
  tid=@tableid and
  level_id=@levelid and
  cust_id=@cust_id
 

 UPDATE tbl_booking_master SET
  status=0,hold_status=0
  where order_id=@orderid

 SET @errorCode = 0 
 SET @errorMessage = 'Success'
END TRY
BEGIN CATCH
 SET @errorCode = 5001
 SET @errorMessage = 'Internal Server Error'
END CATCH

/****** Object:  StoredProcedure [dbo].[KotPayBill]    Script Date: 12/31/2016 5:12:44 PM ******/
SET ANSI_NULLS ON






GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_GetAllCategory]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [QuizprojectUser123].[SP_GetAllCategory]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TopCategoryId,TopCategoryName FROM tbl_TopCategory WHERE TopCategoryId IN
( SELECT TopCategoryId FROM tbl_SecondCategory )
SELECT p.SecondCategoryId , p.SecondCategoryName ,p.TopCategoryId FROM tbl_SecondCategory p
END

GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_GetAllCount]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [QuizprojectUser123].[SP_GetAllCount]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  (
        SELECT COUNT(*)
        FROM   tbl_MerchantInfo Where ActiveStatus=1
        ) AS TotalMerchant,
        (
        SELECT COUNT(*)
        FROM   tbl_MerchantMyUser Where IsActive=1
        ) AS TotalUser,
		(
        SELECT COUNT(*)
        FROM   tbl_ExamConfig Where IsActive=1
        ) AS TotalExams,
		(
        SELECT COUNT(*)
        FROM   tbl_QAManage Where IsActive=1
        ) AS TotalQuestion
END

GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_GetCertificate]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [QuizprojectUser123].[SP_GetCertificate]

 (
 @CertificateId int =0,
 @MerchantId int=0,
 @Event varchar(50)=null
 )

AS
BEGIN
  IF @Event='GetCertificateMID'
    BEGIN
	   SELECT CertificateId,CertificateTitle,CertificatePic FROM tbl_MerchantCertificate
	   WHERE MerchantId=@MerchantId AND IsDelete=0 ORDER BY CertificateId DESC
	END

	 IF @Event='GetCertificateWithCId'
    BEGIN
	   SELECT * FROM tbl_MerchantCertificate
	   WHERE CertificateId=@CertificateId AND IsDelete=0
	END
END
GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_GetExamReport]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [QuizprojectUser123].[SP_GetExamReport]
 (
  @ExamReportId int=0,
  @MerchantId int=0,
  @UserId int=0,
  @Event varchar(20)=null
 )

 AS
 BEGIN
   IF @Event='GetExamRptMID'
     BEGIN
	   SELECT        QuizprojectUser123.tbl_ExamReports.ExamReportId, QuizprojectUser123.tbl_ExamReports.UserId, QuizprojectUser123.tbl_ExamReports.CategoryId, QuizprojectUser123.tbl_ExamReports.ExamId, 
                         QuizprojectUser123.tbl_ExamReports.Result, QuizprojectUser123.tbl_ExamReports.Score, QuizprojectUser123.tbl_ExamReports.AllowPrint, QuizprojectUser123.tbl_ExamReports.DigitalCertificateId, 
                         QuizprojectUser123.tbl_ExamReports.CertificationNo, dbo.tbl_ExamConfig.ExamCode, dbo.tbl_MerchantMyUser.UserName, dbo.tbl_SecondCategory.SecondCategoryName
       FROM            dbo.tbl_SecondCategory INNER JOIN
                         QuizprojectUser123.tbl_ExamReports INNER JOIN
                         dbo.tbl_ExamConfig ON QuizprojectUser123.tbl_ExamReports.ExamId = dbo.tbl_ExamConfig.ExamCodeId INNER JOIN
                         dbo.tbl_MerchantMyUser ON QuizprojectUser123.tbl_ExamReports.UserId = dbo.tbl_MerchantMyUser.UserId ON dbo.tbl_SecondCategory.SecondCategoryId = QuizprojectUser123.tbl_ExamReports.CategoryId
						 WHERE QuizprojectUser123.tbl_ExamReports.MerchantId=@MerchantId AND QuizprojectUser123.tbl_ExamReports.IsDelete=0 
						 ORDER BY QuizprojectUser123.tbl_ExamReports.ExamReportId DESC
	 END

	 IF @Event='GetExRptWithUid'
     BEGIN

	   SELECT        tbl_ExamReports.ExamReportId, tbl_ExamReports.ExamGivenDate, dbo.tbl_ExamConfig.ExamCode, dbo.tbl_SecondCategory.SecondCategoryName, tbl_ExamReports.Score, tbl_ExamReports.Result, 
                         tbl_ExamReports.AllowPrint, tbl_ExamReports.DigitalCertificateId
FROM            tbl_ExamReports INNER JOIN
                         dbo.tbl_ExamConfig ON tbl_ExamReports.ExamId = dbo.tbl_ExamConfig.ExamCodeId INNER JOIN
                         dbo.tbl_SecondCategory ON dbo.tbl_ExamConfig.SecondCategoryId = dbo.tbl_SecondCategory.SecondCategoryId
						 WHERE tbl_ExamReports.UserId=@UserId And tbl_ExamReports.IsDelete=0 
						 ORDER BY tbl_ExamReports.ExamReportId DESC
	 END

	 IF @Event='GetExamRptID'
     BEGIN
	   SELECT        QuizprojectUser123.tbl_ExamReports.ExamReportId, QuizprojectUser123.tbl_ExamReports.UserId, QuizprojectUser123.tbl_ExamReports.CategoryId, QuizprojectUser123.tbl_ExamReports.ExamId, 
                         QuizprojectUser123.tbl_ExamReports.Result, QuizprojectUser123.tbl_ExamReports.Score, QuizprojectUser123.tbl_ExamReports.AllowPrint, QuizprojectUser123.tbl_ExamReports.DigitalCertificateId, 
                         QuizprojectUser123.tbl_ExamReports.CertificationNo, dbo.tbl_ExamConfig.ExamCode, dbo.tbl_MerchantMyUser.UserName, dbo.tbl_SecondCategory.SecondCategoryName
       FROM            dbo.tbl_SecondCategory INNER JOIN
                         QuizprojectUser123.tbl_ExamReports INNER JOIN
                         dbo.tbl_ExamConfig ON QuizprojectUser123.tbl_ExamReports.ExamId = dbo.tbl_ExamConfig.ExamCodeId INNER JOIN
                         dbo.tbl_MerchantMyUser ON QuizprojectUser123.tbl_ExamReports.UserId = dbo.tbl_MerchantMyUser.UserId ON dbo.tbl_SecondCategory.SecondCategoryId = QuizprojectUser123.tbl_ExamReports.CategoryId
						 WHERE QuizprojectUser123.tbl_ExamReports.ExamReportId=@ExamReportId AND QuizprojectUser123.tbl_ExamReports.IsDelete=0 
						 ORDER BY QuizprojectUser123.tbl_ExamReports.ExamReportId DESC
	 END
 END
GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_GetFinanceConfig]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [QuizprojectUser123].[SP_GetFinanceConfig]
 (
 @FinanceConfigId int=0,
 @MerchantId int=0,
 @Event nvarchar(20)=null
 )
AS
BEGIN
  IF @Event='GetAllWithMId'
     BEGIN
		SELECT        tbl_MerchantFinanceConfig.FinanceConfigId, dbo.tbl_PaymentOption.PaymentOption, tbl_MerchantFinanceConfig.PaymentOptionId, 
                         tbl_MerchantFinanceConfig.MerchantId, tbl_MerchantFinanceConfig.AccountEmail, tbl_MerchantFinanceConfig.FirstName, 
                         tbl_MerchantFinanceConfig.LastName, tbl_MerchantFinanceConfig.Country, tbl_MerchantFinanceConfig.City, 
                         tbl_MerchantFinanceConfig.BankOfName, tbl_MerchantFinanceConfig.SwiftCode
        FROM            tbl_MerchantFinanceConfig INNER JOIN
                         dbo.tbl_PaymentOption ON tbl_MerchantFinanceConfig.PaymentOptionId = dbo.tbl_PaymentOption.PaymentOptionId
         WHERE tbl_MerchantFinanceConfig.MerchantId=@MerchantId AND tbl_MerchantFinanceConfig.IsDelete=0 
		  ORDER BY tbl_MerchantFinanceConfig.FinanceConfigId DESC
     END

	 IF @Event='GetAllWithFCId'
     BEGIN
		SELECT        tbl_MerchantFinanceConfig.FinanceConfigId, dbo.tbl_PaymentOption.PaymentOption, tbl_MerchantFinanceConfig.PaymentOptionId, 
                         tbl_MerchantFinanceConfig.MerchantId, tbl_MerchantFinanceConfig.AccountEmail, tbl_MerchantFinanceConfig.FirstName, 
                         tbl_MerchantFinanceConfig.LastName, tbl_MerchantFinanceConfig.Country, tbl_MerchantFinanceConfig.City, 
                         tbl_MerchantFinanceConfig.BankOfName, tbl_MerchantFinanceConfig.SwiftCode
        FROM            tbl_MerchantFinanceConfig INNER JOIN
                         dbo.tbl_PaymentOption ON tbl_MerchantFinanceConfig.PaymentOptionId = dbo.tbl_PaymentOption.PaymentOptionId
         WHERE tbl_MerchantFinanceConfig.FinanceConfigId=@FinanceConfigId AND tbl_MerchantFinanceConfig.IsDelete=0
     END
END
GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_GETQA]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [QuizprojectUser123].[SP_GETQA]
 (
  @QAId int=0,
  @MerchantId int=0,
  @Searchtext nvarchar(100)=null,
  @Event nvarchar(20)=null
 )
 AS
 BEGIN
   IF @Event='GetQAWMId'
   BEGIN Declare @SQLQuery AS NVarchar(4000)
	  Declare @ParamDefinition AS NVarchar(2000) 
	  Set @SQLQuery ='SELECT        QuizprojectUser123.tbl_QAManage.QAId, QuizprojectUser123.tbl_QAManage.Question, dbo.tbl_QuestionType.QuestionType, dbo.tbl_ExamConfig.ExamCode
FROM            dbo.tbl_ExamConfig INNER JOIN
                         QuizprojectUser123.tbl_QAManage ON dbo.tbl_ExamConfig.ExamCodeId = QuizprojectUser123.tbl_QAManage.ExamCodeId INNER JOIN
                         dbo.tbl_QuestionType ON QuizprojectUser123.tbl_QAManage.QuestionTypeId = dbo.tbl_QuestionType.QuestionTypeId WHERE QuizprojectUser123.tbl_QAManage.MerchantId=@MerchantId AND QuizprojectUser123.tbl_QAManage.IsDelete=0 '
			If @Searchtext Is Not Null 
					 Set @SQLQuery = @SQLQuery + ' And (dbo.tbl_ExamConfig.ExamCode LIKE ''%''+@Searchtext+''%'')'
					  Set @ParamDefinition =      ' @Searchtext NVarchar(100),@MerchantId int'

Set @SQLQuery = @SQLQuery + ' ORDER BY QuizprojectUser123.tbl_QAManage.QAId DESC'
		  Execute sp_Executesql     @SQLQuery, @ParamDefinition, 
                @Searchtext,@MerchantId
--       SELECT        tbl_QAManage.QAId, tbl_QAManage.Question, dbo.tbl_QuestionType.QuestionType
--FROM            tbl_QAManage INNER JOIN
--                         dbo.tbl_QuestionType ON tbl_QAManage.QuestionTypeId = dbo.tbl_QuestionType.QuestionTypeId WHERE tbl_QAManage.MerchantId=@MerchantId AND tbl_QAManage.IsDelete=0
   END

   IF @Event='GetQAWMIdandSearch'
   BEGIN
       SELECT        tbl_QAManage.QAId, tbl_QAManage.Question, dbo.tbl_QuestionType.QuestionType
FROM            tbl_QAManage INNER JOIN
                         dbo.tbl_QuestionType ON tbl_QAManage.QuestionTypeId = dbo.tbl_QuestionType.QuestionTypeId WHERE tbl_QAManage.MerchantId=@MerchantId AND tbl_QAManage.Question like '%'+@Searchtext+'%' AND tbl_QAManage.IsDelete=0 
						  ORDER BY QuizprojectUser123.tbl_QAManage.QAId DESC
   END

   IF @Event='GetQAwithQId'
   BEGIN
       SELECT       tbl_QAManage.QAId,tbl_QAManage.ExamCodeId,tbl_QAManage.QuestionTypeId,tbl_QAManage.Score, 
                        tbl_QAManage.Question,tbl_QAManage.NoofAnswer,tbl_QAManage.Explanation,tbl_QAManage.MerchantId, 
                        tbl_QAnswer.AnswerId,tbl_QAnswer.Answer,tbl_QAnswer.RightAnswer,
						tbl_QAManage.Exhibit,tbl_QAManage.Topology,tbl_QAManage.Scenario
FROM           tbl_QAManage INNER JOIN
                        tbl_QAnswer ON tbl_QAManage.QAId =tbl_QAnswer.QuestionId WHERE tbl_QAManage.QAId=@QAId AND tbl_QAManage.IsDelete=0 AND tbl_QAnswer.IsDelete=0
   END
END
GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_GetTemplate]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [QuizprojectUser123].[SP_GetTemplate]

 (
 @TemplateId int =0,
 @MerchantId int=0,
 @Event varchar(20)=null
 )

AS
BEGIN
  IF @Event='GetTemplateMID'
    BEGIN
	   SELECT TemplateId,CertificateTitle,TemplatePicture FROM tbl_Template
	   WHERE MerchantId=@MerchantId AND IsDelete=0 ORDER BY TemplateId DESC
	END

	 IF @Event='GetTemplateWithTId'
    BEGIN
	   SELECT TemplateId,CertificateTitle,TemplatePicture FROM tbl_Template
	   WHERE TemplateId=@TemplateId AND IsDelete=0
	END
END
GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_IUDAnswer]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [QuizprojectUser123].[SP_IUDAnswer]
 (
  @AnswerId int=0,
  @Answer nvarchar(Max)=null,
  @QuestionId int=0,
  @RightAnswer nchar(50)=null,
  @IsActive bit=1,
  @IsDelete bit=0,
  @CreatedBy int=0,
  @CreatedDate datetime=null,
  @UpdatedBy int=0,
  @UpdatedDate datetime=null,
  @Event nvarchar(20)=null,
  @returnvalue int=0 OUTPUT
 )

 AS
 BEGIN
   IF @Event='Insert'
   BEGIN
       --INSERT INTO tbl_QAnswer (Answer,QuestionId,RightAnswer,IsActive,IsDelete,CreatedBy,CreatedDate) 
	      --          VALUES (@Answer,@QuestionId,@RightAnswer,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)

       SET @returnvalue=1; ---Insert Record
   END
   IF @Event='Update'
   BEGIN
       UPDATE tbl_QAnswer SET Answer=@Answer,QuestionId=@QuestionId,RightAnswer=@RightAnswer,IsActive=@IsActive,
						UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate

						WHERE AnswerId=@AnswerId

       SET @returnvalue=2 ---Update Record
   END
   IF @Event='Delete'
   BEGIN
       UPDATE tbl_QAnswer SET IsDelete=@IsDelete,
						UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate
						WHERE QuestionId=@QuestionId

       SET @returnvalue=3 ---Delete Record
   END
END
GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_IUDCertificate]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [QuizprojectUser123].[SP_IUDCertificate]
 (
  @CertificateId int=0,
  @CertificateTitle nvarchar(50)=null,
  @CertificatePic nvarchar(200)=null,
   @NameBox nvarchar(200)=null,
    @DateBox nvarchar(200)=null,
  @SampleUserName nvarchar(50)=null,
  @MerchantId int=0,
  @IsActive bit=1,
  @IsDelete bit=0,
  @CreatedBy int=0,
  @CreatedDate datetime=null,
  @UpdatedBy int=0,
  @UpdatedDate datetime=null,
  @Event char(20)=null,
  @retrunValue int=0 output
 )
 AS 
 BEGIN
       IF @Event='Insert'
		   BEGIN
				INSERT INTO tbl_MerchantCertificate (CertificateTitle,CertificatePic,NameBox,DateBox,SampleUserName,MerchantId,IsActive,IsDelete,CreatedBy,CreatedDate)
								VALUES (@CertificateTitle,@CertificatePic,@NameBox,@DateBox,@SampleUserName,@MerchantId,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)

		   SET @retrunValue=1 --Insert Record
	   END

	   IF @Event='Update'
		   BEGIN
				UPDATE tbl_MerchantCertificate SET CertificateTitle=@CertificateTitle,SampleUserName=@SampleUserName,
				            CertificatePic=@CertificatePic,NameBox=@NameBox,DateBox=@DateBox,IsActive=@IsActive,UpdatedBy=@UpdatedBy,
							UpdatedDate=@UpdatedDate
                WHERE  CertificateId=@CertificateId

		   SET @retrunValue=2 --Update Record
	   END

	   IF @Event='Delete'
		   BEGIN
				UPDATE tbl_MerchantCertificate SET IsDelete=@IsDelete,UpdatedBy=@UpdatedBy,
							UpdatedDate=@UpdatedDate
                WHERE  CertificateId=@CertificateId

		   SET @retrunValue=3 --Delete Record
	   END
 END
GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_IUDFinanceConfig]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [QuizprojectUser123].[SP_IUDFinanceConfig]
	(
	  @FinanceConfigId int=0,
	  @PaymentOptionId int=0,
	  @MerchantId int=0,
	  @AccountEmail nvarchar(50)=null,
	  @FirstName nvarchar(50)=null,
	  @LastName nvarchar(50)=null,
	  @Country nvarchar(50)=null,
	  @City nvarchar(50)=null,
	  @BankOfName nvarchar(50)=null,
	  @SwiftCode nvarchar(50),
	  @IsActive bit=1,
	  @IsDelete bit=0,
	  @CreatedBy int=0,
	  @CreatedDate datetime=null,
	  @UpdatedBy int=0,
	  @UpdatedDate datetime=null,
	  @Event nvarchar(20)=null,
	  @returnValue int output
	)

 AS
 BEGIN
    IF @Event='Insert'
	BEGIN
	    INSERT INTO tbl_MerchantFinanceConfig (PaymentOptionId,MerchantId,
		     AccountEmail,FirstName,LastName,Country,City,BankOfName,
			 SwiftCode,IsActive,IsDelete,CreatedBy,CreatedDate)
		  VALUES    (@PaymentOptionId,@MerchantId,@AccountEmail,@FirstName,
		  @LastName,@Country,@City,@BankOfName,@SwiftCode,@IsActive,@IsDelete,
		  @CreatedBy,@CreatedDate)

		  SET @returnValue=1 -- Record Insert Success
	END

	IF @Event='Update'
	BEGIN
	    UPDATE tbl_MerchantFinanceConfig SET PaymentOptionId=@PaymentOptionId,
		     AccountEmail=@AccountEmail,FirstName=@FirstName,LastName=@LastName,
			 Country=@Country,City=@City,BankOfName=@BankOfName,SwiftCode=@SwiftCode,
			 UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate
	    WHERE FinanceConfigId=@FinanceConfigId

		SET @returnValue=2 -- Record Update Success
	END
 END
GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_IUDQA]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [QuizprojectUser123].[SP_IUDQA]
 (
  @QAId int=0,
  @ExamCodeId int=0,
  @ExamCode nvarchar(50)=null,
  @QuestionTypeId int=0,
  @Score decimal(18,2)=null,
  @Question nvarchar(MAX)=null,
  @NoofAnswer int=0,
  @Explanation nvarchar(MAX)=null,
  @MerchantId int=0,
  @IsActive bit=1,
  @IsDelete bit=0,
  @CreatedBy int=0,
  @CreatedDate datetime=null,
  @UpdatedBy int=0,
  @UpdatedDate datetime=null,
  @Event nvarchar(20)=null,
  @Resource nvarchar(max)=null,
  @Exhibit nvarchar(max)=null,
  @Topology nvarchar(max)=null,
  @Scenario nvarchar(max)=null,
  @returnvalue int=0 OUTPUT
 )

 AS
 BEGIN
   IF @Event='Insert'
   BEGIN
     --  INSERT INTO tbl_QAManage (ExamCodeId,ExamCode,QuestionTypeId,Score,Question,NoofAnswer,
	    --                Explanation,MerchantId,Resource,Exhibit,Topology,Scenario,IsActive,IsDelete,CreatedBy,CreatedDate) 
	    --            VALUES (@ExamCodeId,@ExamCode,@QuestionTypeId,@Score,@Question,@NoofAnswer,@Explanation,@MerchantId,
					--@Resource,@Exhibit,@Topology,@Scenario,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)

       SET @returnvalue=1;--SCOPE_IDENTITY(); ---Insert Record
   END
   IF @Event='Update'
   BEGIN
       UPDATE tbl_QAManage SET ExamCodeId=@ExamCodeId,ExamCode=@ExamCode,QuestionTypeId=@QuestionTypeId,
	                      Score=@Score,Question=@Question,NoofAnswer=@NoofAnswer,
	                    Explanation=@Explanation,MerchantId=@MerchantId,
						Exhibit=@Exhibit,Topology=@Topology,Scenario=@Scenario,IsActive=@IsActive,
						UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate

						WHERE QAId=@QAId

       SET @returnvalue=2 ---Update Record
   END
   IF @Event='Delete'
   BEGIN
       UPDATE tbl_QAManage SET IsDelete=@IsDelete,
						UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate
						WHERE QAId=@QAId

       SET @returnvalue=3 ---Delete Record
   END
END
GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_IUDReports]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [QuizprojectUser123].[SP_IUDReports]
 (
  @ExamReportId int=0,
  @UserId int=0,
  @CategoryId  int=0,
  @ExamId int=0,
  @Result bit=1,
  @Score decimal(18,2)=null,
  @OutofScore decimal(18,2)=null,
  @AllowPrint bit=1,
  @DigitalCertificateId int=0,
  @CertificationNo int=0,
  @ExamGivenDate datetime=null,
  @MerchantId int=0,
  @IsActive bit=1,
  @IsDelete bit=0,
  @CreatedBy int=0,
  @CreatedDate datetime=null,
  @UpdatedBy int=0,
  @UpdatedDate datetime=null,
  @Event nvarchar(20)=null,
  @returnvalue int=0 OUTPUT
 )

 AS
 BEGIN
   IF @Event='Insert'
   BEGIN
      INSERT INTO [QuizprojectUser123].[tbl_ExamReports]
           ([UserId],[CategoryId],[ExamId],[Result]
           ,[Score]
           ,[OutofScore]
           ,[AllowPrint]
           ,[DigitalCertificateId]
           ,[CertificationNo]
           ,[ExamGivenDate]
           ,[MerchantId]
           ,[IsActive]
           ,[IsDelete]
           ,[CreatedBy]
           ,[CreatedDate])
     VALUES
           (@UserId
           ,@CategoryId
           ,@ExamId
           ,@Result
           ,@Score
           ,@OutofScore
           ,@AllowPrint
           ,@DigitalCertificateId
           ,@CertificationNo
           ,@ExamGivenDate
           ,@MerchantId
           ,@IsActive
           ,@IsDelete
           ,@CreatedBy
           ,@CreatedDate)

       SET @returnvalue=SCOPE_IDENTITY(); ---Insert Record
   END
END
GO
/****** Object:  StoredProcedure [QuizprojectUser123].[SP_IUDTemplate]    Script Date: 2/7/2018 6:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [QuizprojectUser123].[SP_IUDTemplate]
 (
  @TemplateId int=0,
  @CertificateTitle nvarchar(50)=null,
  @SampleUserName nvarchar(50)=null,
  @TemplatePicture nvarchar(200)=null,
  @MerchantId int=0,
  @IsActive bit=1,
  @IsDelete bit=0,
  @CreatedBy int=0,
  @CreatedDate datetime=null,
  @UpdatedBy int=0,
  @UpdatedDate datetime=null,
  @Event char(20)=null,
  @retrunValue int=0 output
 )
 AS 
 BEGIN
       IF @Event='Insert'
		   BEGIN
				INSERT INTO tbl_Template (CertificateTitle,SampleUserName,TemplatePicture,MerchantId,IsActive,IsDelete,CreatedBy,CreatedDate)
								VALUES (@CertificateTitle,@SampleUserName,@TemplatePicture,@MerchantId,@IsActive,@IsDelete,@CreatedBy,@CreatedDate)

		   SET @retrunValue=1 --Insert Record
	   END

	   IF @Event='Update'
		   BEGIN
				UPDATE tbl_Template SET CertificateTitle=@CertificateTitle,SampleUserName=@SampleUserName,
				            TemplatePicture=@TemplatePicture,IsActive=@IsActive,UpdatedBy=@UpdatedBy,
							UpdatedDate=@UpdatedDate
                WHERE  TemplateId=@TemplateId

		   SET @retrunValue=2 --Update Record
	   END

	   IF @Event='Delete'
		   BEGIN
				UPDATE tbl_Template SET IsDelete=@IsDelete,UpdatedBy=@UpdatedBy,
							UpdatedDate=@UpdatedDate
                WHERE  TemplateId=@TemplateId

		   SET @retrunValue=3 --Delete Record
	   END
 END
GO
USE [master]
GO
ALTER DATABASE [mobi96_Quizproject] SET  READ_WRITE 
GO
