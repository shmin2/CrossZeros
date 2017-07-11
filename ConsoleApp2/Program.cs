using ConsoleApp2;
using System;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field(new[,] { { 'X', '†', '†' }, { '†', '†', '†' }, { '†', '†', 'X' } });
            field.Print();
            field.SetValue(1,1,'X');
            Console.ReadLine();
        }
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
            Engine.DoTurn(this,x,y);
        }
    }
}