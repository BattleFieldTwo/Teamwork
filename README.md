# Team Battle Field 2
This is the official repository for the teamwork project in High Quality Code @ Telerik Academy Sofia - Season 2015/2016.
# Team members:
  - Nikola Hristov - [anarhist_hristo](https://telerikacademy.com/Users/anarhist_hristov) @ Telerik Academy Student System.
  - Veselin Tsvetanov - [veselints](https://telerikacademy.com/Users/veselints) @ Telerik Academy Student System.
  - Ivan Nikolov - [Ivan_Nik](https://telerikacademy.com/Users/Ivan_Nik) @ Telerik Academy Student System.
  - Vyara Hristova - [vyarah](https://telerikacademy.com/Users/vyarah) @ Telerik Academy Student System.
  - Tsvetanka Chipilova - [zvet80](https://telerikacademy.com/Users/zvet80) @ Telerik Academy Student System.
  - Georgi Kermekchiev - [jokerbg](https://telerikacademy.com/Users/jokerbg) @ Telerik Academy Student System.

# Official Telerik Academy HQC repo:
  - [HQC Teamworks initial repo](https://github.com/TelerikAcademy/High-Quality-Code/tree/master/Teamwork)
  - This repository contains basic guidelines and requirements for all the teams.


Redesigned the project structure: Team Battlefield 2
====================================================

-   Renamed assembly name from “ГърмящитеБомби” to “BattleField2”;

-   Renamed root namespace from “ГърмящитеБомби” to “BattleField2”;

-   Created seven projects included in the solution:

    -   Common – containing Constants and Validations;

    -   GameLogic – containing Main (EntryPoint) for the console application and GameEngine for the console;

    -   Renderers – containing the Renderer Contracts, Implementations and Conficurations;

    -   Tests – containing unit test;

    -   Models – containing all the models used ;

    -   WpfGUI – containing the WPF Graphical user interface - Contracts and implementations;

-   Renamed main class “Program” to “EmtryPoint”;

-   Created class “GameEngin” containing the game logic;

-   Separated rendering logic in interface “IGameRenderer” and implemented “ConsoleGameRenderer” which is writing and reading form the console;

-   Extracted “Constants” class containing all the constants used in the game;

Reformatted the source code:
============================

-   Removed all unneeded empty lines, e.g. in the method \`PlayGame()\`;

-   Inserted empty lines between the methods;

-   Split the lines containing several statements into several simple lines;

-   Formatted the curly braces “{“ and “}” according to the best practices for the C\\\# language;

-   Put “{” and “}” after all conditionals and loops (when missing);

-   Character casing: variables and fields made “camelCase”, types and methods made “PascalCase”, constants made “ALL\_CAPS”;

-   Formatted all other elements of the source code according to the best practices introduced in the course High-Quality Programming Code;

Renamed variables:
==================

-   In class \`Field\`: “pozicii” to “fieldPositions”. Created property “FieldPositions”;

Renamed methods:
================

-   “InitField()” to “GenerateField()”;

-   “InitMines()” to

-   “PrebroiOstavashtiteMinichki()” to “CountRemainingMines()”;

Introduced constants:
=====================

-   WELCOME\_MESSAGE = "Welcome to the Battle Field game";

-   INVITE\_TO\_ENTER\_SIZE\_MESSAGE = "Enter legal size of board: ";

-   INVITE\_TO\_ENTER\_NAME\_MESSAGE = "Enter your name: ";

-   HI\_MESSAGE = "Hi, ";

-   INVITE\_TO\_ENTER\_COORDINATES\_MESSAGE = "Enter coordinates: ";

-   INVALID\_MOVE\_NOTIFICATION\_MESSAGE = "Invalid Move";

-   GAME\_OVER\_MESSAGE = "Game Over. Detonated Mines: ";

-   MINES\_COUNT\_MESSAGE = "Mines count is: ";

-   SCORE\_MESSAGE = "Score: ";

-   APP\_WIDTH = 90;

-   APP\_HEIGHT = 45;

-   MIN\_FIELDSIZE = 1;

-   MAX\_FIELDSIZE = 10;

-   MESSAGE\_LEFT\_POSSITION = 45;

-   MESSAGE\_TOP\_POSSITION = 10;

-   PLAYER\_NAME\_REGEX\_PATTERN = "\[^a-zA-Z0-9\]";

-   EMPTY\_CELL\_COLOR = "Yellow";

-   MINE\_CELL\_COLOR = "Green";

-   EXPLODED\_CELL\_COLOR = "Red";

-   DEFAULT\_COLOR = "Blue";

Extracted the method:
=====================

-   “InitillizeGame()” from the method \`Main()\` and moved it to the GameEngine;

-   “PlayGame()” from the method \`Main()\` and moved it to the GameEngine;

Introduced interfaces:
======================

-   “IGameRenderer” containing the interface needed for implementation of Console game renderers;

-   “IViewModel” containing the interface needed for implementation of View models;

Introduced abstract classes:
============================

-   “Cell” which is the base class for cell in the game field;

-   “Explosive” which inherits “Cell” and adds exploding functionality for the Mines;

Introduced classes:
===================

-   “MineLevel\[One-Five\]Upgrade”. Moved related functionality in it. Applied Docorator (removed code duplication from the different types of Mine) and Factory Design patterns to these classes;

-   “DetonatedCell” representing a detonated cell in the Game field;

-   “EmptyCell” representing an empty cell on the field;

-   “CellFactory” containing factory for creating and returning different types of Cells;

-   “Field” containing the Game field logic and properties;

-   “Player” containing the player logic and properties;

-   “Validator” containing all Validations needed by the game;

-   “Constants” containing all Constants needed in the game;

-   “GameLogic” containing the logic running the console app;

-   “ConsoleGameRenderer” implementing “IGameRenderer” interface;

-   “ColorConfig” containing the color configuration of the console;

-   “WpfViewModel” containing the View model for the Desktop UI project;

Introduced emumerations:
========================

-   “CellType” enumeration, containing the different Cell types;

Introduced structures:
======================

-   “Coordinates” which is a structure, containing X and Y coordinates;

Removed type checking:
======================

-   Removed method “DetonateMine()” and replaced it with polymorphism of the classes “Mine”;
