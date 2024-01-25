using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe_Pribyl
{
    public class NPC
    {
        public Character[,] Area { get; set; }
        public void SetArea(Character[,] area)
        {
            this.Area = area;
        }
    }
}
