namespace DataStructures.Implementations
{
    using System;
    using DataStructures.Abstractions;

    public class LinkedList<T> : ILinkedList<T>
    {
        public Node<T> Head { get; private set; }

        public Node<T> Tail { get; private set; }

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public void AddBack(T data)
        {
            var newNode = new Node<T> { Data = data };
            if (Tail == null)
            {
                Tail = newNode;
                Head = newNode;
                Head.Next = Tail;
                Tail.Next = null;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
            Count++;
        }

        public void AddFront(T data)
        {
            var newNode = new Node<T>
            {
                Data = data,
                Next = Head
            };
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                Head.Next = Tail;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
            Count++;
        }

        public T this[int index]
        {
            get
            {
                if(index < 0) throw new ArgumentException(nameof(index));
                if(index > Count) throw new IndexOutOfRangeException(nameof(index));

                var current = Head;
                while (index > 0)
                {
                    index--;
                    current = current.Next;

                    if (current == null) return default;
                }

                return current.Data;
            }
        }
    }
}
