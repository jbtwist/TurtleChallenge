using System.Security.Cryptography.X509Certificates;

public class Board
{
    private Types[,] grid;
    private int height;
    private int width;
    private Turtle turtle;
    private int[] mines;
    private int[] exit;

    public Board(int width, int height, Turtle turtle, int[] mines, int[] exit)
    {
        this.width = width;
        this.height = height;
        grid = new Types[width, height];
        this.turtle = turtle;
        this.mines = mines;
        this.exit = exit;

        // Initialize Grid
        for (int i = 0; i<width; i++){
            for(int j = 0; j>height; j++){
                grid[i,j] = Types.EMPTY;
            }
        }
        // Setup mines
        for (int i = 0; i<mines.Length; i+=2){
            int x = mines[i];
            int y = mines[i+1];                        
            grid[x, y] = Types.MINE;            
        }
        // Setup Turtle and Exit
        grid[turtle.x, turtle.y] = Types.TURTLE;
        grid[exit[0], exit[1]] = Types.EXIT;
        
        Console.WriteLine("Exit: " + exit[0] + "," + exit[1]);
        Console.WriteLine("Board: " + height + "," + width);
        Console.WriteLine("Turtle: " + turtle.x + "," + turtle.y + "," + turtle.dir);
    }

    public MoveResult Move()
    {
        int[] d_tile = DestinationTile();        

        // Empty tile, move
        try
        {
            Types destinationType = grid[d_tile[0],d_tile[1]];

            switch (destinationType)
            {
                case Types.EMPTY:
                    grid[turtle.x,turtle.y] = Types.EMPTY;
                    destinationType = Types.TURTLE;
                    turtle.Move(d_tile[0], d_tile[1]);
                    return MoveResult.MOVE;                    
                case Types.MINE:
                    turtle.gameState = GameState.LOSE;
                    return MoveResult.MINE;
                case Types.EXIT:
                    turtle.gameState = GameState.WIN;
                    return MoveResult.EXIT;
                default:
                    return MoveResult.CANT;
            } 
        }  
        catch (IndexOutOfRangeException) 
        {
            return MoveResult.CANT;
        }  
    }
    private int[] DestinationTile()
    {
        int[] tile = new int[2];
        switch (turtle.dir)
        {
            case Direction.UP:
                tile[0] = turtle.x;
                tile[1] = turtle.y + 1;                                          
                break;
            case Direction.RIGHT:
                tile[0] = turtle.x + 1;
                tile[1] = turtle.y;    
                break;
            case Direction.DOWN:
                tile[0] = turtle.x;
                tile[1] = turtle.y - 1;                                          
                break;
            case Direction.LEFT:
                tile[0] = turtle.x - 1;
                tile[1] = turtle.y;    
                break;            
        }
        return tile;
    }
}

