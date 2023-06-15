using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace data_structures
{
    public class LinkedList<T>
    {
        public int Count = 0;
        public Node<T> First;
        public Node<T> Last;

        /// <summary>
        /// Initializes an emoty LinkedList
        /// </summary>
        public LinkedList()
        {
        }

        /// <summary>
        /// Initialize a new LinkedList with value
        /// </summary>
        /// <param name="value">Value to create first node</param>
        public LinkedList(T value)
        {
            Node<T> node = new Node<T>(value);
            this.First = node;
            this.Last = node;
            this.Count++;
        }

        /// <summary>
        /// Adds a new node containing the specified value after the specified existing node in the LinkedList<T>.
        /// </summary>
        /// <param name="node">The LinkedListNode<T> after which to insert a new LinkedListNode<T> containing value.</param>
        /// <param name="value">The value to add to the LinkedList<T>.</param>
        /// <exception cref="ArgumentNullException">Node is null</exception>
        public void AddAfter(Node<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Node is null");
            }

            Node<T> newNode = new Node<T>(value);
            this.AddAfter(node, newNode);
        }

        /// <summary>
        /// Adds the specified new node after the specified existing node in the LinkedList<T>.
        /// </summary>
        /// <param name="node">The LinkedListNode<T> after which to insert newNode.</param>
        /// <param name="newNode">The new LinkedListNode<T> to add to the LinkedList<T>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Node is null</exception>
        /// <exception cref="InvalidOperationException">node is not in the current LinkedList<T>.</exception>
        public Node<T> AddAfter(Node<T> node, Node<T> newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Node is null");
            }

            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "New node is null");
            }

            // Edge case -- if list only has one item and target is head of the list
            if (this.First == this.Last && this.First == node)
            {
                this.First.Next = newNode;
                newNode.Prev = this.First;
                this.Last = newNode;

                this.Count++;
                return newNode;
            }
            else
            {
                Node<T> iter = this.First;
                while (iter != null)
                {
                    if (iter == node)
                    {
                        newNode.Next = iter.Next;
                        newNode.Prev = iter;
                        iter.Next = newNode;

                        if (newNode.Next != null)
                        {
                            newNode.Next.Prev = newNode;
                        }
                        else
                        {
                            this.Last = newNode;
                        }

                        this.Count++;
                        return newNode;
                    }

                    iter = iter.Next;
                }
            }

            throw new InvalidOperationException("Node does not belong to the linked list");
        }

        /// <summary>
        /// Adds a new node containing the specified value before the specified existing node in the LinkedList<T>.<T>.
        /// </summary>
        /// <param name="node">The LinkedListNode<T> before which to insert newNode.</param>
        /// <param name="value">The new LinkedListNode<T> to add to the LinkedList<T>.</param>
        public void AddBefore(Node<T> node, T value)
        {
            Node<T> newNode = new Node<T>(value);
            this.AddBefore(node, newNode);
        }

        /// <summary>
        /// Adds the specified new node before the specified existing node in the LinkedList<T>.
        /// </summary>
        /// <param name="node">The LinkedListNode<T> before which to insert newNode.</param>
        /// <param name="newNode">The new LinkedListNode<T> to add to the LinkedList<T>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Node is null or new node is null</exception>
        /// <exception cref="InvalidOperationException">Node is not in the current linked list</exception>
        public Node<T> AddBefore(Node<T> node, Node<T> newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Node is null");
            }

            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "New node is null");
            }

            // Edge case -- if list only has one item and target is the head of the list
            if (this.First == node)
            {
                newNode.Next = node;
                node.Prev = newNode;
                this.First = newNode;

                this.Count++;
                return newNode;
            }
            else
            {
                Node<T> iter = this.First;
                while (iter != null)
                {
                    if (iter.Next == node)
                    {
                        newNode.Next = node;
                        newNode.Prev = iter;
                        iter.Next = newNode;
                        node.Prev = newNode;

                        this.Count++;
                        return newNode;
                    }

                    iter = iter.Next;
                }
            }

            throw new InvalidOperationException("Node does not belong to the linked list");
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

        /// <summary>
        /// Determines whether a value is in the LinkedList<T>.
        /// </summary>
        /// <param name="value">The value to locate in the LinkedList<T>. The value can be null for reference types.</param>
        /// <returns>true if value is found in the LinkedList<T>; otherwise, false.</returns>
        public bool Contains(T value)
        {
            Node<T> iter = this.First;

            while(iter != null)
            {
                if (EqualityComparer<T>.Default.Equals(iter.Value, value))
                {
                    return true;
                }

                iter = iter.Next;
            }

            return false;
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

        /// <summary>
        /// Finds the first node that contains the specified value.
        /// </summary>
        /// <param name="value">The value to locate in the LinkedList<T>.</param>
        /// <returns>The first Node<T> that contains the specified value, if found; otherwise, null.</returns>
        public Node<T> Find(T value)
        {
            Node<T> iter = this.First;

            while (iter != null)
            {
                if (EqualityComparer<T>.Default.Equals(iter.Value, value))
                {
                    return iter;
                }

                iter = iter.Next;
            }

            return null;
        }

        /// <summary>
        /// Finds the last node that contains the specified value.
        /// </summary>
        /// <param name="value">The value to locate in the LinkedList<T>.</param>
        /// <returns>The last LinkedListNode<T> that contains the specified value, if found; otherwise, null.</returns>
        public Node<T> FindLast(T value)
        {
            Node<T> iter = this.Last;

            while(iter != null)
            {
                if (EqualityComparer<T>.Default.Equals(iter.Value, value))
                {
                    return iter;
                }

                iter = iter.Prev;
            }

            return null;
        }

        /// <summary>
        /// Removes the first occurrence of the specified value from the LinkedList<T>.
        /// </summary>
        /// <param name="value">The value to remove from the LinkedList<T>.</param>
        /// <returns>true if the element containing value is successfully removed; otherwise, false. This method also returns false if value was not found in the original LinkedList<T>.</returns>
        public bool Remove(T value)
        {
            if (this.Count == 1)
            {
                this.First = null;
                this.Last = null;

                this.Count--;
            }
            else
            {
                Node<T> iter = this.First;
                while (iter != null)
                {
                    if (EqualityComparer<T>.Default.Equals(iter.Value, value))
                    {
                        iter.Prev.Next = iter.Next;

                        this.Count--;
                        return true;
                    }

                    iter = iter.Next;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes the specified node from the LinkedList<T>.
        /// </summary>
        /// <param name="node">The LinkedListNode<T> to remove from the LinkedList<T>.</param>
        /// <exception cref="ArgumentNullException">node is null</exception>
        /// <exception cref="InvalidOperationException">node is not in the current LinkedList<T>.</exception>
        public void Remove(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node is null");
            }

            if (this.First == null)
            {
                throw new InvalidOperationException("List is empty");
            }

            if (this.First == node)
            {
                if (this.First == this.Last)
                {
                    this.First = null;
                    this.Last = null;
                }
                else
                {
                    this.First = this.First.Next;
                    this.First.Prev = null;
                }

                this.Count--;
                return;
            }

            Node<T> iter = this.First.Next;
            while (iter != null)
            {
                if (iter == node)
                {
                    if (iter == this.Last)
                    {
                        this.Last = iter.Prev;
                        this.Last.Next = null;
                    }
                    else
                    {
                        iter.Prev.Next = iter.Next;
                        iter.Next.Prev = iter.Prev;
                    }

                    this.Count--;
                    return;
                }

                iter = iter.Next;
            }

            throw new InvalidOperationException("Node does not exist in LinkedList");
        }

        /// <summary>
        /// Removes the node at the start of the LinkedList<T>.
        /// </summary>
        /// <exception cref="InvalidOperationException">The LinkedList<T> is empty.</exception>
        public void RemoveFirst()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException("Linked list is empty");
            }

            if(this.First == this.Last)
            {
                this.First = null;
                this.Last = null;
            } else
            {
                this.First = this.First.Next;
            }
        }

        /// <summary>
        /// Removes the node at the end of the LinkedList<T>.
        /// </summary>
        /// <exception cref="InvalidOperationException">The LinkedList<T> is empty.</exception>
        public void RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked list is empty");
            }

            if (this.First == this.Last)
            {
                this.First = null;
                this.Last = null;
            }
            else
            {
                this.Last = this.Last.Prev;
            }
        }
    }
}

