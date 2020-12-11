using HepsiBurada_MarsRover_CLI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HepsiBurada_MarsRover_CLI.Models
{
    public class Coordinate
    {
        #region Const
        public Coordinate(string _coord)
        {
            var coord = _coord.Split(' ').Select(x => Convert.ToInt32(x));
            this.X = coord.First();
            this.Y = coord.Last();
        }
        public Coordinate(int _x, int _y)
        {
            this.X = _x;
            this.Y = _y;
        }
        public Coordinate(Coordinate _coordinate)
        {
            this.X = _coordinate.X;
            this.Y = _coordinate.Y;
        }
        #endregion

        #region Props
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return String.Format("{0} | {1}", X, Y);
        }
        #endregion
    }
}
