-- Survivor Island Extra Procedures Script

use GameDB;

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