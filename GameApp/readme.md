# Readme

## Instructions

To run this project:
1. Load Solution into Visual Studio
2. Run /db/main.sql to initialise the database
3. Run the program

Note: if testing procedure, you may need to reset the database or errors may occur.

Suggested user accounts for testing:
1. U: "Player1", P: "Password123" (existing game)
2. U: "Player3", P: "Password123" (no game)

## Run Modes

In Program.cs there is a boolean to toggle test mode:
- On: no forms will be opened, the program will run all database tests logging to the console and end.
- Off: run the winform app as normal

Note: testing mode has two options:
- Run the M2 procedure tests
- Run the M3 C# error handling tests

Note: ENSURE you have a clean setup on the database and procedures before running any tests, 
as manipulations of the data will cause issues if re-run.