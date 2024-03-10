namespace TurtleChallenge;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMovementShouldPass()
    {
        Direction dir = Direction.UP;
        Turtle turtle = new (dir, 0, 0);
        Board board = new (1, 3, turtle, [], [0,2]); //Creates Board with 1 height and 2 width, where exit is placed on [0,2]
        MoveResult move = board.Move();
        Assert.AreEqual(move, MoveResult.MOVE);
    }

    [TestMethod]
    public void TestMovementShouldFail()
    {
        Direction dir = Direction.UP;
        Turtle turtle = new (dir, 0, 0);
        Board board = new (2, 1, turtle, [], [1, 0]); //Creates Board with 1 height and 2 width, where exit is placed on [1,0]
        MoveResult move = board.Move();
        Assert.AreEqual(move, MoveResult.CANT);
    }

    [TestMethod]
    public void TestMovementShouldExit()
    {
        Direction dir = Direction.UP;
        Turtle turtle = new (dir, 0, 0);
        Board board = new (1, 2, turtle, [], [0,1]); //Creates Board with 2 height and 1 width, where exit is placed on [0,1]
        MoveResult move = board.Move();
        Assert.AreEqual(move, MoveResult.EXIT);
    }
    
    [TestMethod]
    public void TestMovementShouldMine()
    {
        Direction dir = Direction.UP;
        Turtle turtle = new (dir, 0, 0);
        Board board = new (1, 3, turtle, [0,1], [0,2]); //Creates Board with 3 height and 1 width, where mine is placed on [0,1]
        MoveResult move = board.Move();
        Assert.AreEqual(move, MoveResult.MINE);
    }

    [TestMethod]
    public void TestPlacingExitOut()
    {
        try{
        Direction dir = Direction.UP;
        Turtle turtle = new (dir, 0, 0);
        Board board = new (2, 1, turtle, [], [4, 0]); 
        } catch (IndexOutOfRangeException) {
            return;
        }
        Assert.Fail("Not thrown exception");        
    }

    [TestMethod]
    public void TestPlacingTurtleOut()
    {
        try{
        Direction dir = Direction.UP;
        Turtle turtle = new (dir, 5, 5);
        Board board = new (2, 1, turtle, [], [0, 0]); 
        } catch (IndexOutOfRangeException) {
            return;
        }
        Assert.Fail("Not thrown exception");        
    }

    [TestMethod]
    public void TestPlacingMineOut()
    {
        try{
        Direction dir = Direction.UP;
        Turtle turtle = new (dir, 1, 0);
        Board board = new (2, 1, turtle, [4,0], [0, 0]); 
        } catch (IndexOutOfRangeException) {
            return;
        }
        Assert.Fail("Not thrown exception");        
    }

    [TestMethod]
    public void TestTurtleOverlapping()
    {
        try{
        Direction dir = Direction.UP;
        Turtle turtle = new (dir, 0, 0);
        Board board = new (5, 5, turtle, [], [0, 0]); 
        } catch (OverlapException) {
            return;
        }
        Assert.Fail("Not thrown exception");        
    }

    [TestMethod]
    public void TestMineOverlapping()
    {
        try{
        Direction dir = Direction.UP;
        Turtle turtle = new (dir, 0, 0);
        Board board = new (5, 5, turtle, [1,1], [1, 1]); 
        } catch (OverlapException) {
            return;
        }
        Assert.Fail("Not thrown exception");        
    }
}