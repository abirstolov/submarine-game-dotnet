
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using FluentAssertions;
using Moq;
using submarines.API.BL;
using submarines.API.Models;

namespace submarines.Tests;
public class SubmarinesUnitTest
{
    [Fact]
    public void Get_Is_Submarine_At_Location__Return_False__When_Board_Does_Not_Have_A_Submarine_At_Location()
    {
        SubmarinesBoard submarinesBoard = new();
        submarinesBoard.Place(new XYLocation(1,1), SubmarinesBoard.Orientation.Horizontal, length: 3);
        var submarinesService = new SubmarinesService(submarinesBoard);

        var response = submarinesService.GetIsSubmarineAtLocation(new XYLocation(0,0));
        
        Assert.NotNull(response);
        response.Should().BeOfType<Ok<bool>>();
        var okResult = response as Ok<bool>;
        Assert.NotNull(okResult);
        okResult.Value.Should().BeFalse();
    }

    [Fact]
    public void Get_Is_Submarine_At_Location__Return_True__When_Board_Does_Have_A_Submarine_At_Location()
    {
        SubmarinesBoard submarinesBoard = new();
        submarinesBoard.Place(new XYLocation(0,0), SubmarinesBoard.Orientation.Horizontal, length: 3);
        var submarinesService = new SubmarinesService(submarinesBoard);

        var response = submarinesService.GetIsSubmarineAtLocation(new XYLocation(0,0));
        
        Assert.NotNull(response);
        response.Should().BeOfType<Ok<bool>>();
        var okResult = response as Ok<bool>;
        Assert.NotNull(okResult);
        okResult.Value.Should().BeTrue();
    }

    [Fact]
    public void Place_A_New_Submarine_At_Location_0_8_Horizontal_With_Length_3__Throws__Argument_Out_Of_Range_Exception()
    {
        SubmarinesBoard submarinesBoard = new();
        try
        {
            submarinesBoard.Place(new XYLocation(8,0), SubmarinesBoard.Orientation.Horizontal, length: 3);
            Assert.Fail("Didn't throw an ArgumentOutOfRangeException");
        }
        catch (ArgumentOutOfRangeException)
        {
        }

    }

    [Fact]
    public void Place_A_New_Ajacent_Submarine__Throws__Invalid_Placement_Exception()
    {
        SubmarinesBoard submarinesBoard = new();
        try
        {
            submarinesBoard.Place(new XYLocation(0,0), SubmarinesBoard.Orientation.Vertical, length: 3);
            submarinesBoard.Place(new XYLocation(1,0), SubmarinesBoard.Orientation.Vertical, length: 5);
            Assert.Fail("Didn't throw an InvalidPlacementException");
        }
        catch (InvalidPlacementException)
        {
        }
    }

    [Fact]
    public void Place_A_New_Submarine_Overlapping_Exising_One_Throws__Invalid_Placement_Exception()
    {
        SubmarinesBoard submarinesBoard = new();
        try
        {
            submarinesBoard.Place(new XYLocation(0,0), SubmarinesBoard.Orientation.Horizontal, length: 3);
            submarinesBoard.Place(new XYLocation(2,0), SubmarinesBoard.Orientation.Horizontal, length: 5);
            Assert.Fail("Didn't throw an InvalidPlacementException");
        }
        catch (InvalidPlacementException)
        {
        }
    }
}