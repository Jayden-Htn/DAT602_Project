-- Survivor Island Start Script

drop database if exists GameDB;
create database GameDB;
use GameDB;

-- Make Tables Procedure
delimiter //
drop procedure if exists MakeTables//
create procedure MakeTables()
begin
    drop table if exists tblPlayer;
	create table tblPlayer (
		ID            	int not null auto_increment, 
		Username      	varchar(255) not null unique, 
		`Password`    	varchar(255) not null, 
		LoginAttempts 	tinyint default 0 not null, 
		`Locked`      	bit(1) default 0 not null, 
		`Online`     	bit(1) default 0 not null, 
		`Admin`      	bit(1) default 0 not null, 
		HighestScore  	int default 0 not null, 
        primary key (ID)
	);
	drop table if exists tblGame;
    create table tblGame (
        GameID    		int not null auto_increment, 
        StartTime 		datetime not null, 
        primary key (GameID)
	);
    drop table if exists tblCharacter;
    create table tblCharacter (
		ID				int not null auto_increment,
        PlayerID    	int not null, 
        GameID        	int not null, 
        ColPosition     	int default 1 not null, 
        RowPosition     	int default 1 not null, 
        Score         	int default 0 not null, 
        CurrentHealth 	tinyint  default 100 not null, 
        MaxHealth     	tinyint  default 100 not null, 
        primary key (ID),
        foreign key (PlayerID) references tblPlayer(ID) on delete cascade,
        foreign key (GameID) references tblGame(GameID) on delete cascade
	);
	drop table if exists tblEntity;
    create table tblEntity (
        `Name`       	varchar(255) not null, 
        HealthEffect 	tinyint not null, 
        ScoreEffect  	tinyint not null, 
        AddInventory 	bit(1) not null, 
        IsNpc	bit(1) not null, 
        primary key (`Name`)
	);
	drop table if exists tblTileType;
    create table tblTileType (
        `Name`        	varchar(255) not null, 
        Entity         	varchar(255), 
        IsObstacle    	bit(1) not null, 
        SpawnModifier 	double not null, 
        primary key (`Name`),
        foreign key (Entity) references tblEntity(`Name`)
	);
    drop table if exists tblChatMessage;
    create table tblChatMessage (
        ID       		int not null auto_increment, 
        PlayerID 		int not null, 
        GameID   		int not null, 
        Message  		varchar(255) not null, 
        `DateTime` 		datetime not null, 
        primary key (ID),
        foreign key (PlayerID) references tblPlayer(ID) on delete cascade,
        foreign key (GameID) references tblGame(GameID) on delete cascade
	);
	drop table if exists tblMap;
    create table tblMap (
        ID         		int not null auto_increment, 
        GameID    		int not null unique, 
        MaxColumns 		int not null, 
        MaxRows    		int not null, 
        HomeTile		int,
        primary key (ID),
        foreign key (GameID) references tblGame(GameID) on delete cascade
	);
    drop table if exists tblTile;
    create table tblTile (
        ID             	int not null auto_increment, 
        MapID          	int not null, 
        ColPosition 	int not null, 
        RowPosition    	int not null, 
        TileTypeName   	varchar(255) not null, 
        primary key (ID),
        foreign key (MapID) references tblMap(ID) on delete cascade
	);
    drop table if exists tblInventory;
    create table tblInventory(
		ID				int not null auto_increment,
        ItemName    	varchar(255) not null, 
        CharacterID 	int not null,
        primary key (ID),
        foreign key (ItemName) references tblEntity(`Name`),
		foreign key (CharacterID) references tblCharacter(ID) on delete cascade
	);
    drop table if exists tblGameRequests;
    create table tblGameRequest (
        PlayerID  		int not null, 
        PlayerID2 		int not null, 
        primary key (PlayerID, PlayerID2),
        foreign key (PlayerID) references tblPlayer(ID) on delete cascade,
        foreign key (PlayerID2) references tblPlayer(ID) on delete cascade
	);
	alter table tblMap add foreign key (HomeTile) references tblTile(ID);
end//
delimiter ;

-- Insert Data Procedure
delimiter //
drop procedure if exists InsertData//
create procedure InsertData()
begin
	insert into tblPlayer (Username, `Password`, `Locked`)
	values 
        ("Player1", "Password123", 0),
        ("Player2", "Password123", 0),
        ("Player3", "Password123", 0),
        ("Player4", "Password123", 1);
	insert into tblGame (StartTime)
	values 
        ("2004-08-27 11:46:22"),
        ("2004-08-27 11:46:22"),
        ("2004-08-27 11:46:22");
	insert into tblEntity (`Name`, HealthEffect, ScoreEffect, AddInventory, IsNpc)
	values 
        ("Fruit", 20, 0, 1, 0),
        ("Meat", 50, 0, 1, 0),
        ("Coin", 0, 1, 0, 0),
        ("Gem", 0, 5, 0, 0),
        ("Spider", -10, 5, 0, 1),
        ("Snake", -30, 10, 0, 1),
        ("Boar", -80, 20, 0, 1);
	insert into tblCharacter (PlayerID, GameID)
	values 
        (1, 1),
        (2, 1);
	insert into tblInventory(ItemName, CharacterID)
	values 
        ("Meat", 1);
    insert into tblChatMessage (PlayerID, GameID, Message, `Datetime`)
	values 
        (1, 1, "Hey where are you", "2004-08-27 11:49:32"),
        (2, 1, "Go away", "2004-08-27 11:51:51");
	insert into tblTileType(`Name`, Entity, IsObstacle, SpawnModifier)
	values 
		("Coin", "Coin", 0, 0.7),
        ("Gem", "Gem", 0, 0.3),
        ("Spider", "Spider", 0, 0.7),
        ("Snake", "Snake", 0, 0.5),
        ("Boar", "Boar", 0, 0.2),
        ("Fruit", "Fruit", 0, 0.8),
        ("Meat", "Meat", 0, 0.2),
        ("Rock", null, 1, 1);
	insert into tblMap(GameID, MaxColumns, MaxRows)
	values 
        (1, 10, 10),
        (2, 10, 10);
	insert into tblTile(MapID, ColPosition, RowPosition, TileTypeName)
	values 
        (1, 2, 1, "Gem"),
        (1, 2, 2, "Snake"),
        (1, 6, 2, "Boar"),
        (1, 3, 2, "Fruit");
	insert into tblGameRequest(PlayerID, PlayerID2)
	values 
        (1, 2);
end//
delimiter ;

call MakeTables();
call InsertData();