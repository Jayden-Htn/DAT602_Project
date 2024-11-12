-- Survivor Island Full Database Script

drop database if exists GameDB;
create database GameDB;
use GameDB;




-- <==================== TABLES ====================>

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

-- Create Database Users Procedure
delimiter //
drop procedure if exists CreateUsers//
create procedure CreateUsers()
begin
	-- drop user 'game'@'localhost';
	if (not exists (select user, host from mysql.user where user = 'game' and host = 'localhost')) then
		create user 'game'@'localhost' identified by 'password123';
		grant execute, select, insert, update, delete on GameDB.* to 'game'@'localhost';
	end if;
end//
delimiter ;

call MakeTables();
call InsertData();
call CreateUsers();




-- <==================== PROCEDURES ====================>

-- <========== 1. Login Procedure ==========>
delimiter //
drop procedure if exists Login//
create definer = 'game'@'localhost' procedure Login (
	in pUsername varchar(255),
    in pPassword varchar(255)
)
comment 'Check user login'
begin
	declare numAttempts int default 0;
    
	declare exit handler for 1205
	begin
		rollback;
		select 'Error: Lock wait timeout. Please try again later.' as 'Message';
	end;
    declare exit handler for sqlstate 'HY000'
    begin
		rollback;
		select 'Error: General database error occurred.' as 'Message';
	end;
    declare exit handler for SQLEXCEPTION
    begin
		rollback;
		select 'Error: Database error occurred.' as 'Message';
	end;
    
    start transaction; 
    
    -- Check if user exists
	if exists (select * from tblPlayer where Username = pUsername and `Password` = pPassword and `Locked` = 0) then
		-- Successful login
		update tblPlayer
        set LoginAttempts = 0, `Online` = 1 where Username = pUsername;
        select ID as 'Message' from tblPlayer where Username = pUsername;
    else
		-- Failed login
		if exists (select * from tblPlayer where Username = pUsername) then 
			-- Account does exist so increment attempts
			select LoginAttempts into numAttempts
            from tblPlayer where Username = pUsername;
            set numAttempts = numAttempts + 1;
            
            if numAttempts > 5 then 
				-- Too many attempts, lock account
                update tblPlayer set `locked` = 1 where Username = pUsername;
                
                select 'Locked out' as 'Message';
			elseif (select `Locked` from tblPlayer where Username = pUsername and `Password` = pPassword) = 1 then
				-- Account is locked
                select 'Locked out' as 'Message';
			else
				-- Incorrect login
                update tblPlayer set LoginAttempts = numAttempts where Username = pUsername;
                
                select 'Invalid credentials' as 'Message';
			end if;
		else
			-- No account found
            select 'No account' as 'Message';
		end if;
	end if;
    
    commit;
end//
delimiter ;

-- <========== 2. Register Procedure ==========>
delimiter //
drop procedure if exists Register//
create definer = 'game'@'localhost' procedure Register (
	in pUsername varchar(255),
    in pPassword varchar(255)
)
comment 'Register new user'
begin
	declare exit handler for 1205
	begin
		rollback;
		select 'Error: Lock wait timeout. Please try again later.' as 'Message';
	end;
	declare exit handler for 1062
	begin
		rollback;
		select 'Error: Duplicate entry detected.' as 'Message';
	end;
	declare exit handler for 1048
	begin
		rollback;
		select 'Error: A required column cannot be null.' as 'Message';
	end;
    declare exit handler for sqlstate 'HY000'
    begin
		rollback;
		select 'Error: Database error occurred.' as 'Message';
	end;
    
    start transaction; 
    
    -- Check if user exists
	if exists (select * from tblPlayer where Username = pUsername) then
		-- Username already exists
        select 'Duplicate' as 'Message';
    else
		-- Create user
        insert into tblPlayer (Username, `Password`)
		values (pUsername, pPassword);
        
		select ID as 'Message' from tblPlayer where Username = pUsername;
	end if;
    
    commit;
end//
delimiter ;

