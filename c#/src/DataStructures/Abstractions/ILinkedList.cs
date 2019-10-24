namespace DataStructures.Abstractions
{
    using DataStructures.Implementations;

    public interface ILinkedList<T>
    {
        Node<T> Head { get; }

        int Count { get; }

        bool IsEmpty { get; }

        void AddBack(T data);

        void AddFront(T data);

        T PopFront();

        T PopBack();

        void InsertAt(T item, int index);
    }
}
