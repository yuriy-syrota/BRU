CREATE SCHEMA [MAIN]
GO

CREATE SCHEMA [REFERENCE]
GO

CREATE TABLE [REFERENCE].[BikeType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL primary key,
	[Name] [varchar](100) NOT NULL
)
GO

insert into [REFERENCE].[BikeType] (Name) values('Road bike');
insert into [REFERENCE].[BikeType] (Name) values('Gravel bike');
insert into [REFERENCE].[BikeType] (Name) values('Mountain bike');
insert into [REFERENCE].[BikeType] (Name) values('Lifestyle bike');
insert into [REFERENCE].[BikeType] (Name) values('E-bike');
insert into [REFERENCE].[BikeType] (Name) values('BMX bike');
insert into [REFERENCE].[BikeType] (Name) values('Kids bike');

CREATE TABLE [REFERENCE].[ProductType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL primary key,
	[Name] [varchar](100) NOT NULL
)
GO

insert into [REFERENCE].[ProductType] (Name) values('Bikes/Frames');
insert into [REFERENCE].[ProductType] (Name) values('Accesories');
insert into [REFERENCE].[ProductType] (Name) values('Clothing');
insert into [REFERENCE].[ProductType] (Name) values('Maintenance');
insert into [REFERENCE].[ProductType] (Name) values('Parts');
insert into [REFERENCE].[ProductType] (Name) values('Tires/Tubes');

CREATE TABLE [REFERENCE].[Brand](
	[Id] [bigint] IDENTITY(1,1) NOT NULL primary key,
	[Name] [varchar](100) NOT NULL
)
GO

insert into [REFERENCE].[Brand] (Name) values('Shimano');
insert into [REFERENCE].[Brand] (Name) values('Specialaized');
insert into [REFERENCE].[Brand] (Name) values('Garmin');
insert into [REFERENCE].[Brand] (Name) values('SRAM');
insert into [REFERENCE].[Brand] (Name) values('Performance');
insert into [REFERENCE].[Brand] (Name) values('Giro');


CREATE TABLE [MAIN].[ProductImage](
	[Id] [bigint] identity(1,1) NOT NULL PRIMARY KEY,
	[ImageData] [varbinary](max) NOT NULL,
)
GO

CREATE TABLE [MAIN].[Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL primary key,
	[Name] [varchar](1000) NOT NULL,
	[Description] [varchar](MAX) NOT NULL,
	[Rating] [int] null,
	[Price] decimal not null,
	[ProductTypeId] [bigint] NOT NULL,
	[BikeTypeId] [bigint] NULL,
	[BrandId] [bigint] NOT NULL,
	[ImageId] [bigint] NULL,
	CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ProductTypeId]) REFERENCES [REFERENCE].[ProductType] ([Id]),
	CONSTRAINT [FK_Product_BikeType] FOREIGN KEY([BikeTypeId]) REFERENCES [REFERENCE].[BikeType] ([Id]),
	CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandId]) REFERENCES [REFERENCE].[Brand] ([Id]),
	CONSTRAINT [FK_Product_Image] FOREIGN KEY([ImageId]) REFERENCES [MAIN].[ProductImage] ([Id])
)
GO

CREATE TABLE [MAIN].[Inventory](
	[Id] [bigint] identity(1,1) NOT NULL PRIMARY KEY,
	[ProductId] [bigint] not null,
	[Quantity] [int] null,
	CONSTRAINT [FK_Invenory_Product] FOREIGN KEY([ProductId]) REFERENCES [MAIN].[Product] ([Id])
)
GO