-- <========== 3. Layout Procedure ==========>
delimiter //
drop procedure if exists Layout//
create definer = 'game'@'localhost' procedure Layout (
	in pCharacterID varchar(255),
	in pGameID varchar(255)
)
comment 'Lay out tiles on board around a players position'
begin
	declare xPos int default 0;
	declare yPos int default 0;
    
    declare exit handler for 1205
	begin
		rollback;
		select 'Error: Lock wait timeout. Please try again later.' as 'Message';
	end;
	declare exit handler for 1048
	begin
		rollback;
		select 'Error: A required column cannot be null.' as 'Message';
	end;
    declare exit handler for sqlstate 'HY000'
    begin
		rollback;
		select 'Error: Database error occurred.' as 'Message';
	end;
    
    start transaction; 
    
    -- Get character position
    select ColPosition, RowPosition
	into xPos, yPos
	from tblCharacter
	where ID = pCharacterID and GameID = pGameID;
	
    -- Find unique tiles in 4 tile radius
    -- Note: only special tiles are stored, empty tiles are not
    select * 
    from tblTile
    where MapID = (select ID from tblMap where GameID = pGameID) and ColPosition >= xPos-4 
		and ColPosition <= xPos+4 and RowPosition >= yPos-4 and RowPosition <= yPos+4;
        
	commit;
end//
delimiter ;


-- <========== 4. Generate Tiles Procedure (placing items) ==========>
delimiter //
drop procedure if exists GenerateMap//
create definer = 'game'@'localhost' procedure GenerateMap (
	in pMapID varchar(255),
    in pOutputToggle int
)
comment 'Generating unique tiles (items) in the map'
begin
	declare rowMax int default 0;
	declare colMax int default 0;
    declare colNo int default 1;
    declare rowNo int default 1;
    declare tileName varchar(255) default "";
    
    declare exit handler for 1205
	begin
		rollback;
		select 'Error: Lock wait timeout. Please try again later.' as 'Message';
	end;
    declare exit handler for sqlstate '02000'
	begin
		rollback;
		select 'Error: Map ID not found.' as 'Message';
	end;
    declare exit handler for sqlstate 'HY000'
    begin
		rollback;
		select 'Error: Database error occurred.' as 'Message';
	end;
    
    start transaction; 
    
    -- Get map size
    select MaxColumns, MaxRows into colMax, rowMax from tblMap where ID = pMapID;

    -- For each column
	while colNo <= colMax do
        -- For each row
        set rowNo = 1;
        while rowNo <= rowMax do            
			-- 33% chance for a tile to be unique, don't want to overload with entities
            if (rand() >= 0.67) then
				-- If entity random select entity type name
				select `name` into tileName from tblTileType 
				where rand() < SpawnModifier order by rand() limit 1;
                -- Add unique tile
				insert into tblTile(MapID, ColPosition, RowPosition, TileTypeName)
                values (pMapID, colNo, rowNo, tileName);
			-- else: will be empty tile and not stored
			end if;
            set rowNo = rowNo + 1;
		end while;
        set colNo = colNo + 1;
	end while;
    
    -- Return map
    if (pOutputToggle = 1) then
		select * from tblTile where MapID = pMapID; 
	end if;
    
    commit;
end//
delimiter ;


