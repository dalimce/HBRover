using HepsiBurada_MarsRover_CLI.Enums;
using HepsiBurada_MarsRover_CLI.Helpers;
using HepsiBurada_MarsRover_CLI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada_MarsRover_CLI.Models
{
    public class Rover
    {
        #region Fields
        private IValidator _validator = new Validator();
        #endregion

        #region Const
        public Rover(Coordinate _position, Grid _grid, string _heading)
        {
            if (_validator.Validate(_position))
            {
                _heading = _heading.Trim().ToUpper();
                if (_heading == "N")
                {
                    Heading = Orientations.North;
                }
                else if (_heading == "W") {
                    Heading = Orientations.West;
                }else if (_heading == "E")
                {
                    Heading = Orientations.East;
                }else if (_heading == "S")
                {
                    Heading = Orientations.South;
                }
                else
                {
                    Heading = Orientations.North;
                }

                Position = _position;
                grid = _grid;
            }
            else
            {
                Logger.AddErrorLog(String.Format("Rover Error => {0}", _validator.GetLastestError()));
            }
        }
        public Rover(Coordinate _position, Grid _grid)
        {
            if (_validator.Validate(_position))
            {
                Position = _position;
                grid = _grid;
            }
            else
            {
                Logger.AddErrorLog(String.Format("Rover Error => {0}", _validator.GetLastestError()));
            }
        }
        #endregion

        #region Methods
        private void rotateRight()
        {
            Heading = Heading + 1 > Orientations.West ? Orientations.North : Heading + 1;
        }
        private void rotateLeft()
        {
            Heading = Heading - 1 < Orientations.North ? Orientations.West : Heading - 1;
        }

        public void CommandRover(string commandCharList)
        {
            foreach (Char letter in commandCharList.ToCharArray())
            {
                switch (char.ToUpper(letter))
                {
                    case 'L':
                        rotateLeft();
                        break;
                    case 'R':
                        rotateRight();
                        break;
                    case 'M':
                        moveRover(grid);
                        break;
                    default:
                        Logger.AddErrorLog("Invalid Input");
                        return;
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0}  {1}", Position.ToString(), Heading.ToString());
        }

        private void moveRover(Grid grid)
        {
            Coordinate possiblePosition = new Coordinate(Position);
            if (Heading == Orientations.North)
            {
                possiblePosition.Y++;
            }
            else if (Heading == Orientations.South)
            {
                possiblePosition.Y--;
            }
            else if (Heading == Orientations.West)
            {
                possiblePosition.X--;
            }
            else if (Heading == Orientations.East)
            {
                possiblePosition.X++;
            }

            if (_validator.Validate(possiblePosition))
            {
                Position = possiblePosition;
            }
            else
            {
                Logger.AddErrorLog(_validator.GetLastestError());
            }
        }

        #endregion

        #region Props
        public Coordinate Position { get; set; }
        public Orientations Heading { get; set; }
        private Grid grid { get; set; }
        #endregion
    }
}
