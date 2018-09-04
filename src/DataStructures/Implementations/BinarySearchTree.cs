namespace DataStructures.Implementations
{
    using System;
    using DataStructures.Abstractions;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
    {
        private TreeNode<T> _root;
        private int _count = 0;
        private readonly int _height = 0;
        private readonly Comparison<T> _comparison;

        public BinarySearchTree(Comparison<T> comparison)
        {
            _comparison = comparison;
        }

        public int Count => _count;

        public int Height => _height;

        public T Min => throw new System.NotImplementedException();

        public T Max => throw new System.NotImplementedException();

        public T Successor => throw new System.NotImplementedException();

        public void Delete(T item)
        {
            throw new System.NotImplementedException();
        }

        public bool Find(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(T item)
        {
            if (_root == null)
            {
                _root = new TreeNode<T> { Data = item };
                _count++;
                return;
            }

            var node = _root;
            while (node != null)
            {
                if (_comparison.Invoke(node.Data, item) > 0 && node.Left != null) node = node.Left;
                else if (_comparison.Invoke(node.Data, item) <= 0 && node.Right != null) node = node.Right;
                else
                {
                    if (_comparison.Invoke(node.Data, item) > 0)
                    {
                        node.Left = new TreeNode<T> { Data = item };
                        _count++;
                        return;
                    }
                    else
                    {
                        node.Right = new TreeNode<T> {Data = item};
                        _count++;
                        return;
                    }
                }
            }
        }
    }
}
