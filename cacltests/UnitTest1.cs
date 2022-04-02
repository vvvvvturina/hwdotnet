using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace calculator.Tests
{
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AdditionTest()
        {
            //arrange
            int a = 4;
            int b = 7;
            var testOperation = Calculator.operation.Addition;
            //act
            var result = Calculator.Calculate(a, b, testOperation);
            //assert
            Assert.AreEqual(11, result);
        }

        [ExcludeFromCodeCoverage]
        [Test]
        public void DivisionTest()
        {
            //arrange
            int a = 8;
            int b = 2;
            var testOperation = Calculator.operation.Division;
            //act
            var result = Calculator.Calculate(a, b, testOperation);
            //assert
            Assert.AreEqual(4, result);
        }

        [ExcludeFromCodeCoverage]
        [Test]
        public void DivisionZeroTest()
        {
            //arrange
            int a = 8;
            int b = 0;
            var testOperation = Calculator.operation.Division;
            //act
            try
            {
                Calculator.Calculate(a, b, testOperation);
            }
            //assert
            catch (Exception e)
            {
                Assert.AreEqual(Calculator.CanNotDivideByZero, e);
            }
        }

        [Test]
        public void SubstractionTest()
        {
            //arrange
            int a = 8;
            int b = 2;
            var operationTest = Calculator.operation.Substraction;
            //act
            var result = Calculator.Calculate(a, b, operationTest);
            //assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void MultiplicationTest()
        {
            //arrange
            int a = 8;
            int b = 2;
            var testOperation = Calculator.operation.Multiply;
            //act
            var result = Calculator.Calculate(a,b,testOperation);
            //assert
            Assert.AreEqual(16, result);
        }

        [ExcludeFromCodeCoverage]
        [Test]
        public void NotAnOperatorExeptionTest()
        {
            //arrange
            int a = 3;
            int b = 5;
            var oper = Calculator.GetOperator(":");
            var operationType = Calculator.operation.NotOperator;
            //act
            try
            {
                Calculator.Calculate(a, b, operationType);
            }
            //assert
            catch (Exception e)
            {
                Assert.AreEqual(Calculator.NotAnOperatorException, e);
            }
        }

        [Test]
        public void GetAdditionTest()
        {
            //arrange
            string argument = "+";
            //act
            Calculator.operation testOperator = Calculator.GetOperator("+");
            //assert
            Assert.AreEqual(Calculator.operation.Addition, testOperator);
        }

        [Test]
        public void GetSubstractionTest()
        {
            //arrange
            //act
            Calculator.operation testOperator = Calculator.GetOperator("-");
            //assert
            Assert.AreEqual(Calculator.operation.Substraction, testOperator);
        }

        [Test]
        public void GetDivisionTets()
        {
            //arrange
            //act
            Calculator.operation testOperator = Calculator.GetOperator("/");
            //assert
            Assert.AreEqual(Calculator.operation.Division, testOperator);
        }

        [Test]
        public void GetMultiplicationTest()
        {
            //arrange
            //act
            Calculator.operation testOperator = Calculator.GetOperator("*");
            //assert
            Assert.AreEqual(Calculator.operation.Multiply, testOperator);
        }
    }

    [ExcludeFromCodeCoverage]
    public class ParserTests
    {
        [Test]
        public void CheckIfArgIsIntegerTest()
        {
            //arrange
            string input = "17";
            //act
            bool checkResult = Parser.CheckIfArgIsInteger(input);
            //assert
            Assert.AreEqual(true, checkResult);
        }

        [Test]
        public void CheckArgsLengthTest()
        {
            //arrange
            string[] arguments = {"5", "*", "4"};
            //act
            try
            {
                Parser.CheckArgsLength(arguments);
            }
            //assert
            catch (Exception e)
            {
                Assert.AreEqual(Parser.NotEnoughArguments, e);
            }
        }

        [Test]
        public void CheckIfArgsIsCorrectTest()
        {
            //arrange
            string[] arguments = {"4", "/", "5"};
            //act
            try
            {
                Parser.CheckIfArgsIsCorrect(arguments);
            }
            catch (Exception e)
            {
                Assert.AreEqual(Parser.SomeArgsAreNotInteger, e);
            }
        }
    }

    public class ProgramTests
    {
        [Test]
        public void ProgramMainTest()
        {
            //arrange
            string[] args = new string[] {"5", "+", "7"};
            Calculator.operation oper;
            double result;
            //act
            Parser.CheckArgsLength(args);
            Parser.CheckIfArgsIsCorrect(args);
            oper = Calculator.GetOperator(args[1]);
            result = Calculator.Calculate(int.Parse(args[0]), int.Parse(args[2]), oper);
            //assert
            Assert.AreEqual(12, result);
        }
    }
}