
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/12/2018 11:52:33
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

IF OBJECT_ID(N'[dbo].[FK_CEvoteTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VoteTables] DROP CONSTRAINT [FK_CEvoteTable];
GO
IF OBJECT_ID(N'[dbo].[FK_sectorCE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CEs] DROP CONSTRAINT [FK_sectorCE];
GO
IF OBJECT_ID(N'[dbo].[FK_Regionsector]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sectors] DROP CONSTRAINT [FK_Regionsector];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Sectors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sectors];
GO
IF OBJECT_ID(N'[dbo].[Partidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Partidos];
GO
IF OBJECT_ID(N'[dbo].[CEs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CEs];
GO
IF OBJECT_ID(N'[dbo].[VoteTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VoteTables];
GO
IF OBJECT_ID(N'[dbo].[Votes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Votes];
GO
IF OBJECT_ID(N'[dbo].[Provinces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Provinces];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Regions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Regions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Sectors'
CREATE TABLE [dbo].[Sectors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [RegionId] int  NOT NULL
);
GO

-- Creating table 'Partidos'
CREATE TABLE [dbo].[Partidos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Enabled] bit  NOT NULL
);
GO

-- Creating table 'CEs'
CREATE TABLE [dbo].[CEs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [sectorId] int  NOT NULL
);
GO

-- Creating table 'VoteTables'
CREATE TABLE [dbo].[VoteTables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CEId] int  NOT NULL,
    [TotalRegisted] int  NOT NULL,
    [InvalidVotes] int  NOT NULL
);
GO

-- Creating table 'Votes'
CREATE TABLE [dbo].[Votes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [idRegion] int  NOT NULL,
    [idSector] int  NOT NULL,
    [idCE] int  NOT NULL,
    [idVoteTable] int  NOT NULL,
    [idPartido] int  NOT NULL,
    [provinceId] int  NOT NULL,
    [voteData] int  NOT NULL
);
GO

-- Creating table 'Provinces'
CREATE TABLE [dbo].[Provinces] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
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
    [Type] int  NOT NULL,
    [ProvinceId] int  NOT NULL,
    [Salt] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Regions'
CREATE TABLE [dbo].[Regions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [idProvince] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Sectors'
ALTER TABLE [dbo].[Sectors]
ADD CONSTRAINT [PK_Sectors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Partidos'
ALTER TABLE [dbo].[Partidos]
ADD CONSTRAINT [PK_Partidos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CEs'
ALTER TABLE [dbo].[CEs]
ADD CONSTRAINT [PK_CEs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VoteTables'
ALTER TABLE [dbo].[VoteTables]
ADD CONSTRAINT [PK_VoteTables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [idSector], [idRegion], [idCE], [idVoteTable], [idPartido], [provinceId] in table 'Votes'
ALTER TABLE [dbo].[Votes]
ADD CONSTRAINT [PK_Votes]
    PRIMARY KEY CLUSTERED ([Id], [idSector], [idRegion], [idCE], [idVoteTable], [idPartido], [provinceId] ASC);
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

-- Creating primary key on [Id] in table 'Regions'
ALTER TABLE [dbo].[Regions]
ADD CONSTRAINT [PK_Regions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CEId] in table 'VoteTables'
ALTER TABLE [dbo].[VoteTables]
ADD CONSTRAINT [FK_CEvoteTable]
    FOREIGN KEY ([CEId])
    REFERENCES [dbo].[CEs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CEvoteTable'
CREATE INDEX [IX_FK_CEvoteTable]
ON [dbo].[VoteTables]
    ([CEId]);
GO

-- Creating foreign key on [sectorId] in table 'CEs'
ALTER TABLE [dbo].[CEs]
ADD CONSTRAINT [FK_sectorCE]
    FOREIGN KEY ([sectorId])
    REFERENCES [dbo].[Sectors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_sectorCE'
CREATE INDEX [IX_FK_sectorCE]
ON [dbo].[CEs]
    ([sectorId]);
GO

-- Creating foreign key on [RegionId] in table 'Sectors'
ALTER TABLE [dbo].[Sectors]
ADD CONSTRAINT [FK_Regionsector]
    FOREIGN KEY ([RegionId])
    REFERENCES [dbo].[Regions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Regionsector'
CREATE INDEX [IX_FK_Regionsector]
ON [dbo].[Sectors]
    ([RegionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------