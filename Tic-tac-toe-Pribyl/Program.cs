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

            Console.Write("Singleplayer[S]/Multiplayer[M]");
            string str = "";
            do
            {
                str = Console.ReadLine();
            }
            while (str != "S" && str != "M");

            bool npc = false;
            if (str == "M")
            {
                npc = true;
            }

            Console.Clear();
            Game game = new Game(side_length, npc);

            bool game_finished = false;
            while (true)
            {
                game.DrawMove();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                game.HandleKey(keyInfo.Key);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    if (game.CheckArea())
                    {
                        game_finished = true;
                        break;
                    }
                }
            }
            if (game_finished)
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
