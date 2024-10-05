-- Survivor Island Procedure Script

use GameDB;

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
    
    -- Check if user exists
	if exists (select * from tblPlayer where Username = pUsername and `Password` = pPassword and `Locked` = 0) then
		-- Successful login
		update tblPlayer
        set LoginAttempts = 0, `Online` = 1
        where Username = pUsername;
        select 'Success' as 'Message';
    else
		-- Failed login
		if exists (select * from tblPlayer where Username = pUsername) then 
			-- Account does exist so increment attempts
			select LoginAttempts
            into numAttempts
            from tblPlayer
            where Username = pUsername;
            set numAttempts = numAttempts + 1;
            
            if numAttempts > 5 then 
				-- Too many attempts, lock account
                update tblPlayer set `locked` = 1 where Username = pUsername;
                
                -- Reset login attempts for if unlocked
                update tblPlayer set `locked` = 1 where Username = pUsername;
                
                select 'Locked out' as 'Message';
			elseif (select `Locked` from tblPlayer where Username = pUsername and `Password` = pPassword) = 1 then
				-- Account is locked
                select 'Locked out' as 'Message';
			else
				-- Incorrect login
                update tblPlayer
                set LoginAttempts = numAttempts
                where Username = pUsername;
                
                select 'Invalid credentials' as 'Message';
			end if;
		else
			-- No account found
            select 'Invalid credentials' as 'Message';
		end if;
	end if;
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
    -- Check if user exists
	if exists (select * from tblPlayer where Username = pUsername) then
		-- Username already exists
        select 'Duplicate' as 'Message';
    else
		-- Create user
        insert into tblPlayer (Username, `Password`)
		values (pUsername, pPassword);
		select 'Success' as 'Message';
	end if;
end//
delimiter ;

-- <========== 3. Layout Procedure ==========>
delimiter //
drop procedure if exists Layout//
create definer = 'game'@'localhost' procedure Layout (
	in pPlayerID varchar(255),
	in pGameID varchar(255)
)
comment 'Lay out tiles on board around a players position'
begin
	declare xPos int default 0;
	declare yPos int default 0;
    
    -- Get character position
    select ColPosition, RowPosition
	into xPos, yPos
	from tblCharacter
	where PlayerID = pPlayerID and GameID = pGameID;
	
    -- Find unique tiles in 4 tile radius
    -- Note: only special tiles are stored, empty tiles are not
    select * 
    from tblTile
    where MapID = (select ID from tblMap where GameID = pGameID) and ColPosition >= xPos-4 
		and ColPosition <= xPos+4 and RowPosition >= yPos-4 and RowPosition <= yPos+4;
end//
delimiter ;


-- <========== 4. Generate Tiles Procedure (placing items) ==========>
delimiter //
drop procedure if exists GenerateMap//
create definer = 'game'@'localhost' procedure GenerateMap (
	in pMapID varchar(255)
)
comment 'Generating unique tiles (items) in the map'
begin
	declare rowMax int default 0;
	declare colMax int default 0;
    declare colNo int default 1;
    declare rowNo int default 1;
    declare tileName varchar(255) default "";
    
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
    -- Find charcter
    if exists (select * from tblCharacter where ID = pCharacterID) then
		update tblCharacter set Score = Score + pScoreChange where ID = pCharacterID;
		select "Score updated" as 'Message';
	else
		select "Player not found" as 'Message';
	end if;
end//
delimiter ;


-- <========== 7. Interact (Pickup) Procedure ==========>
delimiter //
drop procedure if exists TileInteract//
create definer = 'game'@'localhost' procedure TileInteract (
	in pCharacterID int,
    in pMapID int,
    in pColPos int,
    in pRowPos int
)
comment 'Character picking up or interacting with entities'
begin	
	declare tileType varchar(255) default 0;
    -- Get tile
    select TileTypeName into tileType from tblTile 
		where MapID = pCharacterID and ColPosition = pColPos and RowPosition = pRowPos;
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
         delete from tblTile where MapID = pCharacterID and ColPosition = pColPos and RowPosition = pRowPos;
         -- Check character isn't dead
		if (select CurrentHealth from tblCharacter where ID = pCharacterID) <= 0 then
			select "Character dead" as 'Message';
		else
			select 'Success' as 'Message';
		end if;
	else
		select "Tile not found" as 'Message';
	end if;
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
	declare done int default 0;
    declare tileID int;
    declare colPos int;
    declare rowPos int;
    declare colNew int;
    declare rowNew int;
    
	declare npcCursor cursor for
        select id, ColPosition, RowPosition 
        from tblTile t
        join tblEntity e on t.TileTypeName = e.`Name`
        where MapID = pMapID and IsNpc = 1;

    declare continue handler for not found set done = 1;
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
				end if;
			end if;
            -- Don't move if tile not free. Don't loop until valid tile to avoid potential inifnite loops with random generation
		end if;
    end loop npcLoop;
    close npcCursor;
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
	-- Note: deleting a game should cascade delete map, tiles, inventory, characters, chat messages
    if (pGameID is null) then
		-- Stop all games, temporarily disable safe updates as no where clause
        SET SQL_SAFE_UPDATES = 0;
        delete from tblGame;
        SET SQL_SAFE_UPDATES = 1;
	else
		-- Stop one game
        delete from tblGame where GameID = pGameID;
	end if;
end//
delimiter ;


-- <========== 10. New Player Procedure ==========>


-- ************** same as register????



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
end//
delimiter ;

				 