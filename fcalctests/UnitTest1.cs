using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using fCalc;

namespace fCalc.tests
{
    public class CalculationsModuleTests
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
            var testOperation = fCalc.calculations.Calculation.Addition;
            //act
            var result = fCalc.calculations.Calculate(a, b, testOperation);
            //assert
            Assert.AreEqual(11, result);
        }
        
        [Test]
        public void SubstractionTest()
        {
            //arrange
            int a = 10;
            int b = 3; 
            var testOperation = fCalc.calculations.Calculation.Substraction;
            //act
            var result = fCalc.calculations.Calculate(a, b, testOperation);
            //assert
            Assert.AreEqual(7, result);
        }
        
        [Test]
        public void DivisionTest()
        {
            //arrange
            int a = 10;
            int b = 2; 
            var testOperation = fCalc.calculations.Calculation.Division;
            //act
            var result = fCalc.calculations.Calculate(a, b, testOperation);
            //assert
            Assert.AreEqual(5, result);
        }
        
        [Test]
        public void DivisionZeroTest()
        {
            //arrange
            int a = 8;
            int b = 0;
            var testOperation = fCalc.calculations.Calculation.Division;
            Assert.Throws<fCalc.calculations.CanNotDivideByZero>((() =>
                fCalc.calculations.Calculate(a, b, testOperation)));
        }

        [Test]
        public void MultiplyTest()
        {
            //arrange
            int a = 5;
            int b = 3;
            var testOperation = fCalc.calculations.Calculation.Multiply;
            //act
            var result = fCalc.calculations.Calculate(a, b, testOperation);
            //assert
            Assert.AreEqual(15, result);
        }
        
        [Test]
        public void GetAdditionTest()
        {
            //arrange
            //act
            var testOperator = fCalc.calculations.GetOperator("+");
            //assert
            Assert.AreEqual(fCalc.calculations.Calculation.Addition, testOperator);
        }

        [Test]
        public void GetSubstractionTest()
        {
            //arrange
            //act
            var testOperator = fCalc.calculations.GetOperator("-");
            //assert
            Assert.AreEqual(fCalc.calculations.Calculation.Substraction, testOperator);
        }

        [Test]
        public void GetDivisionTets()
        {
            //arrange
            //act
            var testOperator = fCalc.calculations.GetOperator("/");
            //assert
            Assert.AreEqual(fCalc.calculations.Calculation.Division, testOperator);
        }

        [Test]
        public void GetMultiplyTets()
        {
            //arrange
            //act
            var testOperator = fCalc.calculations.GetOperator("*");
            //assert
            Assert.AreEqual(fCalc.calculations.Calculation.Multiply, testOperator);
        }

        [Test]
        public void NotAnOperatorExceptionTest()
        {
            //arrange
            var operationArgument = ":";
            //act
            //assert
            Assert.Throws<fCalc.calculations.NotAnOperatorException>((() => fCalc.calculations.GetOperator(operationArgument)));
        }
    }
    public class ParserModuleTests
    {

        [Test]
        public void NotEnoughArgsTest()
        {
            //arrange
            string[] args = new[] {"2"};
            //act
            //assert
            Assert.Throws<fCalc.parser.NotEnoughArguments>((() => fCalc.parser.IsArgsEnough(args)));
        }
        
        [Test]
        public void IsArgsEnoughTest()
        {
            //arrange
            string[] args = new[] {"2", "+", "4"};
            //act
            var result = fCalc.parser.IsArgsEnough(args);
            //assert
            Assert.True(result);
        }

        [Test]
        public void IsIntTest()
        {
            //arrange
            var argument = "3";
            //act
            var result = fCalc.parser.IsInt(argument);
            //assert
            Assert.True(result);
        }

        [Test]
        public void IsArgsIntTest()
        {
            //arrange
            string[] args = new[] {"2", "+", "5"};
            //act
            var result = fCalc.parser.IsArgsInt(args[0], args[2]);
            //assert
            Assert.True(result);
        }
    }
}