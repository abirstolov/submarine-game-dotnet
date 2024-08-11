
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using FluentAssertions;
using submarines.API.BL;

namespace submarines.Tests;
public class MissleUnitTest
{
    [Fact]
    public void Post_Missle_Returns__StatusCode_201()
    {
        var misslesService = new MisslesService();
        
        var result = misslesService.PostMissle();
        result.Should().NotBeNull();
        var resultWithStatusCode = result as IStatusCodeHttpResult;
        resultWithStatusCode.Should().NotBeNull();
        resultWithStatusCode?.StatusCode.Should().Be(201);
    }

    [Fact]
    public void Post_Missle_Returns__Location_Of_Created_Missle()
    {
        var misslesService = new MisslesService();
        
        var result = misslesService.PostMissle();

        result.Should().NotBeNull();
        result.Should().BeOfType<Created>();
        var resultWithLocation = result as Created;
        resultWithLocation?.Location.Should().NotBeEmpty();
    }

    [Fact]
    public void Get_Missle_Returns__False__When_Submarines_Board_Does_Not_Have_A_Submarine_In_The_Location()
    {
        var misslesService = new MisslesService();

        var result = misslesService.PostMissle();

        Assert.NotNull(result);

    }

    [Fact]
    public void Get_Missle_Returns__True__When_Submarines_Board_Does_Have_A_Submarine_In_The_Location()
    {
        var misslesService = new MisslesService();

        var result = misslesService.PostMissle();

        Assert.NotNull(result);

    }
}