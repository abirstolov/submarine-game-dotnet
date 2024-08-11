using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace submarines.API.BL
{
    public class MisslesService
    {
        public IResult PostMissle()
        {
            return TypedResults.Created("2");
        }
    }
}