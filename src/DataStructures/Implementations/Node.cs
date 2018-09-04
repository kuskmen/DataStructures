namespace DataStructures.Implementations
{
    public sealed class Node<T>
    {
        public Node<T> Next { get; set; }

        public T Data { get; set; }
    }

    public sealed class TreeNode<T>
    {
        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public T Data { get; set; }
    }
}
