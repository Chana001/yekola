/* Check if database already exists and delete it if it does exist*/
IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'yekolaDB') 
BEGIN
	DROP DATABASE yekolaDB
	print '' print '*** dropping database yekolaDB'
END
GO

print '' print '*** creating database yekolaDB'
GO
CREATE DATABASE yekolaDB
GO

print '' print '*** using database yekolaDB'
GO
USE [yekolaDB]
GO

print '' print '*** Creating Users Table'
GO
/* ***** Object:  Table [dbo].[Employees]     ***** */
CREATE TABLE [dbo].[Users](
	[UsersID] 		[int] IDENTITY (1000,1)	NOT NULL,
	[FirstName]		[varchar](50)			NOT NULL,
	[LastName]		[varchar](100)			NOT NULL,
	[PhoneNumber]	[varchar](10)			NOT NULL,
	[Email]			[varchar](100)			,
	[UserName]		[varchar](20)			NOT NULL,
	[UserRolesId]	[varchar](50)			NOT NULL,
	[PasswordHash]	[varchar](100)			NOT NULL DEFAULT 'helloworld',
	[Active]		[bit]					NOT NULL DEFAULT 1,

	CONSTRAINT [pk_UsersID] PRIMARY KEY([UsersID] ASC),
	CONSTRAINT [ak_UserName] UNIQUE ([UserName] ASC)
)
GO

print '' print '*** Inserting User Test Records'
INSERT INTO [dbo].[Users]
		([FirstName], [LastName], [PhoneNumber], [Email], [UserName],[UserRolesId],[PasswordHash],[Active])
	VALUES
		('Tacha', 'Ilunga', '3195557777', 'TI01@ycquiz.cd', 'TI01','Admin','6cf615d5bcaac778352a8f1f3360d23f02f34ec182e259897fd6ce485d7870d4','1'),
		('Fred', 'Okange', '3195557777', 'FO02@ycquiz.cd', 'F002','Player','6cf615d5bcaac778352a8f1f3360d23f02f34ec182e259897fd6ce485d7870d4','1')		
GO

print '' print '*** Creating User Roles Table'
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRolesId]			[varchar](50)					NOT NULL,
	[RoleDescription]		[varchar](250)					NOT NULL,
	CONSTRAINT [pk_UserRolesId] PRIMARY KEY([UserRolesID] ASC)
)
GO

print '' print '*** Inserting Role Records'
INSERT INTO [dbo].[UserRoles]
		([UserRolesId], [RoleDescription])
	VALUES
		('Admin', 'Adds Questions and Sets Answers'),
		('Player', 'Takes Questions')
GO

print '' print '*** Creating Questions Table'
GO
CREATE TABLE [dbo].[Questions](
	[QuestionsId]			[int] IDENTITY (1,1)	NOT NULL,
	[Text]					[varchar](255)					NOT NULL,	
	[LevelsId]				[int]							NOT NULL,
	CONSTRAINT [pk_QuestionsId] PRIMARY KEY([QuestionsID] ASC)
)
GO