-- <========== 5. Player Movement Procedure ==========>
delimiter //
drop procedure if exists MovePlayer//
create definer = 'game'@'localhost' procedure MovePlayer (
	in pCharacterID int,
    in pGameID int,
    in pNewCol int,
    in pNewRow int
)
comment 'Moving player to a valid tile'
begin
	declare currentCol int default 0;
	declare currentRow int default 0;
	declare newTileType int default null;
    declare mapMaxCol int default 0;
    declare mapMaxRow int default 0;
    
    declare exit handler for 1205
	begin
		rollback;
		select 'Error: Lock wait timeout. Please try again later.' as 'Message';
	end;
    declare exit handler for sqlstate 'HY000'
    begin
		rollback;
		select 'Error: Database error occurred.' as 'Message';
	end;
    
    start transaction; 
    
    -- Get current character position
    select ColPosition, RowPosition into currentCol, currentRow from tblCharacter where ID = pCharacterID;
    
    -- Get max map position
    select MaxColumns, MaxRows into mapMaxCol, mapMaxRow from tblMap where GameID = pGameID;
        
    -- Check that tile is adjacent
    if (pNewCol >= (currentCol-1) and pNewCol <= (currentCol+1) 
		and pNewRow >= (currentRow-1) and pNewRow <= (currentRow+1)) then 
		-- Check that tile is within game bounds
        if (pNewCol >= 1 and pNewCol <= mapMaxCol) and (pNewRow >= 1 
			and pNewRow <= mapMaxRow) then
			-- Check if any character (including self) is not on tile
			if (not exists (select * from tblCharacter where GameID = pGameID 
				and ColPosition = pNewCol and RowPosition = pNewRow)) then
				-- Check if the tile is unique (stored)
				if (exists (select * from tblTile where colPosition = pNewCol and rowPosition = pNewRow)) then
					-- Check tile type is valid for move (not obstacle)
					if (select IsObstacle from tblTileType where `Name` = 
						(select TileTypeName from tblTile where colPosition = pNewCol and rowPosition = pNewRow)) = 0 then
						-- Not obstacle so valid 
                        update tblCharacter set ColPosition = pNewCol, RowPosition = pNewRow where ID = pCharacterID;
						select "Successful move" as 'Message';
					else
						select "Is obstacle, cannot move" as 'Message';
					end if;
				else
					-- Tile isn't stored so must be empty tile and valid
                    update tblCharacter set ColPosition = pNewCol, RowPosition = pNewRow where ID = pCharacterID;
					select "Successful move" as 'Message';
				end if;
			else
				select "Character already in position" as 'Message';
			end if;
		else
			select "Out of map" as 'Message';
		end if;
	else
		select "Tile not in range" as 'Message';
	end if;
    
    commit;
end//
delimiter ;


-- <========== 6. Scoring Procedure ==========>
delimiter //
drop procedure if exists UpdateScore//
create definer = 'game'@'localhost' procedure UpdateScore (
	in pCharacterID int,
    in pScoreChange int
)
comment 'Adding score points to a player'
begin	
	declare exit handler for 1205
	begin
		rollback;
		select 'Error: Lock wait timeout. Please try again later.' as 'Message';
	end;
    declare exit handler for sqlstate 'HY000'
    begin
		rollback;
		select 'Error: Database error occurred.' as 'Message';
	end;
    
    start transaction; 
    
    -- Find charcter
    if exists (select * from tblCharacter where ID = pCharacterID) then
		update tblCharacter set Score = Score + pScoreChange where ID = pCharacterID;
		select "Score updated" as 'Message';
	else
		select "Player not found" as 'Message';
	end if;
    
    commit;
end//
delimiter ;


-- <========== 7. Interact (Pickup) Procedure ==========>
delimiter //
drop procedure if exists TileInteract//
create definer = 'game'@'localhost' procedure TileInteract (
	in pCharacterID int,
    in pGameID int,
    in pColPos int,
    in pRowPos int
)
comment 'Character picking up or interacting with entities'
begin	
	declare tileType varchar(255) default 0;
    declare mapID int;
    
    declare exit handler for 1205
	begin
		rollback;
		select 'Error: Lock wait timeout. Please try again later.' as 'Message';
	end;
	declare exit handler for 1048
	begin
		rollback;
		select 'Error: A required column cannot be null.' as 'Message';
	end;
    declare exit handler for sqlstate 'HY000'
    begin
		rollback;
		select 'Error: Database error occurred.' as 'Message';
	end;
    
    start transaction; 
    
    -- Get map id
    select ID into mapID from tblMap where GameID = pGameID;
    
    -- Get tile
    select TileTypeName into tileType from tblTile 
		where MapID = mapID and ColPosition = pColPos and RowPosition = pRowPos;
        
    -- Check if tile exists
	if (tileType is not null and tileType != '0') then
		if (select AddInventory from tblEntity where `Name` = tileType) then
			-- Collectible so add to inventory
			insert into tblInventory(ItemName, CharacterID)
			values (tileType, pCharacterID);
        else
			-- Else apply effects now
			update tblCharacter
			set Score = Score + (select ScoreEffect from tblEntity where `Name` = tileType), 
				CurrentHealth = CurrentHealth + (select HealthEffect from tblEntity where `Name` = tileType)
			where ID = pCharacterID;
            
            -- Check new health isn't over max
            if (select CurrentHealth from tblCharacter where ID = pCharacterID) 
				> (select MaxHealth from tblCharacter where ID = pCharacterID) then
				update tblCharacter
				set CurrentHealth = (select MaxHealth from tblCharacter where ID = pCharacterID)
				where ID = pCharacterID;
			end if;
		end if;
        
        -- Remove tile (now empty)
		set SQL_SAFE_UPDATES = 0; -- Error since where doesn't use tile key
		delete from tblTile where MapID = mapID and ColPosition = pColPos and RowPosition = pRowPos;
		set SQL_SAFE_UPDATES = 1;
         
		-- Check character isn't dead
		if (select CurrentHealth from tblCharacter where ID = pCharacterID) <= 0 then
			select "Character dead" as 'Message';
		else
			select 'Success' as 'Message';
		end if;
	else
		select "Tile not found" as 'Message';
	end if;
    
    commit;
