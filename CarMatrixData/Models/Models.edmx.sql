
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/17/2013 18:07:10
-- Generated from EDMX file: D:\Git\CarMatrix\CarMatrixData\Models\Models.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CMDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CompanyCar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarSet] DROP CONSTRAINT [FK_CompanyCar];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyBrands]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BrandsSet] DROP CONSTRAINT [FK_CompanyBrands];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyCarModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarModelSet] DROP CONSTRAINT [FK_CompanyCarModel];
GO
IF OBJECT_ID(N'[dbo].[FK_CarBrands]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarSet] DROP CONSTRAINT [FK_CarBrands];
GO
IF OBJECT_ID(N'[dbo].[FK_CarModelCar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarSet] DROP CONSTRAINT [FK_CarModelCar];
GO
IF OBJECT_ID(N'[dbo].[FK_CarOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_CarOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_PersonOrder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CompanySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanySet];
GO
IF OBJECT_ID(N'[dbo].[BrandsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BrandsSet];
GO
IF OBJECT_ID(N'[dbo].[CarModelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarModelSet];
GO
IF OBJECT_ID(N'[dbo].[CarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarSet];
GO
IF OBJECT_ID(N'[dbo].[OrderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderSet];
GO
IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[RecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecordSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CompanySet'
CREATE TABLE [dbo].[CompanySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BrandsSet'
CREATE TABLE [dbo].[BrandsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Company_Id] int  NOT NULL
);
GO

-- Creating table 'CarModelSet'
CREATE TABLE [dbo].[CarModelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Company_Id] int  NOT NULL
);
GO

-- Creating table 'CarSet'
CREATE TABLE [dbo].[CarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Company_Id] int  NOT NULL,
    [Brands_Id] int  NOT NULL,
    [CarModel_Id] int  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BuyTime] datetime  NOT NULL,
    [CarId] int  NOT NULL,
    [Car_Id] int  NOT NULL,
    [Person_Id] int  NOT NULL
);
GO

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [Birthday] datetime  NULL,
    [Lat] float  NULL,
    [Lnt] float  NULL,
    [Gender] bit  NOT NULL,
    [Zip] nvarchar(max)  NULL
);
GO

-- Creating table 'RecordSet'
CREATE TABLE [dbo].[RecordSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Brands] nvarchar(max)  NULL,
    [Model] nvarchar(max)  NULL,
    [City] nvarchar(max)  NULL,
    [Time] datetime  NULL,
    [Both] datetime  NULL,
    [Gender] bit  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [Zip] nvarchar(max)  NULL,
    [Lat] float  NULL,
    [Lnt] float  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CompanySet'
ALTER TABLE [dbo].[CompanySet]
ADD CONSTRAINT [PK_CompanySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BrandsSet'
ALTER TABLE [dbo].[BrandsSet]
ADD CONSTRAINT [PK_BrandsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CarModelSet'
ALTER TABLE [dbo].[CarModelSet]
ADD CONSTRAINT [PK_CarModelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CarSet'
ALTER TABLE [dbo].[CarSet]
ADD CONSTRAINT [PK_CarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecordSet'
ALTER TABLE [dbo].[RecordSet]
ADD CONSTRAINT [PK_RecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Company_Id] in table 'CarSet'
ALTER TABLE [dbo].[CarSet]
ADD CONSTRAINT [FK_CompanyCar]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[CompanySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyCar'
CREATE INDEX [IX_FK_CompanyCar]
ON [dbo].[CarSet]
    ([Company_Id]);
GO

-- Creating foreign key on [Company_Id] in table 'BrandsSet'
ALTER TABLE [dbo].[BrandsSet]
ADD CONSTRAINT [FK_CompanyBrands]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[CompanySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyBrands'
CREATE INDEX [IX_FK_CompanyBrands]
ON [dbo].[BrandsSet]
    ([Company_Id]);
GO

-- Creating foreign key on [Company_Id] in table 'CarModelSet'
ALTER TABLE [dbo].[CarModelSet]
ADD CONSTRAINT [FK_CompanyCarModel]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[CompanySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyCarModel'
CREATE INDEX [IX_FK_CompanyCarModel]
ON [dbo].[CarModelSet]
    ([Company_Id]);
GO

-- Creating foreign key on [Brands_Id] in table 'CarSet'
ALTER TABLE [dbo].[CarSet]
ADD CONSTRAINT [FK_CarBrands]
    FOREIGN KEY ([Brands_Id])
    REFERENCES [dbo].[BrandsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarBrands'
CREATE INDEX [IX_FK_CarBrands]
ON [dbo].[CarSet]
    ([Brands_Id]);
GO

-- Creating foreign key on [CarModel_Id] in table 'CarSet'
ALTER TABLE [dbo].[CarSet]
ADD CONSTRAINT [FK_CarModelCar]
    FOREIGN KEY ([CarModel_Id])
    REFERENCES [dbo].[CarModelSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarModelCar'
CREATE INDEX [IX_FK_CarModelCar]
ON [dbo].[CarSet]
    ([CarModel_Id]);
GO

-- Creating foreign key on [Car_Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_CarOrder]
    FOREIGN KEY ([Car_Id])
    REFERENCES [dbo].[CarSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarOrder'
CREATE INDEX [IX_FK_CarOrder]
ON [dbo].[OrderSet]
    ([Car_Id]);
GO

-- Creating foreign key on [Person_Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_PersonOrder]
    FOREIGN KEY ([Person_Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonOrder'
CREATE INDEX [IX_FK_PersonOrder]
ON [dbo].[OrderSet]
    ([Person_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------