/* Inserting Questions Data */
print '' print '*** Inserting Questions Data'
INSERT INTO [dbo].[Questions]
		([Text], [LevelsId] )
	VALUES
		('Democratic Republic of the Congo is a country located in which continent?', 3000 ),
		('The Official name of Democratic Republic of the Congo (DRC) is ______ .', 3000 ),
		('What is the capital of Democratic Republic of the Congo?', 3000 ),
		('What is the currency used in Democratic Republic of the Congo?', 3000 ),
		('Democratic Republic of the Congo obtained independence from which country?', 3000 ),
		('The Democratic Republic of the Congo was formerly known as ________.', 3000 ),
		('Democratic Republic of the Congo is ____________.', 3000 ),
		('In ____  the portuguese navigator Diogo Cao becomes the first European to visit the Congo.', 3001 ),
		('In ____ the british explorer Henry Stanley navigates Congo river to the Atlantic Ocean.', 3001 ),
		('In ____ Leopold commissions Stanley to establish the king''s authority in the Congo basin.', 3001 ),
		('In ____ Leopold announces the establishment of the Congo Free State, headed by himself.', 3001 ),
		('In ____ Belgium begins to lose control over events in the Congo following serious nationalist riots in Leopoldville.', 3001 ),
		('When the Congo becomes independent with Patrice Lumumba as prime minister and Joseph Kasavubu as president.', 3001 ),
		('They arrived during the Upper Paleolithic Period, are thought to have been the earliest inhabitants of the Congo basin. Which ethnic group is about?', 3002 ),
		('_____ is an ethnic group made of culturally similar to the Bantu communities. The community is native to the Kasai, Maniema, and Katanga regions of the country. Is the largest ethnic group in the Democratic Republic of the Congo.', 3002 ),
		('Which ethnic group in Congo consist of several smaller constituent groups, including the Mbole, Ekonda, Boyela, Bolia, and Nkutu. These groups speak different dialects of the Mongo language.', 3002 ),
		('Which ethnic group is native to the DR Congo, the Republic of the Congo, and Angola. And arrived in the DR Congo in line with the Bantu migration in the 13th Century.', 3002 ),
		('The ________ ethnicity in the Democratic Republic of the Congo is concentrated within the Orientale Province. Their presence in the country was a result of migration from Sudan at the start of the 19th Century.', 3002 ),
		('The _______ ethnicity is native to the Democratic Republic of the Congo and South Sudan. The Moru people are named in narratives depicting wars with the Zande people.', 3002 ),
		('Migration of the ________ people into the Democratic Republic of the Congo and Sudan began in the 1600s.', 3002 ),
		('The Democratic Republic of the Congo is a multilingual country. How many languages are spoken in the country?', 3003 ),
		('What are the four national spoken languages in Democratic Republic of Congo?', 3003 ),
		('What is the the official language of the country since its colonial period under Belgian rule?', 3003 ),
		('_________  is one of the national languages, but in fact it is a Kikongo-based creole.', 3003 ),
		('____________ was made the official language of the army under Mobutu, but since the rebellions the army has also used Swahili in the east.', 3003 )
GO

print '' print '*** Creating Options Table'
GO
CREATE TABLE [dbo].[Options](
	[OptionsId]				[int] IDENTITY (2000,1)	NOT NULL,
	[Text]					[varchar](255)				NOT NULL,
	[QuestionsId]			[int]						NOT NULL,
	[isCorrect]				[bit]						NOT NULL,	
	CONSTRAINT [pk_OptionsId] PRIMARY KEY([OptionsID] ASC)
)
GO

