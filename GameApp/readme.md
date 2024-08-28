# Instructions

To run this project:
1. Load Solution into Visual Studio
2. Run /db/start.sql to initialise the database
3. Run /db/test_procedures.sql to create the test procedures_
4. Run the program


## The Program

Screen 1: login/register. Entering a valid user will return true, if the username and password doesn't match a user, 
it will return false. The lobby page will be loaded on EITHER result. Example users: 'Player1', 'Player2', 'Player3', 
'Player4', all with 'Password123'.

Screen 2: lobby. Used to connect to admin and game screens for tests.

Screen 3: game. Clicking load map will show the special tiles in the map (empty tiles are not stored). Should show two tiles.

Screen 4: admin. Clicking display users displays all users in the database (Player1-4).