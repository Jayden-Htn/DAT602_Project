-- Survivor Island Test Script

use GameDB;

-- Login Player Procedure
delimiter //
drop procedure if exists LoginPlayer//
create procedure LoginPlayer(
	in pUsername varchar(255),
    in pPassword varchar(255)
)
begin
	if exists (
		select *
		from tblPlayer
		where Username = pUsername and `Password` = pPassword) 
	then
		select true as `Exists`;
    else
		select false as `Exists`;
	end if;
end//
delimiter ;

-- Get All Players Procedure
delimiter //
drop procedure if exists GetAllPlayers//
create procedure GetAllPlayers()
begin
    select Username
    from tblPlayer;
end//
delimiter ;

-- Get Map Procedure
delimiter //
drop procedure if exists GetMap//
create procedure GetMap(
	in pMapId int
)
begin
    select ID, TileTypeName, ColumnPosition, RowPosition
    from tblTile
    where MapID = pMapId;
end//
delimiter ;