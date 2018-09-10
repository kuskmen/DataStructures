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

        public TreeNode<T> Parent { get; set; }

        public TreeNode<T> Successor
        {
            get
            {
                if (Right == null) return Parent.Parent;

                var node = Right;
                while (Right.Left != null)
                {
                    node = Right.Left;
                }

                return node;
            }
        }

        public T Data { get; set; }
    }
}