/* Inserting Questions Data */
print '' print '*** Inserting Questions Data'
INSERT INTO [dbo].[Options]
		([Text], [QuestionsId], [isCorrect] )
	VALUES
		('South America', 1, 0),
		('North America', 1, 0),
		('Asia', 1, 0),
		('Africa',1, 1),
		('Congo', 2, 0),
		('Democratic Republic of the Congo', 2, 1),
		('People''s Democratic Republic of the Congo', 2, 0),
		('Zaire',2, 0),
		('Kinshasa', 3, 1),
		('Lubumbashi ', 3, 0),
		('Mbuji-Mayi', 3, 0),
		('Kisangani',3, 0),			
		('Peso', 4, 0),
		('West African CFA franc', 4, 0),
		('Congolese franc', 4, 1),
		('Central African CFA franc',4, 0),
		('United Kingdom ', 5, 0),
		('Spain', 5, 0),
		('France', 5, 0),
		('Belgium',5, 1),
		('Zaire', 6, 1),
		('Gold Coast ', 6, 0),
		('Zanzibar', 6, 0),
		('Formosa',6, 0),		
		('the most populous officially Francophone country ', 7, 0),
		('the fourth most populous nation in Africa', 7, 0),
		('the nineteenth most populous nation in the world ', 7, 0),
		('All the above',7, 1),
		('1481', 8, 0),
		('1482', 8, 1),
		('1483', 8, 0),
		('1382',8, 0),
		('1874', 9, 1),
		('1748', 9, 0),
		('1847', 9, 0),
		('1788',9, 0),		
		('1878', 10, 0),
		('1877', 10, 0),
		('1869', 10, 0),
		('1879',10, 1),		
		('1885', 11, 1),
		('1888', 11, 0),
		('1889', 11, 0),
		('1884',11, 0),		
		('1956', 12, 0),
		('1959', 12, 1),
		('1957', 12, 0),
		('1955',12, 0),		
		('1950', 13, 0),
		('1970', 13, 0),
		('1966', 13, 0),
		('1960',13, 1),		
		('The Pygmies', 14, 1),
		('The Zandes', 14, 0),
		('The Tusti', 14, 0),
		('The Kongo',14, 0),
		('The Bandu', 15, 0),
		('The Luba', 15, 1),
		('The Kongo', 15, 0),
		('The Mongo`',15, 0),		
		('The Kongo', 16, 0),
		('The Mangbetu', 16, 0),
		('The Mongo', 16, 1),
		('The Zandes',16, 0),		
		('The Kongo', 17, 1),
		('The Zandes', 17, 0),
		('The Moru', 17, 0),
		('The Bandu',17, 0),		
		('The Mangbetu', 18, 1),
		('The Mongo', 18, 0),
		('The Kongo', 18, 0),
		('The Moru',18, 0),		
		('Tutsi', 19, 0),
		('Luba', 19, 0),
		('Mongo', 19, 0),
		('Moru',19, 1),		
		('Luba', 20, 0),
		('Pygmies', 20, 0),
		('Zandes', 20, 1),
		('Tutsi',20, 0),
		('Over 240', 21, 1),
		('157', 21, 0),
		('103', 21, 0),
		('77',21, 0),		
		('Kingo, Lingla, Swahili, Tshiluba', 22, 1),
		('Mangbetu, Nande, Ngbaka, Zande', 22, 0),
		('Mongo, Lunda, Kilega, Tetela', 22, 0),
		('Chokwe, Budza, Ngbandi, Lendu',22, 0),		
		('French', 23, 1),
		('Meridional French', 23, 0),
		('Francophones of France', 23, 0),
		('French-based creole',23, 0),		
		('Chokwe', 24, 0),
		('Mongo', 24, 0),
		('Kilega', 24, 0),
		('Kikongo',24, 1),		
		('Kikongo', 25, 0),
		('Lingala', 25, 1),
		('Swahili', 25, 0),
		('Lunda',25, 0)
GO


print '' print '*** Creating Levels Table'
GO
CREATE TABLE [dbo].[Levels](
	[LevelsId]				[int] IDENTITY (3000,1)	NOT NULL,
	[Name]					[varchar](50)				,
	[CategoryId]			[varchar](10)				NOT NULL,
	[Description]		[varchar](250)					NOT NULL,
	
	CONSTRAINT [pk_LevelsId] PRIMARY KEY([LevelsID] ASC)
)
GO

print '' print '*** Inserting Levels Records'
INSERT INTO [dbo].[Levels]
		( [Name], [CategoryId], [Description] )
	VALUES
		('Level 1', 'Category A', 'Entry Level'),
		('Level 1', 'Category B', 'Entry Level'),
		('Level 2', 'Category A', 'Advanced Level'),
		('Level 2', 'Category B', 'Advanced Level'),
		('Level 3', 'Category A', 'Advanced Advanced Level')
GO

print '' print '*** Creating Categories Table'
GO
CREATE TABLE [dbo].[Category](
	[CategoryId]			[varchar](10)				NOT NULL,
	[Description]			[varchar](250)					NOT NULL,
	CONSTRAINT [pk_CategoryId] PRIMARY KEY([CategoryId] ASC)
)
GO

print '' print '*** Inserting Category'
INSERT INTO [dbo].[Category]
		( [CategoryId], [Description] )
	VALUES
		('Category A', 'Warm up your basic knowledge about the country'),
		('Category B', 'DR Congo Early History TimeLine')
GO

print '' print '*** Creating User_Levels Table'
GO
CREATE TABLE [dbo].[User_Levels](
	[UsersId]			[int]				NOT NULL,
	[LevelsId]			[int]				NOT NULL,
	[isPassed]			[bit]				
)
GO

