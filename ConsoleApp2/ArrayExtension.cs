using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class ArrayExtension
    {
        public static bool ArrayEquals(this Char[,] source, Char[,] target)
        {
            if ((source.Rank == target.Rank && source.Length == target.Length) == false)
            {
                return false;
            }

            for (int i = 0; i < source.Rank; i++)
            {
                for (int j = 0; j < source.Length; j++)
                {
                    if (source[i, j] != target[i, j])
                        return false;
                }
            }
            return true;
        }
    }
}
