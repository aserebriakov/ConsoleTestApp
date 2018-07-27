using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApp2.Tests
{
    public class FractionCalculatorTests
    {
        [Theory]
        [InlineData(1,2,3,4,5,4)]
        [InlineData(1, 2, 3, 2, 2, 1)]
        public void AddPositiveFractionsTest(int leftNum, int leftDen, int rightNum, int rightDen, int resNum, int resDen)
        {
            var left = new Fraction(leftNum, leftDen);

            var right = new Fraction(rightNum, rightDen);

            var result = FractionCalculator.Add(left, right);

            Assert.Equal(resNum, result.Numerator);
            Assert.Equal(resDen, result.Denominator);
        }

        [Theory]
        [InlineData(-1, 2, 3, 4, 1, 4)]
        [InlineData(1, 2, -3, 2, -1, 1)]
        public void AddNegativeFractionsTest(int leftNum, int leftDen, int rightNum, int rightDen, int resNum, int resDen)
        {
            var left = new Fraction(leftNum, leftDen);

            var right = new Fraction(rightNum, rightDen);

            var result = FractionCalculator.Add(left, right);

            Assert.Equal(resNum, result.Numerator);
            Assert.Equal(resDen, result.Denominator);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, -1, 4)]
        [InlineData(4, 3, 1, 2, 5, 6)]
        [InlineData(1, 2, 1, 2, 0, 2)]
        public void SubstractPositiveFractionsTest(int leftNum, int leftDen, int rightNum, int rightDen, int resNum, int resDen)
        {
            var left = new Fraction(leftNum, leftDen);

            var right = new Fraction(rightNum, rightDen);

            var result = FractionCalculator.Substract(left, right);

            Assert.Equal(resNum, result.Numerator);
            Assert.Equal(resDen, result.Denominator);
        }

        [Theory]
        [InlineData(-1, 2, 1, 2, -1, 1)]
        [InlineData(1, 2, -3, 2, 2, 1)]
        public void SubstractNegativeFractionsTest(int leftNum, int leftDen, int rightNum, int rightDen, int resNum, int resDen)
        {
            var left = new Fraction(leftNum, leftDen);

            var right = new Fraction(rightNum, rightDen);

            var result = FractionCalculator.Substract(left, right);

            Assert.Equal(resNum, result.Numerator);
            Assert.Equal(resDen, result.Denominator);
        }

        [Theory]
        [InlineData(-1, 2, 1, 2, -1, 4)]
        [InlineData(1, 2, 3, 5, 3, 10)]
        [InlineData(2, 3, 3, 2, 1, 1)]
        public void MultiplyFractionsTest(int leftNum, int leftDen, int rightNum, int rightDen, int resNum, int resDen)
        {
            var left = new Fraction(leftNum, leftDen);

            var right = new Fraction(rightNum, rightDen);

            var result = FractionCalculator.Multiply(left, right);

            Assert.Equal(resNum, result.Numerator);
            Assert.Equal(resDen, result.Denominator);
        }

        [Theory]
        [InlineData(4, 1, 1, 4, 16, 1)]
        [InlineData(1, 4, 1, 4, 1, 1)]
        public void DevideFractionsTest(int leftNum, int leftDen, int rightNum, int rightDen, int resNum, int resDen)
        {
            var left = new Fraction(leftNum, leftDen);

            var right = new Fraction(rightNum, rightDen);

            var result = FractionCalculator.Devide(left, right);

            Assert.Equal(resNum, result.Numerator);
            Assert.Equal(resDen, result.Denominator);
        }

        [Fact]
        public void DevideFractionsThrowDevideByZeroExceptionTest()
        {
            var left = new Fraction(1, 2);

            var right = new Fraction(0, 3);

            Assert.Throws<DivideByZeroException>(() => FractionCalculator.Devide(left, right));
        }
    }
}
