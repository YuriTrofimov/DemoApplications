-- Copyright (c) 2023 Yuri Trofimov.
-- Licensed under the MIT license. See LICENSE file in the project root for full license information.

if (not exists(select * from INFORMATION_SCHEMA.TABLES 
	where TABLE_NAME='Products' and TABLE_SCHEMA='dbo'))
begin
	create table dbo.Products(
		Id int NOT NULL IDENTITY(1,1),
		Article varchar(50) COLLATE Cyrillic_General_CI_AS NOT NULL,
		[Name] varchar(250) COLLATE Cyrillic_General_CI_AS NOT NULL,
		Price numeric(15, 2) NOT NULL default 0.00,
		Quantity int NOT NULL default 0,
		PRIMARY KEY(Id)
	)
end