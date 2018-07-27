using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApp2.Tests
{
    public class FractionTests
    {
        [Fact]
        public void DenominatorCannotBeZero()
        {
            Assert.Throws<ArgumentException>("denominator", () => new Fraction(5, 0));
        }

        [Fact]
        public void CtorTest()
        {
            //Act
            var target = new Fraction(5, 7);

            //Assert
            Assert.Equal(5, target.Numerator);
            Assert.Equal(7, target.Denominator);
        }

        [Theory]
        [InlineData(25,5,5,1)]
        [InlineData(4, 16, 1, 4)]
        [InlineData(4, 6, 2, 3)]
        [InlineData(6, 4, 3, 2)]
        [InlineData(6, -4, 3, -2)]
        [InlineData(-6, 4, -3, 2)]
        public void ReductionTest(int num, int den, int newNum, int newDen)
        {
            //Act
            var target = new Fraction(num, den);

            //Assert
            Assert.Equal(newNum, target.Numerator);
            Assert.Equal(newDen, target.Denominator);
        }

        [Fact]
        public void InsertItemToMiddle()
        {
            //Arrange
            int valueToInsert = 6;
            var list = new SortedLinkedList();
            list.Add(5);
            list.Add(7);

            //Act
            list.Add(valueToInsert);

            //Assert
            CheckSorting(list);
        }

        [Fact]
        public void InsertItemToBegin()
        {
            //Arrange
            int valueToInsert = 1;
            var list = new SortedLinkedList();
            list.Add(5);
            list.Add(7);

            //Act
            list.Add(valueToInsert);

            //Assert
            CheckSorting(list);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(10)]
        public void InsertMultipleItemsToList(int count)
        {
            //Arrange
            var list = new SortedLinkedList();

            //Act
            for(int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            //Assert
            Assert.Equal(count, GetLength(list));
        }

        public void InsertTheSameValueTwiceToList()
        {
            //Arrange
            var list = new SortedLinkedList();
            list.Add(2);

            //Act
            list.Add(2);
            list.Add(2);

            //Assert
            Assert.Equal(3, GetLength(list));
            CheckSorting(list);
        }

        private void CheckSorting(SortedLinkedList list)
        {
            var current = list.Head;
            int index = 0;
            do
            {
                Assert.True(current.Next == null || current.Value < current.Next.Value
                    , $"item at index {index} is larger than {index + 1} ({current.Value} > {current.Next?.Value})");

                index++;
                current = current.Next;

            } while (current != null);
        }

        private int GetLength(SortedLinkedList list)
        {
            var current = list.Head;
            int count = 0;
            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }
    }
}
