public enum Direction 
{
    Up = 0,
    Left = 1,
    Down = 2,
    Right = 3
}

public static class DirectionExtension
{
    public static Direction TurnLeft(this Direction dir) => (Direction)(((int)dir + 1) & 0x03);
    public static Direction TurnRight(this Direction dir) => (Direction)(((int)dir - 1) & 0x03);
} 