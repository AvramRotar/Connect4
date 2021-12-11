using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4New
{
    class Rules
    {
        public static bool ValidColumn(List<List<Cell>> grid, int column)
        {
            int line = 0;
            if (grid[column][line].State == 0)
                return true;
            else
                return false;
        }
        public static bool MainDiagonalWin(List<List<Cell>> grid, Cell cell)
        {
            for (int lineIndex = cell.LineIndex - 3, columnIndex = cell.ColumnIndex - 3; lineIndex < cell.LineIndex + 3 && columnIndex < cell.ColumnIndex + 3; lineIndex++, columnIndex++)
            {
                if (lineIndex >= 0 && lineIndex < grid[0].Count && columnIndex >= 0 && columnIndex < grid.Count)
                {
                    int sum = 0;
                    for (int index = 0; index < 4 && (lineIndex + index < grid[0].Count) && (columnIndex + index < grid.Count); index++)
                        sum += grid[columnIndex + index][lineIndex + index].State;
                    if (sum == 4 * cell.State)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool SecondaryDiagonalWin(List<List<Cell>> grid, Cell cell)
        {
            for (int lineIndex = cell.LineIndex + 3, columnIndex = cell.ColumnIndex - 3; lineIndex > cell.LineIndex - 3 && columnIndex < cell.ColumnIndex + 3; lineIndex--, columnIndex++)
            {
                if (lineIndex >= 0 && lineIndex < grid[0].Count && columnIndex >= 0 && columnIndex < grid.Count)
                {
                    int sum = 0;
                    for (int index = 0; index < 4 && (lineIndex - index < grid[0].Count) && (columnIndex + index < grid.Count) && (lineIndex - index >= 0); index++)
                        sum += grid[columnIndex + index][lineIndex - index].State;
                    if (sum == 4 * cell.State)
                    {

                        return true;
                    }
                }
            }
            return false;
        }
        public static bool LineWin(List<List<Cell>> grid, Cell cell)
        {
            for (int columnIndex = cell.ColumnIndex - 3; columnIndex < cell.ColumnIndex + 3; columnIndex++)
            {
                if (columnIndex >= 0 && columnIndex < grid.Count)
                {
                    int sum = 0;
                    for (int index = 0; index < 4 && (columnIndex + index < grid.Count); index++)
                        sum += grid[columnIndex + index][cell.LineIndex].State;
                    if (sum == 4 * cell.State)
                    {
                        return true;
                    }
                }
            } return false;
        }
        public static bool ColumnWin(List<List<Cell>> grid, Cell cell)
        {
            for (int lineIndex = cell.LineIndex - 3; lineIndex < cell.LineIndex + 3; lineIndex++)
            {
                if (lineIndex >= 0 && lineIndex < grid[0].Count)
                {
                    int sum = 0;
                    for (int index = 0; index < 4 && (lineIndex + index < grid[0].Count); index++)
                        sum += grid[cell.ColumnIndex][lineIndex + index].State;
                    if (sum == 4 * cell.State)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool Draw(List<List<Cell>> grid)
        {
            for (int columnIndex = 0; columnIndex < grid.Count; columnIndex++)
                if (grid[columnIndex][0].State == 0)
                    return false;
            return true;
        }
    }
}
