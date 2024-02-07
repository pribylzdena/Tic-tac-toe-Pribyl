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
            this.SymbolsColumns = new List<Symbol> { this };
            this.SymbolsRows = new List<Symbol> { this };
            this.SymbolsDiagonals = new List<Symbol> { this };
            this.SymbolsAntidiagonals = new List<Symbol> { this };
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
            this.SetSymbolsInRows();
            this.SetSymbolsInDiagonals();
            this.SetSymbolsInAntidiagonals();
        }
        public void SetSymbolsInColumns()
        {
            for (int i = 0; i < this.SymbolsColumns.Count; i++)
            {
                for (int j = 0; j < this.SymbolsColumns[i].SymbolsColumns.Count; j++)
                {
                    if (!this.SymbolsColumns.Any(o => o.PositionX == this.SymbolsColumns[i].SymbolsColumns[j].PositionX
                        && o.PositionY == this.SymbolsColumns[i].SymbolsColumns[j].PositionY))
                    {
                        this.SymbolsColumns.Add(this.SymbolsColumns[i].SymbolsColumns[j]);
                        SymbolsColumns[i].SymbolsColumns[j].SymbolsColumns = this.SymbolsColumns;
                    }
                }
            }
        }
        public void SetSymbolsInRows()
        {
            for (int i = 0; i < this.SymbolsRows.Count; i++)
            {
                for (int j = 0; j < this.SymbolsRows[i].SymbolsRows.Count; j++)
                {
                    if (!this.SymbolsRows.Any(o => o.PositionX == this.SymbolsRows[i].SymbolsRows[j].PositionX
                        && o.PositionY == this.SymbolsRows[i].SymbolsRows[j].PositionY))
                    {
                        this.SymbolsRows.Add(this.SymbolsRows[i].SymbolsRows[j]);
                    }
                    if (!this.SymbolsRows[i].SymbolsRows[j].SymbolsRows.Any(o => o.PositionX == this.SymbolsRows[i].PositionX
                        && o.PositionY == this.SymbolsRows[i].PositionY))
                    {
                        this.SymbolsRows[i].SymbolsRows[j].SymbolsRows.Add(this.SymbolsRows[i]);
                    }
                }
            }
        }
        public void SetSymbolsInDiagonals()
        {
            for (int i = 0; i < this.SymbolsDiagonals.Count; i++)
            {
                for (int j = 0; j < this.SymbolsDiagonals[i].SymbolsDiagonals.Count; j++)
                {
                    if (!this.SymbolsDiagonals.Any(o => o.PositionX == this.SymbolsDiagonals[i].SymbolsDiagonals[j].PositionX
                        && o.PositionY == this.SymbolsDiagonals[i].SymbolsDiagonals[j].PositionY))
                    {
                        this.SymbolsDiagonals.Add(this.SymbolsDiagonals[i].SymbolsDiagonals[j]);
                        SymbolsDiagonals[i].SymbolsDiagonals[j].SymbolsDiagonals = this.SymbolsDiagonals;
                    }
                    //TODO
                }
            }
        }
        public void SetSymbolsInAntidiagonals()
        {
            for (int i = 0; i < this.SymbolsAntidiagonals.Count; i++)
            {
                for (int j = 0; j < this.SymbolsAntidiagonals[i].SymbolsAntidiagonals.Count; j++)
                {
                    if (!this.SymbolsAntidiagonals.Any(o => o.PositionX == this.SymbolsAntidiagonals[i].SymbolsAntidiagonals[j].PositionX
                        && o.PositionY == this.SymbolsAntidiagonals[i].SymbolsAntidiagonals[j].PositionY))
                    {
                        this.SymbolsAntidiagonals.Add(this.SymbolsAntidiagonals[i].SymbolsAntidiagonals[j]);
                        SymbolsAntidiagonals[i].SymbolsAntidiagonals[j].SymbolsAntidiagonals = this.SymbolsAntidiagonals;
                    }
                    //TODO
                }
            }
        }

    }
}
