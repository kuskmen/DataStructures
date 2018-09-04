namespace DataStructures.Abstractions
{
    public interface IBinarySearchTree<T>
    {
        void Insert(T item);

        int Count { get; }

        bool Find(T item);

        int Height { get; }

        T Min { get; }

        T Max { get; }

        void Delete(T item);

        T Successor { get; }
    }
}
