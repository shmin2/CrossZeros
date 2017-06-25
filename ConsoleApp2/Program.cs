using ConsoleApp2;
using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {

            Field fild = new Field(new[,] { { '†', '†', '†' }, { '†', '†', '†' }, { '†', '†', '†' } });
            fild.Print();
            int turn = 0;
            while (true)
            {
                WinMyGame(fild);
                //char symbol;
                //int x;
                //int y;

                //if (turn % 2 == 0)
                //{
                //    symbol = 'X';

                //}
                //else
                //{
                //    symbol = 'O';
                //}
                //Console.WriteLine($"[X,Y] - {symbol}");
                //x = int.Parse(Console.ReadKey().KeyChar.ToString());
                //y = int.Parse(Console.ReadKey().KeyChar.ToString());
                //fild.SetValue(x, y, symbol);
                //turn++;
            }
        }

        private static void WinMyGame(Field field)
        {
            field.SetValue(0, 0, 'X');
            field.SetValue(0, 1, 'X');
            field.SetValue(0, 2, 'X');
        }



        public class Field
        {
            public char[,] _field;

            private int win;

            public Field(char[,] field)
            {
                _field = field;
            }

            public void Print()
            {
                Console.Clear();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(_field[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            public void SetValue(int x, int y, char value)
            {
                _field[x, y] = value;
                this.Print();
                WinCheck(value);
            }

            public bool CheckDiagonalWin(char value)
            {
                if (_field[0, 0] == value && _field[1, 1] == value && _field[2, 2] == value)
                {
                    return doWin();
                }
                if (_field[0, 2] == value && _field[1, 1] == value && _field[2, 0] == value)
                {
                    return doWin();
                }
                return false;
            }

            public bool CheckColumnWin(char value)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_field[i, 0] == value && _field[i, 1] == value && _field[i, 2] == value)
                    {
                        return doWin();
                    }
                }
                return false;
            }

            public bool CheckRowWin(char value)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_field[0, i] == value && _field[1, i] == value && _field[2, i] == value)
                    {
                        return doWin();
                    }
                }
                return false;
            }

            public bool doWin()
            {
                Console.WriteLine("YOU WIN");
                new AI().AddSnapshot(this);
                return true;
            }

            public void WinCheck(char value)
            {
                CheckRowWin(value);
                CheckColumnWin(value);
                CheckDiagonalWin(value);
            }
        }
    }
}