using System;

namespace data_structures
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Next;
        public Node<T> Prev;

        public Node(T value)
        {
            this.Value = value;
        }
    }
}

