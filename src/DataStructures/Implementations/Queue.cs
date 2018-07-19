namespace DataStructures.Implementations
{
    using System;
    using DataStructures.Abstractions;

    public class Queue<T> : IQueue<T>
    {
        private readonly LinkedList<T> _items;

        public Queue()
        {
            _items = new LinkedList<T>();
        }

        public bool IsEmpty => _items.IsEmpty;

        public void Enqueue(T item)
        {
            _items.AddBack(item);
        }

        public T Dequeue() => _items.PopFront();
    }

    public class ArrayQueue<T> : IQueue<T>
    {
        private readonly T[] _items;
        private int _nextFreeIndex;
        private const int DefaultSize = 16;

        public ArrayQueue() : this(DefaultSize)
        {
        }

        public ArrayQueue(int length)
        {
            _items = new T[length];
            _nextFreeIndex = length - 1;
        }

        public bool IsEmpty => _nextFreeIndex == _items.Length - 1;
        public bool IsFull => _nextFreeIndex == -1;

        public void Enqueue(T item)
        {
            if(_nextFreeIndex == -1) throw new InvalidOperationException("Queue is full.");
            _items[_nextFreeIndex] = item;
            _nextFreeIndex--;
        }

        public T Dequeue()
        {
            ++_nextFreeIndex;
            var result = _items[_nextFreeIndex];
            _items[_nextFreeIndex] = default;
            return result;
        }
    }
}
