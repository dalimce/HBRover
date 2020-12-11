using HepsiBurada_MarsRover_CLI.Helpers;
using HepsiBurada_MarsRover_CLI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HepsiBurada_MarsRover_CLI.Models
{
    public class Grid : Validator
    {
        #region Fields
        private IValidator _validator = new Validator();
        #endregion

        #region Const
        public Grid(string size)
        {
            var xy = size.Split(' ').Select(x=> Convert.ToInt32(x)); 
            BottomLeft = new Coordinate(0, 0);
            TopRight = new Coordinate(xy.First(), xy.Last());
            if (!_validator.Validate(this))
            {
                Logger.AddErrorLog(_validator.GetLastestError());
            }
        }

        public Grid(Coordinate _topRight)
        {
            BottomLeft = new Coordinate(0, 0);
            TopRight = _topRight;
            if (!_validator.Validate(this)) {
                Logger.AddErrorLog(_validator.GetLastestError());
            }
        }

        public Grid(Coordinate _topRight, Coordinate _bottomLeft)
        {
            BottomLeft = _bottomLeft;
            TopRight = _topRight;
            if (!_validator.Validate(this))
            {
                Logger.AddErrorLog(_validator.GetLastestError());
            }
        }
        #endregion

        #region Props
        public Coordinate BottomLeft { get; set; }
        public Coordinate TopRight { get; set; }
        #endregion
    }
}
