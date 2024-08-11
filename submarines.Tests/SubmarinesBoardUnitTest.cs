using submarines.API.Models;

namespace submarines.Tests;

public class SubmarinesBoardUnitTest
{
    [Fact]
    public void Place_A_New_Submarine_At_Location_0_8_Horizontal_With_Length_3__Throws__Argument_Out_Of_Range_Exception()
    {
        SubmarinesBoard submarinesBoard = new();
        try
        {
            submarinesBoard.Place(new XYLocation(8,0), SubmarinesBoard.Orientation.Horizontal, length: 3);
            Assert.Fail("Didn't throw an InvalidPlacementException");
        }
        catch (InvalidPlacementException)
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

    [Fact]
    public void Put_Submarines_On_Board_Returns__Bad_Request_400__When_Given_2_Submarines_Of_Length_5()
    {
        SubmarinesBoard submarinesBoard = new();
        try
        {
            submarinesBoard.Place(new XYLocation(0,0), SubmarinesBoard.Orientation.Horizontal, length: 5);
            submarinesBoard.Place(new XYLocation(0,3), SubmarinesBoard.Orientation.Horizontal, length: 5);
            Assert.Fail("Didn't throw an InvalidPlacementException");
        }
        catch (InvalidPlacementException)
        {
        }
    }

    [Fact]
    public void Put_Submarines_On_Board_Returns__Bad_Request_400__When_Given_A_Submarine_Of_Length_1()
    {
        SubmarinesBoard submarinesBoard = new();
        try
        {
            submarinesBoard.Place(new XYLocation(0,3), SubmarinesBoard.Orientation.Horizontal, length: 1);
            Assert.Fail("Didn't throw an InvalidPlacementException");
        }
        catch (InvalidPlacementException)
        {
        }
    }

    [Fact]
    public void Put_Board_Returns__Bad_Request_400__When_A_Given_Submarine_Is_Adjacent_To_Another_One()
    {

    }

}