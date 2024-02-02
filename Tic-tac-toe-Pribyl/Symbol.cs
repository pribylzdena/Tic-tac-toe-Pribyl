namespace Tic_tac_toe_Pribyl
{
    public class Symbol
    {
        public List<Symbol> SymbolsColumns { get; set; }
        public List<Symbol> SymbolsRows { get; set; }
        public List<Symbol> SymbolsDiagonals { get; set; }
        public List<Symbol> SymbolsAntidiagonals { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public List<Symbol> Symbols { get; set; }
        public Character SymbolType { get; set; }

        public Symbol(int positionX, int positionY, Character character)
        {
            this.Symbols = new List<Symbol>();
            this.SymbolsColumns = new List<Symbol>();
            this.SymbolsRows = new List<Symbol>();
            this.SymbolsDiagonals = new List<Symbol>();
            this.SymbolsAntidiagonals = new List<Symbol>();
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
                else if (this.PositionX - symbol.PositionX == this.PositionY - symbol.PositionY)
                {
                    this.SymbolsDiagonals.Add(symbol);
                }
                else
                {
                    this.SymbolsAntidiagonals.Add(symbol);
                }
            }
        }
        public void SetSymbols()
        {
            this.SetSymbolsInColumns();

            List<Symbol> same_symbols_in_row = new List<Symbol> { this };
            foreach (Symbol symbol in this.SymbolsRows)
            {
                foreach (Symbol item in symbol.SymbolsRows)
                {
                    same_symbols_in_row.Add(item);
                }
                symbol.SymbolsRows = same_symbols_in_row;
            }
            this.SymbolsRows = same_symbols_in_row;

            List<Symbol> same_symbols_in_diagonal = new List<Symbol> { this };
            foreach (Symbol symbol in this.SymbolsDiagonals)
            {
                foreach (Symbol item in symbol.SymbolsDiagonals)
                {
                    same_symbols_in_diagonal.Add(item);
                }
                symbol.SymbolsDiagonals = same_symbols_in_diagonal;
            }
            this.SymbolsDiagonals = same_symbols_in_diagonal;

            List<Symbol> same_symbols_in_antidiagonal = new List<Symbol> { this };
            foreach (Symbol symbol in this.SymbolsAntidiagonals)
            {
                foreach (Symbol item in symbol.SymbolsAntidiagonals)
                {
                    same_symbols_in_antidiagonal.Add(item);
                }
                symbol.SymbolsAntidiagonals = same_symbols_in_antidiagonal;
            }
            this.SymbolsAntidiagonals = same_symbols_in_antidiagonal;
        }
        public void SetSymbolsInColumns()
        {
            List<Symbol> same_symbols_in_column = new List<Symbol>();
            foreach (Symbol symbol in this.SymbolsColumns)
            {   
                symbol.SetSymbolsInColumns();
            }
            this.SymbolsColumns = same_symbols_in_column;
        }
    }
    //foreach (Symbol item in symbol.SymbolsColumns)
    //{
    //    same_symbols_in_column.Add(item);
    //}
    //symbol.SymbolsColumns = same_symbols_in_column;
}
