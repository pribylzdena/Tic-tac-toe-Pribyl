namespace Tic_tac_toe_Pribyl
{
    public class Game
    {
        public Arena CurrentArena { get; set; }
        public Symbol[,] Area { get; set; }
        public int GameWidth { get; set; }
        public int GameHight { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int PreviousX { get; set; }
        public int PreviousY { get; set; }
        public int Goal { get; set; }
        public bool GameFinished { get; set; }
        public bool Player { get; set; }
        private const int moveY = 2;
        private const int moveX = 4;
        public Character Char { get; set; }

        public Game(int x)
        {
            this.CurrentArena = new Arena(x, x);
            this.CurrentArena.DrawArea();
            this.Area = new Symbol[x, x];
            this.GameWidth = x * moveX + 1;
            this.GameHight = x * moveY + 1;
            this.PositionX = 2;
            this.PositionY = 1;
            this.PreviousX = 0;
            this.PreviousY = 0;
            this.Player = true;
            this.GameFinished = false;
            if (x >= 5) this.Goal = 5;
            else this.Goal = x;
            this.SetArea();
        }

        public void DrawMove()
        {
            this.DrawCurrentPlayer();
            if (this.PreviousY != 0 || this.PreviousX != 0)
            {
                Console.SetCursorPosition(this.PreviousX, this.PreviousY);
                Symbol sym = this.GetSymbol(this.PreviousX, this.PreviousY);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sym.SymbolType);
                Console.ResetColor();
            }
            Console.SetCursorPosition(this.PositionX, this.PositionY);
            Symbol symbol = this.GetSymbol(this.PositionX, this.PositionY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(symbol.SymbolType);
            Console.ResetColor();
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
            {
                this.Move(Direction.Up);
            }
            if (key == ConsoleKey.DownArrow)
            {
                this.Move(Direction.Down);
            }
            if (key == ConsoleKey.LeftArrow)
            {
                this.Move(Direction.Left);
            }
            if (key == ConsoleKey.RightArrow)
            {
                this.Move(Direction.Right);
            }
            if (key == ConsoleKey.Spacebar)
            {
                this.Play();
            }
            if (key == ConsoleKey.Escape)
            {
                return;
            }
        }
        public void Move(Direction direction)
        {
            this.PreviousX = this.PositionX;
            this.PreviousY = this.PositionY;

            if (direction == Direction.Up && this.PositionY - moveY > 0)
            {
                this.PositionY -= moveY;
            }
            if (direction == Direction.Down && this.PositionY + moveY < GameHight)
            {
                this.PositionY += moveY;
            }
            if (direction == Direction.Left && this.PositionX - moveX > 1)
            {
                this.PositionX -= moveX;
            }
            if (direction == Direction.Right && this.PositionX + moveX < GameWidth)
            {
                this.PositionX += moveX;
            }
            this.DrawMove();
        }
        public void SetArea()
        {
            for (int i = 0; i < this.Area.GetLength(0); i++)
            {
                for (int j = 0; j < this.Area.GetLength(1); j++)
                {
                    this.Area[i, j] = new Symbol(i, j, Character._);
                }
            }
        }
        public Symbol GetSymbol(int x, int y)
        {
            int new_x = this.ToAreaX(x);
            int new_y = this.ToAreaY(y);
            return this.Area[new_x, new_y];
        }
        public int ToAreaX(int x)
        {
            return (x - 2) / moveX;
        }
        public int ToAreaY(int y)
        {
            return y / moveY;
        }
        public Symbol SetCurrentChar(int x, int y)
        {
            int new_x = this.ToAreaX(x);
            int new_y = this.ToAreaY(y);
            Symbol newSymbol = new Symbol(new_x, new_y, this.Char);
            this.Area[new_x, new_y] = newSymbol;
            newSymbol.SetSurroundedSymbols(this.Area);
            newSymbol.SetSurroundedSame();
            newSymbol.SetSymbols();
            return newSymbol;
        }
        public void SwitchPlayer()
        {
            if (this.Player)
            {
                this.Player = false;
                this.Char = Character.O;
            }
            else
            {
                this.Player = true;
                this.Char = Character.X;
            }
        }
        public void Play()
        {
            Symbol symbol = this.GetSymbol(this.PositionX, this.PositionY);
            if (symbol.SymbolType != Character.X && symbol.SymbolType != Character.O)
            {
                Symbol newSymbol = this.SetCurrentChar(this.PositionX, this.PositionY);
                this.SwitchPlayer();
                this.GameFinished = this.CheckWin(newSymbol);
                Console.SetCursorPosition(50, 10);
                Console.Write(newSymbol.SymbolsRows.Count);
            }
        }
        public void DrawCurrentPlayer()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.ForegroundColor = ConsoleColor.Blue;
            if (this.Player)
            {
                Console.Write("Player1");
            }
            else
            {
                Console.Write("Player2");
            }
            Console.ResetColor();
        }
        public bool CheckWin(Symbol symbol)
        {
            return (symbol.SymbolsColumns.Count >= this.Goal || symbol.SymbolsRows.Count >= this.Goal
                || symbol.SymbolsDiagonals.Count >= this.Goal || symbol.SymbolsAntidiagonals.Count >= this.Goal);
        }
        //    public bool CheckRows()
        //    {
        //        for (int i = 0; i < this.Area.GetLength(0); i++)
        //        {
        //            int rep = 1;
        //            Character prev_character = Character._;
        //            for (int j = 0; j < this.Area.GetLength(1); j++)
        //            {
        //                Character character = this.Area[i, j];
        //                if (character == Character._)
        //                {
        //                    rep = 1;
        //                    continue;
        //                }
        //                if (character == prev_character)
        //                {
        //                    rep += 1;
        //                }
        //                else
        //                {
        //                    rep = 1;
        //                }
        //                if (rep >= this.Goal)
        //                {
        //                    return true;
        //                }
        //                prev_character = character;

        //            }
        //        }
        //        return false;
        //    }
        //    public bool CheckColumns()
        //    {
        //        for (int i = 0; i < this.Area.GetLength(1); i++)
        //        {
        //            int rep = 1;
        //            Character prev_character = Character._;
        //            for (int j = 0; j < this.Area.GetLength(0); j++)
        //            {
        //                Character character = this.Area[j, i];
        //                if (character == Character._)
        //                {
        //                    rep = 1;
        //                    continue;
        //                }
        //                if (character == prev_character)
        //                {
        //                    rep += 1;
        //                }
        //                else
        //                {
        //                    rep = 1;
        //                }
        //                if (rep >= this.Goal)
        //                {
        //                    return true;
        //                }
        //                prev_character = character;

        //            }
        //        }
        //        return false;
        //    }
        //    public bool CheckDiagonal()
        //    {


        //        int x;
        //        for (int i = 0; i < this.Area.GetLength(0); i++)
        //        {
        //            int rep = 1;
        //            Character prev_character = Character._;

        //            x = 1;
        //            for (int j = 0; x > 0; j++)
        //            {
        //                x = i - j;
        //                Character character = this.Area[x, j];
        //                if (character == Character._)
        //                {
        //                    rep = 1;
        //                    continue;
        //                }
        //                if (character == prev_character)
        //                {
        //                    rep += 1;
        //                }
        //                else
        //                {
        //                    rep = 1;
        //                }
        //                if (rep >= this.Goal)
        //                {
        //                    return true;
        //                }
        //                prev_character = character;
        //            }
        //        }
        //        for (int i = 0; i < this.Area.GetLength(1); i++)
        //        {
        //            x = i;
        //            int rep = 1;
        //            Character prev_character = Character._;
        //            for (int j = this.Area.GetLength(0) - 1; j >= 0; j--)
        //            {
        //                if (i < this.Area.GetLength(1) && x < this.Area.GetLength(0))
        //                {
        //                    Character character = this.Area[j, x];
        //                    if (character == Character._)
        //                    {
        //                        rep = 1;
        //                        continue;
        //                    }
        //                    if (character == prev_character)
        //                    {
        //                        rep += 1;
        //                    }
        //                    else
        //                    {
        //                        rep = 1;
        //                    }
        //                    if (rep >= this.Goal)
        //                    {
        //                        return true;
        //                    }
        //                    prev_character = character;
        //                }
        //                x++;
        //            }
        //        }

        //        for (int i = 0; i <= this.Area.GetLength(1) - 1; i++)
        //        {
        //            x = i;
        //            int rep = 1;
        //            Character prev_character = Character._;
        //            for (int j = this.Area.GetLength(0) - 1; x >= 0 && j >= 0; j--)
        //            {
        //                Character character = this.Area[j, x];
        //                if (character == Character._)
        //                {
        //                    rep = 1;
        //                    continue;
        //                }
        //                if (character == prev_character)
        //                {
        //                    rep += 1;
        //                }
        //                else
        //                {
        //                    rep = 1;
        //                }
        //                if (rep >= this.Goal)
        //                {
        //                    return true;
        //                }
        //                prev_character = character;
        //                x--;
        //            }
        //        }
        //        return false;
        //    }
    }
}
