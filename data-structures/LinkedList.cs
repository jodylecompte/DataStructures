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

        public void AddFirst()
        {

        }

        public void AddLast()
        {

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

