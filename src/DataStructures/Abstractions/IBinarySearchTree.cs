namespace DataStructures.Abstractions
{
    using DataStructures.Implementations;

    public interface IBinarySearchTree<T>
    {
        void Insert(T item);

        int Count { get; }

        bool Find(T item, out TreeNode<T> searchedNode);

        int Height { get; }

        T Min { get; }

        T Max { get; }

        T Successor(T item);

        void Delete(T item);
    }
}
