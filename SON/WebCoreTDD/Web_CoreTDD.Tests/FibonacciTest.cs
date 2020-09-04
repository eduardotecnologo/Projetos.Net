using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_CoreTDD.Tests
{
    [TestClass]
    public class FibonacciTest
    {
        // Posição 0 1 2 3 4 5 6  7  8  9  10 ... 
        // Número  0 1 1 2 3 5 8 13 21 34  55 ...
        [TestMethod]
        public void PrimeiroElementoDeveSerZero()
        {
            var resultado = Fibonacci.ObterElemento(0);
            Assert.AreEqual(resultado, 0, "O valor não é zero.");
        }

        [TestMethod]
        public void SegundoElementoDeveSerZero()
        {
            var resultado = Fibonacci.ObterElemento(1);
            Assert.AreEqual(resultado, 1, "O valor não é um.");
        }


    }
    public class Fibonacci
    {
        public static int ObterElemento(int posicao)
        {
            if (posicao == 0) return 0;
            return 1;
        }
    }
}
