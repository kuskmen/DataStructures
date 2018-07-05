namespace DataStructures.Implementations
{
    using System;
    using DataStructures.Abstractions;

    public class LinkedList<T> : ILinkedList<T>
    {
        public Node<T> Head { get; private set; }

        public int Count { get; private set; }

        public LinkedList()
        {
            Head = null;
            Count = 0;
        }

        public T Tail()
        {
            if (Head == null) return default;

            var it = Head;
            while (it.Next != null)
            {
                it = it.Next;
            }

            return it.Data;
        }

        public bool IsEmpty => Count == 0;

        public void AddBack(T data)
        {
            var newNode = new Node<T> { Data = data };
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                var it = Head;
                while (it.Next != null)
                {
                    it = it.Next;
                }

                it.Next = newNode;
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

        public T PopFront()
        {
            if(IsEmpty) throw new InvalidOperationException("List is empty");

            var front = Head;
            Head = Head.Next;
            return front.Data;
        }

        public T PopBack()
        {
            if(IsEmpty) throw new InvalidOperationException("List is empty");

            var it = Head;
            while (it.Next != null)
            {
                it = it.Next;
            }

            return it.Data;
        }

        public void InsertAt(T item, int index)
        {
            if(index > Count) throw new IndexOutOfRangeException();

            if(IsEmpty) throw new InvalidOperationException();

            var current = Head;
            var previous = Head;
            
            while (current.Next != null && index != 0)
            {
                previous = current;
                current = current.Next;
                index--;
            }

            previous.Next = new Node<T>
            {
                Data = item,
                Next = current
            };
        }
    }
}