end//
delimiter ;


-- <========== 8. NPC Move Procedure ==========>
delimiter //
drop procedure if exists NpcMove//
create definer = 'game'@'localhost' procedure NpcMove (
	in pMapID int
)
comment 'Move npcs (animals) randomly'
begin	
    declare tileID int;
    declare colPos int;
    declare rowPos int;
    declare colNew int;
    declare rowNew int;
    declare npcMovedCount int default 0;
    declare done int default 0;
    
	declare npcCursor cursor for
        select id, ColPosition, RowPosition 
        from tblTile t
        join tblEntity e on t.TileTypeName = e.`Name`
        where MapID = pMapID and IsNpc = 1;
	declare continue handler for not found set done = 1;
        
	declare exit handler for 1205
	begin
		rollback;
		select 'Error: Lock wait timeout. Please try again later.' as 'Message';
	end;
    declare exit handler for sqlstate 'HY000'
    begin
		rollback;
		select 'Error: Database error occurred.' as 'Message';
	end;
        
    start transaction;
    open npcCursor;
    
    -- Loop over npc tiles
    npcLoop: loop
		-- Random chance each npc moves (currently 100%)
		if (RAND() >= 0) then        
			-- Get interation values
			fetch npcCursor into tileID,  colPos, rowPos;
            
			-- Exit loop if no more rows
			if done then
				leave npcLoop;
			end if;
            
            -- Generate random move (-1 -> +1)
            select colPos + FLOOR(-1 + (RAND() * 3)) into colNew;
            select rowPos + FLOOR(-1 + (RAND() * 3)) into rowNew;
			
            -- Check if tile empty (not stored)
			if (not exists (select * from tblTile 
				where MapID = pMapID and ColPosition = colNew and RowPosition = rowNew)) then
                
				-- Check if in map bounds
                if colNew >= 1 and colNew <= (select MaxColumns from tblMap where ID = pMapID) and 
					rowNew >= 1 and rowNew <= (select MaxRows from tblMap where ID = pMapID) then
                    
					-- Move NPC to new tile
                    update tblTile
					set ColPosition = colNew, RowPosition = rowNew
					where ID = tileID;
                    set npcMovedCount = npcMovedCount + 1;
				end if;
			end if;
            -- Don't move if tile not free. I decided not to loop until valid tile to avoid 
            -- potential infinite loops with random generation
		end if;
    end loop npcLoop;
    close npcCursor;
    
    -- Return number of NPCs moved
    select npcMovedCount as 'Message';
    
    commit;
end//
delimiter ;


-- <========== 9. Stop Game Procedure ==========>
delimiter //
drop procedure if exists StopGame//
create definer = 'game'@'localhost' procedure StopGame (
	in pGameID int
)
comment 'Stop one or all games'
begin	
	declare exit handler for 1205
	begin
		rollback;
		select 'Error: Lock wait timeout. Please try again later.' as 'Message';
	end;
    declare exit handler for sqlstate 'HY000'
    begin
		rollback;
		select 'Error: Database error occurred.' as 'Message';
	end;
        
    start transaction;
    
	-- Note: deleting a game should cascade delete map, tiles, inventory, characters, chat messages
    if (pGameID is null) then
		-- Stop all games, temporarily disable safe updates as no where clause
        set SQL_SAFE_UPDATES = 0;
        delete from tblGame;
        set SQL_SAFE_UPDATES = 1;
        
        select "Stopped all games" as 'Message';
	else
		-- Stop one game
        delete from tblGame where GameID = pGameID;
        
        select "Stopped game" as 'Message';
	end if;
    
    commit;
