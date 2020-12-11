using HepsiBurada_MarsRover_CLI.Models;
using System;

namespace HepsiBurada_MarsRover_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Mars Rover v1.0 !");
            Console.WriteLine("Please type terrain size like 'X Y' and press enter :");
            string gridSizeStr = Console.ReadLine();
            Grid grid = new Grid(gridSizeStr);

            while (true)
            {
                Console.WriteLine("Enter rover position and heading type of '1 1 E' and press enter : ");
                string roverPositionAndHeading = Console.ReadLine();
                var tmpRoverPos = roverPositionAndHeading.Split(' ');
                Rover rover = new Rover(new Coordinate(tmpRoverPos[0] + " " + tmpRoverPos[1]), grid, tmpRoverPos[2]);
                Console.WriteLine("Okay let's type movements and press enter : ");
                string roverMovements = Console.ReadLine();
                rover.CommandRover(roverMovements);
                Console.WriteLine(rover.ToString());
                Console.WriteLine("Want to create a rover ? Y/N");
                string createRoverAnswer = Console.ReadLine();
                if (createRoverAnswer.Trim().ToUpper() == "Y")
                    continue;
                else
                    break;
            }
        }
    }
}
