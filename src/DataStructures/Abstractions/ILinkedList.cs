namespace DataStructures.Abstractions
{
    public interface ILinkedList<in T>
    {
        int Count { get; }

        void AddLast(T data);

        void AddStart(T data);
    }
}