end//
delimiter ;


-- <========== 10. New Player Procedure ==========>
-- Please view register procedure above

-- <========== 11. Update Player Procedure ==========>
delimiter //
drop procedure if exists UpdatePlayer//
create definer = 'game'@'localhost' procedure UpdatePlayer (
	in pPlayerID int,
    in pUsername varchar(255),
    in pPassword varchar(255),
    in pLocked int,
    in pAdmin int,
    in pHighestScore int
)
comment "Update a player's data"
begin	
	declare exit handler for 1205
	begin
		rollback;
		select 'Error: Lock wait timeout. Please try again later.' as 'Message';
	end;
	declare exit handler for 1062
	begin
		rollback;
		select 'Error: Duplicate entry detected.' as 'Message';
	end;
	declare exit handler for 1048
	begin
		rollback;
		select 'Error: A required column cannot be null.' as 'Message';
	end;
    declare exit handler for sqlstate 'HY000'
    begin
		rollback;
		select 'Error: Database error occurred.' as 'Message';
	end;
        
    start transaction;
    
	if (pUsername is not null) then
		update tblPlayer set Username = pUsername where ID = pPlayerID;
	end if;
    if (pPassword is not null) then
		update tblPlayer set Password = pPassword where ID = pPlayerID;
	end if;
    if (pLocked is not null) then
		update tblPlayer set Locked = pLocked where ID = pPlayerID;
	end if;
    if (pAdmin is not null) then
		update tblPlayer set Admin = pAdmin where ID = pPlayerID;
	end if;
    if (pHighestScore is not null) then
		update tblPlayer set HighestScore = pHighestScore where ID = pPlayerID;
	end if;
    
    select * from tblPlayer where ID = pPlayerID;
    
    commit;
end//
delimiter ;


-- <========== 12. Delete Player Procedure ==========>
delimiter //
drop procedure if exists DeletePlayer//
create definer = 'game'@'localhost' procedure DeletePlayer (
	in pPlayerID int
)
comment "Delete a player"
begin	
	declare exit handler for 1205
	begin
		rollback;
		select 'Error: Lock wait timeout. Please try again later.' as 'Message';
	end;
    declare exit handler for sqlstate 'HY000'
    begin
		rollback;
		select 'Error: Database error occurred.' as 'Message';
	end;
        
    start transaction;
    
	-- Note: deleting a player should cascade game requests, 
    -- chat messages, characters, games, maps, inventory, tiles
    if (exists (select * from tblPlayer where ID = pPlayerID)) then
        if (exists (select GameID from tblCharacter where PlayerID = pPlayerID)) then
			delete from tblGame where GameID in 
				(select GameID from tblCharacter where PlayerID = pPlayerID);
		end if;
        delete from tblPlayer where ID = pPlayerID;
        select "Player deleted" as 'Message';
	else
		select "Player doesn't exist" as 'Message';
	end if;
    
    commit;
end//
delimiter ;




-- <==================== EXTRA PROCEDURES ====================>

-- <========== 1e. Get Character Data Procedure ==========>
delimiter //
drop procedure if exists GetCharacterData//
create definer = 'game'@'localhost' procedure GetCharacterData (
	in pCharacterID int
)
comment 'Get character position, score and health'
begin
    -- Check if user exists
	if exists (select * from tblCharacter where ID = pCharacterID) then
		-- Username already exists
        select ColPosition, RowPosition, Score, CurrentHealth from tblCharacter where ID = pCharacterID;
    else
		select "No character" as 'Message';
	end if;
end//
delimiter ;


