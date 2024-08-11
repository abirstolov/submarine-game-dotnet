
public class SubmarinesBoard()
{
    const int Width = 10;
    const int Height = 10;

    public bool[,] Grid { get; internal set; } = new bool[Width, Height];

    public void Place(XYLocation xYLocation, Orientation orientation, int length)
    {
        if (orientation == Orientation.Horizontal)
            if (xYLocation.X + length > Width)
                throw new ArgumentOutOfRangeException($"Width overflow (Width = {Width})");
        else
            if (xYLocation.Y + length > Height)
                throw new ArgumentOutOfRangeException($"Height overflow (Height = {Height}");
        for (int i=0; i<length; i++)
            Grid[xYLocation.X + (orientation == Orientation.Horizontal? i : 0), xYLocation.Y + (orientation == Orientation.Vertical? i : 0)] = true;
    }

    public enum Orientation
    {
        Horizontal,
        Vertical
    }
}