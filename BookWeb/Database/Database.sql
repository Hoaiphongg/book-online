

--use master

-- drop database if exists
--if (select count(name)
--from sysdatabases
--where name = 'BookStore') <> 0
	--drop database [BookStore]
--go--

-- create database
create database [BookStore]
go

-- use database
use [BookStore]
go

---------------------------------------------------------------------------------------
-- create table
create table [AccountGroup](
	[id] varchar(20) primary key,
	[name] varchar(50) not null
)


create table [Account]
(
	[id] int identity primary key,
	[username] varchar(50) not null,
	[password] varchar(200) not null,
	[groupid] varchar(20) references [AccountGroup]([id]) default ('Member'),
	-- 1: customer, 2: manager
	[name] nvarchar(50) not null,
	[gender] bit not null,
	-- 0: female, 1: male
	[birthday] date not null,
	[address] nvarchar(100) not null,
	[phone] varchar(15) not null,
	[email] varchar(50),
	[status] bit not null default 1
	-- 0: disable, --1: enable
)
go

create table [Category]
(
	[id] int identity primary key,
	[name] nvarchar(50) not null unique,
	[metatitle] varchar(50) not null,
	[status] bit not null default 1
	-- 0: disable, --1: enable
)
go

create table [Book]
(
	[id] int identity primary key,
	[name] nvarchar(50) not null,
	[metatitle] varchar(50) not null,
	[author] nvarchar(50) not null,
	[idCategory] int not null references [Category]([id]),
	[price] float not null,
	[status] bit not null default 1,
	-- 0: disable, --1: enable
	[image] varchar(100) not null
)
go

create table [Discount]
(
	[id] int identity primary key,
	[name] uniqueidentifier,
	[sale] float not null,
	[status] int not null default 1
	-- 0: disable, --1: enable, --2: giving out
)
go

create table [Bill]
(
	[id] int identity primary key,

	[idCustomer] int references [Account]([id]),
	[idDiscount] int references [Discount]([id]),
	[sale] float not null default 0,
	[checkin] datetime not null default getdate(),
	[shipaddress] nvarchar(100),
	[shipMobile] nvarchar(50),
	[shipname] nvarchar(100),
	[shipemail] nvarchar(50)
)
go

create table [BillDetail]
(
	[id] int identity primary key,
	[idBill] int not null references [Bill]([id]),
	[quantity] int not null,
	[price] float not null
)
go

create table [Slide](
	[id] int identity primary key,
	[image] nvarchar(100),
	[link] nvarchar(100),
	[createday] datetime,
	[status] bit default 1
)

create table [MenuType](
	[id] int identity primary key,
	[name] nvarchar(100) not null
)