-- <========== 2e. Find Game Procedure ==========>
delimiter //
drop procedure if exists FindGame//
create definer = 'game'@'localhost' procedure FindGame (
	in pPlayerID int,
    in pOpponentID int
)
comment 'Find an existing game between two players'
begin
    -- Find games
	select c.ID as 'CharacterID', PlayerID, c.GameID as 'GameID', ColPosition, RowPosition, 
		Score, CurrentHealth, m.ID as 'MapID' from tblCharacter c
    join tblMap m on c.GameID = m.GameID
	where PlayerID = pPlayerID 
        and c.GameID in (select GameID from tblCharacter where PlayerID = pPlayerID) 
        and c.GameID in (select GameID from tblCharacter where PlayerID = pOpponentID);
end//
delimiter ;


-- <========== 3e. Start Game Procedure ==========>
delimiter //
drop procedure if exists StartGame//
create definer = 'game'@'localhost' procedure StartGame (
	in pPlayerID int,
    in pOpponentID int
)
comment 'Create a new game, characters and map'
begin
	declare vGameID int;
    declare vMapID int;
    
    -- Create new game
    insert into tblGame (StartTime)
	values (Now());  
	
	select Last_Insert_ID() into vGameID;
        
	-- Create characters
    insert into tblCharacter (PlayerID, GameID)
	values 
		(pPlayerID, vGameID),
		(pOpponentID, vGameID);
        
	-- Create map
    insert into tblMap(GameID, MaxColumns, MaxRows)
	values (vGameID, 10, 10);
    
    select ID into vMapID from tblMap where GameID = vGameID;
    
	call GenerateMap(vMapID, 0);
    
    -- Return character data
    select c.ID as 'CharacterID', PlayerID, c.GameID as 'GameID', ColPosition, RowPosition, 
		Score, CurrentHealth, m.ID as 'MapID' from tblCharacter c
    join tblMap m on c.GameID = m.GameID
    where PlayerID = pPlayerID and c.GameID = vGameID;
end//
delimiter ;


-- <========== 4e. Get Active Players Procedure ==========>
delimiter //
drop procedure if exists GetActivePlayers//
create definer = 'game'@'localhost' procedure GetActivePlayers ()
comment 'Get all active players'
begin
	select ID, Username, HighestScore from tblPlayer where `Online` = 1;
end//
delimiter ;


-- <========== 5e. Get Games Procedure ==========>
delimiter //
drop procedure if exists GetGames//
create definer = 'game'@'localhost' procedure GetGames ()
comment 'Get all games'
begin 
	-- Get game id and both player usernames for each game
	select g.GameID as 'ID', p1.Username as 'Username1', p2.Username as 'Username2'
    from tblGame g
    join tblCharacter c1 on g.GameID = c1.GameID
    join tblCharacter c2 on g.GameID = c2.GameID and c2.PlayerID > c1.PlayerID
    join tblPlayer p1 on c1.PlayerID = p1.ID
    join tblPlayer p2 on c2.PlayerID = p2.ID;
end//
delimiter ;


-- <========== 6e. Setup Database Procedure ==========>
delimiter //
drop procedure if exists SetupDatabase//
create definer = 'game'@'localhost' procedure SetupDatabase ()
comment 'Set isolation level'
begin 
	set transaction isolation level read committed;
end//
delimiter ;







-- <==================== TESTS ====================>

-- <========== Login Procedure ==========>
-- Inputs: username, password
select * from tblPlayer where `Online` = 1; -- Return: no players online
call Login('Player1', 'Password123'); -- Return Message: <Player ID>
call Login('Player1', 'Password'); -- Return Message: 'Invalid credentials'
call Login('Player46', 'Password123'); -- Return Message: 'No account'
call Login('Player4', 'Password123'); -- Return Message: 'Locked out'
select * from tblPlayer where `Online` = 1; -- Return: only Player 1 as online

-- <========== Register Procedure ==========>
-- Inputs: username, password
call Register('Player5', 'Password123'); -- Return Message: <Player ID>
call Register('Player5', 'Password123'); -- Return Message: 'Duplicate'

-- <========== Layout Procedure ==========>
-- Inputs: CharacterID, GameID
call Layout(1, 1); -- Return three unique tiles within 4 tiles of character (1,1) 
-- Note: range to be modified to meet game implementation or can be removed

