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

}