-- Survivor Island Start Script

drop database if exists GameDB;
create database GameDB;
use GameDB;

-- Make Tables Procedure
delimiter //
drop procedure if exists MakeTables//
create procedure MakeTables()
begin
    -- Make tables
    drop table if exists tblPlayer;
	create table tblPlayer (
		ID            	int(10) not null, 
		Username      	varchar(255) not null unique, 
		`Password`    	varchar(255) not null, 
		LoginAttempts 	tinyint(3) default 0 not null, 
		`Locked`      	bit(1) default 0 not null, 
		`Online`     	bit(1) default 1 not null, 
		`Admin`      	bit(1) default 0 not null, 
		HighestScore  	int(10) default 0 not null, 
        primary key (ID));
    drop table if exists tblCharacter;
    create table tblCharacter (
        ID            	int(10) not null auto_increment, 
        PlayerID    	int(10) not null, 
        GameID        	int(10) not null, 
        InventoryID   	int(10) not null unique, 
        XPosition     	int(10) not null, 
        YPosition     	int(10) not null, 
        Score         	int(10) not null, 
        CurrentHealth 	int(3) not null, 
        MaxHealth     	int(3) not null, 
        primary key (ID));
    drop table if exists tblItem;
    create table tblItem (
        `Name`       	varchar(255) not null, 
        HealthEffect 	int(10) not null, 
        ScoreEffect  	int(10) not null, 
        AddInventory 	bit(1) not null, 
        primary key (Name));
    drop table if exists tblGame;
    create table tblGame (
        GameID    		int(10) not null auto_increment, 
        StartTime 		date not null, 
        primary key (GameID));
    drop table if exists tblChatMessage;
    create table tblChatMessage (
        ID       		int(10) not null auto_increment, 
        PlayerID 		int(10) not null, 
        GameID   		int(10) not null, 
        Message  		varchar(255) not null, 
        `DateTime` 		date not null, 
        primary key (ID));
    drop table if exists tblInventory;
    create table tblInventory (
        ID int(10) 		not null auto_increment, 
        primary key (ID));
    drop table if exists tblTile;
    create table tblTile (
        ID             	int(10) not null auto_increment, 
        MapID          	int(10) not null, 
        ColumnPosition 	int(10) not null, 
        RowPosition    	int(10) not null, 
        TileTypeName   	varchar(255) not null, 
        primary key (ID));
    drop table if exists tblMap;
    create table tblMap (
        ID         		int(10) not null auto_increment, 
        GameID    		int(10) not null unique, 
        MaxColumns 		int(10) not null, 
        MaxRows    		int(10) not null, 
        primary key (ID));
    drop table if exists tblTileType;
    create table tblTileType (
        `Name`        	varchar(255) not null, 
        Item          	varchar(255) not null, 
        IsObstacle    	bit(1) not null, 
        SpawnModifier 	int(2) not null, 
        primary key (Name));
    drop table if exists tblInventory_Item;
    create table tblInventory_Item (
        InventoryID 	int(10) not null, 
        ItemName    	varchar(255) not null, 
        primary key (InventoryID, 
        ItemName));
    drop table if exists tblGameRequests;
    create table tblGameRequest (
        PlayerID  		int(10) not null, 
        PlayerID2 		int(10) not null, 
        primary key (PlayerID, 
        PlayerID2));

    -- Add constraints
    alter table tblCharacter add constraint FKCharacter364171 foreign key (GameID) references tblGame (GameID);
    alter table tblCharacter add constraint FKCharacter575292 foreign key (InventoryID) references tblInventory (ID);
    alter table tblMap add constraint FKMap482625 foreign key (GameID) references tblGame (GameID);
    alter table tblTile add constraint FKTile797128 foreign key (MapID) references tblMap (ID);
    alter table tblCharacter add constraint FKCharacter770219 foreign key (PlayerID) references tblPlayer (ID);
    alter table tblChatMessage add constraint FKChatMessag532923 foreign key (PlayerID) references tblPlayer (ID);
    alter table tblChatMessage add constraint FKChatMessag938971 foreign key (GameID) references tblGame (GameID);
    alter table tblTile add constraint FKTile387365 foreign key (TileTypeName) references tblTileType (`Name`);
    alter table tblTileType add constraint FKTileType337721 foreign key (Item) references tblItem (`Name`);
    alter table tblInventory_Item add constraint FKInventory_981203 foreign key (InventoryID) references tblInventory (ID);
    alter table tblInventory_Item add constraint FKInventory_288484 foreign key (ItemName) references tblItem (`Name`);
    alter table tblGameRequest add constraint FKGameReques913089 foreign key (PlayerID) references tblPlayer (ID);
    alter table tblGameRequest add constraint FKGameReques40555 foreign key (PlayerID2) references tblPlayer (ID);
end//
delimiter ;

-- Insert Data Procedure
delimiter //
drop procedure if exists InsertData//
create procedure InsertData()
begin
	insert into tblPlayer (Username)
	values 
        ("Player1"),
        ("Player2"),
        ("Player3"),
        ("Player4");
end//
delimiter ;

call MakeTables();