-- <========== Generate Map Procedure ==========>
-- Inputs: MapID, output? bit
delete from tblTile where MapID = 2;
call GenerateMap(2, 1); -- Return approx. 33 unique tiles (if 10x10 map)
-- Disabling output means this procedure can be called from another 
-- procedure without affect its output

-- <========== Move Player Procedure ==========>
-- Inputs: CharacterID, GameID, NewTileCol, NewTileRow (use position as empty tiles don't have id)
select * from tblCharacter where ID = 1; -- Character at 1, 1
call MovePlayer(1, 1, 0, 0); -- Return Message: 'Out of map'
call MovePlayer(1, 1, 5, 5); -- Return Message: 'Tile not in range'
call MovePlayer(1, 1, 1, 1); -- Return Message: 'Character already in position'
call MovePlayer(1, 1, 2, 2); -- Return Message: 'Successful move'
select * from tblCharacter where ID = 1; -- Character at at 2, 2

-- <========== Update Score Procedure ==========>
-- Inputs: CharacterID, Score change 
-- Note: this will likely be called in the tile interact prodecure which will check tile type and effect
select * from tblCharacter where ID = 1; -- Score is 0
call UpdateScore(1, 20); -- Return Message: 'Score updated'
select * from tblCharacter where ID = 1; -- Score is 20
call UpdateScore(546, 20); -- Return Message: 'Player not found'

-- <========== Interact (Pickup) Procedure ==========>
-- Inputs: CharacterID, GameID, ColPos, RowPos
-- Note: if clicked tile matches own character position, call this instead of move
select * from tblCharacter where ID = 1; -- Score 20, health 100
call TileInteract(1, 1, 2, 1); -- Collects gem, Return Message: 'Success'
select * from tblCharacter where ID = 1; -- Score 25, health 100
call TileInteract(1, 1, 2, 2); -- Fights snake, Return Message: 'Success'
select * from tblCharacter where ID = 1; -- Score 35, health 70
call TileInteract(1, 1, 2, 2); -- Empty tile, Return Message: 'Tile not found'
select * from tblInventory where CharacterID = 1; -- Just 1x meat
call TileInteract(1, 1, 3, 2); -- Picks up fruit, Return Message: 'Success'
select * from tblInventory where CharacterID = 1; -- Now fruit in inventory too

-- <========== NPC Move Procedure ==========>
-- Inputs: MapID
select * from tblTile t join tblEntity e on t.TileTypeName = e.`Name` where MapID = 1 and IsNpc = 1; 
	-- Gets one NPC, positions 6,2
call NpcMove(1); -- Return Message: <number of NPCs moved>

select * from tblTile t join tblEntity e on t.TileTypeName = e.`Name` where MapID = 1 and IsNpc = 1; 
	-- NPC should have moved to an adjacent tile 
-- Note: won't move if hit map boundary or selects occupied tile, otherwise 100% chance
-- But may need to be run multiple times depending on the random tiles selected

-- <========== Stop Game Procedure ==========>
-- Inputs: GameID [null]
select * from tblGame; -- 3 games
call StopGame(1); -- Return Message: 'Stopped game'
select * from tblGame; -- 2 games, GameID 1 stopped
/* call StopGame(null); -- Return Message: 'Stopped all games' */ /* Commented out to test other procedures?
select * from tblGame; -- 0 games, stops all games if not specified
select * from tblTile; -- Cascaded so no tiles, maps, etc. stored

-- <========== Update Player Procedure ==========>
-- ???

-- <========== Update Player Procedure ==========>
-- Inputs: PlayerID, Username [null], Password [null], Locked [null], Admin [null], HighScore [null]
select * from tblPlayer where ID = 1; -- Original data
call UpdatePlayer(1, "EpicGamer", "NewPassword", 1, 1, 0); -- Return: updated player details
call UpdatePlayer(1, null, null, 0, 0, null); -- Return: updated player details (null fields the same)

-- <========== Delete Player Procedure ==========>
-- Inputs: PlayerID
select * from tblPlayer; -- Player exists
call DeletePlayer(3); -- Return Message: 'Success'
select * from tblPlayer; -- Player deleted
call DeletePlayer(3); -- Return Message: 'Player doesn't exist'
-- Cascade deleted game, characters, etc. (already deleted from delete all games example)
				 

				 