using HepsiBurada_MarsRover_CLI.Interfaces;
using HepsiBurada_MarsRover_CLI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada_MarsRover_CLI.Helpers
{
    public class Validator : IValidator
    {
        private string _validationError { get; set; }
        public string GetLastestError()
        {
            return _validationError;
        }
        public bool Validate(Coordinate coordinate)
        {
            if (coordinate.X < 0 || coordinate.Y < 0)
            {
                _validationError = "X or Y cannot be less than zero";
                return false;
            }
            _validationError = "";
            return true;
        }

        public bool Validate(Grid grid)
        {
            if (grid.TopRight.X < 0 || grid.TopRight.Y < 0 || grid.BottomLeft.X < 0 || grid.BottomLeft.Y < 0)
            {
                _validationError = "Grid edges cannot be less than zero";
                return false;
            }

            if (grid.TopRight.X < grid.BottomLeft.X || grid.TopRight.Y < grid.BottomLeft.Y || (grid.TopRight.ToString() == grid.BottomLeft.ToString()))
            {
                _validationError = "Invalid grid plan";
                return false;
            }

            _validationError = "";
            return true;
        }
    }
}
