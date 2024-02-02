namespace Tic_tac_toe_Pribyl
{
    public class Symbol
    {
        public List<Symbol> SymbolsColumns { get; set; }
        public List<Symbol> SymbolsRows { get; set; }
        public List<Symbol> SymbolsDiagonal { get; set; }
        public List<Symbol> SymbolsAntidiagonal { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public List<Symbol> Symbols { get; set; }
        public Character SymbolType { get; set; }

        public Symbol(int positionX, int positionY, Character character)
        {
            this.Symbols = new List<Symbol>();
            this.SymbolsColumns = new List<Symbol>();
            this.SymbolsRows = new List<Symbol>();
            this.SymbolsDiagonal = new List<Symbol>();
            this.SymbolsAntidiagonal = new List<Symbol>();
            this.SymbolType = character;
            PositionX = positionX;
            PositionY = positionY;  
        }
        public void SetSurroundedSymbols(Symbol[,] area)
        {
            for (int i = this.PositionX - 1; i <= this.PositionX + 1; i++)
            {
                for (int j = this.PositionY - 1; j <= this.PositionY + 1; j++)
                {
                    if (i >= 0 && i < area.GetLength(0) && j >= 0 && j < area.GetLength(1) 
                        && (i != this.PositionX || j != this.PositionY))
                    {
                        Symbol symbol = area[i, j];
                        if (symbol.SymbolType == this.SymbolType) this.Symbols.Add(symbol);
                    }
                }
            }
        }
        public void SetSurroundedSame()
        {
            foreach (Symbol symbol in this.Symbols)
            {
                if (symbol.PositionX == this.PositionX) 
                {
                    this.SymbolsColumns.Add(symbol);
                }
                else if (symbol.PositionY == this.PositionY)
                {
                    this.SymbolsRows.Add(symbol);
                }
                else if (Math.Abs(this.PositionX - symbol.PositionX) == Math.Abs(this.PositionY - symbol.PositionY))
                {
                    this.SymbolsDiagonal.Add(symbol);
                }
                else
                {
                    this.SymbolsAntidiagonal.Add(symbol);
                }
            }
        }
        public void SetSymbols()
        {
            List<Symbol> same_symbols_in_column = new List<Symbol>();
            foreach (Symbol symbol in this.SymbolsColumns)
            {
                foreach (Symbol item in symbol.SymbolsColumns)
                {
                    same_symbols_in_column.Add(item);
                }
                same_symbols_in_column.Add(symbol);
                same_symbols_in_column.Add(this);
                symbol.SymbolsColumns = same_symbols_in_column;
            }
            this.SymbolsColumns = same_symbols_in_column;

            List<Symbol> same_symbols_in_row = new List<Symbol>();
            foreach (Symbol symbol in this.SymbolsRows)
            {
                foreach (Symbol item in symbol.SymbolsRows)
                {
                    same_symbols_in_row.Add(item);
                }
                same_symbols_in_row.Add(symbol);
            }
            this.SymbolsRows = same_symbols_in_row;

            List<Symbol> same_symbols_in_diagonal = new List<Symbol>();
            foreach (Symbol symbol in this.SymbolsDiagonal)
            {
                foreach (Symbol item in symbol.SymbolsDiagonal)
                {
                    same_symbols_in_diagonal.Add(item);
                }
                same_symbols_in_diagonal.Add(symbol);
            }
            this.SymbolsDiagonal = same_symbols_in_diagonal;

            List<Symbol> same_symbols_in_antidiagonal = new List<Symbol>();
            foreach (Symbol symbol in this.SymbolsAntidiagonal)
            {
                foreach (Symbol item in symbol.SymbolsAntidiagonal)
                {
                    same_symbols_in_antidiagonal.Add(item);
                }
                same_symbols_in_antidiagonal.Add(symbol);
            }
            this.SymbolsAntidiagonal = same_symbols_in_antidiagonal;
        }
    }
}
