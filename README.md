# Maze-Machine-Learning-Demo
A Machine Learning Demo

This demo was created in eight days and as such has rough edges and lacks unit tests.
I intend to revisit this project and write unit tests as well as new features.

## To Compile:
  C# & .NET code Compiled with Visual Studio 2013.

## To Use:
  * Run the application and it will present a menu to configure the environment.
  * I suggest reducing the initial cutoff time to something like 400 and raising it later.
  * Click the "Go!" button. The menu will close and the maze window will open.
  * At any time close the maze and the menu will reopen.
  * If you change properties on the menu and click "Go!" again, it will try to not regenerate the bots, however if nessessary it will.
  * When you are done close the maze and menu windows to exit.

## Known Issues:
  * Bots can see through corners.
  * If radius is low and speed is high, bots can pass through walls.
  * Walls act as if they are rough instead of smooth when pressed against.
  
## Planned Features:
  * Save / Load
  * Better Collision Detection
  * Better Raycasting
  * Unit Tests
  * Bot to Bot Communication & Population vs Population Evolution
