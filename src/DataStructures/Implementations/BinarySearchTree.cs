namespace DataStructures.Implementations
{
    using System;
    using DataStructures.Abstractions;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
    {
        private TreeNode<T> _root;
        private int _count = 0;
        private readonly Comparison<T> _comparison;

        public BinarySearchTree(Comparison<T> comparison)
        {
            _comparison = comparison;
        }

        public int Count => _count;

        public int Height => FindHeight(_root);

        public T Min => FindMin(_root).Data;

        public T Max => FindMax(_root).Data;

        public T Successor(T item)
        {
            if (!Find(item, out var node)) return default;

            var comparison = _comparison.Invoke(node.Parent.Data, node.Data);

            if (node.Right == null && comparison >= 0) return node.Parent.Data;
            if (node.Right == null && comparison < 0)
            {
                while (node != _root && _comparison.Invoke(node.Parent.Data, node.Data) < 0)
                {
                    node = node.Parent;
                }
                return node == _root ? default : node.Parent.Data;
            }

            return node.Right != null ? FindMin(node.Right).Data : default;
        }

        public void Delete(T item)
        {
            if (!Find(item, out var node)) return;

            // its a leaf
            if (node.Right == null && node.Left == null)
            {
                if (_comparison.Invoke(node.Parent.Data, node.Data) > 0) node.Parent.Left = null;
                else node.Parent.Right = null;
            }
            // node has both left and right child subtrees
            else if (node?.Right != null && node.Left != null)
            {
                node.Data = FindMin(node.Right).Data;
            }
            // node has only right child subtree
            else if (node.Right != null)
            {
                node.Right.Parent = node.Parent;

                if (_comparison.Invoke(node.Parent.Data, node.Data) > 0) node.Parent.Left = node.Right;
                else node.Parent.Right = node.Right;
            }
            // node has only left child subtree
            else if (node.Left != null)
            {
                node.Left.Parent = node.Parent;

                if (_comparison.Invoke(node.Parent.Data, node.Data) > 0) node.Parent.Left = node.Left;
                else node.Parent.Right = node.Left;
            }
        }

        public bool Find(T item, out TreeNode<T> searchedNode)
        {
            var node = _root;
            while (node != null)
            {
                var comparison = _comparison.Invoke(node.Data, item);
                if (comparison == 0)
                {
                    searchedNode = node;
                    return true;
                }

                node = comparison < 0 ? node.Right : node.Left;
            }

            searchedNode = null;
            return false;
        }

        public void Insert(T item)
        {
            if (_root == null)
            {
                _root = new TreeNode<T> { Data = item, Parent = null };
                _count++;
                return;
            }

            var node = _root;
            while (node != null)
            {
                var comparison = _comparison.Invoke(node.Data, item);

                if (comparison > 0 && node.Left != null) node = node.Left;
                else if (comparison <= 0 && node.Right != null) node = node.Right;
                else
                {
                    if (comparison > 0)
                    {
                        node.Left = new TreeNode<T> { Data = item, Parent = node };
                        _count++;
                    }
                    else
                    {
                        node.Right = new TreeNode<T> { Data = item, Parent = node };
                        _count++;
                    }

                    return;
                }
            }

        }

        private static TreeNode<T> FindMin(TreeNode<T> tree)
        {
            var node = tree;
            while (node.Left != null) node = node.Left;

            return node;
        }

        private static TreeNode<T> FindMax(TreeNode<T> tree)
        {
            var node = tree;
            while (node.Right != null) node = node.Right;

            return node;
        }

        private static int FindHeight(TreeNode<T> tree)
        {
            // is leaf
            if (tree.Left == null && tree.Right == null) return 1;

            // have left and right subtree
            if (tree.Left != null && tree.Right != null)
            {
                var leftHeight = FindHeight(tree.Left);
                var rightHeight = FindHeight(tree.Right);
                return leftHeight > rightHeight ? leftHeight + 1 : rightHeight + 1;
            }

            // have only left subtree
            if (tree.Left != null) return 1 + FindHeight(tree.Left);

            // have only right subtree
            if (tree.Right != null) return 1 + FindHeight(tree.Right);

            return 0;
        }
    }
}
