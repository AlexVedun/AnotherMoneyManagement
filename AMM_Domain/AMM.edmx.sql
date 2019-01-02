
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/31/2018 13:54:10
-- Generated from EDMX file: C:\Users\Алексей\source\repos\AnotherMoneyManagement\AMM_Domain\AMM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AMM];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TransactionUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionSet] DROP CONSTRAINT [FK_TransactionUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFamily]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserFamily];
GO
IF OBJECT_ID(N'[dbo].[FK_SourceTypeOfSource]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SourceSet] DROP CONSTRAINT [FK_SourceTypeOfSource];
GO
IF OBJECT_ID(N'[dbo].[FK_FamilyUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FamilySet] DROP CONSTRAINT [FK_FamilyUser];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionSource]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionSet] DROP CONSTRAINT [FK_TransactionSource];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionSource1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionSet] DROP CONSTRAINT [FK_TransactionSource1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserSource]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SourceSet] DROP CONSTRAINT [FK_UserSource];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TransactionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[FamilySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FamilySet];
GO
IF OBJECT_ID(N'[dbo].[SourceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SourceSet];
GO
IF OBJECT_ID(N'[dbo].[TypeOfSourceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeOfSourceSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TransactionSet'
CREATE TABLE [dbo].[TransactionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Debet] decimal(18,0)  NOT NULL,
    [Credit] decimal(18,0)  NOT NULL,
    [TransactionLog_Id] int  NOT NULL,
    [Source_Id] int  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NULL,
    [Patronymic] nvarchar(max)  NULL,
    [Family_Id] int  NULL
);
GO

-- Creating table 'FamilySet'
CREATE TABLE [dbo].[FamilySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Admin_Id] int  NOT NULL
);
GO

-- Creating table 'SourceSet'
CREATE TABLE [dbo].[SourceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Money] decimal(18,0)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Type_Id] int  NOT NULL,
    [UserSource_Source_Id] int  NOT NULL
);
GO

-- Creating table 'TypeOfSourceSet'
CREATE TABLE [dbo].[TypeOfSourceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TransactionLogSet'
CREATE TABLE [dbo].[TransactionLogSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Status] int  NOT NULL,
    [ErrorDetail] nvarchar(max)  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [User_Id] int  NOT NULL,
    [From_Id] int  NOT NULL,
    [To_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TransactionSet'
ALTER TABLE [dbo].[TransactionSet]
ADD CONSTRAINT [PK_TransactionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FamilySet'
ALTER TABLE [dbo].[FamilySet]
ADD CONSTRAINT [PK_FamilySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SourceSet'
ALTER TABLE [dbo].[SourceSet]
ADD CONSTRAINT [PK_SourceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeOfSourceSet'
ALTER TABLE [dbo].[TypeOfSourceSet]
ADD CONSTRAINT [PK_TypeOfSourceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionLogSet'
ALTER TABLE [dbo].[TransactionLogSet]
ADD CONSTRAINT [PK_TransactionLogSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Family_Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_UserFamily]
    FOREIGN KEY ([Family_Id])
    REFERENCES [dbo].[FamilySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFamily'
CREATE INDEX [IX_FK_UserFamily]
ON [dbo].[UserSet]
    ([Family_Id]);
GO

-- Creating foreign key on [Type_Id] in table 'SourceSet'
ALTER TABLE [dbo].[SourceSet]
ADD CONSTRAINT [FK_SourceTypeOfSource]
    FOREIGN KEY ([Type_Id])
    REFERENCES [dbo].[TypeOfSourceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SourceTypeOfSource'
CREATE INDEX [IX_FK_SourceTypeOfSource]
ON [dbo].[SourceSet]
    ([Type_Id]);
GO

-- Creating foreign key on [Admin_Id] in table 'FamilySet'
ALTER TABLE [dbo].[FamilySet]
ADD CONSTRAINT [FK_FamilyUser]
    FOREIGN KEY ([Admin_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FamilyUser'
CREATE INDEX [IX_FK_FamilyUser]
ON [dbo].[FamilySet]
    ([Admin_Id]);
GO

-- Creating foreign key on [UserSource_Source_Id] in table 'SourceSet'
ALTER TABLE [dbo].[SourceSet]
ADD CONSTRAINT [FK_UserSource]
    FOREIGN KEY ([UserSource_Source_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserSource'
CREATE INDEX [IX_FK_UserSource]
ON [dbo].[SourceSet]
    ([UserSource_Source_Id]);
GO

-- Creating foreign key on [User_Id] in table 'TransactionLogSet'
ALTER TABLE [dbo].[TransactionLogSet]
ADD CONSTRAINT [FK_TransactionLogUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionLogUser'
CREATE INDEX [IX_FK_TransactionLogUser]
ON [dbo].[TransactionLogSet]
    ([User_Id]);
GO

-- Creating foreign key on [From_Id] in table 'TransactionLogSet'
ALTER TABLE [dbo].[TransactionLogSet]
ADD CONSTRAINT [FK_TransactionLogSource]
    FOREIGN KEY ([From_Id])
    REFERENCES [dbo].[SourceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionLogSource'
CREATE INDEX [IX_FK_TransactionLogSource]
ON [dbo].[TransactionLogSet]
    ([From_Id]);
GO

-- Creating foreign key on [To_Id] in table 'TransactionLogSet'
ALTER TABLE [dbo].[TransactionLogSet]
ADD CONSTRAINT [FK_TransactionLogSource1]
    FOREIGN KEY ([To_Id])
    REFERENCES [dbo].[SourceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionLogSource1'
CREATE INDEX [IX_FK_TransactionLogSource1]
ON [dbo].[TransactionLogSet]
    ([To_Id]);
GO

-- Creating foreign key on [TransactionLog_Id] in table 'TransactionSet'
ALTER TABLE [dbo].[TransactionSet]
ADD CONSTRAINT [FK_TransactionTransactionLog]
    FOREIGN KEY ([TransactionLog_Id])
    REFERENCES [dbo].[TransactionLogSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionTransactionLog'
CREATE INDEX [IX_FK_TransactionTransactionLog]
ON [dbo].[TransactionSet]
    ([TransactionLog_Id]);
GO

-- Creating foreign key on [Source_Id] in table 'TransactionSet'
ALTER TABLE [dbo].[TransactionSet]
ADD CONSTRAINT [FK_TransactionSource]
    FOREIGN KEY ([Source_Id])
    REFERENCES [dbo].[SourceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionSource'
CREATE INDEX [IX_FK_TransactionSource]
ON [dbo].[TransactionSet]
    ([Source_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------