using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TeamBattleField2
{
    public interface IMine
    {
        int XCoord { get; set; }

        int YCoord { get; set; }

        bool PrevIsValid(int coord);

        bool NextIsValid(int coord, int size);

        string[,] Detonate(int currentFieldSize, string[,] fieldPositions);
    }
}
