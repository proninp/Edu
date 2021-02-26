using System.Collections.Generic;
using System.Linq;

namespace CodeWars._3kyu
{
    /*
     * Battleship field validator
     * Write a method that takes a field for well-known board game "Battleship"
     * as an argument and returns true if it has a valid disposition of ships,
     * false otherwise. Argument is guaranteed to be 10*10 two-dimension array.
     * Elements in the array are numbers, 0 if the cell is free and 1 if occupied by ship.
     * Battleship (also Battleships or Sea Battle) is a guessing game for two players.
     * Each player has a 10x10 grid containing several "ships" and objective is to destroy enemy's forces
     * by targetting individual cells on his field. The ship occupies one or more cells in the grid. Size and number of ships
     * may differ from version to version. In this kata we will use Soviet/Russian version of the game.
     * Before the game begins, players set up the board and place the ships accordingly to the following rules:
            * There must be single battleship (size of 4 cells), 2 cruisers (size 3), 3 destroyers (size 2) and 4 submarines (size 1).
              Any additional ships are not allowed, as well as missing ships.
            * Each ship must be a straight line, except for submarines, which are just single cell.
            * The ship cannot overlap or be in contact with any other ship, neither by edge nor by corner.
            * This is all you need to solve this kata. If you're interested in more information about the game, 
              visit this link http://en.wikipedia.org/wiki/Battleship_(game).
     */
    public class BattleshipFieldValidator
    {
        public static bool ValidateBattlefield(int[,] field)
        {
            Stack<int[]> pool = new Stack<int[]>();
            Dictionary<int, int> d = new Dictionary<int, int>() { { 1, 4 }, { 2, 3 }, { 3, 2 }, { 4, 1 } };
            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                    if (field[i, j] == 1)
                    {
                        if (!Search(i, j, field, pool)) return false;
                        if (pool.Count > 4) return false;
                        d[pool.Count]--;
                        while (pool.Count > 0)
                        {
                            int[] el = pool.Pop();
                            field[el[0], el[1]] = 2;
                        }
                    }
            return d.Where(el => el.Value != 0).Count() == 0;
        }
        public static bool Search(int i, int j, int[,] field, Stack<int[]> pool)
        {
            if (field[i, j] == 2) return false;
            if (field[i, j] == 1)
            {
                field[i, j] = 3;
                pool.Push(new int[] { i, j });
                int[] a = new int[] { -1, 1 };
                for (int k = 0; k < a.Length; k++)
                {
                    if (i + a[k] < field.GetLength(0) && i + a[k] >= 0)
                        if (!Search(i + a[k], j, field, pool)) return false;
                    if (j + a[k] < field.GetLength(1) && j + a[k] >= 0)
                        if (!Search(i, j + a[k], field, pool)) return false;
                    for (int l = 0; l < a.Length; l++)
                        if (i + a[k] >= 0 && i + a[k] < field.GetLength(0) && j + a[l] >= 0 && j + a[l] < field.GetLength(1))
                            if (field[i + a[k], j + a[l]] == 1 || field[i + a[k], j + a[l]] == 2) return false;
                }
            }
            return true;
        }
    }
}
