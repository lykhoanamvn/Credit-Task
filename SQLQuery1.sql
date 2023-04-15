create database CreditTask_Ex2

create table users(
	id int IDENTITY(1,1) PRIMARY KEY,
	username varchar(10) ,
	fullname nvarchar(20),
	pass nvarchar(30),
)

select * from users 