# DAT602_Project
DAT602 project repo.


## Concept

### Overview
Survivor Island is a 2D point-and-click style game. Two or more players can verse each other, racing to collect items and stay alive the longest. Plays can click on tiles to move around the 2D tile map. The island is covered in an assortment of items, including food to heal health, treasure to increase the score. Fighting animals will award score points but reduce health.

### Items
Players move onto a tile with an item to add it to their inventory. Food items will be added to the players inventory and treasure items will be instantly converted to score. Items are spawned at random empty tiles throughout the game.
Picked up items are added to the inventory and stacked in designated slots, while treasure is automatically converted to score. Use buttons will use the related item and apply its effect.

| Item        | Effect     |
| ----------- | ---------- |
| Fruit       | Health +20 |
| Meat        | Health +50 |
| Coin        | Score +1   |
| Gem	        | Score +5   |

### Hunting
NPC animals will spawn at random tiles around the map. Moving to a tile with a creature and clicking the tile again will trigger the fight calculation. Successfully hunting an animal will award score points. Animals will wander randomly around the map with a simple algorithm.

| Animal | Effect                |
| ------ | --------------------- |
| Spider | Health -10, Score +5  |
| Snake  | Health -30, Score +10 |
| Boar   | Health -80, Score +20 |

### Scoring and Winning
Score points are gained through picking up treasure and hunting animals. The game ends when there are no items and animals left (as there is no way to gain score). The player with the highest score wins!

### Accounts
Players can login to their personal account. If the account does not exist, it will automatically be created. Accounts can be banned by admins and will be locked if a user fails too many login attempts. Accounts store basic information about the player and all of their characters. Accounts can be deleted by the player.

### Admins
Some accounts will have admin abilities. This includes killing running games, adding new players, updating existing player’s data, deleting player accounts and banning an account.

### Map
The map is composed of 2d tiles, that may have other items, animals or obstacles placed on top. The map and item placement will be randomly generated. Player’s move by clicking on an adjacent tile (no diagonal). Some tiles will be filled with obstacles (e.g. rocks) which the player cannot move to.

### Lobby and Games
Once signed in, each player will be able to see a list of all other online players and their highest score. Player’s can click on another player to send a game request. If the other player accepts, a new game is started.

### Chat
Each game has its own text chat where players can message each other. 




