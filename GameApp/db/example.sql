-- Single line comment

/* Multi
Line
Comment */


-- Example table setup with procedure
drop database if exists GameDB;

create database GameDB;
use GameDB;

delimiter //
drop procedure if exists MakeTables//
create procedure MakeTables()
begin
	drop table if exists tblName;
    create table tblName(
		ID int auto_increment primary key,
        `NAME` varchar(255)
	);
    
    drop table if exists tblCar;
	create table tblCar(
		ID int auto_increment primary key,
        MODEL varchar(255),
        CARID int,
        foreign key(CARID) references tblName(ID)
	);
end//
delimiter ;

call MakeTable;
desc tblCar;
desc tblName;