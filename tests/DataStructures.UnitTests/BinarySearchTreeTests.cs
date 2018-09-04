namespace DataStructures.UnitTests
{
    using System;
    using DataStructures.Implementations;
    using NUnit.Framework;

    [TestFixture]
    public class BinarySearchTreeTests
    {
        private BinarySearchTree<int> _binarySearchTree;
        private readonly Comparison<int> _comparison = (int x, int y) => x > y ? 1 : x < y ? -1 : 0;

        [SetUp]
        public void SetUp()
        {
            _binarySearchTree = new BinarySearchTree<int>(_comparison);
        }

        [Test]
        public void Insert_ShouldInsertItemAtRoot_WhenThereAreNoItemsInTheTree()
        {
            // Arrange
            // Act
            _binarySearchTree.Insert(5);
            _binarySearchTree.Insert(4);
            _binarySearchTree.Insert(2);
            _binarySearchTree.Insert(3);
            _binarySearchTree.Insert(1);
            _binarySearchTree.Insert(-1);
            _binarySearchTree.Insert(6);
            _binarySearchTree.Insert(8);
            _binarySearchTree.Insert(7);

            // Assert
            Assert.That(_binarySearchTree.Count, Is.EqualTo(1));
        }
    }
}
