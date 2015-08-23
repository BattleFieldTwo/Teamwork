using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamBattleField2
{
    internal class MineFactory
    {
        internal static IMine GetMine(int type, int x, int y)
        {
            IMine currentMine = null;
            switch (type)
            {
                case 1:
                    currentMine = new MineOne(x, y);
                    break;
                case 2:
                    currentMine = new MineTwo(x, y);
                    break;
                case 3:
                    currentMine = new MineThree(x, y);
                    break;
                case 4:
                    currentMine = new MineFour(x, y);
                    break;
                case 5:
                    currentMine = new MineFive(x, y);
                    break;
                default:
                    break;
            }
            return currentMine;
        }
    }
}
