
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2013 20:59:47
-- Generated from EDMX file: C:\Users\nEmo\Documents\Visual Studio 2012\Projects\CarMatrix\CarMatrixData\Models\Models.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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