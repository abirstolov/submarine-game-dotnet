
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using FluentAssertions;
using Moq;
using submarines.API.BL;

namespace submarines.Tests;
public class MissleUnitTest
{
    [Fact]
    public void Get_Is_Submarine_At_Location__Return_False__When_Board_Does_Not_Have_A_Submarine_At_Location()
    {
        SubmarinesBoard submarinesBoard = new();
        submarinesBoard.Place(new XYLocation(1,1), SubmarinesBoard.Orientation.Horizontal, length: 3);
        var misslesService = new MisslesService(submarinesBoard);

        var response = misslesService.GetIsSubmarineAtLocation(new XYLocation(0,0));
        
        Assert.NotNull(response);
        response.Should().BeOfType<Ok<bool>>();
        var okResult = response as Ok<bool>;
        Assert.NotNull(okResult);
        okResult.Value.Should().BeFalse();
    }

    [Fact]
    public void Get_Is_Submarine_At_Location__Return_False__When_Board_Does_Have_A_Submarine_At_Location()
    {
        SubmarinesBoard submarinesBoard = new();
        submarinesBoard.Place(new XYLocation(0,0), SubmarinesBoard.Orientation.Horizontal, length: 3);
        var misslesService = new MisslesService(submarinesBoard);

        var response = misslesService.GetIsSubmarineAtLocation(new XYLocation(0,0));
        
        Assert.NotNull(response);
        response.Should().BeOfType<Ok<bool>>();
        var okResult = response as Ok<bool>;
        Assert.NotNull(okResult);
        okResult.Value.Should().BeTrue();
    }

}