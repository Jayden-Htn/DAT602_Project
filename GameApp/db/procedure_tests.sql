-- Survivor Island Procedure Test Script

use GameDB;

-- <========== Login Procedure ==========>
-- Inputs: username, password
select * from tblPlayer where `Online` = 1; -- Return: no players online
call Login('Player1', 'Password123'); -- Return Message: 'Success'
call Login('Player1', 'Password'); -- Return Message: 'Invalid credentials'
call Login('Player46', 'Password123'); -- Return Message: 'Invalid credentials'
call Login('Player4', 'Password123'); -- Return Message: 'Locked out'
select * from tblPlayer where `Online` = 1; -- Return: only Player 1 as online

-- <========== Register Procedure ==========>
-- Inputs: username, password
call Register('Player5', 'Password123'); -- Return Message: 'Success'
call Register('Player5', 'Password123'); -- Return Message: 'Duplicate'

-- <========== Layout Procedure ==========>
-- Inputs: PlayerID, GameID
call Layout(1, 1); -- Return three unique tiles within 4 tiles of character (1,1) 
-- Note: range to be modified to meet game implementation or can be removed

-- <========== Generate Map Procedure ==========>
-- Inputs: MapID
delete from tblTile where MapID = 2;
call GenerateMap(2); -- Return approx. 33 unique tiles (if 10x10 map)

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
-- Inputs: CharacterID, MapID, ColPos, RowPos
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
call StopGame(null); -- Return Message: 'Stopped all games'
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
				 