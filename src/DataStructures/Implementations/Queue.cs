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
}
