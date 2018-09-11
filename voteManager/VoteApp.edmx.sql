
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/11/2018 12:15:50
-- Generated from EDMX file: C:\Users\bigtech-dev\source\repos\voteManager\voteManager\VoteApp.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [voteApp];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_regionsector]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sectors] DROP CONSTRAINT [FK_regionsector];
GO
IF OBJECT_ID(N'[dbo].[FK_CEvoteTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[voteTables] DROP CONSTRAINT [FK_CEvoteTable];
GO
IF OBJECT_ID(N'[dbo].[FK_sectorCE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CEs] DROP CONSTRAINT [FK_sectorCE];
GO
IF OBJECT_ID(N'[dbo].[FK_Provinceregion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Regions1] DROP CONSTRAINT [FK_Provinceregion];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Regions1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Regions1];
GO
IF OBJECT_ID(N'[dbo].[sectors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sectors];
GO
IF OBJECT_ID(N'[dbo].[partidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[partidos];
GO
IF OBJECT_ID(N'[dbo].[CEs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CEs];
GO
IF OBJECT_ID(N'[dbo].[voteTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[voteTables];
GO
IF OBJECT_ID(N'[dbo].[votes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[votes];
GO
IF OBJECT_ID(N'[dbo].[Provinces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Provinces];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Regions1'
CREATE TABLE [dbo].[Regions1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [Province_Id] int  NOT NULL
);
GO

-- Creating table 'sectors'
CREATE TABLE [dbo].[sectors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [regionId] int  NOT NULL
);
GO

-- Creating table 'partidos'
CREATE TABLE [dbo].[partidos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CEs'
CREATE TABLE [dbo].[CEs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [sectorId] int  NOT NULL
);
GO

-- Creating table 'voteTables'
CREATE TABLE [dbo].[voteTables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CEId] int  NOT NULL
);
GO

-- Creating table 'votes'
CREATE TABLE [dbo].[votes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [idRegion] int  NOT NULL,
    [idSector] int  NOT NULL,
    [idCE] int  NOT NULL,
    [idVoteTable] int  NOT NULL,
    [idPartido] int  NOT NULL,
    [voteData] int  NOT NULL
);
GO

-- Creating table 'Provinces'
CREATE TABLE [dbo].[Provinces] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Admin] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Enabled] bit  NOT NULL,
    [DateCreation] datetime  NOT NULL,
    [OwnerId] int  NOT NULL,
    [Type] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Regions1'
ALTER TABLE [dbo].[Regions1]
ADD CONSTRAINT [PK_Regions1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'sectors'
ALTER TABLE [dbo].[sectors]
ADD CONSTRAINT [PK_sectors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'partidos'
ALTER TABLE [dbo].[partidos]
ADD CONSTRAINT [PK_partidos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CEs'
ALTER TABLE [dbo].[CEs]
ADD CONSTRAINT [PK_CEs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'voteTables'
ALTER TABLE [dbo].[voteTables]
ADD CONSTRAINT [PK_voteTables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [idSector], [idRegion], [idCE], [idVoteTable], [idPartido] in table 'votes'
ALTER TABLE [dbo].[votes]
ADD CONSTRAINT [PK_votes]
    PRIMARY KEY CLUSTERED ([Id], [idSector], [idRegion], [idCE], [idVoteTable], [idPartido] ASC);
GO

-- Creating primary key on [Id] in table 'Provinces'
ALTER TABLE [dbo].[Provinces]
ADD CONSTRAINT [PK_Provinces]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [regionId] in table 'sectors'
ALTER TABLE [dbo].[sectors]
ADD CONSTRAINT [FK_regionsector]
    FOREIGN KEY ([regionId])
    REFERENCES [dbo].[Regions1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_regionsector'
CREATE INDEX [IX_FK_regionsector]
ON [dbo].[sectors]
    ([regionId]);
GO

-- Creating foreign key on [CEId] in table 'voteTables'
ALTER TABLE [dbo].[voteTables]
ADD CONSTRAINT [FK_CEvoteTable]
    FOREIGN KEY ([CEId])
    REFERENCES [dbo].[CEs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CEvoteTable'
CREATE INDEX [IX_FK_CEvoteTable]
ON [dbo].[voteTables]
    ([CEId]);
GO

-- Creating foreign key on [sectorId] in table 'CEs'
ALTER TABLE [dbo].[CEs]
ADD CONSTRAINT [FK_sectorCE]
    FOREIGN KEY ([sectorId])
    REFERENCES [dbo].[sectors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_sectorCE'
CREATE INDEX [IX_FK_sectorCE]
ON [dbo].[CEs]
    ([sectorId]);
GO

-- Creating foreign key on [Province_Id] in table 'Regions1'
ALTER TABLE [dbo].[Regions1]
ADD CONSTRAINT [FK_Provinceregion]
    FOREIGN KEY ([Province_Id])
    REFERENCES [dbo].[Provinces]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Provinceregion'
CREATE INDEX [IX_FK_Provinceregion]
ON [dbo].[Regions1]
    ([Province_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------