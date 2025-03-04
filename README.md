# Tic-Tac-Toe Game

This is a Tic-Tac-Toe game implemented using ASP.NET Core MVC with a three-layer architecture (Presentation Layer, Business Logic Layer, Data Access Layer). The game supports single-player mode with an AI opponent and multiplayer mode.

## Project Structure

The project follows a clean architecture approach with the following layers:

### 1. **DataAccessLayer**

Responsible for handling database interactions and managing entity data.

- **Abstraction**: Contains interfaces for repositories.
- **Data**: Database configurations and context.
- **Entities**: Defines the `Game` entity and enums for `GameStatus` and `GameType`.
- **Migrations**: Manages database migrations.
- **Repositories**: Implements repository logic for game data persistence.

### 2. **GameLogicLayer**

Contains business logic related to game operations.

- **Abstraction**: Interfaces for game management services.
- **DTOs**: Data Transfer Objects for communication between layers.
- **Managers**: Implements `GameManager`, which contains core game logic.
- **Services**: Additional game-related services.

### 3. **XOGame (Presentation Layer)**

Handles user interactions and game UI.

- **Controllers**: Handles game-related HTTP requests.
- **Models**: View models for rendering game data.
- **Views**: Razor views for UI.
- **VMs**: ViewModels for data binding.
- **wwwroot**: Static files like CSS and JavaScript.

## Features of `GameManager`

The `GameManager` class is responsible for handling all game logic. It provides the following functionalities:

### 1. **Game Creation (********`CreateGame`********\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*)**

- Initializes a new game with an empty board.
- Sets the starting player to 'X'.
- Saves the game to the repository.

### 2. **Fetching Game Data (********`GetGame`********\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*)**

- Retrieves game details by ID.
- Converts `Game` entity to `GameDTO`.

### 3. **Handling Player Moves (********`Move`********\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*)**

- Validates the move.
- Updates the board with the player's symbol.
- Checks for a win or draw condition.
- Switches turn to the other player.

### 4. **AI Move (********`AIMove`********\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*)**

- Uses the Minimax algorithm to determine the best move.
- Ensures the AI plays optimally to minimize losses.**\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\***

### 5\*\*\*\*\*\*`GetAllGames`\*\*\*\*****\*\*\*\*)**********\***************\*\*\*\*ry (**********\*\*\*\*\***\*\*\*\***\*\*\*\*\*\*\*\*\*\*\*\*\*\`\`**)\*\*

- Retrieve\*\*\*\*\*\*\*\*s all played games for a given session.

### 6. **Win and Draw Conditions (**`**, **`**)**

- Determines if a player has won.
- Checks if the board is full (draw).

### 7. **AI Logic (**`**, **`**)**

- Implements Minimax algorithm for AI moves.
- Evaluates the board to find the best move for the AI.
- Adjusts scores based on depth to prioritize faster wins.

## How to Run the Project

1. Clone the repository.
2. Configure the database in `appsettings.json`.
3. Run migrations using Entity Fra using SignalRmework Core.
4. Start the application using `dotnet run`.
5. Open the browser and play Tic-Tac-Toe!

Enjoy the game! 🎮

