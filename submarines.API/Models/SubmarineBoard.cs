namespace submarines.API.Models;

public class SubmarinesBoard()
{
    const int Width = 10;
    const int Height = 10;

    private bool[,] _grid = new bool[Width, Height];

    /*
    No.	Class of ship	Size
    1	Carrier	        5
    2	Battleship	    4
    3	Cruiser	        3
    4	Submarine	    3
    5	Destroyer	    2
    */
    private List<int> _allowedLengthOfSubmarines = [2, 3, 3, 4, 5];

    public void Place(XYLocation xYLocation, Orientation orientation, int length)
    {
        List<XYLocation> newOccupiedLocations = ValidatePlacment(xYLocation, orientation, length);

        ApplyPlacment(length, newOccupiedLocations);

        void ApplyPlacment(int length, List<XYLocation> newOccupiedLocations)
        {
            _allowedLengthOfSubmarines.Remove(length);
            foreach (var location in newOccupiedLocations)
                _grid[location.X, location.Y] = true;
        }

        List<XYLocation> ValidatePlacment(XYLocation xYLocation, Orientation orientation, int length)
        {
            if (orientation == Orientation.Horizontal)
            {
                if (xYLocation.X + length > Width)
                    throw new InvalidPlacementException($"Width overflow (Width = {Width})");
            }
            else
            {
                if (xYLocation.Y + length > Height)
                    throw new InvalidPlacementException($"Height overflow (Height = {Height}");
            }
            if (!_allowedLengthOfSubmarines.Contains(length))
                throw new InvalidPlacementException();

            List<XYLocation> newOccupiedLocations = GenerateXYLocations(xYLocation, orientation, length);
            foreach (var location in newOccupiedLocations)
                if (IsAdjacentOrCurrentOccupied(location.X, location.Y))
                    throw new InvalidPlacementException();

            return newOccupiedLocations;
        }
    }

    public bool IsOccupied(XYLocation xYLocation)
        => _grid[xYLocation.X, xYLocation.Y];

    public enum Orientation
    {
        Horizontal,
        Vertical
    }
    
    private bool IsAdjacentOrCurrentOccupied(int x, int y)
    {
        if (_grid[x, y])
            return true;
        if (_grid[Math.Min(x+1, Width-1), y] || _grid[Math.Max(x-1, 0), y])
            return true;
        if (_grid[x, Math.Min(y+1, Height-1)] || _grid[x, Math.Max(y-1, 0)])
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

}