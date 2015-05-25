USE [DiningManagementSystem]
GO
/****** Object:  StoredProcedure [dbo].[USPBalances]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USPBalances]

AS
BEGIN
SELECT * FROM balanceEntryTable
END
GO
/****** Object:  StoredProcedure [dbo].[USPBalanceUpdation]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USPBalanceUpdation]
(
@memberId int,
@balance int,
@mealEntryDate date
)
AS
 BEGIN
   UPDATE balanceEntryTable 
   SET balance=@balance,
    mealEntryDate=@mealEntryDate
   WHERE memberId=@memberId
 END

GO
/****** Object:  StoredProcedure [dbo].[uspBazarCost]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspBazarCost]
AS
BEGIN
SELECT * FROM bazarCostTable
END
GO
/****** Object:  StoredProcedure [dbo].[USPDeletionFromBalance]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USPDeletionFromBalance]
@memberId int
As
 Begin
   DELETE FROM balanceEntryTable WHERE memberId=@memberId
End

GO
/****** Object:  StoredProcedure [dbo].[USPDeletionFromBazarCost]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USPDeletionFromBazarCost]
@id int
As
 Begin
   DELETE FROM bazarCostTable WHERE id=@id
End

GO
/****** Object:  StoredProcedure [dbo].[USPDeletionFromMeal]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USPDeletionFromMeal]
@memberId int
As
 Begin
   DELETE FROM mealEntryTable WHERE memberId=@memberId
End

GO
/****** Object:  StoredProcedure [dbo].[USPDeletionOfMember]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USPDeletionOfMember]
@memberId int
As
 Begin
   DELETE FROM memberCodeTable WHERE memberId=@memberId
End

GO
/****** Object:  StoredProcedure [dbo].[USPInsertIntoBalance]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USPInsertIntoBalance]
(
@memberId int,
@balance int,
@balanceEntryDate date
)
AS
BEGIN
INSERT INTO balanceEntryTable(memberId,balance,balanceEntryDate)
VALUES(@memberId,@balance,@balanceEntryDate)
END
GO
/****** Object:  StoredProcedure [dbo].[USPInsertIntoBazar]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USPInsertIntoBazar]
(
@amount int,
@date date
)
AS
BEGIN
INSERT INTO bazarCostTable(amount,date)
VALUES(@amount,@date)
END
GO
/****** Object:  StoredProcedure [dbo].[USPInsertIntoMeal]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USPInsertIntoMeal]
(
@memberId int,
@noOfMeals int,
@mealEntryDate date
)
AS
BEGIN
INSERT INTO mealEntryTable(memberId,noOfMeals,mealEntryDate)
VALUES(@memberId,@noOfMeals,@mealEntryDate)
END
GO
/****** Object:  StoredProcedure [dbo].[USPInsertIntoMemberCode]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USPInsertIntoMemberCode]
(
@memberName nvarchar(50),
@roomNo nvarchar(50),
@address nvarchar(50),
@dateOfEntry date
)
AS
BEGIN

INSERT INTO memberCodeTable(memberName,roomNo,address,dateOfEntry)
VALUES(@memberName,@roomNo,@address,@dateOfEntry)

END

GO
/****** Object:  StoredProcedure [dbo].[uspLogin]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspLogin]
(
@userName nvarchar(50),
@password nvarchar(50)
)
AS
BEGIN
 SELECT * 
 FROM loginTable
 WHERE  userName=@userName And password =@password 
END

GO
/****** Object:  StoredProcedure [dbo].[USPMealEntries]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USPMealEntries]
AS
BEGIN
SELECT * FROM mealEntryTable
END

GO
/****** Object:  StoredProcedure [dbo].[USPMemberInfoUpdation]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USPMemberInfoUpdation]
(
@memberId int,
@memberName nvarchar(50),
@roomNo nvarchar(50),
@address nvarchar(50),
@dateOfEntry date
)
AS
 BEGIN
   UPDATE memberCodeTable 
   SET memberName=@memberName,
   roomNo=@roomNo,
   address=@address,
   dateOfEntry=@dateOfEntry
   
   WHERE memberId=@memberId
 END

GO
/****** Object:  StoredProcedure [dbo].[uspMembers]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMembers]

AS
BEGIN
SELECT * FROM dbo.memberCodeTable
END

GO
/****** Object:  StoredProcedure [dbo].[USPPasswordUpdation]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USPPasswordUpdation]
(
@userName nvarchar(50),
@password nvarchar(50)
)
AS
 BEGIN
   UPDATE loginTable 
   SET password=@password    
   WHERE userName=@userName
 END

GO
/****** Object:  Table [dbo].[balanceEntryTable]    Script Date: 5/24/2015 12:02:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[balanceEntryTable](
	[memberId] [int] NOT NULL,
	[balance] [int] NOT NULL,
	[balanceEntryDate] [date] NOT NULL,
 CONSTRAINT [PK_balanceEntryTable] PRIMARY KEY CLUSTERED 
(
	[memberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bazarCostTable]    Script Date: 5/24/2015 12:02:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bazarCostTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[amount] [int] NOT NULL,
	[date] [date] NOT NULL,
 CONSTRAINT [PK_bazarCostTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[loginTable]    Script Date: 5/24/2015 12:02:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loginTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_loginTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[mealEntryTable]    Script Date: 5/24/2015 12:02:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mealEntryTable](
	[memberId] [int] NOT NULL,
	[noOfMeals] [int] NOT NULL,
	[mealEntryDate] [date] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[memberCodeTable]    Script Date: 5/24/2015 12:02:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[memberCodeTable](
	[memberId] [int] IDENTITY(1,1) NOT NULL,
	[memberName] [nvarchar](50) NOT NULL,
	[roomNo] [nvarchar](50) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[dateOfEntry] [date] NOT NULL,
 CONSTRAINT [PK_memberCodeTable] PRIMARY KEY CLUSTERED 
(
	[memberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO