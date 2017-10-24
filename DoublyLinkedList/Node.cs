using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class Node<T> where T : IComparable<T>
    {
        private T data;
        private Node<T> previous;
        public Node<T> next;

        /// <summary>
        /// No arg contructor for a node
        /// </summary>
        public Node() { }

        /// <summary>
        /// A data constructor for a node
        /// </summary>
        /// <param name="data">The data to be stored in the node</param>
        public Node(T data)
        {
            this.data = data;
        }

        /// <summary>
        /// An all arg constructor for a node
        /// </summary>
        /// <param name="data">The data to be stored in the node</param>
        /// <param name="previous">The node that was created before this one</param>
        /// <param name="next">The node that was created after this one</param>
        public Node(T data, Node<T> previous, Node<T> next)
        {
            this.data = data;
            this.previous = previous;
            this.next = next;
        }

        /// <summary>
        /// Returns the data stored in the node
        /// </summary>
        /// <returns>The data from the node</returns>
        public T GetData()
        {
            return data;
        }

        /// <summary>
        /// Adds data to a node
        /// </summary>
        /// <param name="data">The data to be added</param>
        public void SetData(T data)
        {
            this.data = data;
        }

        /// <summary>
        /// Returns the previous node propertry
        /// </summary>
        /// <returns>The previous node</returns>
        public Node<T> GetPrevious()
        {
            return previous;
        }

        /// <summary>
        /// Sets the previous node property
        /// </summary>
        /// <param name="previous">The previous node</param>
        public void SetPrevious(Node<T> previous)
        {
            this.previous = previous;
        }

        /// <summary>
        /// Returns the next node property
        /// </summary>
        /// <returns>The next node</returns>
        public Node<T> GetNext()
        {
            return next;
        }

        /// <summary>
        /// Sets the next node property
        /// </summary>
        /// <param name="next">The next node</param>
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
    }
}
