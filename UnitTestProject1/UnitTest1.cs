using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsoleApp1.Program;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RowPositive()
        {
            Field fild = new Field(new[,] { { 'X', 'O', 'O' }, { 'X', 'O', 'O' }, { 'X', 'O', 'O' } });
            Assert.IsTrue(fild.CheckRowWin('X'));
        }

        [TestMethod]
        public void RowPositive2()
        {
            Field fild = new Field(new[,] { { 'X', 'X', 'O' }, { 'O', 'X', 'O' }, { 'X', 'X', 'O' } });
            Assert.IsTrue(fild.CheckRowWin('X'));
        }

        [TestMethod]
        public void RowNegative()
        {
            Field fild = new Field(new[,] { { 'O', 'X', 'O' }, { 'X', 'O', 'O' }, { 'X', 'O', 'O' } });
            Assert.IsFalse(fild.CheckRowWin('X'));
        }

        [TestMethod]
        public void ColumnPositive()
        {
            Field fild = new Field(new[,] { { 'X', 'X', 'X' }, { 'O', 'O', 'O' }, { 'O', 'O', 'O' } });
            Assert.IsTrue(fild.CheckColumnWin('X'));
        }

        [TestMethod]
        public void ColumnPositive2()
        {
            Field fild = new Field(new[,] { { 'O', 'O', 'O' }, { 'X', 'X', 'X' }, { 'O', 'O', 'O' } });
            Assert.IsTrue(fild.CheckColumnWin('X'));
        }

        [TestMethod]
        public void ColumnNegative()
        {
            Field fild = new Field(new[,] { { 'O', 'X', 'O' }, { 'X', 'O', 'O' }, { 'X', 'X', 'O' } });
            Assert.IsFalse(fild.CheckColumnWin('X'));
        }

        [TestMethod]
        public void DiagonalPositive()
        {
            Field fild = new Field(new[,] { { 'X', 'O', 'O' }, { 'X', 'X', 'X' }, { 'O', 'O', 'X' } });
            Assert.IsTrue(fild.CheckDiagonalWin('X'));
        }

        [TestMethod]
        public void DiagonalNegative()
        {
            Field fild = new Field(new[,] { { 'O', 'X', 'O' }, { 'X', 'O', 'O' }, { 'X', 'X', 'O' } });
            Assert.IsFalse(fild.CheckDiagonalWin('X'));
        }
    }
}
