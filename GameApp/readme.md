# Readme

## Instructions

To run this project:
1. Load Solution into Visual Studio
2. Run /db/start.sql to initialise the database
3. Run /db/procedures.sql to create the main procedures
4. Run /db/procedures_extra_.sql to create extra required procedures
5. Run the program

## Run Modes

In Program.cs there is a boolean to toggle test mode.
- On: no forms will be opened, the program will run all database tests logging to the console and end.
- Off: run the winform app as normal

Note: ENSURE you have a clean setup on the database and procedures before running any tests, 
as manipulations of the data will cause issues if re-run.