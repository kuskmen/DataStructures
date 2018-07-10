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
            Assert.AreEqual(2, smallSizeVector.Capacity * 2);
        }
    }
}
