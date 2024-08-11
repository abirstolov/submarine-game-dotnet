namespace submarines.API.Models;

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
        
        List<XYLocation> newOccupiedLocations = GenerateXYLocations(xYLocation, orientation, length);

        for (int i=0; i<length; i++)
            if (IsAdjacentOrOccupied(xYLocation.X + (orientation == Orientation.Horizontal? i : 0), xYLocation.Y + (orientation == Orientation.Vertical? i : 0)))
                throw new InvalidPlacementException();
        
        // for (int i=0; i<length; i++)
        //     Grid[xYLocation.X + (orientation == Orientation.Horizontal? i : 0), xYLocation.Y + (orientation == Orientation.Vertical? i : 0)] = true;
        foreach (var location in newOccupiedLocations)
            Grid[location.X, location.Y] = true;
    }

    private bool IsAdjacentOrOccupied(int x, int y)
    {
        if (Grid[x, y])
            return true;
        if (Grid[Math.Min(x+1, Width-1), y] || Grid[Math.Max(x-1, 0), y])
            return true;
        if (Grid[x, Math.Min(y+1, Height-1)] || Grid[x, Math.Max(y-1, 0)])
            return true;
        return false;
    }

    private List<XYLocation> GenerateXYLocations(XYLocation startXYLocation, Orientation orientation, int length)
    {
        List<XYLocation> xyLocations = [];
        for (int i=0; i<length; i++)
            xyLocations.Add(
                new XYLocation(startXYLocation.X + (orientation == Orientation.Horizontal? i : 0), 
                startXYLocation.Y + (orientation == Orientation.Vertical? i : 0)));
        return xyLocations;
    }

    public enum Orientation
    {
        Horizontal,
        Vertical
    }
}