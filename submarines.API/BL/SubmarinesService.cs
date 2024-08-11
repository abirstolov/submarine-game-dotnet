using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using submarines.API.Models;

namespace submarines.API.BL
{
    public class SubmarinesService(SubmarinesBoard submarinesBoard)
    {
        public IResult GetIsSubmarineAtLocation(XYLocation xYLocation)
        {
            bool isOccupied = submarinesBoard.IsOccupied(xYLocation);
            return TypedResults.Ok<bool>(isOccupied);
        }

        public IResult PutSubmarinesOnBoard(SubmarineBoardPlacment submarineBoardPlacment)
        {
            try
            {
                submarinesBoard.Place(submarineBoardPlacment.xYLocation, submarineBoardPlacment.orientation, submarineBoardPlacment.length);
                return TypedResults.Ok();
            }
            catch (InvalidPlacementException)
            {
                return TypedResults.BadRequest();            
            }
        }
    }
}