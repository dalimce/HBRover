using HepsiBurada_MarsRover_CLI.Models;
using Xunit;

namespace Tests
{
    public class RoverV1Test
    {
        [Theory]
        [InlineData(new object[] { "10 10", "1 2 N", "LMLMLMLMM", 1,3,"North" })]
        [InlineData(new object[] { "10 10", "3 3 E", "MMRMMRMRRM", 5,5, "North" })]
        public void GeneratePlataueAndExecuteRoverCommands(
            string gridStr,
            string roverStr,
            string commandStr,
            int expectedCoordinateX,
            int expectedCoordinateY,
            string expectedCoordinateHeading
            )
        {
            var grid = new Grid(gridStr);
            var rover = new Rover(new Coordinate(roverStr), grid);
            rover.CommandRover(commandStr);
            Assert.NotNull(rover);
            Assert.Equal(expectedCoordinateX, rover.Position.X);
            Assert.Equal(expectedCoordinateY, rover.Position.Y);
            Assert.Equal(expectedCoordinateHeading, rover.Heading.ToString());
        }
    }
    
}