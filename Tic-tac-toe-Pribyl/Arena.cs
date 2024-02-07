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
            this.DrawNewArea();
            //for (int i = 0; i < this.Area.GetLength(1); i++)
            //{
            //    this.DrawEdge();
            //    this.DrawRow();
            //}
            //this.DrawEdge();
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
        public void DrawNewArea()
        {
            string ahoj = "┌┐─│└┘├┬┴┼┤";
            Console.Write("┌");
            for (int i = 0; i < this.Area.GetLength(1) - 1; i++)
            {
                if (i < this.Area.GetLength(1) - 2)
                {
                    Console.Write("───┬");
                }
                else
                {
                    Console.Write("───┤");
                }
            }
            Console.WriteLine("┐");

            for (int i = 0; i < this.Area.GetLength(1); i++)
            {
                for (int j = 0; j < this.Area.GetLength(0) - 1; j++)
                {
                    Console.Write("│ " + Character._ + " ");
                }
                Console.WriteLine("│");
                for (int j = 0; j < this.Area.GetLength(0) - 1; j++)
                {
                    if (j < this.Area.GetLength(0) - 2)
                    {
                        Console.Write("├──┼");
                    }
                    else
                    {
                        Console.Write("──");

                    }
                }
                Console.WriteLine();
            }

            Console.Write("└");
            for (int i = 0; i < this.Area.GetLength(1) - 1; i++)
            {
                if (i < this.Area.GetLength(1) - 2)
                {
                    Console.Write("───┴");
                }
                else
                {
                    Console.Write("───");
                }
            }
            Console.WriteLine("┘");
        }
    }
}
