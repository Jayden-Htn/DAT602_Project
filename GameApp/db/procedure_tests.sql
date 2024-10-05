-- Survivor Island Procedure Test Script

use GameDB;

-- <========== Login Procedure ==========>
-- Inputs: username, password
call Login('Player1', 'Password123'); -- Should return Message: 'Success'
call Login('Player1', 'Password'); -- Should return Message: 'Invalid credentials'
call Login('Player46', 'Password123'); -- Should return Message: 'Invalid credentials'
call Login('Player4', 'Password123'); -- Should return Message: 'Locked out'
select * from tblPlayer where `Online` = 1; -- Should return only Player1 as online

-- <========== Register Procedure ==========>
-- Inputs: username, password
call Register('Player5', 'Password123'); -- Should return Message: 'Success'
call Register('Player5', 'Password123'); -- Should return Message: 'Duplicate'

-- <========== Layout Procedure ==========>
-- Inputs: PlayerID, GameID
call Layout(1, 1); -- Should return two unique tiles within 4 tiles of character (0,0)

-- <========== Generate Tiles Procedure ==========>
-- Inputs: GameID
delete from tblTile where MapID = 2;
call GenerateMap(2);
select * from tblTile where MapID = 2; -- Should return approximately 33 (~25-40 as random) unique tiles (if 10x10 map)

-- <========== Move Player Procedure ==========>
-- Inputs: CharacterID, GameID, NewTileCol, NewTileRow (use pos as empty tiles don't have id)
select * from tblCharacter where ID = 1; -- Character at 1, 1
call MovePlayer(1, 1, 0, 0); -- Should return Message: 'Out of map'
call MovePlayer(1, 1, 5, 5); -- Should return Message: 'Tile not in range'
call MovePlayer(1, 1, 1, 1); -- Should return Message: 'Character already in position'
call MovePlayer(1, 1, 2, 2); -- Should return Message: 'Successful move'
select * from tblCharacter where ID = 1; -- Character should be at at 2, 2

-- <========== Update Score Procedure ==========>
-- Inputs: CharacterID, Score change (this will likely be called in the tile interact prodecure which will check tile type and effect) 
select Score from tblCharacter where ID = 1; -- Score is 0
call UpdateScore(1, 20);
select Score from tblCharacter where ID = 1; -- Score is 20

-- <========== Interact (Pickup) Procedure ==========>
-- Inputs: CharacterID, MapID, ColPos, RowPos (if clicked tile matches own character position, call this instead of move) 
select * from tblCharacter where ID = 1; -- Score 0, health 100
call TileInteract(1, 1, 2, 1); -- Collects gem, should return Message: 'Success'
select * from tblCharacter where ID = 1; -- Score 5, health 100
call TileInteract(1, 1, 2, 2); -- Fights snake, should return Message: 'Success'
select * from tblCharacter where ID = 1; -- Score 15, health 70
call TileInteract(1, 1, 2, 2); -- Empty tile, should return Message: 'Tile not found'
select * from tblInventory where CharacterID = 1; -- Just 1x meat
call TileInteract(1, 1, 3, 2); -- Picks up fruit, should return Message: 'Success'
select * from tblInventory where CharacterID = 1; -- Now fruit in inventory too

-- <========== NPC Move Procedure ==========>
-- Inputs: MapID
select * from tblTile t join tblEntity e on t.TileTypeName = e.`Name` where MapID = 1 and IsNpc = 1; -- Gets two NPCs, positions 2,2 and 6,2 (or just one if hunted snake in interact)
call NpcMove(1); 
select * from tblTile t join tblEntity e on t.TileTypeName = e.`Name` where MapID = 1 and IsNpc = 1; -- NPC should have moved to an adjacent tile 
-- Note: won't move if hit map boundary or selects occupied tile

-- <========== Stop Game Procedure ==========>
-- Inputs: GameID [null]
select * from tblGame; -- 3 games
call StopGame(1); -- Stop game ID: 1
select * from tblGame; -- 2 games
call StopGame(null); -- Stop all games if not specified
select * from tblGame; -- 0 games
select * from tblTile; -- Cascaded so no tiles, maps, etc. stored

-- <========== Update Player Procedure ==========>
-- Inputs: PlayerID, Username [null], Password [null], Locked [null], Admin [null], HighScore [null]
select * from tblPlayer where ID = 1; -- Original data
call UpdatePlayer(1, "EpicGamer", "NewPassword", 1, 1, 0); -- Change data
select * from tblPlayer where ID = 1; -- Data changed
call UpdatePlayer(1, null, null, 0, 0, null); -- Select daata can be changed using null values
select * from tblPlayer where ID = 1; -- Data changed


-- <========== Delete Player Procedure ==========>
-- Inputs: PlayerID
select * from tblPlayer; -- Player exists
call DeletePlayer(1); -- Should return Message: 'Success'
select * from tblPlayer; -- Player deleted
call DeletePlayer(1); -- Should return Message: 'Player doesn't exist'
select * from tblCharacter; -- Cascade deleted game, characters, etc.
				 