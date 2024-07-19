create database QL_XepHang

create table Nguoichoi(
	Manguoichoi int primary key,
	Name nvarchar(50)
)
go
create table diem(
	Manguoichoi int,
	diem float,
	thang int,
	foreign key(Manguoichoi) references Nguoichoi(Manguoichoi)
)
insert into Nguoichoi 
values (1,N'John Wick 1')
insert into Nguoichoi 
values (2,N'Joh Wick 2')
insert into Nguoichoi 
values (3,N'Joh Wick 3')
insert into Nguoichoi 
values (4,N'Joh Wick 4')
insert into Nguoichoi 
values (5,N'Joh Wick 5')

insert into diem 
values (2,200,1)
insert into diem 
values (1,245,12)
insert into diem 
values (3,500,4)
insert into diem 
values (4,56,7)
insert into diem 
values (5,12,3)
insert into diem 
values (2,90,3)

select * from Nguoichoi;

select * from diem;
