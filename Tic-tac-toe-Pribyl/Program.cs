using System.Numerics;

namespace Tic_tac_toe_Pribyl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Console.Write("Side length of the area: ");
            int side_length;
            while (true)
            {
                try
                {
                    side_length = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Must be a number");
                }
            }
            Console.WriteLine();

            Console.Clear();
            Game game = new Game(side_length);

            while (true)
            {
                game.DrawMove();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                game.HandleKey(keyInfo.Key);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (game.GameFinished)
                {
                    break;
                }
            }
            if (game.GameFinished)
            {
                string player;
                if (game.Player)
                {
                    player = "Player2(O)";
                }
                else
                {
                    player = "Player1(X)";
                }
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Winner: " + player);
                Console.ReadLine();
            }
        }
    }
}
