
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/03/2019 21:43:50
-- Generated from EDMX file: C:\Users\Nachisu\Source\Repos\TheLonelyStagg\WPF_Project\WPF_Project\AlbumEF.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CollectionsDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AlbumCollectionCollectionRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollectionRecordSet] DROP CONSTRAINT [FK_AlbumCollectionCollectionRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_AuthorAlbum_Author]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AuthorAlbum] DROP CONSTRAINT [FK_AuthorAlbum_Author];
GO
IF OBJECT_ID(N'[dbo].[FK_AuthorAlbum_Album]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AuthorAlbum] DROP CONSTRAINT [FK_AuthorAlbum_Album];
GO
IF OBJECT_ID(N'[dbo].[FK_GenreAlbum_Genre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GenreAlbum] DROP CONSTRAINT [FK_GenreAlbum_Genre];
GO
IF OBJECT_ID(N'[dbo].[FK_GenreAlbum_Album]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GenreAlbum] DROP CONSTRAINT [FK_GenreAlbum_Album];
GO
IF OBJECT_ID(N'[dbo].[FK_FormatCollectionRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollectionRecordSet] DROP CONSTRAINT [FK_FormatCollectionRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_AlbumCollectionRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollectionRecordSet] DROP CONSTRAINT [FK_AlbumCollectionRecord];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AlbumSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlbumSet];
GO
IF OBJECT_ID(N'[dbo].[AuthorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuthorSet];
GO
IF OBJECT_ID(N'[dbo].[GenreSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GenreSet];
GO
IF OBJECT_ID(N'[dbo].[FormatSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormatSet];
GO
IF OBJECT_ID(N'[dbo].[AlbumCollectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlbumCollectionSet];
GO
IF OBJECT_ID(N'[dbo].[CollectionRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollectionRecordSet];
GO
IF OBJECT_ID(N'[dbo].[AuthorAlbum]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuthorAlbum];
GO
IF OBJECT_ID(N'[dbo].[GenreAlbum]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GenreAlbum];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AlbumSet'
CREATE TABLE [dbo].[AlbumSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ReleaseDate] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ImgUrl] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AuthorSet'
CREATE TABLE [dbo].[AuthorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GenreSet'
CREATE TABLE [dbo].[GenreSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GenreName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FormatSet'
CREATE TABLE [dbo].[FormatSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FormatName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AlbumCollectionSet'
CREATE TABLE [dbo].[AlbumCollectionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CollectionName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [CreationDate] nvarchar(max)  NOT NULL,
    [FileName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CollectionRecordSet'
CREATE TABLE [dbo].[CollectionRecordSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AlbumCollectionId] int  NOT NULL,
    [FormatId] int  NOT NULL,
    [AlbumId] int  NOT NULL
);
GO

-- Creating table 'AuthorAlbum'
CREATE TABLE [dbo].[AuthorAlbum] (
    [Author_Id] int  NOT NULL,
    [Album_Id] int  NOT NULL
);
GO

-- Creating table 'GenreAlbum'
CREATE TABLE [dbo].[GenreAlbum] (
    [Genre_Id] int  NOT NULL,
    [Album_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AlbumSet'
ALTER TABLE [dbo].[AlbumSet]
ADD CONSTRAINT [PK_AlbumSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AuthorSet'
ALTER TABLE [dbo].[AuthorSet]
ADD CONSTRAINT [PK_AuthorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GenreSet'
ALTER TABLE [dbo].[GenreSet]
ADD CONSTRAINT [PK_GenreSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormatSet'
ALTER TABLE [dbo].[FormatSet]
ADD CONSTRAINT [PK_FormatSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AlbumCollectionSet'
ALTER TABLE [dbo].[AlbumCollectionSet]
ADD CONSTRAINT [PK_AlbumCollectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CollectionRecordSet'
ALTER TABLE [dbo].[CollectionRecordSet]
ADD CONSTRAINT [PK_CollectionRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Author_Id], [Album_Id] in table 'AuthorAlbum'
ALTER TABLE [dbo].[AuthorAlbum]
ADD CONSTRAINT [PK_AuthorAlbum]
    PRIMARY KEY CLUSTERED ([Author_Id], [Album_Id] ASC);
GO

-- Creating primary key on [Genre_Id], [Album_Id] in table 'GenreAlbum'
ALTER TABLE [dbo].[GenreAlbum]
ADD CONSTRAINT [PK_GenreAlbum]
    PRIMARY KEY CLUSTERED ([Genre_Id], [Album_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AlbumCollectionId] in table 'CollectionRecordSet'
ALTER TABLE [dbo].[CollectionRecordSet]
ADD CONSTRAINT [FK_AlbumCollectionCollectionRecord]
    FOREIGN KEY ([AlbumCollectionId])
    REFERENCES [dbo].[AlbumCollectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlbumCollectionCollectionRecord'
CREATE INDEX [IX_FK_AlbumCollectionCollectionRecord]
ON [dbo].[CollectionRecordSet]
    ([AlbumCollectionId]);
GO

-- Creating foreign key on [Author_Id] in table 'AuthorAlbum'
ALTER TABLE [dbo].[AuthorAlbum]
ADD CONSTRAINT [FK_AuthorAlbum_Author]
    FOREIGN KEY ([Author_Id])
    REFERENCES [dbo].[AuthorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Album_Id] in table 'AuthorAlbum'
ALTER TABLE [dbo].[AuthorAlbum]
ADD CONSTRAINT [FK_AuthorAlbum_Album]
    FOREIGN KEY ([Album_Id])
    REFERENCES [dbo].[AlbumSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuthorAlbum_Album'
CREATE INDEX [IX_FK_AuthorAlbum_Album]
ON [dbo].[AuthorAlbum]
    ([Album_Id]);
GO

-- Creating foreign key on [Genre_Id] in table 'GenreAlbum'
ALTER TABLE [dbo].[GenreAlbum]
ADD CONSTRAINT [FK_GenreAlbum_Genre]
    FOREIGN KEY ([Genre_Id])
    REFERENCES [dbo].[GenreSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Album_Id] in table 'GenreAlbum'
ALTER TABLE [dbo].[GenreAlbum]
ADD CONSTRAINT [FK_GenreAlbum_Album]
    FOREIGN KEY ([Album_Id])
    REFERENCES [dbo].[AlbumSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GenreAlbum_Album'
CREATE INDEX [IX_FK_GenreAlbum_Album]
ON [dbo].[GenreAlbum]
    ([Album_Id]);
GO

-- Creating foreign key on [FormatId] in table 'CollectionRecordSet'
ALTER TABLE [dbo].[CollectionRecordSet]
ADD CONSTRAINT [FK_FormatCollectionRecord]
    FOREIGN KEY ([FormatId])
    REFERENCES [dbo].[FormatSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FormatCollectionRecord'
CREATE INDEX [IX_FK_FormatCollectionRecord]
ON [dbo].[CollectionRecordSet]
    ([FormatId]);
GO

-- Creating foreign key on [AlbumId] in table 'CollectionRecordSet'
ALTER TABLE [dbo].[CollectionRecordSet]
ADD CONSTRAINT [FK_AlbumCollectionRecord]
    FOREIGN KEY ([AlbumId])
    REFERENCES [dbo].[AlbumSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlbumCollectionRecord'
CREATE INDEX [IX_FK_AlbumCollectionRecord]
ON [dbo].[CollectionRecordSet]
    ([AlbumId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------