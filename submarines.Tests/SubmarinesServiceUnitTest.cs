
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using FluentAssertions;
using Moq;
using submarines.API.BL;
using submarines.API.Models;

namespace submarines.Tests;
public class SubmarinesServiceUnitTest
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
    public void Put_Submarines_At_Board__Returns__Bad_Request__When_Invalidly_Placed()
    {
        SubmarinesBoard submarinesBoard = new();
        var submarinesService = new SubmarinesService(submarinesBoard);

        var response = submarinesService.PutSubmarinesOnBoard(new SubmarineBoardPlacment(new XYLocation(0, 9), SubmarinesBoard.Orientation.Vertical, 3));

        Assert.NotNull(response);
        response.Should().BeOfType<BadRequest>();

    }

    [Fact]
    public void Put_Submarines_At_Board__Returns__Bad_Request__When_Invalidly_Placed2()
    {
        SubmarinesBoard submarinesBoard = new();
        var submarinesService = new SubmarinesService(submarinesBoard);

        var response = submarinesService.PutSubmarinesOnBoard(new SubmarineBoardPlacment(new XYLocation(0, 3), SubmarinesBoard.Orientation.Vertical, 3));

        Assert.NotNull(response);
        response.Should().BeOfType<Ok>();

        response = submarinesService.PutSubmarinesOnBoard(new SubmarineBoardPlacment(new XYLocation(0, 3), SubmarinesBoard.Orientation.Vertical, 3));

        Assert.NotNull(response);
        response.Should().BeOfType<BadRequest>();

    }

    [Fact]
    public void Put_Submarines_At_Board__Returns__Bad_Request__When_Invalidly_Placed3()
    {
        SubmarinesBoard submarinesBoard = new();
        var submarinesService = new SubmarinesService(submarinesBoard);

        var response = submarinesService.PutSubmarinesOnBoard(new SubmarineBoardPlacment(new XYLocation(0, 3), SubmarinesBoard.Orientation.Vertical, 3));

        Assert.NotNull(response);
        response.Should().BeOfType<Ok>();

        response = submarinesService.PutSubmarinesOnBoard(new SubmarineBoardPlacment(new XYLocation(0, 0), SubmarinesBoard.Orientation.Horizontal, 6));

        Assert.NotNull(response);
        response.Should().BeOfType<BadRequest>();

    }
    
}