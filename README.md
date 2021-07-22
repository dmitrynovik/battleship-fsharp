# battleship-fsharp

# battleship-game
For desciption of the game please click [here](https://en.wikipedia.org/wiki/Battleship_(game))

The solution concentrates on tracking of the state for a single player.

## Principles
- Extensibility - supports arbitrary board size and potentially other pieces (shapes) in the future;
- Performance - greedy on memory (if someone decides to use very large boards) , fast to lookup;
- Brevity and simplicity: no redundant code to show off;