print '' print '*** Inserting User_Levels Table'
INSERT INTO [dbo].[User_Levels]
		([UsersId], [LevelsId], [isPassed])
	VALUES
		('1001', '3000', 0),
		('1001', '3001', 0),
		('1001', '3002', 0),
		('1001', '3003', 0),
		('1001', '3004', 0)
GO

print '' print '*** Creating Security Questions Table'
GO
CREATE TABLE [dbo].[Security](
	[SecurityId]		[int] IDENTITY (400000,1)	NOT NULL,
	[Question]			[varchar](100),
	[Answer]			[varchar](100),
	[UsersId]			[int]				,
)
GO

print '' print '*** Creating Users UserRolesID foreign key'
GO
ALTER TABLE [dbo].[Users]  WITH NOCHECK 
	ADD CONSTRAINT [FK_UserRolesId] FOREIGN KEY([UserRolesID])
	REFERENCES [dbo].[UserRoles] ([UserRolesId])
	ON UPDATE CASCADE
GO

print '' print '*** Creating Questions LevelID foreign key'
GO
ALTER TABLE [dbo].[Questions]  WITH NOCHECK 
	ADD CONSTRAINT [FK_LevelsId] FOREIGN KEY([LevelsID])
	REFERENCES [dbo].[Levels] ([LevelsId])
	ON UPDATE CASCADE
GO

/*print '' print '*** Creating Questions Options foreign key'
GO
ALTER TABLE [dbo].[Questions]  WITH NOCHECK 
	ADD CONSTRAINT [FK_Options] FOREIGN KEY([OptionsID])
	REFERENCES [dbo].[Options] ([OptionsId])
	ON UPDATE CASCADE
GO*/

print '' print '*** Creating Questions CategoryId foreign key'
GO
ALTER TABLE [dbo].[Levels]  WITH NOCHECK 
	ADD CONSTRAINT [FK_CategoryIdonLevels] FOREIGN KEY([CategoryId])
	REFERENCES [dbo].[Category] ([CategoryId])
	ON UPDATE CASCADE
GO

print '' print '*** Creating Options QuestionsId foreign key'
GO
ALTER TABLE [dbo].[Options]  WITH NOCHECK 
	ADD CONSTRAINT [FK_QuestionsId] FOREIGN KEY([QuestionsId])
	REFERENCES [dbo].[Questions] ([QuestionsId])
GO

print '' print '*** Creating User_Levels QuestionsId foreign key'
GO
ALTER TABLE [dbo].[User_Levels]  WITH NOCHECK 
	ADD CONSTRAINT [FK_LevelsIdonUser_Levels] FOREIGN KEY([LevelsId])
	REFERENCES [dbo].[Levels] ([LevelsId])
GO

print '' print '*** Creating User_Levels UserId foreign key'
GO
ALTER TABLE [dbo].[User_Levels]  WITH NOCHECK 
	ADD CONSTRAINT [FK_UsersIdonUser_Levels] FOREIGN KEY([UsersId])
	REFERENCES [dbo].[Users] ([UsersId])
GO


print '' print '*** Creating Security UsersId foreign key'
GO
ALTER TABLE [dbo].[Security]  WITH NOCHECK 
	ADD CONSTRAINT [FK_UsersIdonSecurity] FOREIGN KEY([UsersId])
	REFERENCES [dbo].[Users] ([UsersId])
GO

print '' print '*** Creating sp_authenticate_user'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_user]
	(
	@Username		varchar(20),
	@PasswordHash	varchar(100)
	)
AS
	BEGIN
		SELECT COUNT(UsersID)
		FROM Users
		WHERE UserName = @Username
		AND PasswordHash = @PasswordHash
	END
GO

print '' print '*** Creating sp_retrieve_user_roles'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_user_roles]
	(
	@UsersID		int
	)
AS
	BEGIN
		SELECT [UserRoles].UserRolesID, [UserRoles].RoleDescription
		FROM Users, UserRoles
		WHERE [Users].[UsersId] = @UsersID
		AND [Users].[UserRolesID] = [UserRoles].[UserRolesID]
	END
