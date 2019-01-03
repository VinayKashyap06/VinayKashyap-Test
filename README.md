# VinayKashyap-Test
Scenes-> a) Start b) Game.

Data-> Data.json file inside Streaming Assests folder. Includes a simple data structure similar to a tree.
Map-> A 3D plane object

Gameplay Scripts:

a) Level Loader-> uses Unity Engine Scene Management for traveling within scenes.

b) Data Loader-> uses System.IO to load data from Data.json in a data structure. Retrieves cube color and points. Randomly spawns the cubes.

c)Movement -> This script uses Input axis to move in the game. (WASD or Arrow keys)

d)Collision-> Checks for trigger collisions and update scores and streak.

e)Cube Properties-> Individual script for each of the cube clone created.

f)Game Controller-> Handles score updation, streak updation, timer updation and Game Over panel.

g) Follow Camera-> Follows the player using late update.

Prefabs-> CubePrefab.

Materials-> CubeMat, Plane Mat and  PlayerMat.
