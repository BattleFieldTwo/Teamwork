using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BattleField2.Models.Contracts
{
    public interface IMine
    {
        int Row { get; set; }

        int Col { get; set; }

        bool PrevIsValid(int coord);

        bool NextIsValid(int coord, int size);

        string[,] Detonate(int currentFieldSize, string[,] fieldPositions);
    }
}
