﻿namespace DataStructures.Implementations
{
    using System;
    using DataStructures.Abstractions;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
    {
        private TreeNode<T> _root;
        private int _count = 0;
        private int _height = 0;
        private readonly Comparison<T> _comparison;

        public BinarySearchTree(Comparison<T> comparison)
        {
            _comparison = comparison;
        }

        public int Count => _count;

        public int Height => _height;

        public T Min
        {
            get
            {
                var node = _root;
                while (node.Left != null) node = node.Left;

                return node.Data;
            }
        }

        public T Max
        {
            get
            {
                var node = _root;
                while (node.Right != null) node = node.Right;

                return node.Data;
            }
        } 

        public T Successor => throw new System.NotImplementedException();

        public void Delete(T item)
        {
            throw new System.NotImplementedException();
        }

        public bool Find(T item)
        {
            var node = _root;
            while (node != null)
            {
                var comparison = _comparison.Invoke(node.Data, item);
                if (comparison == 0) return true;

                node = comparison < 0 ? node.Right : node.Left;
            }

            return false;
        }

        public void Insert(T item)
        {
            if (_root == null)
            {
                _root = new TreeNode<T> { Data = item };
                _height++;
                _count++;
                return;
            }

            var node = _root;
            var depth = 1;
            while (node != null)
            {
                depth++;
                var comparison = _comparison.Invoke(node.Data, item);

                if (comparison > 0 && node.Left != null) node = node.Left;
                else if (comparison <= 0 && node.Right != null) node = node.Right;
                else
                {
                    if (comparison > 0)
                    {
                        node.Left = new TreeNode<T> { Data = item };
                        _count++;
                        if(depth > _height) _height = depth;
                        return;
                    }
                    else
                    {
                        node.Right = new TreeNode<T> {Data = item};
                        _count++;
                        if (depth > _height) _height = depth;
                        return;
                    }
                }
            }

        }
    }
}
