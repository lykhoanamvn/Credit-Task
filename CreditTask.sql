create database CreditTask

create table Item(
	id int Identity(1,1) primary key,
	itemID varchar(10),
	itemName nvarchar(30),
	size int,
	quantity int,
)

create table Agent(
	id int Identity(1,1) primary key,
	agentId varchar(10),
	agentName nvarchar(30),
	address nvarchar(30),
)

create table Order_order(
	id int Identity(1,1) primary key,
	orderId varchar(10),
	orderDate datetime not null default CURRENT_TIMESTAMP,
	agentID varchar(10),
)

create table order_Detail(
	id_detail int Identity(1,1) primary key,
	id varchar(10),
	orderId varchar(10),
	itemId varchar(10),
	quantity int,
	unitAmount int
)

create table username(
	id varchar(10),
	username nvarchar(20),
	pass nvarchar(30),
)

drop table Order_order

insert into username values('user','Ly Khoa Nam','user')

select * from username

insert into Item values('I0001','Iphone 1',5,100)
insert into Item values('I0002','Iphone 2',6,10)
insert into Item values('I0003','Iphone 3',7,3)
insert into Item values('I0004','Iphone 4',8,52)
insert into Item values('I0005','Iphone 5',8,1)
insert into Item values('I0006','Iphone 6',8,5)
insert into Item values('I0007','Iphone 7',9,43)
insert into Item values('I0008','Iphone 8',10,13)
insert into Item values('I0009','Iphone 9',12,12)
insert into Item values('I0010','Iphone X',12,11)
insert into Item values('I0011','Iphone X Plus',14,100)
insert into Item values('I0012','Iphone 11',14,34)
insert into Item values('I0013','Iphone 12',14,20)
insert into Item values('I0014','Iphone 13',15,30)
insert into Item values('I0015','Iphone 14',16,10)

insert into Agent values('A0001','Nguyen Thanh Long','Ha Tinh')
insert into Agent values('A0002','Ly Khoa Nam','An Giang')
insert into Agent values('A0003','Ly Khuynh Thien','An Giang')
insert into Agent values('A0004','Mai Dang','Ca Mau')
insert into Agent values('A0005','Bui Thi Oi','Ha Giang')
insert into Agent values('A0006','Nguyen Dinh Cong Hung','Ha Noi')
insert into Agent values('A0007','Le Thi My Tuyen','An Giang')
insert into Agent values('A0008','Dang Hoang Dan Tam','An Giang')
insert into Agent values('A0009','Ly Vu Kha','An Giang')
insert into Agent values('A0010','Ngo Van Hoang Tam','Dak Lak')
insert into Agent values('A0011','Dang Ngoc Thach','TP Da Nang')
insert into Agent values('A0012','Trang Cat Tuong','TP Ho Chi Minh')
insert into Agent values('A0013','Gia Cat Luong','Tam Quoc')
insert into Agent values('A0014','Quan Cong','Tam Quoc')
insert into Agent values('A0015','Trieu Tu Long','Tam Quoc')

insert into Order_order values('OD0001','2/12/2023','A0002')
insert into Order_order values('OD0002','1/23/2023','A0002')
insert into Order_order values('OD0003','6/25/2023','A0002')
insert into Order_order values('OD0004','3/2/2023','A0005')
insert into Order_order values('OD0005','6/29/2023','A0006')
insert into Order_order values('OD0006','5/4/2023','A0007')
insert into Order_order values('OD0007','6/6/2023','A0007')
insert into Order_order values('OD0008','2/7/2023','A0007')
insert into Order_order values('OD0009','12/12/2023','A0002')
insert into Order_order values('OD0010','11/2/2023','A0010')
insert into Order_order values('OD0011','1/23/2023','A0011')
insert into Order_order values('OD0012','2/3/2023','A0011')
insert into Order_order values('OD0013','12/11/2023','A0012')
insert into Order_order values('OD0014','2/11/2023','A0013')
insert into Order_order values('OD0015','10/12/2023','A0013')

insert into order_Detail values('DETAIL0001','OD0001','I0001',100,100)
insert into order_Detail values('DETAIL0002','OD0001','I0002',100,100)
insert into order_Detail values('DETAIL0003','OD0001','I0002',100,100)
insert into order_Detail values('DETAIL0004','OD0001','I0002',100,100)
insert into order_Detail values('DETAIL0005','OD0002','I0003',100,100)
insert into order_Detail values('DETAIL0006','OD0003','I0002',100,100)
insert into order_Detail values('DETAIL0007','OD0003','I0005',100,100)
insert into order_Detail values('DETAIL0008','OD0004','I0002',100,100)
insert into order_Detail values('DETAIL0009','OD0006','I0010',100,100)
insert into order_Detail values('DETAIL0010','OD0010','I0010',100,100)
insert into order_Detail values('DETAIL0011','OD0010','I0010',100,100)
insert into order_Detail values('DETAIL0012','OD0011','I0012',100,100)
insert into order_Detail values('DETAIL0013','OD0012','I0013',100,100)
insert into order_Detail values('DETAIL0014','OD0014','I0014',100,100)
insert into order_Detail values('DETAIL0015','OD0015','I0015',100,100)

select * from item

select * from Agent

select * from Order_order

select * from order_Detail

select count(*) from item

select distinct agentName from Agent where agentId in (

select agentId from Order_order where orderID in (

select order_Detail.orderId from order_Detail, Item where Item.itemID = order_Detail.itemId

	)
)

select top 3 * from order_Detail ORDER BY itemId DESC


select * from item where itemid in (

SELECT  top 3 itemId
FROM order_Detail
GROUP BY itemId
HAVING COUNT(itemId) > 0
ORDER BY COUNT(itemId) desc
)
select * from Agent where agentId in (SELECT  top 3 agentId FROM Order_order GROUP BY agentId HAVING COUNT(agentId) > 1 ORDER BY COUNT(agentId) desc)



