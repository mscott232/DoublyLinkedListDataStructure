using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class LinkedList<T> where T : IComparable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int size;

        /// <summary>
        /// Linked list contructor
        /// </summary>
        public LinkedList() { }

        /// <summary>
        /// Adds a node to the linked list
        /// </summary>
        /// <param name="data">The data to be added</param>
        /// <returns>True once the node has been added</returns>
        public bool Add(T data)
        {
            LinkHead(data);

            return true;
        }

        /// <summary>
        /// Sets the linked list back to its default
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
        }

        /// <summary>
        /// Returns the data from the node
        /// </summary>
        /// <returns>The data from the node</returns>
        public T Get()
        {
            // Determine if linked list size is 0
            if (size == 0)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                return head.GetData();
            }
        }

        /// <summary>
        /// Returns the size of the linked list
        /// </summary>
        /// <returns>The size of the linked list</returns>
        public int GetSize()
        {
            return size;
        }

        /// <summary>
        /// Returns true if linked list empty, false if not
        /// </summary>
        /// <returns>True or false depending on linked list size</returns>
        public bool IsEmpty()
        {
            return size <= 0;
        }

        /// <summary>
        /// Removes and returns the first data item in the linked list, throw an exception if list empty
        /// </summary>
        /// <returns>The data from the first item</returns>
        public T Remove()
        {
            T data;

            if (size <= 0)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                data = UnlinkHead();
            }

            return data;
        }

        /// <summary>
        /// Change the data in the head node and return the old data
        /// </summary>
        /// <param name="data">New data for head node</param>
        /// <returns>The old data</returns>
        public T Set(T data)
        {
            T oldData;

            // Determine if the linked list is empty or not
            if (size == 0)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                oldData = SetData(data, head);
            }

            return oldData;
        }

        /// <summary>
        /// Add a new node to the linked list at the head
        /// </summary>
        /// <param name="data">Data to add to the head</param>
        /// <returns>True when complete</returns>
        public bool AddFirst(T data)
        {
            LinkHead(data);

            return true;
        }

        /// <summary>
        /// Add a new node to the linked list at the end
        /// </summary>
        /// <param name="data">The data to add</param>
        /// <returns>True when complete</returns>
        public bool AddLast(T data)
        {
            if (size <= 0)
            {
                LinkHead(data);
            }
            else
            {
                LinkTail(data);
            }

            return true;
        }

        /// <summary>
        /// Remove and return teh first data item in the linked list by calling remove
        /// </summary>
        /// <returns>The data stored in the node</returns>
        public T RemoveFirst()
        {
            return Remove();
        }

        /// <summary>
        /// Remove and return the last data item in the linked list
        /// </summary>
        /// <returns>The data stored in the node</returns>
        public T RemoveLast()
        {
            if (tail == null)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                return UnlinkTail();
            }
        }

        /// <summary>
        /// A new node is added to the list while the list is kept in ascending sorted order automatically
        /// </summary>
        /// <param name="data">The data to be added</param>
        /// <returns>True when complete</returns>
        public bool InsertData(T data)
        {
            Node<T> previous;
            Node<T> current;
            previous = null;
            current = head;

            // Loop while current is not null and the data in current is less than the data passed in
            while (current != null && current.GetData().CompareTo(data) < 0)
            {
                previous = current;
                current = current.GetNext();
            }

            // Determine if previous is still null
            if (previous == null)
            {
                LinkHead(data);
            }
            else
            {
                // Determine if current is not null
                if (current != null)
                {
                    Link(data, previous, current);
                }
                else
                {
                    LinkTail(data);
                }
            }

            return true;
        }

        /// <summary>
        /// The new node containing data is to be added to the linked list after the node at the specified number.
        /// </summary>
        /// <param name="data">Data to add</param>
        /// <param name="position">The number of the node to add after</param>
        /// <returns>True when complete</returns>
        public bool AddAfter(T data, int position)
        {
            ValidatePositon(position);

            // Determine if possition is equal to size
            if (position == size)
            {
                LinkTail(data);
            }
            else
            {
                Node<T> previous = Find(position);
                Node<T> next = previous.GetNext();

                Link(data, previous, next);
            }

            return true;
        }

        /// <summary>
        /// Add a new node containing the passed data to the list before the node position specified
        /// </summary>
        /// <param name="data">Data to add</param>
        /// <param name="position">Numeric position to insert before</param>
        /// <returns>True when complete</returns>
        public bool AddBefore(T data, int position)
        {
            ValidatePositon(position);

            // Determine if position is equal to 1
            if (position == 1)
            {
                LinkHead(data);
            }
            else
            {
                Node<T> next = Find(position);
                Node<T> previous = next.GetPrevious();

                Link(data, previous, next);
            }

            return true;
        }

        /// <summary>
        /// Change the data in the node based on the position number specified
        /// </summary>
        /// <param name="data">Data to add in the node</param>
        /// <param name="position">Node position number to replace data on</param>
        /// <returns>The data that was in the node</returns>
        public T Set(T data, int position)
        {
            Node<T> node;

            ValidatePositon(position);

            // Determind if position is equal to size
            if (position == size)
            {
                node = tail;
            }
            else
            {
                node = Find(position);
            }

            return SetData(data, node);
        }

        /// <summary>
        /// Returns the data in the numeric position specified
        /// </summary>
        /// <param name="position">Numeric position of node to retrieve</param>
        /// <returns>The data of the node at the specified position</returns>
        public T Get(int position)
        {
            Node<T> node;

            ValidatePositon(position);

            node = Find(position);

            return node.GetData();
        }

        /// <summary>
        /// Remove and return the data in the numeric position specified
        /// </summary>
        /// <param name="position">Numeric position to retrieve</param>
        /// <returns>The data from the node being removed</returns>
        public T Remove(int position)
        {
            T data;

            ValidatePositon(position);

            // Determine if the position is equal to the head
            if (position == 1)
            {
                data = UnlinkHead();
            }
            else
            {
                // Determine if the position is equal to the size of the list
                if (position == size)
                {
                    data = UnlinkTail();
                }
                else
                {
                    Node<T> node = Find(position);
                    data = Unlink(node);
                }
            }

            return data;
        }

        /// <summary>
        /// Returns the first data item in the linked list by calling 'Get'
        /// </summary>
        /// <returns>The data from the first item in the list</returns>
        public T GetFirst()
        {
            return Get();
        }

        /// <summary>
        /// Returns the last data item in the linked list.
        /// </summary>
        /// <returns>The data from the last node</returns>
        public T GetLast()
        {
            // Determine if size of linked list is 0 and throw an exception if it is
            if (size == 0)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                return tail.GetData();
            }
        }

        /// <summary>
        /// A node containing the supplied data value is to be added after the node containing oldData
        /// </summary>
        /// <param name="data">The data to be added to the list</param>
        /// <param name="oldData">Value used to to find the node containing the oldData</param>
        /// <returns>True when complete</returns>
        public bool AddAfter(T data, T oldData)
        {
            Node<T> node = Find(oldData);

            // Determine if node is null and throw exception if it is
            if (node == null)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                // Dtermine if the node is the tail
                if (node == tail)
                {
                    LinkTail(data);
                }
                else
                {
                    Link(data, node, node.GetNext());
                }
            }

            return true;
        }

        /// <summary>
        /// Add a new node with the specified data to the link list. This new node will be added after the node containing the oldData.
        /// </summary>
        /// <param name="data">The data to be added to the list</param>
        /// <param name="oldData">Value used to to find the node containing the oldData</param>
        /// <returns>True when complete</returns>
        public bool AddBefore(T data, T oldData)
        {
            Node<T> node = Find(oldData);

            // Determine if node is null and throw exception if it is
            if (node == null)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                // Determine if the node is the head
                if (node == head)
                {
                    LinkHead(data);
                }
                else
                {
                    Link(data, node.GetPrevious(), node);
                }
            }

            return true;
        }

        /// <summary>
        /// Returns the data using a value stored in the linked list
        /// </summary>
        /// <param name="data">Data to look for in the list</param>
        /// <returns>Node found containing the data specified</returns>
        public T Get(T data)
        {
            Node<T> node = Find(data);

            // Determine if node is null and throw exception if it is
            if (node == null)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                return node.GetData();
            }
        }

        /// <summary>
        /// Find the node containing the oldData and replace it with the new data
        /// </summary>
        /// <param name="data">New data for the node</param>
        /// <param name="oldData">The data to be replaced</param>
        /// <returns>The old data</returns>
        public T Set(T data, T oldData)
        {
            Node<T> node = Find(oldData);

            // Determine if node is null and throw exception if it is
            if (node == null)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                return SetData(data, node);
            }
        }

        /// <summary>
        /// Change the data in the head node. This method does not change node position, it only changes the data the node points to.
        /// </summary>
        /// <param name="data">New data for the node</param>
        /// <returns>The old data from the node</returns>
        public T SetFirst(T data)
        {
            // Determine if size is 0 and throw exception if it is
            if (size == 0)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                return SetData(data, head);
            }
        }

        /// <summary>
        /// Change the data in the tail node. This method does not change node position, it only changes the data the node points to.
        /// </summary>
        /// <param name="data">New data for the node</param>
        /// <returns>The old data from the node</returns>
        public T SetLast(T data)
        {
            // Determine if size is 0 and throw exception if it is
            if (size == 0)
            {
                throw new IndexOutOfRangeException("No such element");
            }
            else
            {
                return SetData(data, tail);
            }
        }

        /// <summary>
        /// Adds the node to the head when null if not adds it after the head
        /// </summary>
        /// <param name="data">The node to be added</param>
        private void LinkHead(T data)
        {
            Node<T> toAdd = new Node<T>(data);

            // Determine if the head is null
            if (head != null)
            {
                head.SetPrevious(toAdd);
                toAdd.SetNext(head);
            }

            head = toAdd;


            // Determine if the linked list is empty and make the tail also the head
            if (size == 0)
            {
                tail = head;
            }

            size++;
        }

        /// <summary>
        /// Removes the node at the head of the linked list and returns the data it contains
        /// </summary>
        /// <returns>The data from the unlinked head node</returns>
        private T UnlinkHead()
        {
            Node<T> oldHead = head;
            T data;

            head = head.GetNext();

            size -= 1;

            // Determine if head is now null and if it is make the tail null as well
            if (head == null)
            {
                tail = null;
            }

            head?.SetPrevious(null);

            data = oldHead.GetData();

            return data;
        }

        /// <summary>
        /// Change the supplied node's data to the data value passed
        /// </summary>
        /// <param name="newData">The new data to set</param>
        /// <param name="node">The node to have its data replaced</param>
        /// <returns>The old data from the node</returns>
        private T SetData(T newData, Node<T> node)
        {
            T oldData = node.GetData();
            node.SetData(newData);

            return oldData;
        }

        /// <summary>
        /// Adds a new node containing the data provided to the linked list at the tail
        /// </summary>
        /// <param name="data">The data to add</param>
        private void LinkTail(T data)
        {
            Node<T> toAdd = new Node<T>(data, tail, null);

            // Not in diagram
            tail.SetNext(toAdd);

            tail = toAdd;

            size++;
        }

        /// <summary>
        /// Remove the node at the tail of the linked list and return the data it contains
        /// </summary>
        /// <returns>The data stored in the node being removed</returns>
        private T UnlinkTail()
        {
            Node<T> oldTail = tail;

            tail = tail.GetPrevious();

            tail.SetNext(null);

            size--;

            return oldTail.GetData();
        }

        /// <summary>
        /// Adds the data to a new node in the linked list between the nodes specified
        /// </summary>
        /// <param name="data">Data to add to the list</param>
        /// <param name="previous">A pointer to the node that will come before data's node</param>
        /// <param name="next">A pointer to the node that will come after the data's node</param>
        private void Link(T data, Node<T> previous, Node<T> next)
        {
            Node<T> newNode = new Node<T>(data, previous, next);

            previous.SetNext(newNode);

            next.SetPrevious(newNode);

            size++;
        }

        /// <summary>
        /// Validates that the position specified is within the bounds of the linked list: (greater or equal to 1, less than or equal to Size)
        /// </summary>
        /// <param name="position">The position to be validated</param>
        private void ValidatePositon(int position)
        {
            if (position < 1 || position > size)
            {
                throw new IndexOutOfRangeException("No such element");
            }
        }

        /// <summary>
        /// Returns the node at the position number specified
        /// </summary>
        /// <param name="position">Numeric position of node to look for</param>
        /// <returns>Returns the node</returns>
        private Node<T> Find(int position)
        {
            Node<T> current = head;
            int i = 1;

            while (i < position)
            {
                current = current.GetNext();
                i++;
            }

            return current;
        }

        /// <summary>
        /// Removes the specified node from the linked list
        /// </summary>
        /// <param name="node">The node to be removed</param>
        /// <returns>Data from the node being removed</returns>
        private T Unlink(Node<T> node)
        {
            Node<T> previous = node.GetPrevious();
            Node<T> next = node.GetNext();

            previous.SetNext(next);
            next.SetPrevious(previous);
            size--;

            return node.GetData();
        }

        /// <summary>
        /// Returns the node containing the data specified
        /// </summary>
        /// <param name="data">The data to look for in the linked list</param>
        /// <returns>The node that contains the data</returns>
        private Node<T> Find(T data)
        {
            Node<T> current = head;
            T currentData;
            bool firstIteration = true;

            // While data is not equal to current data loop
            do
            {
                // Determine if first iteration, if it is make first iteration false and after update current
                if (firstIteration)
                {
                    firstIteration = false;
                }
                else
                {
                    current = current.GetNext();
                }

                // Determine if current is null
                if (current == null)
                {
                    return null;
                }
                else
                {
                    currentData = current.GetData();
                }

            } while (currentData.CompareTo(data) < 0 || currentData.CompareTo(data) > 0);

            return current;
        }
    }
}
