using System;
using System.Collections.Generic;

namespace data_structures
{
    public class LinkedList<T>
    {
        public int Count = 0;
        public Node<T> First;
        public Node<T> Last;

        public LinkedList()
        {
        }

        public LinkedList(T value)
        {
            Node<T> node = new Node<T>(value);
            this.First = node;
            this.Last = node;
            this.Count++;
        }

        public void AddAfter(T value)
        {
          
        }

        public void AddAfter(Node<T> node)
        {

        }

        public void AddBefore()
        {

        }

        /// <summary>
        /// Adds a new node containing the specified value at the start of the LinkedList<T>.
        /// </summary>
        /// <param name="value">The value to add at the start of the LinkedList<T>.</param>
        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);

            this.AddFirst(node); 
        }

        /// <summary>
        /// Adds the specified new node at the start of the LinkedList<T>.
        /// </summary>
        /// <param name="node">The new Node<T> to add at the start of the LinkedList<T>.</param>
        /// <exception cref="ArgumentNullException">Node is null</exception>
        public Node<T> AddFirst(Node<T> node)
        {
            if(node == null)
            {
                throw new ArgumentNullException(nameof(node), "Node is null");
            }

            if(this.First == null)
            {
                this.First = node;
                this.Last = node;
            } else if(this.First != null && this.First == this.Last)
            {
                Node<T> temp = this.First;

                this.First = node;
                this.Last = temp;

                this.First.Next = temp;
                this.Last.Prev = node;
            } else
            {
                node.Next = this.First;
                this.First = node;
                this.First.Next.Prev = node;
            }

            this.Count++;
            return node;
        }

        /// <summary>
        /// Adds a new node containing the specified value at the end of the LinkedList<T>.
        /// </summary>
        /// <param name="value">The value to add at the end of the LinkedList<T>.</param>
        public void AddLast(T value)
        {
            Node<T> node = new Node<T>(value);
            this.AddLast(node);
        }

        /// <summary>
        /// Adds the specified new node at the end of the LinkedList<T>.
        /// </summary>
        /// <param name="node">The new Node<T> to add at the end of the LinkedList<T>.</param>
        /// <returns>The new LinkedListNode<T> containing value.</returns>
        /// <exception cref="ArgumentNullException">Node is null</exception>
        public Node<T> AddLast(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Node is null");
            }

            if (this.First == null)
            {
                this.First = node;
                this.Last = node;
            }
            else if (this.First != null && this.First == this.Last)
            {
                this.Last = node;
                this.First.Next = node;
                this.Last.Prev = this.First;
            }
            else
            {
                node.Prev = this.Last;
                this.Last.Next = node;
                this.Last = node;
            }

            this.Count++;
            return node;
        }

        /// <summary>
        /// Removes all nodes from the LinkedList<T>.
        /// </summary>
        public void Clear()
        {
            this.First = null;
            this.Last = null;
            this.Count = 0;
        }

        public void Contains()
        {

        }

        /// <summary>
        /// Copies the entire LinkedList<T> to a compatible one-dimensional Array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from LinkedList<T>. The Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentNullException">Array is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Index less than zero</exception>
        /// <exception cref="ArgumentException">Array has insufficent length</exception>
        public void CopyTo(T[] array, int index)
        {
            if(array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            if(index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            int requiredLength = index + this.Count;
            if (requiredLength > array.Length)
            {
                throw new ArgumentException(nameof(array), "Array length is not sufficient to accommodate the linked list.");
            }

            Node<T> currentNode = this.First;
            int currentIndex = index;

            while (currentNode != null)
            {
                array[currentIndex] = currentNode.Value;
                currentNode = currentNode.Next;
                currentIndex++;
            }
        }

        public void FindLast()
        {

        }

        public void GetEnumerator()
        {

        }

        public void Remove()
        {

        }

        public void RemoveFirst()
        {

        }

        public void RemoveLast()
        {

        }
    }
}

