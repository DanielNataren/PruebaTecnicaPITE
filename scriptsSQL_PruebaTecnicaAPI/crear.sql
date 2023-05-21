use DBPRUEBATECNICA
go
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'DBPRUEBATECNICA')
CREATE DATABASE DBPRUEBATECNICA

GO 

USE DBPRUEBATECNICA

GO

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'TRABAJADORES')
create table TRABAJADORES(
id int primary key identity(1,1),
documentoIdentidad varchar(60),
nombres varchar(60),
telefono varchar(60),
correo varchar(60),
ciudad varchar(60),
fechaRegistro datetime default getdate()
)

go

select * from dbo.TRABAJADORES