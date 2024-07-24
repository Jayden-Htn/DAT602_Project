# DAT602_Project
DAT602 project repo.


## Concept

### Overview
Survivor Island is a 2D point-and-click style game. Two or more players can verse each other, racing to collect items and stay alive the longest. Plays can click on tiles to move around the 2D tile map. The island is covered in an assortment of items, including food to heal health, treasure to increase the score. Fighting animals will award score points but reduce health.

### Items
Players move onto a tile with an item to add it to their inventory. Items are spawned at random empty tiles throughout the game.
Picked up items are added to the inventory and stacked in designated slots, while treasure is automatically converted to score. Use buttons will use the related item and apply its effect.

| Item        | Effect     |
| ----------- | ---------- |
| Fruit       | Health +20 |
| Meat        | Health +50 |
| Coin        | Score +1   |
| Gem	Score | Score +5   |

### Hunting
NPC creatures will spawn at random tiles around the map. Moving to a tile with a creature will trigger the fight calculation. Successfully hunting an animal will award score points.

| Animal | Effect                |
| ------ | --------------------- |
| Spider | Health -10, Score +5  |
| Snake  | Health -30, Score +10 |
| Boar   | Health -80, Score +20 |


