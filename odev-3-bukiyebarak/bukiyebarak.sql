USE [GraduatesStored]
GO
/****** Object:  UserDefinedFunction [dbo].[func_CalculateNetSalary]    Script Date: 15.07.2022 20:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[func_CalculateNetSalary]
(
	@price decimal
)
RETURNS decimal
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result decimal;
	set @result=@price + (@price*20/100);
	

	-- Return the result of the function
	RETURN @result

END
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 15.07.2022 20:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personelId] [int] NOT NULL,
	[tel_number] [nvarchar](11) NULL,
	[mail] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work]    Script Date: 15.07.2022 20:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personelId] [int] NOT NULL,
	[company] [nvarchar](50) NULL,
	[position] [nvarchar](50) NULL,
	[salary] [int] NULL,
 CONSTRAINT [PK__WorkInfo__3213E83F42FFD5A0] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 15.07.2022 20:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[student_number] [nvarchar](5) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[birhtday] [date] NULL,
	[gender] [nvarchar](50) NULL,
 CONSTRAINT [PK__Personal__3213E83F1A78C099] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 15.07.2022 20:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personelId] [int] NOT NULL,
	[faculty] [nvarchar](50) NOT NULL,
	[department] [nvarchar](50) NOT NULL,
	[diploma_grade] [nvarchar](3) NULL,
	[finish_date] [date] NULL,
 CONSTRAINT [PK_EducationInformation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_PersonalReport]    Script Date: 15.07.2022 20:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[view_PersonalReport]
as
	select 
		pers.first_name,
		pers.last_name,
		edu.department,
		edu.diploma_grade,
		cont.tel_number,
		cont.mail,
		work.company,
		work.position,
		work.salary,
		(work.salary-560) as old_salary
	from [Personal] pers
	inner join Education edu on edu.personelId=pers.id
	inner join Contact cont on cont.personelId=edu.personelId
	inner join Work work on work.personelId=pers.id
GO
/****** Object:  UserDefinedFunction [dbo].[func_PersonalAndWork]    Script Date: 15.07.2022 20:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[func_PersonalAndWork]
(	
	
)
RETURNS TABLE 
AS
RETURN 
(
	select 
	pers.first_name,
	pers.last_name,
	wrk.position,
	wrk.salary
	from Personal pers
	inner join Work wrk on pers.id=wrk.personelId
)
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([id], [personelId], [tel_number], [mail], [city]) VALUES (1, 2, N'54555555555', N'alidemir@gmail.com', NULL)
INSERT [dbo].[Contact] ([id], [personelId], [tel_number], [mail], [city]) VALUES (2, 3, NULL, N'emrekaat@gmail.com', NULL)
INSERT [dbo].[Contact] ([id], [personelId], [tel_number], [mail], [city]) VALUES (3, 4, N'54577799985', N'aysebulut@gmail.com', N'Ankara')
INSERT [dbo].[Contact] ([id], [personelId], [tel_number], [mail], [city]) VALUES (4, 5, N'55555555555', N'zeynep@gmail.com', N'İstanbul')
INSERT [dbo].[Contact] ([id], [personelId], [tel_number], [mail], [city]) VALUES (5, 6, N'53278912345', N'kardelenduru@gmail.com', N'İzmir')
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Education] ON 

INSERT [dbo].[Education] ([id], [personelId], [faculty], [department], [diploma_grade], [finish_date]) VALUES (1, 2, N'MÜHENDİSLİK', N'BİLGİSAYAR', N'80 ', CAST(N'2020-06-14' AS Date))
INSERT [dbo].[Education] ([id], [personelId], [faculty], [department], [diploma_grade], [finish_date]) VALUES (3, 3, N'MÜHENDİSLİK', N'MAKİNE', N'90 ', CAST(N'2021-06-06' AS Date))
INSERT [dbo].[Education] ([id], [personelId], [faculty], [department], [diploma_grade], [finish_date]) VALUES (4, 4, N'MÜHENDİSİLİK', N'ELEKTRONİK', N'50 ', CAST(N'2020-10-06' AS Date))
INSERT [dbo].[Education] ([id], [personelId], [faculty], [department], [diploma_grade], [finish_date]) VALUES (7, 5, N'MİMARLIK', N'MİMAR', N'75 ', CAST(N'2022-10-10' AS Date))
INSERT [dbo].[Education] ([id], [personelId], [faculty], [department], [diploma_grade], [finish_date]) VALUES (8, 6, N'MİMARLIK', N'MİMAR', N'60 ', CAST(N'2020-06-04' AS Date))
SET IDENTITY_INSERT [dbo].[Education] OFF
GO
SET IDENTITY_INSERT [dbo].[Personal] ON 

INSERT [dbo].[Personal] ([id], [student_number], [first_name], [last_name], [birhtday], [gender]) VALUES (2, N'12334', N'ALI', N'DEMIR', CAST(N'1999-05-10' AS Date), N'E')
INSERT [dbo].[Personal] ([id], [student_number], [first_name], [last_name], [birhtday], [gender]) VALUES (3, N'11111', N'EMRE', N'KAAT', CAST(N'1999-02-06' AS Date), N'E')
INSERT [dbo].[Personal] ([id], [student_number], [first_name], [last_name], [birhtday], [gender]) VALUES (4, N'22222', N'AYŞE', N'BULUT', CAST(N'1998-05-03' AS Date), N'K')
INSERT [dbo].[Personal] ([id], [student_number], [first_name], [last_name], [birhtday], [gender]) VALUES (5, N'33333', N'ZEYNEP', N'POLAT', CAST(N'1997-06-10' AS Date), N'K')
INSERT [dbo].[Personal] ([id], [student_number], [first_name], [last_name], [birhtday], [gender]) VALUES (6, N'44444', N'KARDELEN', N'DURU', CAST(N'1995-07-12' AS Date), N'K')
INSERT [dbo].[Personal] ([id], [student_number], [first_name], [last_name], [birhtday], [gender]) VALUES (8, N'55555', N'MEHMET', N'KURU', CAST(N'1998-10-12' AS Date), N'E')
INSERT [dbo].[Personal] ([id], [student_number], [first_name], [last_name], [birhtday], [gender]) VALUES (11, N'spNum', N'spName', N'spLastName', NULL, NULL)
INSERT [dbo].[Personal] ([id], [student_number], [first_name], [last_name], [birhtday], [gender]) VALUES (12, N'00000', N'Mert', N'Kara', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Personal] OFF
GO
SET IDENTITY_INSERT [dbo].[Work] ON 

INSERT [dbo].[Work] ([id], [personelId], [company], [position], [salary]) VALUES (1, 2, N'BalGrup', N'Müdür', 10000)
INSERT [dbo].[Work] ([id], [personelId], [company], [position], [salary]) VALUES (2, 3, N'BalGrup', N'Mühendis', 8000)
INSERT [dbo].[Work] ([id], [personelId], [company], [position], [salary]) VALUES (3, 4, N'Enoca', N'Mühendis', 9000)
INSERT [dbo].[Work] ([id], [personelId], [company], [position], [salary]) VALUES (4, 5, N'ASNC ', N'Mimar', 10000)
INSERT [dbo].[Work] ([id], [personelId], [company], [position], [salary]) VALUES (5, 6, N'Enoca', N'Mimar', 8000)
SET IDENTITY_INSERT [dbo].[Work] OFF
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_PersonalInformation] FOREIGN KEY([personelId])
REFERENCES [dbo].[Personal] ([id])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_PersonalInformation]
GO
ALTER TABLE [dbo].[Education]  WITH CHECK ADD  CONSTRAINT [FK_EducationInformation_PersonalInformation] FOREIGN KEY([personelId])
REFERENCES [dbo].[Personal] ([id])
GO
ALTER TABLE [dbo].[Education] CHECK CONSTRAINT [FK_EducationInformation_PersonalInformation]
GO
ALTER TABLE [dbo].[Work]  WITH CHECK ADD  CONSTRAINT [FK_Work_Personal] FOREIGN KEY([personelId])
REFERENCES [dbo].[Personal] ([id])
GO
ALTER TABLE [dbo].[Work] CHECK CONSTRAINT [FK_Work_Personal]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateAndListPerson]    Script Date: 15.07.2022 20:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CreateAndListPerson]
	-- Add the parameters for the stored procedure here
	@PersonStudentNumber nvarchar(5),
	@PersonName nvarchar(50),
	@PersonSurname nvarchar(50)

AS
BEGIN
-- Insert statements for procedure here
	insert into Personal(student_number,first_name,last_name)
	values(@PersonStudentNumber,@PersonName,@PersonSurname)
	
	SELECT * from Personal
END
GO
