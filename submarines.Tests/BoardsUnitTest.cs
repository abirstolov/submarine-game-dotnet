namespace submarines.Tests;

public class BoardsUnitTest
{
    [Fact]
    public void Post_PlayerBoardsSet_Returns__Created_201_With_Boards_Set_Id()
    {
        // arrange
        // act
        // validate
    }

    [Fact]
    public void Put_Board_Returns__Bad_Request_400__When_Given_Submarines_Different_In_Count_Or_Size_From_Available()
    {
        /*
        No.	Class of ship	Size
        1	Carrier	        5
        2	Battleship	    4
        3	Cruiser	        3
        4	Submarine	    3
        5	Destroyer	    2
        */
    }

    [Fact]
    public void Put_Board_Returns__Bad_Request_400__When_A_Given_Submarine_Is_Adjacent_To_Another_One()
    {

    }

    [Fact]
    public void Get_Hits_Board_Returns__True__For_A_Hitted_Coordinate()
    {

    }

    [Fact]
    public void Get_Hits_Board_Returns__False__For_A_Not_Hitted_Coordinate()
    {
        
    }
}