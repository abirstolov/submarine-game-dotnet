using static submarines.API.Models.SubmarinesBoard;

namespace submarines.API.Models;
public record SubmarineBoardPlacment(XYLocation xYLocation, Orientation orientation, int length);