USE [EmployeeDB]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 3/27/2019 7:01:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 3/27/2019 7:01:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[Salary] [int] NULL,
	[DepartmentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeesUpdated]    Script Date: 3/27/2019 7:01:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesUpdated](
	[code] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NULL,
	[gender] [nvarchar](50) NULL,
	[annualSalary] [decimal](18, 3) NULL,
PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([ID], [Name], [Location]) VALUES (1, N'IT', N'New York')
INSERT [dbo].[Departments] ([ID], [Name], [Location]) VALUES (2, N'HR', N'London')
INSERT [dbo].[Departments] ([ID], [Name], [Location]) VALUES (3, N'Payroll', N'Sydney')
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([ID], [FirstName], [LastName], [Gender], [Salary], [DepartmentId]) VALUES (1, N'Mark', N'Hastings', N'Male', 60000, 1)
INSERT [dbo].[Employees] ([ID], [FirstName], [LastName], [Gender], [Salary], [DepartmentId]) VALUES (2, N'Steve', N'Pound', N'Male', 45000, 3)
INSERT [dbo].[Employees] ([ID], [FirstName], [LastName], [Gender], [Salary], [DepartmentId]) VALUES (3, N'Ben', N'Hoskins', N'Male', 70000, 1)
INSERT [dbo].[Employees] ([ID], [FirstName], [LastName], [Gender], [Salary], [DepartmentId]) VALUES (4, N'Philip', N'Hastings', N'Male', 45000, 2)
INSERT [dbo].[Employees] ([ID], [FirstName], [LastName], [Gender], [Salary], [DepartmentId]) VALUES (5, N'Mary', N'Lambeth', N'Female', 30000, 2)
INSERT [dbo].[Employees] ([ID], [FirstName], [LastName], [Gender], [Salary], [DepartmentId]) VALUES (6, N'Valarie', N'Vikings', N'Female', 35000, 3)
INSERT [dbo].[Employees] ([ID], [FirstName], [LastName], [Gender], [Salary], [DepartmentId]) VALUES (7, N'John', N'Stanmore', N'Male', 80000, 1)
SET IDENTITY_INSERT [dbo].[Employees] OFF
INSERT [dbo].[EmployeesUpdated] ([code], [name], [gender], [annualSalary]) VALUES (N'emp101', N'Tom', N'Male', CAST(5500.000 AS Decimal(18, 3)))
INSERT [dbo].[EmployeesUpdated] ([code], [name], [gender], [annualSalary]) VALUES (N'emp102', N'Alex', N'Male', CAST(5700.950 AS Decimal(18, 3)))
INSERT [dbo].[EmployeesUpdated] ([code], [name], [gender], [annualSalary]) VALUES (N'emp103', N'Mike', N'Male', CAST(5900.000 AS Decimal(18, 3)))
INSERT [dbo].[EmployeesUpdated] ([code], [name], [gender], [annualSalary]) VALUES (N'emp104', N'Mary', N'Female', CAST(6500.826 AS Decimal(18, 3)))
INSERT [dbo].[EmployeesUpdated] ([code], [name], [gender], [annualSalary]) VALUES (N'emp105', N'Nancy', N'Female', CAST(6700.826 AS Decimal(18, 3)))
INSERT [dbo].[EmployeesUpdated] ([code], [name], [gender], [annualSalary]) VALUES (N'emp106', N'Steve', N'Male', CAST(7700.481 AS Decimal(18, 3)))
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([ID])
GO
