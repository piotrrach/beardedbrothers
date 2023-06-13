# Code sample: Asteroids

To test the project simply open the "Main" scene and press play button.

![image](https://github.com/piotrrach/beardedbrothers/assets/126329938/6de0aaaf-53ce-43ab-85af-ab431bf77da3)

In order to twaek levels get into the folder Data/Levels and adjust levels settings as pleased:

![image](https://github.com/piotrrach/beardedbrothers/assets/126329938/7ddf8775-e14f-42c2-9589-791c55fddb46)

You can always create more levels but remember to add them to the LevelsLoader object in "GameplayScene":

![image](https://github.com/piotrrach/beardedbrothers/assets/126329938/030c0984-f282-4dce-9df7-23a552c8e2d7)

It is possible to modify almost any design values within "Data" folder in similar way, like asteroirds speed:

![image](https://github.com/piotrrach/beardedbrothers/assets/126329938/fd62c591-388b-4b5a-8ca5-4057afa53db4)

or player shoot cooldown:

![image](https://github.com/piotrrach/beardedbrothers/assets/126329938/690f292c-3c42-41e9-b503-51ab44fd4aac)

# Task details
In a nutshell:
Create a simple game based on Asteroids game:
https://www.youtube.com/watch?v=WYSupJ5r2zo

### Design goal
In this game, the player's goal is to destroy all the asteroids on screen by shooting them
while avoiding colliding with any asteroids in the process.
Consider this as a part of the prototyping stage, so if the game is playable on Unity Editor is
more than enough. Keep in mind though, the final goal is to target mobile devices, and we
plan to support a wide range of them, so performance should be taken into
consideration.

# Core Mechanics

## Player Ship
Unlike the original Asteroids game, the player will directly move their ship up, down, left, and
right (in the XY plane) using WASD.
PlayerShip maximum speed should be easily customizable by game designer.
The PlayerShip begins with three lives. When the PlayerShip collides with an Asteroid, it will
destroy the Asteroid and jump/teleport the PlayerShip to a safer location (consuming one life
in the process)

## Firing
The PlayerShip will fire a bullet every time the player clicks the left mouse button. The
PlayerShip will constantly rotate to track the (visible) mouse pointer.
After two seconds, Bullets will destroy themselves. Bullets will also be destroyed if they
collide with an Asteroid.

## Asteroids
There are three different sizes of Asteroids (3>2>1), and all Asteroid sizes pull a random
model from the same set of models (for each size, different variant). Unlike the original
game, for this prototype, Asteroids will not spawn smaller Asteroids when destroyed.
When an Asteroid is Spawned, it is generated at a random rotation with a random velocity
based on the size (smaller being faster).
When an Asteroid collides with a Bullet, both the Bullet and Asteroid are destroyed, and the
Player gains points based on the size of the Asteroid hit, with smaller Asteroids worth more
(Size 3: 100, Size 2: 200, Size 1: 400).
Enemy Ships - optional
As in the original game, apart from Asteroids, we will have EnemyShips that will be spawned
randomly.
Enemy ships will have similar behaviour as Asteroids in terms of movement and
spawning.
Once spawned however, they will start shooting the player.
Once destroyed, it will give the player 600 points.
Screen Wrapping
One of the key features of Asteroids game is that everything wraps around the screen
(i.e., if a GameObject exits the right side of the screen, it will enter at the same Y position on
the left side of the screen). The object should be completely off screen before it wraps.
Level Completion and Game Over
The level is completed when all Asteroids have been destroyed. The game is over when the
PlayerShip hits an Asteroid but has zero lives remaining

# Game Features

## Screens
### Main Menu:
● Will contain an Input Field for the Player name, Start Game and Exit Game buttons.
### Gameplay Screen
● Should display the score, the lives and the current level progression (starting from 1)
### Game Over Screen
● The Player name (set up in the main menu) should be displayed on the game over
screen, along with the level reached and the final score.

## LevelProgression
The game should have multiple levels that the level designers (not necessarily with a
technical background) can easily create/modify. For the purpose of this task, just having a
few of them would be enough.
For each level, the designer should be able to adjust the amount of Asteroids to spawn
for each category size (i.e., Lv1:Ast_size1: 6, Ast_size2:4, Ast_size3:2).
NOTE: If the optional part is implemented, the amount of enemies per level should be as
well customizable.

# Requirements
The Main menu, Gameplay screen and Game Over screen must be implemented in
separate scenes.
Use Git to track the progress of the development, as you would normally do working in a
team.

# Considerations
Focus on mechanics and code quality.
Keep it design friendly, so a level designer could tweak and balance the game.
You can use Kenny assets for the art
https://www.kenney.nl/assets/simple-space
https://www.kenney.nl/assets/space-shooter-redux
Estimation and Submission
One week, counting from the next day you receive the task.
Publish the game on Github in a private repository. Invite the following account
task-bbgames as a collaborator, so we will receive an invitation and access to your project.
More info about how to invite collaborators (click here). Good luck!
