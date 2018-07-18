namespace DataStructures.Implementations
{
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
        private int _capacity;
        private const int DefaultCapacity = 16;

        public ArrayQueue() : this(DefaultCapacity)
        {
        }

        public ArrayQueue(int capacity)
        {
            _items = new T[capacity];
            _capacity = capacity;
        }

        public bool IsEmpty => _items.Length == 0;
        public bool IsFull => _items.Length == _capacity - 1;

        public void Enqueue(T item)
        {
            _items[_capacity] = item;
        }

        public T Dequeue()
        {
            throw new System.NotImplementedException();
        }
    }
}
