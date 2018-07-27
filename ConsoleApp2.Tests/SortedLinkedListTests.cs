using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApp2.Tests
{
    public class SortedLinkedListTests
    {
        [Fact]
        public void ctorTest()
        {
            //Act
            var list = new SortedLinkedList();

            //Assert
            Assert.Null(list.Head);
        }

        [Fact]
        public void InsertFirstItemToList()
        {
            //Arrange
            int valueToInsert = 5;
            var list = new SortedLinkedList();

            //Act
            list.Add(valueToInsert);

            //Assert
            Assert.Equal(valueToInsert, list.Head.Value);
            Assert.Null(list.Head.Next);
        }

        [Fact]
        public void InsertItemToEnd()
        {
            //Arrange
            int valueToInsert = 10;
            var list = new SortedLinkedList();
            list.Add(5);
            list.Add(7);

            //Act
            list.Add(valueToInsert);

            //Assert
            CheckSorting(list);
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
