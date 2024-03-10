public class Turtle
{
    public GameState gameState;
    public int x;
    public int y;
    public Direction dir;


    public Turtle(Direction dir, int x, int y)
    {
        this.dir = dir;
        this.x = x;
        this.y = y;        
        gameState = GameState.ALIVE;
    }

    public void Move(int x, int y)
    {        
        this.x = x;
        this.y = y;      
    }
    
    public void Rotate()
    {
        switch (dir){
            case Direction.UP:
                dir = Direction.RIGHT;
                break;
            case Direction.RIGHT:
                dir = Direction.DOWN;
                break;
            case Direction.DOWN:
                dir = Direction.LEFT;
                break;
            case Direction.LEFT:
                dir = Direction.UP;
                break;            
        }
    }

}