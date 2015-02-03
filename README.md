# Maze-Machine-Learning-Demo
A Machine Learning Demo

This demo was created in eight days and as such has rough edges and lacks unit tests.
I intend to revisit this project and write unit tests as well as new features.

## What I Am:
  This program is a demonstration of neural networks learning to solve a randomly generated maze.
  The training algorithm is a genetic algorithm, it kills off the least effective and breeds the most effective.
  The networks are "feed forward" style neural networks, meaning they have no memory or reflective behaviour.

## To Compile:
  C# & .NET code Compiled with Visual Studio 2013.

## To Use:
  * Run the application and it will present a menu to configure the environment.
  * I suggest reducing the initial cut-off time to something like 400 and raising it later.
  * Click the "Go!" button. The menu will close and the maze window will open.
  * At any time close the maze and the menu will reopen.
  * If you change properties on the menu and click "Go!" again, it will try to not regenerate the bots, however if necessary it will.
  * When you are done close the maze and menu windows to exit.
  * The networks will breed when the simulation reaches the cut-off time, so having an initially low cut-off time will quickly train basic behaviour necessary to solve the maze.
  * It is a good idea to later increase the cut-off time, as this will weed out over fitting problems.

## Training & Learning Features:
  * Changing any of these options will force the bots to be regenerated and retrain from scratch.
  * The "Maze Distance To Goal" option will use a path finding algorithm to score networks during breeding.
  * The "Path Distance To Goal" option will allow the networks to see the fastest path to the goal.
  * The "Direct Distance To Goal" option will provide the networks a value that indicates how far from the goal they are.
  * Finally, "Aware of Velocity" tells the network its current speed and angle.

## Planning
Refer to [Review & Roadmap](Review & Roadmap.md).
