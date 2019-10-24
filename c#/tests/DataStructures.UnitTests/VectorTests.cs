using System;
using DataStructures.Implementations;
using NUnit.Framework;

namespace DataStructures.UnitTests
{
    [TestFixture]
    public class VectorTests
    {
        private Vector<int> _vector;

        [SetUp]
        public void SetUp()
        {
            _vector = new Vector<int>();
        }

        [Test]
        public void IsEmpty_ShouldReturnTrueWhenVectorIsEmptyAndFalseWhenItIsNot()
        {
            // Arrange
            _vector.Push(1);

            // Act
            // Assert
            Assert.IsFalse(_vector.IsEmpty);
            Assert.IsTrue(new Vector<int>().IsEmpty);
        }

        [Test]
        public void Indexer_ShouldReturnItemAtGivenIndex()
        {
            // Arrange
            _vector.Push(2);

            // Act
            var actual = _vector[0];

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestCase(2)]
        [TestCase(-1)]
        public void Indexer_WhenIndexIsInvalidOrLowerThanNumberOfItemsInVector_ShouldThrowException(int index)
        {
            // Arrange
            _vector.Push(3);

            // Act
            // Assert
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var _ = _vector[index];
            });
        }

        [Test]
        public void Push_WhenTheIsEnoughCapacityInTheVector_ShouldInsertItemAtTheBackOfTheVectorAndIncrementCount()
        {
            // Arrange
            _vector.Push(3);
            _vector.Push(5);

            // Act
            // Assert
            Assert.AreEqual(5, _vector[1]);
            Assert.AreEqual(2, _vector.Count);
        }

        [Test]
        public void Push_WhenTheIsNotEnoughCapacityInTheVector_ShouldResizeTheVectorAndThenInsertTheItemAtTheBack()
        {
            // Arrange
            const int initialCapacity = 1;
            var smallSizeVector = new Vector<int>(initialCapacity);
            Assert.AreEqual(1, smallSizeVector.Capacity);

            // Act
            smallSizeVector.Push(3);
            smallSizeVector.Push(4);

            // Assert
            Assert.AreEqual(2, smallSizeVector.Capacity);
        }

        [Test]
        public void Insert_WhenIndexIsNotValid_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => _vector.Insert(1, -5));
        }

        [Test]
        public void Insert_WhenIndexIsValid_ShouldInsertTheItemAtSpecifiedIndex()
        {
            // Arrange
            _vector.Push(0);
            _vector.Push(2);

            // Act
            _vector.Insert(1, 1);

            // Assert
            for (var i = 0; i < _vector.Count; i++)
            {
                Assert.AreEqual(i, _vector[i]);
            }
        }

        [Test]
        public void Insert_WhenIndexIsValidAndThereIsNoCapacity_ShouldFirstResizeTheVectorThenInsertIt()
        {
            // Arrange
            var smallSizeVector = new Vector<int>(1);
            smallSizeVector.Push(1);

            // Act
            smallSizeVector.Insert(2, 1);

            // Assert
            Assert.AreEqual(2, smallSizeVector.Capacity);
            Assert.AreEqual(2, smallSizeVector[1]);
        }

        [Test]
        public void Pop_ShouldReturnLastElementFromTheVectorInEmptyVectorThisIsDefaultValue()
        {
            // Arrange
            _vector.Push(1);
            _vector.Push(5);

            // Act
            // Assert
            Assert.AreEqual(5, _vector.Pop());
        }

        [Test]
        public void Delete_WhenIndexIsValid_ShouldDeleteElementAtGivenIndexAndShiftAllElementLeft()
        {
            // Arrange
            _vector.Push(7);
            _vector.Push(1);
            _vector.Push(2);

            // Act
            _vector.Delete(1);

            // Assert
            Assert.AreEqual(2, _vector.Count);
            Assert.AreEqual(7, _vector[0]);
            Assert.AreEqual(2, _vector[1]);
        }

        [Test]
        public void Delete_WhenIndexIsInvalid_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => _vector.Delete(-5));
        }

        [Test]
        public void Remove_ShouldRemoveAllItemsFromVectorThatSatisfiesGivenPredicate()
        {
            // Arrange
            _vector.Push(6);
            _vector.Push(5);
            _vector.Push(9);
            _vector.Push(3);

            // Act
            _vector.Remove(item => item > 4);

            // Assert
            Assert.AreEqual(1, _vector.Count);
            Assert.AreEqual(3, _vector[0]);
        }

        [Test]
        public void Find_ShouldReturnIndexOfTheFirstItemThatSatisfiesGivenPredicate()
        {
            // Arrange
            _vector.Push(10);
            _vector.Push(5);

            // Act
            // Assert
            Assert.AreEqual(1, _vector.Find(item => item < 10));
        }

        [Test]
        public void Find_ShouldReturnMinusOneIfThereIsNoItemThatSatisfiesGivenPredicate()
        {
            // Arrange
            _vector.Push(10);
            _vector.Push(5);

            // Act
            // Assert
            Assert.AreEqual(-1, _vector.Find(item => item > 10));
        }
    }
}
