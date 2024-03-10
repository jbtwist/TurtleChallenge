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
        Direction ddir = Direction.UP;
        Turtle dturtle = new (ddir, 0, 0);
        Board dboard = new (2, 1, dturtle, [], [1, 0]); //Creates Board with 1 height and 2 width, where exit is placed on [1,0]
        MoveResult dmove = dboard.Move();
        Assert.AreEqual(dmove, MoveResult.CANT);
    }    
}