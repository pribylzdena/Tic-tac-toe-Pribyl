using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe_Pribyl
{
    public class Arena
    {
        public int[,] Area { get; set; }

        public Arena(int x, int y)
        {
            this.Area = new int[x, y];
        }
        public void DrawArea()
        {
            for (int i = 0; i < this.Area.GetLength(1); i++)
            {
                this.DrawEdge();
                this.DrawRow();
            }
            this.DrawEdge();
        }
        public void DrawEdge()
        {
            Console.Write("|");
            for (int j = 0; j < this.Area.GetLength(0); j++)
            {
                Console.Write("---|");
            }
            Console.WriteLine();
        }
        public void DrawRow()
        {
            for (int j = 0; j < this.Area.GetLength(0); j++)
            {
                Console.Write("| " + Character._ + " ");
            }
            Console.WriteLine("|");
        }
    }
}
