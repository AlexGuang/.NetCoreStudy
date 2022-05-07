IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220504024857_InitialMigratin')
BEGIN
    CREATE TABLE [Students] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [ClassName] int NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Students] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220504024857_InitialMigratin')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220504024857_InitialMigratin', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220504031631_SeedStudentsTable')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClassName', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Students]'))
        SET IDENTITY_INSERT [Students] ON;
    INSERT INTO [Students] ([Id], [ClassName], [Email], [Name])
    VALUES (1, 4, N'shinevvip@gmail.com', N'李晓光');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClassName', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Students]'))
        SET IDENTITY_INSERT [Students] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220504031631_SeedStudentsTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220504031631_SeedStudentsTable', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220504032411_AlterStudentSeedData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClassName', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Students]'))
        SET IDENTITY_INSERT [Students] ON;
    INSERT INTO [Students] ([Id], [ClassName], [Email], [Name])
    VALUES (2, 4, N'oliviachen797@gmail.com', N'陈婧瑶');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClassName', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Students]'))
        SET IDENTITY_INSERT [Students] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220504032411_AlterStudentSeedData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClassName', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Students]'))
        SET IDENTITY_INSERT [Students] ON;
    INSERT INTO [Students] ([Id], [ClassName], [Email], [Name])
    VALUES (3, 4, N'haha@ffsd.com', N'张大拿');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClassName', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Students]'))
        SET IDENTITY_INSERT [Students] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220504032411_AlterStudentSeedData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220504032411_AlterStudentSeedData', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220504042959_AddPhotoPathToStudents')
BEGIN
    ALTER TABLE [Students] ADD [PhotoPath] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220504042959_AddPhotoPathToStudents')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220504042959_AddPhotoPathToStudents', N'2.1.14-servicing-32113');
END;

GO

