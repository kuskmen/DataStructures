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

            // Assert
            Assert.That(_binarySearchTree.Height, Is.EqualTo(1));
        }

        [Test]
        public void Height_ShouldEqualToDepthOfTheTree()
        {
            // Arrange
            // Act
            _binarySearchTree.Insert(5);
            _binarySearchTree.Insert(4);
            _binarySearchTree.Insert(6);

            // Assert
            Assert.That(_binarySearchTree.Height, Is.EqualTo(2));
        }

        [Test]
        public void Min_ShouldShowMostOuterLeftNodeOfTheTree()
        {
            // Arrange
            _binarySearchTree.Insert(5);
            _binarySearchTree.Insert(3);
            _binarySearchTree.Insert(4);

            // Act
            // Assert
            Assert.That(_binarySearchTree.Min, Is.EqualTo(3));
        }

        [Test]
        public void Max_ShouldShowMostOuterRightNodeOfTheTree()
        {
            // Arrange
            _binarySearchTree.Insert(5);
            _binarySearchTree.Insert(7);
            _binarySearchTree.Insert(6);

            // Act
            // Assert
            Assert.That(_binarySearchTree.Max, Is.EqualTo(7));
        }

        [Test]
        public void MinAndMax_ShouldShowRootNode_WhenThereIsOnlyOneElementInTheTree()
        {
            // Arrange
            _binarySearchTree.Insert(5);

            // Act
            // Assert
            Assert.That(_binarySearchTree.Max, Is.EqualTo(5));
            Assert.That(_binarySearchTree.Min, Is.EqualTo(5));
        }

        [Test]
        public void Find_ShouldReturnTrue_WhenItemIsPresentInTheTree()
        {
            // Arrange
            _binarySearchTree.Insert(5);
            _binarySearchTree.Insert(3);
            _binarySearchTree.Insert(4);

            // Act
            // Assert
            Assert.That(_binarySearchTree.Find(4), Is.True);
        }


        [Test]
        public void Find_ShouldReturnFalse_WhenItemIsNotPresentInTheTree()
        {
            // Arrange
            _binarySearchTree.Insert(5);
            _binarySearchTree.Insert(3);
            _binarySearchTree.Insert(4);

            // Act
            // Assert
            Assert.That(_binarySearchTree.Find(2), Is.False);
        }
    }
}
