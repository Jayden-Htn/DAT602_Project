-- Survivor Island Extra Procedures Script

use GameDB;

-- <========== 1. Get Character Data Procedure ==========>
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


-- <========== 2. Find Game Procedure ==========>
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


-- <========== 3. Start Game Procedure ==========>
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