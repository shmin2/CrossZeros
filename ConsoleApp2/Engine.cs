using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Engine
    {
        private static char currentSymbol;

        private static readonly char[] symbols = { 'X', 'O' };

        private static readonly IEnumerator enumerator = symbols.GetEnumerator();

        private const int WinRowLengt = 2;

        /// <summary>
        /// Do turn
        /// </summary>
        /// <param name="field"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void DoTurn(Field field, int x, int y)
        {
            try
            {
                enumerator.MoveNext();
                currentSymbol = (char)enumerator.Current;
            }
            catch (Exception)
            {
                enumerator.Reset();
                enumerator.MoveNext();
                currentSymbol = (char)enumerator.Current;
            }

            if (CheckFieldForWin(field, x, y))
            {
                Win(field);
            }
        }

        /// <summary>
        /// Check field for win
        /// </summary>
        /// <param name="field"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="vectorX"></param>
        /// <param name="vectrorY"></param>
        /// <param name="rowLenght"></param>
        public static bool CheckFieldForWin(Field field, int x, int y, int vectorX = 0, int vectrorY = 0, int rowLenght = 1)
        {
            for (int j = -1; j < 2; j++)
            {
                for (int i = -1; i < 2; i++)
                {
                    try
                    {
                        if (field._field[x + i, y + j] == currentSymbol && x + i != x && y + j != y)
                        {
                            if (CheckFront(field, x, y, i, j) + CheckReverse(field, x, y, i, j) >= WinRowLengt)
                            {
                                return true;
                            }
                        }
                    }
                    catch (IndexOutOfRangeException){}
                }
            }
            return false;
        }

        /// <summary>
        /// Get lenght row in normal vector
        /// </summary>
        /// <param name="field"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="vectorX"></param>
        /// <param name="vectrorY"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private static int CheckFront(Field field, int x, int y, int vectorX = 0, int vectrorY = 0, int amount = 0)
        {
            try
            {
                x += vectorX;
                y += vectrorY;
                if (field._field[x, y] == currentSymbol)
                {
                    amount++;
                    amount += CheckFront(field, x, y, vectorX, vectrorY);
                }
                return amount;
            }
            catch (IndexOutOfRangeException)
            {
                return amount;
            }
        }

        /// <summary>
        /// Get lenght row in reverse vector
        /// </summary>
        /// <param name="field"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="vectorX"></param>
        /// <param name="vectrorY"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private static int CheckReverse(Field field, int x, int y, int vectorX = 0, int vectrorY = 0, int amount = 0)
        {
            try
            {
                x += vectorX * -1;
                y += vectrorY * -1;
                if (field._field[x, y] == currentSymbol)
                {
                    amount++;
                    amount += CheckReverse(field, x, y, vectorX, vectrorY);
                }
                return amount;
            }
            catch (IndexOutOfRangeException)
            {
                return amount;
            }
        }

        /// <summary>
        /// Win game message
        /// </summary>
        private static void Win(Field field)
        {
            Console.WriteLine("YOU WIN");
            new AI().AddSnapshot(field);
        }
    }
}
