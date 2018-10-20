
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/20/2018 19:35:40
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TransactionSet'
CREATE TABLE [dbo].[TransactionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Sum] decimal(18,0)  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [User_Id] int  NOT NULL,
    [Source_Id] int  NOT NULL,
    [Cost_Id] int  NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Patronymic] nvarchar(max)  NOT NULL,
    [Family_Id] int  NOT NULL
);
GO

-- Creating table 'FamilySet'
CREATE TABLE [dbo].[FamilySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SourceSet'
CREATE TABLE [dbo].[SourceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Money] decimal(18,0)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Type_Id] int  NOT NULL
);
GO

-- Creating table 'CostSet'
CREATE TABLE [dbo].[CostSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TypeOfSourceSet'
CREATE TABLE [dbo].[TypeOfSourceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
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

-- Creating primary key on [Id] in table 'CostSet'
ALTER TABLE [dbo].[CostSet]
ADD CONSTRAINT [PK_CostSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeOfSourceSet'
ALTER TABLE [dbo].[TypeOfSourceSet]
ADD CONSTRAINT [PK_TypeOfSourceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'TransactionSet'
ALTER TABLE [dbo].[TransactionSet]
ADD CONSTRAINT [FK_TransactionUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionUser'
CREATE INDEX [IX_FK_TransactionUser]
ON [dbo].[TransactionSet]
    ([User_Id]);
GO

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

-- Creating foreign key on [Cost_Id] in table 'TransactionSet'
ALTER TABLE [dbo].[TransactionSet]
ADD CONSTRAINT [FK_TransactionCost]
    FOREIGN KEY ([Cost_Id])
    REFERENCES [dbo].[CostSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionCost'
CREATE INDEX [IX_FK_TransactionCost]
ON [dbo].[TransactionSet]
    ([Cost_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------