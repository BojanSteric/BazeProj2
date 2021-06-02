
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2021 18:38:30
-- Generated from EDMX file: C:\Users\bojan\source\repos\ISAutobuskaStanica\ISAutobuskaStanica.DataModel\AutobuskaStanicaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ISAutobuskaStanica];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AutobuskaStanicaRedVoznje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RedVoznjes] DROP CONSTRAINT [FK_AutobuskaStanicaRedVoznje];
GO
IF OBJECT_ID(N'[dbo].[FK_VoznaSezonaRedVoznje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RedVoznjes] DROP CONSTRAINT [FK_VoznaSezonaRedVoznje];
GO
IF OBJECT_ID(N'[dbo].[FK_AutobuskaStanicaUgovor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ugovors] DROP CONSTRAINT [FK_AutobuskaStanicaUgovor];
GO
IF OBJECT_ID(N'[dbo].[FK_AutobuskiPrevoznikUgovor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ugovors] DROP CONSTRAINT [FK_AutobuskiPrevoznikUgovor];
GO
IF OBJECT_ID(N'[dbo].[FK_AutobuskiPrevoznikAutobus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autobus] DROP CONSTRAINT [FK_AutobuskiPrevoznikAutobus];
GO
IF OBJECT_ID(N'[dbo].[FK_RedVoznjePregledLinija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RedVoznjes] DROP CONSTRAINT [FK_RedVoznjePregledLinija];
GO
IF OBJECT_ID(N'[dbo].[FK_AutobuskiPrevoznikLinija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Linijas] DROP CONSTRAINT [FK_AutobuskiPrevoznikLinija];
GO
IF OBJECT_ID(N'[dbo].[FK_AutobuskiPrevoznikVozac]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vozacs] DROP CONSTRAINT [FK_AutobuskiPrevoznikVozac];
GO
IF OBJECT_ID(N'[dbo].[FK_PregledLinijaLinija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Linijas] DROP CONSTRAINT [FK_PregledLinijaLinija];
GO
IF OBJECT_ID(N'[dbo].[FK_UgovorPregledLinija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PregledLinijas] DROP CONSTRAINT [FK_UgovorPregledLinija];
GO
IF OBJECT_ID(N'[dbo].[FK_VozacLinija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Linijas] DROP CONSTRAINT [FK_VozacLinija];
GO
IF OBJECT_ID(N'[dbo].[FK_Elektricni_inherits_Autobus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autobus_Elektricni] DROP CONSTRAINT [FK_Elektricni_inherits_Autobus];
GO
IF OBJECT_ID(N'[dbo].[FK_Zglobni_inherits_Autobus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autobus_Zglobni] DROP CONSTRAINT [FK_Zglobni_inherits_Autobus];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AutobuskaStanicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutobuskaStanicas];
GO
IF OBJECT_ID(N'[dbo].[RedVoznjes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RedVoznjes];
GO
IF OBJECT_ID(N'[dbo].[VoznaSezonas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VoznaSezonas];
GO
IF OBJECT_ID(N'[dbo].[Ugovors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ugovors];
GO
IF OBJECT_ID(N'[dbo].[AutobuskiPrevozniks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutobuskiPrevozniks];
GO
IF OBJECT_ID(N'[dbo].[Autobus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autobus];
GO
IF OBJECT_ID(N'[dbo].[Vozacs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vozacs];
GO
IF OBJECT_ID(N'[dbo].[Linijas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Linijas];
GO
IF OBJECT_ID(N'[dbo].[PregledLinijas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PregledLinijas];
GO
IF OBJECT_ID(N'[dbo].[Autobus_Elektricni]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autobus_Elektricni];
GO
IF OBJECT_ID(N'[dbo].[Autobus_Zglobni]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autobus_Zglobni];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AutobuskaStanicas'
CREATE TABLE [dbo].[AutobuskaStanicas] (
    [IDAS] int IDENTITY(1,1) NOT NULL,
    [NazivAS] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RedVoznjes'
CREATE TABLE [dbo].[RedVoznjes] (
    [AutobuskaStanicaIDAS] int  NOT NULL,
    [VoznaSezonaIdSezone] int  NOT NULL,
    [DatumReda] nvarchar(max)  NOT NULL,
    [PregledLinija_IDPregleda] int  NULL
);
GO

-- Creating table 'VoznaSezonas'
CREATE TABLE [dbo].[VoznaSezonas] (
    [IdSezone] int IDENTITY(1,1) NOT NULL,
    [NazivSezone] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Ugovors'
CREATE TABLE [dbo].[Ugovors] (
    [AutobuskaStanicaIDAS] int  NOT NULL,
    [AutobuskiPrevoznikIDAP] int  NOT NULL,
    [DatumSklapanja] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AutobuskiPrevozniks'
CREATE TABLE [dbo].[AutobuskiPrevozniks] (
    [IDAP] int IDENTITY(1,1) NOT NULL,
    [NazivPrevoznika] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Autobus'
CREATE TABLE [dbo].[Autobus] (
    [IDA] int IDENTITY(1,1) NOT NULL,
    [AutobuskiPrevoznikIDAP] int  NOT NULL
);
GO

-- Creating table 'Vozacs'
CREATE TABLE [dbo].[Vozacs] (
    [IDV] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [AutobuskiPrevoznikIDAP] int  NOT NULL
);
GO

-- Creating table 'Linijas'
CREATE TABLE [dbo].[Linijas] (
    [NazivLinije] nvarchar(10)  NOT NULL,
    [AutobuskiPrevoznikIDAP] int  NOT NULL,
    [PregledLinija_IDPregleda] int  NULL,
    [Vozac_IDV] int  NULL,
    [Vozac_AutobuskiPrevoznikIDAP] int  NULL
);
GO

-- Creating table 'PregledLinijas'
CREATE TABLE [dbo].[PregledLinijas] (
    [IDPregleda] int  NOT NULL,
    [Ugovor_AutobuskaStanicaIDAS] int  NULL,
    [Ugovor_AutobuskiPrevoznikIDAP] int  NULL
);
GO

-- Creating table 'Autobus_Elektricni'
CREATE TABLE [dbo].[Autobus_Elektricni] (
    [IDA] int  NOT NULL,
    [AutobuskiPrevoznikIDAP] int  NOT NULL
);
GO

-- Creating table 'Autobus_Zglobni'
CREATE TABLE [dbo].[Autobus_Zglobni] (
    [IDA] int  NOT NULL,
    [AutobuskiPrevoznikIDAP] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDAS] in table 'AutobuskaStanicas'
ALTER TABLE [dbo].[AutobuskaStanicas]
ADD CONSTRAINT [PK_AutobuskaStanicas]
    PRIMARY KEY CLUSTERED ([IDAS] ASC);
GO

-- Creating primary key on [AutobuskaStanicaIDAS], [VoznaSezonaIdSezone] in table 'RedVoznjes'
ALTER TABLE [dbo].[RedVoznjes]
ADD CONSTRAINT [PK_RedVoznjes]
    PRIMARY KEY CLUSTERED ([AutobuskaStanicaIDAS], [VoznaSezonaIdSezone] ASC);
GO

-- Creating primary key on [IdSezone] in table 'VoznaSezonas'
ALTER TABLE [dbo].[VoznaSezonas]
ADD CONSTRAINT [PK_VoznaSezonas]
    PRIMARY KEY CLUSTERED ([IdSezone] ASC);
GO

-- Creating primary key on [AutobuskaStanicaIDAS], [AutobuskiPrevoznikIDAP] in table 'Ugovors'
ALTER TABLE [dbo].[Ugovors]
ADD CONSTRAINT [PK_Ugovors]
    PRIMARY KEY CLUSTERED ([AutobuskaStanicaIDAS], [AutobuskiPrevoznikIDAP] ASC);
GO

-- Creating primary key on [IDAP] in table 'AutobuskiPrevozniks'
ALTER TABLE [dbo].[AutobuskiPrevozniks]
ADD CONSTRAINT [PK_AutobuskiPrevozniks]
    PRIMARY KEY CLUSTERED ([IDAP] ASC);
GO

-- Creating primary key on [IDA], [AutobuskiPrevoznikIDAP] in table 'Autobus'
ALTER TABLE [dbo].[Autobus]
ADD CONSTRAINT [PK_Autobus]
    PRIMARY KEY CLUSTERED ([IDA], [AutobuskiPrevoznikIDAP] ASC);
GO

-- Creating primary key on [IDV], [AutobuskiPrevoznikIDAP] in table 'Vozacs'
ALTER TABLE [dbo].[Vozacs]
ADD CONSTRAINT [PK_Vozacs]
    PRIMARY KEY CLUSTERED ([IDV], [AutobuskiPrevoznikIDAP] ASC);
GO

-- Creating primary key on [NazivLinije], [AutobuskiPrevoznikIDAP] in table 'Linijas'
ALTER TABLE [dbo].[Linijas]
ADD CONSTRAINT [PK_Linijas]
    PRIMARY KEY CLUSTERED ([NazivLinije], [AutobuskiPrevoznikIDAP] ASC);
GO

-- Creating primary key on [IDPregleda] in table 'PregledLinijas'
ALTER TABLE [dbo].[PregledLinijas]
ADD CONSTRAINT [PK_PregledLinijas]
    PRIMARY KEY CLUSTERED ([IDPregleda] ASC);
GO

-- Creating primary key on [IDA], [AutobuskiPrevoznikIDAP] in table 'Autobus_Elektricni'
ALTER TABLE [dbo].[Autobus_Elektricni]
ADD CONSTRAINT [PK_Autobus_Elektricni]
    PRIMARY KEY CLUSTERED ([IDA], [AutobuskiPrevoznikIDAP] ASC);
GO

-- Creating primary key on [IDA], [AutobuskiPrevoznikIDAP] in table 'Autobus_Zglobni'
ALTER TABLE [dbo].[Autobus_Zglobni]
ADD CONSTRAINT [PK_Autobus_Zglobni]
    PRIMARY KEY CLUSTERED ([IDA], [AutobuskiPrevoznikIDAP] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AutobuskaStanicaIDAS] in table 'RedVoznjes'
ALTER TABLE [dbo].[RedVoznjes]
ADD CONSTRAINT [FK_AutobuskaStanicaRedVoznje]
    FOREIGN KEY ([AutobuskaStanicaIDAS])
    REFERENCES [dbo].[AutobuskaStanicas]
        ([IDAS])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [VoznaSezonaIdSezone] in table 'RedVoznjes'
ALTER TABLE [dbo].[RedVoznjes]
ADD CONSTRAINT [FK_VoznaSezonaRedVoznje]
    FOREIGN KEY ([VoznaSezonaIdSezone])
    REFERENCES [dbo].[VoznaSezonas]
        ([IdSezone])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VoznaSezonaRedVoznje'
CREATE INDEX [IX_FK_VoznaSezonaRedVoznje]
ON [dbo].[RedVoznjes]
    ([VoznaSezonaIdSezone]);
GO

-- Creating foreign key on [AutobuskaStanicaIDAS] in table 'Ugovors'
ALTER TABLE [dbo].[Ugovors]
ADD CONSTRAINT [FK_AutobuskaStanicaUgovor]
    FOREIGN KEY ([AutobuskaStanicaIDAS])
    REFERENCES [dbo].[AutobuskaStanicas]
        ([IDAS])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AutobuskiPrevoznikIDAP] in table 'Ugovors'
ALTER TABLE [dbo].[Ugovors]
ADD CONSTRAINT [FK_AutobuskiPrevoznikUgovor]
    FOREIGN KEY ([AutobuskiPrevoznikIDAP])
    REFERENCES [dbo].[AutobuskiPrevozniks]
        ([IDAP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutobuskiPrevoznikUgovor'
CREATE INDEX [IX_FK_AutobuskiPrevoznikUgovor]
ON [dbo].[Ugovors]
    ([AutobuskiPrevoznikIDAP]);
GO

-- Creating foreign key on [AutobuskiPrevoznikIDAP] in table 'Autobus'
ALTER TABLE [dbo].[Autobus]
ADD CONSTRAINT [FK_AutobuskiPrevoznikAutobus]
    FOREIGN KEY ([AutobuskiPrevoznikIDAP])
    REFERENCES [dbo].[AutobuskiPrevozniks]
        ([IDAP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutobuskiPrevoznikAutobus'
CREATE INDEX [IX_FK_AutobuskiPrevoznikAutobus]
ON [dbo].[Autobus]
    ([AutobuskiPrevoznikIDAP]);
GO

-- Creating foreign key on [PregledLinija_IDPregleda] in table 'RedVoznjes'
ALTER TABLE [dbo].[RedVoznjes]
ADD CONSTRAINT [FK_RedVoznjePregledLinija]
    FOREIGN KEY ([PregledLinija_IDPregleda])
    REFERENCES [dbo].[PregledLinijas]
        ([IDPregleda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RedVoznjePregledLinija'
CREATE INDEX [IX_FK_RedVoznjePregledLinija]
ON [dbo].[RedVoznjes]
    ([PregledLinija_IDPregleda]);
GO

-- Creating foreign key on [AutobuskiPrevoznikIDAP] in table 'Linijas'
ALTER TABLE [dbo].[Linijas]
ADD CONSTRAINT [FK_AutobuskiPrevoznikLinija]
    FOREIGN KEY ([AutobuskiPrevoznikIDAP])
    REFERENCES [dbo].[AutobuskiPrevozniks]
        ([IDAP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutobuskiPrevoznikLinija'
CREATE INDEX [IX_FK_AutobuskiPrevoznikLinija]
ON [dbo].[Linijas]
    ([AutobuskiPrevoznikIDAP]);
GO

-- Creating foreign key on [AutobuskiPrevoznikIDAP] in table 'Vozacs'
ALTER TABLE [dbo].[Vozacs]
ADD CONSTRAINT [FK_AutobuskiPrevoznikVozac]
    FOREIGN KEY ([AutobuskiPrevoznikIDAP])
    REFERENCES [dbo].[AutobuskiPrevozniks]
        ([IDAP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutobuskiPrevoznikVozac'
CREATE INDEX [IX_FK_AutobuskiPrevoznikVozac]
ON [dbo].[Vozacs]
    ([AutobuskiPrevoznikIDAP]);
GO

-- Creating foreign key on [PregledLinija_IDPregleda] in table 'Linijas'
ALTER TABLE [dbo].[Linijas]
ADD CONSTRAINT [FK_PregledLinijaLinija]
    FOREIGN KEY ([PregledLinija_IDPregleda])
    REFERENCES [dbo].[PregledLinijas]
        ([IDPregleda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PregledLinijaLinija'
CREATE INDEX [IX_FK_PregledLinijaLinija]
ON [dbo].[Linijas]
    ([PregledLinija_IDPregleda]);
GO

-- Creating foreign key on [Ugovor_AutobuskaStanicaIDAS], [Ugovor_AutobuskiPrevoznikIDAP] in table 'PregledLinijas'
ALTER TABLE [dbo].[PregledLinijas]
ADD CONSTRAINT [FK_UgovorPregledLinija]
    FOREIGN KEY ([Ugovor_AutobuskaStanicaIDAS], [Ugovor_AutobuskiPrevoznikIDAP])
    REFERENCES [dbo].[Ugovors]
        ([AutobuskaStanicaIDAS], [AutobuskiPrevoznikIDAP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UgovorPregledLinija'
CREATE INDEX [IX_FK_UgovorPregledLinija]
ON [dbo].[PregledLinijas]
    ([Ugovor_AutobuskaStanicaIDAS], [Ugovor_AutobuskiPrevoznikIDAP]);
GO

-- Creating foreign key on [Vozac_IDV], [Vozac_AutobuskiPrevoznikIDAP] in table 'Linijas'
ALTER TABLE [dbo].[Linijas]
ADD CONSTRAINT [FK_VozacLinija]
    FOREIGN KEY ([Vozac_IDV], [Vozac_AutobuskiPrevoznikIDAP])
    REFERENCES [dbo].[Vozacs]
        ([IDV], [AutobuskiPrevoznikIDAP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VozacLinija'
CREATE INDEX [IX_FK_VozacLinija]
ON [dbo].[Linijas]
    ([Vozac_IDV], [Vozac_AutobuskiPrevoznikIDAP]);
GO

-- Creating foreign key on [IDA], [AutobuskiPrevoznikIDAP] in table 'Autobus_Elektricni'
ALTER TABLE [dbo].[Autobus_Elektricni]
ADD CONSTRAINT [FK_Elektricni_inherits_Autobus]
    FOREIGN KEY ([IDA], [AutobuskiPrevoznikIDAP])
    REFERENCES [dbo].[Autobus]
        ([IDA], [AutobuskiPrevoznikIDAP])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IDA], [AutobuskiPrevoznikIDAP] in table 'Autobus_Zglobni'
ALTER TABLE [dbo].[Autobus_Zglobni]
ADD CONSTRAINT [FK_Zglobni_inherits_Autobus]
    FOREIGN KEY ([IDA], [AutobuskiPrevoznikIDAP])
    REFERENCES [dbo].[Autobus]
        ([IDA], [AutobuskiPrevoznikIDAP])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------