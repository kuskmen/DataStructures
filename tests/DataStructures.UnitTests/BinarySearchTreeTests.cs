namespace DataStructures.UnitTests
{
    using System;
    using DataStructures.Implementations;
    using NUnit.Framework;

    [TestFixture]
    public class BinarySearchTreeTests
    {
        private BinarySearchTree<int> _binarySearchTree;
        private readonly Comparison<int> _comparison = (x, y) => x > y ? 1 : x < y ? -1 : 0;

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
            Assert.That(_binarySearchTree.Find(4, out var searchedNode), Is.True);
            Assert.That(searchedNode.Data, Is.EqualTo(4));
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
            Assert.That(_binarySearchTree.Find(2, out _), Is.False);
        }

        [Test]
        public void Successor_ShouldReturnNextGreaterElementInTheTree_WhenThereIsSuchOtherwiseReturnDefault()
        {
            // Arrange
            _binarySearchTree.Insert(5);
            _binarySearchTree.Insert(3);
            _binarySearchTree.Insert(4);

            // Act
            // Assert
            Assert.That(_binarySearchTree.Successor(4), Is.EqualTo(5));
            Assert.That(_binarySearchTree.Successor(7), Is.EqualTo(default(int)));
        }

        [Test]
        public void Successor_ShouldReturnDefault_WhenThereIsNoGreaterElementInTheTree()
        {
            // Arrange
            _binarySearchTree.Insert(5);
            _binarySearchTree.Insert(6);
            _binarySearchTree.Insert(7);

            // Act
            // Assert
            Assert.That(_binarySearchTree.Successor(7), Is.EqualTo(default(int)));
        }

        [Test]
        public void Successor_ShouldReturnNextGreaterElementInTheTree_WhenNodeHaveLeftSubtree()
        {
            // Arrange
            _binarySearchTree.Insert(8);
            _binarySearchTree.Insert(3);
            _binarySearchTree.Insert(4);
            _binarySearchTree.Insert(6);
            _binarySearchTree.Insert(5);

            // Act
            // Assert
            Assert.That(_binarySearchTree.Successor(4), Is.EqualTo(5));
        }

        [Test]
        public void Delete_ShouldSimplyDeleteElement_WhenElementIsLeaf()
        {
            // Arrange
            _binarySearchTree.Insert(5);
            _binarySearchTree.Insert(4);

            // Act
            _binarySearchTree.Delete(4);
            
            // Assert
            Assert.That(_binarySearchTree.Find(4, out _), Is.False);
        }

        [Test]
        public void Delete_ShouldSwapPointersOfBothChildAndParent_WhenElementHaveOnlyLeftSubtree()
        {
            // Arrange
            _binarySearchTree.Insert(5);
            _binarySearchTree.Insert(7);
            _binarySearchTree.Insert(6);

            // Act
            _binarySearchTree.Delete(7);

            // Assert
            Assert.That(_binarySearchTree.Find(7, out _), Is.False);
            Assert.That(_binarySearchTree.Find(6, out var movedNode), Is.True);
            Assert.That(_binarySearchTree.Find(5, out var root), Is.True);
            Assert.That(movedNode.Parent, Is.EqualTo(root));
            Assert.That(root.Right, Is.EqualTo(movedNode));
        }


        [Test]
        public void Delete_ShouldSwapPointersOfBothChildAndParent_WhenElementHaveOnlyRightSubtree()
        {
            // Arrange
            _binarySearchTree.Insert(5);
            _binarySearchTree.Insert(3);
            _binarySearchTree.Insert(4);

            // Act
            _binarySearchTree.Delete(3);

            // Assert
            Assert.That(_binarySearchTree.Find(3, out _), Is.False);
            Assert.That(_binarySearchTree.Find(4, out var movedNode), Is.True);
            Assert.That(_binarySearchTree.Find(5, out var root), Is.True);
            Assert.That(movedNode.Parent, Is.EqualTo(root));
            Assert.That(root.Left, Is.EqualTo(movedNode));
        }
    }
}
