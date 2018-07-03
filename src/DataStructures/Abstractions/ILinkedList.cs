namespace DataStructures.Abstractions
{
    using DataStructures.Implementations;

    public interface ILinkedList<T>
    {
        Node<T> Head { get; }

        Node<T> Tail { get; }

        int Count { get; }

        bool IsEmpty { get; }

        void AddBack(T data);

        void AddFront(T data);
    }
}
