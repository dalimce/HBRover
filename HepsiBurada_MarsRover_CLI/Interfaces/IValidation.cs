using HepsiBurada_MarsRover_CLI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada_MarsRover_CLI.Interfaces
{
    interface IValidator
    {
        bool Validate(Coordinate coordinate);
        bool Validate(Grid coordinate);
        string GetLastestError();
    }
}
