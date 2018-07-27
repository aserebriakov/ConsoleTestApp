using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Fraction
    {
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("denomirator can't be zero", nameof(denominator));
            }

            if (numerator < 0 && denominator < 0)
            {
                numerator = Math.Abs(numerator);
                denominator = Math.Abs(denominator);
            }

            TryReduction(ref numerator, ref denominator);
            Numerator = numerator;
            Denominator = denominator;            
        }

        private bool TryReduction(ref int numerator, ref int denominator)
        {
            if (TryGetMaxDevider(numerator, denominator, out var maxDevider))
            {
                numerator /= maxDevider.Value;
                denominator /= maxDevider.Value;
                return true;
            }

            return false;
        }

        private bool TryGetMaxDevider(int num1, int num2, out int? maxDevider)
        {
            maxDevider = null;
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);
            int min, max;
            if (num1 > num2)
            {
                max = num1;
                min = num2;
            }
            else
            {
                max = num2;
                min = num1;
            }

            while (max != 0 && min != 0)
            {
                if (max % min > 0)
                {
                    var temp = max;
                    max = min;
                    min = temp % min;
                }
                else break;
            }

            if (min != 0 && max != 0)
            {
                maxDevider = min;
                return true;
            }

            return false;
        }

        public int Numerator { get; }

        public int Denominator { get; }
    }
    public static class FractionCalculator
    {
        public static Fraction Add(Fraction left, Fraction right)
        {
            var newDenominator = left.Denominator;
            var rightMultiplier = 1;
            var leftMultiplier = 1;

            if (left.Denominator != right.Denominator)
            {
                newDenominator = left.Denominator * right.Denominator;
                rightMultiplier = left.Denominator;
                leftMultiplier = right.Denominator;
            }

            return new Fraction(leftMultiplier * left.Numerator + rightMultiplier * right.Numerator, newDenominator);
        }

        public static Fraction Substract(Fraction left, Fraction right)
        {
            var newDenominator = left.Denominator;
            var rightMultiplier = 1;
            var leftMultiplier = 1;

            if (left.Denominator != right.Denominator)
            {
                newDenominator = left.Denominator * right.Denominator;
                rightMultiplier = left.Denominator;
                leftMultiplier = right.Denominator;
            }

            return new Fraction(leftMultiplier * left.Numerator - rightMultiplier * right.Numerator, newDenominator);
        }

        public static Fraction Multiply(Fraction left, Fraction right)
        {
            return new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
        }

        public static Fraction Devide(Fraction left, Fraction right)
        {
            if (right.Numerator == 0)
            {
                throw new DivideByZeroException("Cant devide by zero");
            }

            return new Fraction(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
        }
    }
}
