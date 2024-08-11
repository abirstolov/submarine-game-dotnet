using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace submarines.API.BL
{
    public class MisslesService(SubmarinesBoard submarinesBoard)
    {
        public IResult GetIsSubmarineAtLocation(XYLocation xYLocation)
        {
            bool isOccupied = submarinesBoard.Grid[xYLocation.X, xYLocation.Y];
            return TypedResults.Ok<bool>(isOccupied);
        }

    }
}