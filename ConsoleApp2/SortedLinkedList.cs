using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class SortedLinkedList
    {
        private Node _head;

        public INode Head => _head;

        public void Add(int newValue)
        {
            var nodeToAdd = new Node(newValue);

            if (_head == null || newValue <= _head.Value)
            {
                nodeToAdd.NextNode = _head;
                _head = nodeToAdd;
                return;
            }

            var current = _head;
            
            while (current.NextNode != null 
                && current.NextNode.Value < newValue)
            {
                current = current.NextNode;
            }
            
            nodeToAdd.NextNode = current.NextNode;
            current.NextNode = nodeToAdd;
        }

        private class Node : INode
        {
            public Node(int value)
            {
                Value = value;
            }

            public int Value { get; }

            public Node NextNode { get; set; }

            public INode Next => NextNode;
        }
    }

    public interface INode
    {
        int Value { get; }

        INode Next { get; }
    }
}
