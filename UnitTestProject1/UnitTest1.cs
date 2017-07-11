using System;
using ConsoleApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsoleApp2.Program;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RowPositive()
        {
            Field fild = new Field(new[,] { { 'X', 'O', 'O' }, { 'X', 'O', 'O' }, { 'X', 'O', 'O' } });
            Assert.IsTrue(ConsoleApp2.Engine.DoTurn(fild, 0, 0));
        }

        [TestMethod]
        public void RowPositive2()
        {
            Field fild = new Field(new[,] { { 'X', 'X', 'O' }, { 'O', 'X', 'O' }, { 'X', 'X', 'O' } });
            Assert.IsTrue(ConsoleApp2.Engine.DoTurn(fild, 2, 2));
        }

        [TestMethod]
        public void RowNegative()
        {
            Field fild = new Field(new[,] { { 'O', 'X', 'O' }, { 'X', 'O', 'O' }, { 'X', 'O', 'O' } });
            Assert.IsFalse(ConsoleApp2.Engine.DoTurn(fild, 1, 0));
        }

        [TestMethod]
        public void ColumnPositive()
        {
            Field fild = new Field(new[,] { { 'X', 'X', 'X' }, { 'O', 'O', 'O' }, { 'O', 'O', 'O' } });
            Assert.IsTrue(ConsoleApp2.Engine.DoTurn(fild, 0, 0));
        }

        [TestMethod]
        public void ColumnPositive2()
        {
            Field fild = new Field(new[,] { { 'O', 'O', 'O' }, { 'X', 'X', 'X' }, { 'O', 'O', 'O' } });
            Assert.IsTrue(ConsoleApp2.Engine.DoTurn(fild, 1, 1));
        }

        [TestMethod]
        public void ColumnNegative()
        {
            Field fild = new Field(new[,] { { 'O', 'X', 'O' }, { 'X', 'O', 'O' }, { 'X', 'X', 'O' } });
            Assert.IsFalse(ConsoleApp2.Engine.DoTurn(fild, 0, 1));
        }

        [TestMethod]
        public void DiagonalPositive()
        {
            Field fild = new Field(new[,] { { 'X', 'O', 'O' }, { 'X', 'X', 'X' }, { 'O', 'O', 'X' } });
            Assert.IsTrue(ConsoleApp2.Engine.DoTurn(fild, 1, 1));
        }

        [TestMethod]
        public void DiagonalNegative()
        {
            Field fild = new Field(new[,] { { 'O', 'X', 'O' }, { 'X', 'O', 'O' }, { 'X', 'X', 'O' } });
            Assert.IsFalse(ConsoleApp2.Engine.DoTurn(fild, 0, 1));
        }
    }
}
