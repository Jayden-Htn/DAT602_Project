-- Survivor Island Start Script

drop database if exists GameDB;
create database GameDB;
use GameDB;

delimiter //
drop procedure if exists MakeTables//
create procedure MakeTables()
begin
	drop table if exists tblPlayer;
    create table tblName(
		ID int auto_increment primary key,
        Username varchar(255),
	);
    
    drop table if exists tblCharacter;
	create table tblCar(
		ID int auto_increment primary key,
        MODEL varchar(255),
        CARID int,
        foreign key(CARID) references tblName(ID)
	);
end//
delimiter ;