create table [Menu](
	[id] int identity primary key,
	[name] nvarchar(50) not null,
	[link] nvarchar(50),
	[displayorder] int,
	[status] bit default 1,
	[typeid] int references [MenuType]([id])
)
---------------------------------------------------------------------------------------
-- create view
/*
create view [BillList] as (
	select
		[Bill].[id],
		[Bill].[idCustomer],
		[Customer].[name] as [nameCustomer],
		[Bill].[idEmployee],
		[Employee].[name] as [nameEmployee],
		[Bill].[idDiscount],
		[Discount].[name] as [nameDiscount],
		[Bill].[sale],
		[Bill].[checkIn],
		[Bill].[checkOut],
		sum([BillDetail].[price] * [BillDetail].[quantity]) as [totalBefore]
	from [Bill] 
	left outer join [Account] as [Customer] on [Customer].[id] =[Bill].[idCustomer]
	left outer join [Account] as [Employee] on [Employee].[id] =[Bill].[idEmployee]
	left outer join [Discount] on [Discount].[id] =[Bill].[idDiscount]
	left outer join [BillDetail] on [BillDetail].[idBill] = [Bill].[id]
	group by 
		[Bill].[id],
		[Bill].[idCustomer],
		[Customer].[name],
		[Bill].[idEmployee],
		[Employee].[name],
		[Bill].[idDiscount],
		[Discount].[name],
		[Bill].[sale],
		[Bill].[checkIn],
		[Bill].[checkOut]
)
go

create view [Income] as (
	select 
		cast([checkIn] as date) as [date],
		sum([totalBefore] - [totalBefore] * ([sale] / 100.0)) as [income]
	from  [BillList]
	group by cast([checkIn] as date)
)
go

create view [Buy] as (
	select
		[idCustomer] as [id],
		[nameCustomer] as [name],
		sum([totalBefore] - [totalBefore] * ([sale] / 100.0)) as [income]
	from  [BillList]
	where [idCustomer] is not null
	group by [idCustomer], [nameCustomer]	
)
go

-- tim mon mua nhieu nhat
create view [Sell] as (
	select 
		[idBook],
		[nameBook],
		[idCategory],
		[nameCategory],
		sum([quantity]) as [quantity],
		sum([price]*[quantity]) as [income]		
	from [BillDetail] 
	group by [idBook], [nameBook], [idCategory], [nameCategory]
)
go

---------------------------------------------------------------------------------------
-- create procedure

create proc [loginAdmin]
	@username varchar(50)
as
begin
	select *
	from [Account]
	where [username] = @username and [roll] > 1 and [status] = 1;
end
go

create proc [loginCustomer]
	@username varchar(50)
as
begin
	select *
	from [Account]
	where [username] = @username and [roll] = 1 and [status] = 1;
end
go

create proc [checkDiscount]
	@name varchar(50)
as
begin
	select *
	from [Discount]
	where convert(nvarchar(50), [name]) = @name and [status] > 0;
end
go

create proc [checkoutBill]
	@idTable int
as
begin
	declare @idBill int = (select [id] from [Bill] where [checkout] is null);

	update [Bill] set
		[checkout] = getdate()
	where [id] = @idBill;

	select * from [BillList] where [id] = @idBill;
end
go

-- insert

create proc [insertAccount]
	@username varchar(50),
	@password varchar(200),
	@roll int,
	@name varchar(50),
	@gender bit,
	@birthday date,
	@address varchar(100),
	@phone varchar(15),
	@email varchar(50)
as
begin
	insert into [Account]
		([username], [password], [roll], [name], [gender], [birthday], [address], [phone], [email])
	values
		(@username + cast(ident_current('Account') as varchar), @password, @roll, @name, @gender, @birthday, @address, @phone, @email);
	select *
	from [Account]
	where [id] = scope_identity();
end
go

create proc [insertCategory]
	@name varchar(50)
as
begin
	if exists (select *
	from [Category]
	where [name] = @name)
		select *
	from [Category]
	where [id] = 0;
	else begin
		insert into [Category]
			([name])
		values
			(@name);
		select *
		from [Category]
		where [id] = scope_identity();
	end
end
go

create proc [insertDiscount]	
	@sale float
as
begin
	insert into [Discount]
		([name], [sale])
	values
		(NEWID(), @sale);
	select *
	from [Discount]
	where [id] = scope_identity();
end
go

create proc [insertBook]
	@name varchar(50),
	@author varchar(50),
	@idCategory int,
	@price float
as
begin
	insert into [Book]
		([name],[author],[idCategory],[price])
	values
		(@name, @author, @idCategory, @price);
	select *
	from [Book]
	where [id] = scope_identity();
end
go

create proc [insertBill]
	@idCustomer int,
	@idEmployee int,
	@idDiscount int,
	@sale float
as
begin
	insert into [Bill]
		([idCustomer], [idEmployee], [idDiscount], [sale])
	values(@idCustomer, @idEmployee,@idDiscount, @sale);

	select * 
	from [BillList]
	where [id] = scope_identity();
end
go

create proc [insertBillDetail]
	@idBill int,
	@idBook int,
	@nameBook varchar(50),
	@idCategory int,
	@nameCategory varchar(50),
	@quantity int,
	@price float
as
begin
	insert into [BillDetail]
		([idBill], [idBook], [nameBook], [idCategory], [nameCategory], [quantity], [price])
	values
		(@idBill, @idBook, @nameBook, @idCategory, @nameCategory, @quantity, @price);

	select *
	from [BillList]
	where [id] = @idBill;
end
go

-- update

create proc [updateAccount]
	@id int,
	@password varchar(200),
	@roll int,
	@name varchar(50),
	@gender bit,
	@birthday date,
	@address varchar(100),
	@phone varchar(15),
	@email varchar(50)
as
begin
	update [Account] set
		[password] = @password,
		[roll] = @roll,
		[name] = @name,
		[gender] = @gender,
		[birthday] = @birthday,
		[address] = @address,
		[phone] = @phone,
		[email] = @email
	where [id] = @id;
	select *
	from [Account]
	where [id] = @id;
end
go

create proc [updateCategory]
	@id int,
	@name varchar(50)
as
begin
	if exists (select *
	from [Category]
	where [name]= @name)
		select *
	from [Category]
	where [id] = 0;
	else begin
		update [Category] set
			[name] = @name
		where [id] = @id;
		select *
		from [Category]
		where [id] = @id;
	end
end
go

create proc [updateBook]
	@id int,
	@name varchar(50),
	@idCategory int,
	@price float
as
begin
	update [Book] set
		[name] = @name,
		[idCategory] = @idCategory,
		[price] = @price
	where [id] = @id;
	select *
	from [Book]
	where [id] = @id;
end
go

create proc [updateDiscount]
	@id int,
	@sale float
as
begin
	update [Discount] set
		[sale] = @sale
	where [id] = @id;
	select *
	from [Discount]
	where [id] = @id;
end
go

-- change status

create proc [statusAccount]
	@id int,
	@status bit
as
begin
	update [Account] set
		[status] = @status
	where [id] = @id;
	select *
	from [Account]
	where [id] = @id;
end
go

create proc [statusCategory]
	@id int,
	@status bit
as
begin	
	update [Category] set
		[status] = @status
	where [id] = @id;
	select *
	from [Category]
	where [id] = @id;
end
go

create proc [statusBook]
	@id int,
	@status bit
as
begin
	update [Book] set
		[status] = @status
	where [id] = @id;
	select *
	from [Book]
	where [id] = @id;
end
go

create proc [statusDiscount]
	@id int,
	@status int
as
begin
	update [Discount] set
		[status] = @status
	where [id] = @id;
	select *
	from [Discount]
	where [id] = @id;
end
go

-- delete

create proc [deleteAccount]
	@id int
as
begin
	begin try
		delete [Account] where [id] = @id;
		select * from [Account] where [id] = 0;
	end try
	begin catch
		select * from [Account] where [id] = @id;
	end catch
end
go

create proc [deleteCategory]
	@id int
as
begin	
	begin try
		delete [Category] where [id] = @id;
		select * from [Category] where [id] = 0;
	end try
	begin catch
		select * from [Category] where [id] = @id;
	end catch
end
go

create proc [deleteBook]
	@id int
as
begin
	begin try
		delete [Book] where [id] = @id;
		select * from [Book] where [id] = 0;
	end try
	begin catch
		select * from [Book] where [id] = @id;
	end catch
end
go

create proc [deleteDiscount]
	@id int
as
begin
	begin try
		delete [Discount] where [id] = @id;
		select * from [Discount] where [id] = 0;
	end try
	begin catch
		select * from [Discount] where [id] = @id;
	end catch
end
go*/