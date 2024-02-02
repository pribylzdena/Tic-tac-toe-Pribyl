using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe_Pribyl
{
    public class Symbol
    {
        public List<Symbol> SymbolsRow { get; set; }
        public List<Symbol> SymbolsColumn { get; set; }
        public List<Symbol> SymbolsDiagonal { get; set; }
        public List<Symbol> SymbolsAntidiagonal { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public List<Symbol> Symbols { get; set; }
        public Character SymbolType { get; set; }

        public Symbol(int positionX, int positionY, Character character)
        {
            this.Symbols = new List<Symbol>();
            this.SymbolsRow = new List<Symbol>();
            this.SymbolsColumn = new List<Symbol>();
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
                    this.SymbolsRow.Add(symbol);
                }
                else if (symbol.PositionY == this.PositionY)
                {
                    this.SymbolsColumn.Add(symbol);
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
            List<Symbol> same_symbols_in_direction = new List<Symbol>();
            foreach (Symbol symbol in this.SymbolsRow)
            {
                foreach (Symbol item in symbol.SymbolsRow)
                {
                    same_symbols_in_direction.Add(item);
                }
            }
            this.SymbolsRow = same_symbols_in_direction;

            same_symbols_in_direction.Clear();
            foreach (Symbol symbol in this.SymbolsColumn)
            {
                foreach (Symbol item in symbol.SymbolsColumn)
                {
                    same_symbols_in_direction.Add(item);
                }
            }
            this.SymbolsColumn = same_symbols_in_direction;

            same_symbols_in_direction.Clear();
            foreach (Symbol symbol in this.SymbolsDiagonal)
            {
                foreach (Symbol item in symbol.SymbolsDiagonal)
                {
                    same_symbols_in_direction.Add(item);
                }
            }
            this.SymbolsDiagonal = same_symbols_in_direction;

            same_symbols_in_direction.Clear();
            foreach (Symbol symbol in this.SymbolsAntidiagonal)
            {
                foreach (Symbol item in symbol.SymbolsAntidiagonal)
                {
                    same_symbols_in_direction.Add(item);
                }
            }
            this.SymbolsAntidiagonal = same_symbols_in_direction;
        }
    }
}
