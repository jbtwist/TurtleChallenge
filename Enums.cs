public enum Direction 
{
    UP = 0, 
    RIGHT = 1, 
    DOWN = 2, 
    LEFT = 3
};

public enum MoveResult
{
    MOVE = 0,
    CANT = 1,
    MINE = 2,
    EXIT = 3    
}

public enum Types
{
    EMPTY = 0,
    TURTLE = 1,
    MINE = 2,
    EXIT = 3
}

public enum GameState
{
    ALIVE = 0,
    WIN = 1,
    LOSE = 2,
}