GO

print '' print '*** Creating sp_retrieve_users_by_username'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_users_by_username]
	(
	@Username		varchar(20)
	)
AS
	BEGIN
		SELECT UsersID, FirstName, LastName, PhoneNumber, Email, UserName, Active
		FROM Users
		WHERE UserName = @UserName
	END
GO

print '' print '*** Creating sp_update_passwordHash'
GO
CREATE PROCEDURE [dbo].[sp_update_passwordHash]
	(
	@UsersID			int,
	@OldPasswordHash	varchar(100),
	@NewPasswordHash	varchar(100)
	)
AS
	BEGIN
		UPDATE Users
			SET PasswordHash = @NewPasswordHash
			WHERE UsersID = @UsersID
			AND PasswordHash = @OldPasswordHash
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** Creating sp_retrieve_player_summary'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_player_summary]
	(
	@UsersId		[int]
	)
AS
	BEGIN
		SELECT ul.LevelsID, lv.Name, lv.CategoryId, ul.isPassed
		FROM User_Levels ul, Levels lv
		WHERE ul.UsersId = @UsersId
		AND ul.LevelsId = lv.LevelsId
	END
GO


print '' print '*** Creating sp_retrieve_questions'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_questions]
	(
	@LevelsId		[int]
	)
AS
	BEGIN
		SELECT qt.QuestionsID, qt.Text
		FROM Questions qt
		WHERE qt.LevelsId = @LevelsId
	END
GO

print '' print '*** Creating sp_retrieve_options_by_questionId'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_options_by_questionId]
	(
	@QuestionsID		[int]
	)
AS
	BEGIN
		SELECT OptionsID, Text, QuestionsID, IsCorrect
		FROM Options
		WHERE QuestionsID = @QuestionsID
	END
GO

print '' print '*** Creating sp_create_new_user'
GO
CREATE PROCEDURE [dbo].[sp_create_new_user]
	(
            @FirstName			[varchar](50)			,
            @LastName			[varchar](100)			,
            @PhoneNumber		[varchar](10)			,
			@Email				[varchar](100)			,
			@UserName			[varchar](20)			,
			@UserRolesID		[varchar](50)			,
			@PasswordHash		[varchar](100)			,
			@Active				[bit]
	)
AS
	BEGIN
		INSERT INTO [dbo].[Users]
		(
			FirstName			,
			LastName			,
            PhoneNumber			,
			Email				,
			UserName			,
			UserRolesId			,	
			PasswordHash		,
			Active				
			
		)
		VALUES
		(
			@FirstName			,
			@LastName			,
            @PhoneNumber		,
			@Email				,
			@UserName			,
			@UserRolesId		,	
			@PasswordHash		,
			@Active				
		)
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** Creating sp_create_user_levels'
GO
CREATE PROCEDURE [dbo].[sp_create_user_levels]
	(
            @UsersID			[int]					,
            @LevelsID			[int]					,
            @IsPassed			[bit]					
	)
AS
	BEGIN
		INSERT INTO [dbo].[User_Levels]
		(
			UsersID				,
			LevelsID			,
            IsPassed					
		)
		VALUES
		(
			@UsersID			,
			@LevelsID			,
            @IsPassed				
		)
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** Creating sp_retrieve_levels'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_levels]
AS
	BEGIN
		SELECT LevelsID, Name, CategoryId, Description
		FROM Levels
	END
GO


/* sp_update_user_levels */
print '' print '*** Creating sp_update_user_levels'
GO
CREATE PROCEDURE [dbo].[sp_update_user_levels]
	(
			@UsersID    		[INT]    				,
            @LevelsID			[INT]					,
            @IsPassed			[bit]			
	)
AS
	BEGIN
		UPDATE User_Levels
			SET	UsersID 		= 		@UsersID			,
				LevelsID 		= 		@LevelsID			,
				IsPassed 		= 		@IsPassed			
			WHERE UsersID = @UsersID
			AND LevelsID = @LevelsID
		RETURN @@ROWCOUNT
	END
GO
