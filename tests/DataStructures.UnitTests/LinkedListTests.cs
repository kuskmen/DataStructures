namespace DataStructures.UnitTests
{
    using System;
    using NUnit.Framework;
    using DataStructures.Implementations;

    [TestFixture]
    public class LinkedListTests
    {
        private LinkedList<int> _linkedList;

        [SetUp]
        public void SetUp()
        {
            _linkedList = new LinkedList<int>();
        }

        [Test]
        public void AddStart_ShouldAddItemsAtStartOfTheList()
        {
            // Arrange
            // Act
            _linkedList.AddFront(5);

            // Assert
            Assert.AreEqual(5, _linkedList.Head.Data);
        }

        [Test]
        public void AddLast_ShouldAddItemsInTheEndOfTheList()
        {
            // Arrange
            // Act
            _linkedList.AddBack(7);
            _linkedList.AddBack(6);

            // Assert
            Assert.AreEqual(6, _linkedList.Tail.Data);
        }

        [Test]
        public void Count_ShouldReturnHowManyItemsAreInTheList()
        {
            // Arrange
            // Act
            _linkedList.AddBack(7);
            _linkedList.AddFront(5);

            // Assert
            Assert.AreEqual(2, _linkedList.Count);
        }

        [Test]
        public void Indexer_WhenProvidedWithInvalidIndex_ShouldThrowArgumentException()
        {
            // Arrange
            // Act
            _linkedList.AddFront(9);

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var _ = _linkedList[-1];
            });
        }

        [Test]
        public void Indexer_WhenProvidedWithIndexBiggerThanSizeOfTheList_ShouldThrowIndexOutOfBoundException()
        {
            // Arrange
            // Act
            _linkedList.AddFront(9);

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var _ = _linkedList[2];
            });
        }

        [Test]
        public void Indexer_WhenProvidedWithValidIndex_ShouldReturnDataOfThatIndex()
        {
            // Arrange
            // Act
            _linkedList.AddFront(9);
            _linkedList.AddFront(8);
            _linkedList.AddFront(3);

            // Assert
            // adding to front will push 9 into the back hence we expect 9
            Assert.AreEqual(9, _linkedList[2]);
        }

        [Test]
        public void IsEmpty_ShouldReturnAccordinglyIfThereAreItemsInTheList()
        {
            // Arrange
            var nonEmptyList = new LinkedList<int>();

            // Act
            nonEmptyList.AddBack(3);

            // Assert
            Assert.IsTrue(_linkedList.IsEmpty);
            Assert.IsFalse(nonEmptyList.IsEmpty);
        }

        [Test]
        public void Head_ShouldAlwaysPointToFrontOfTheList()
        {
            // Arrange
            var secondList = new LinkedList<int>();

            // Act
            _linkedList.AddBack(5);
            _linkedList.AddBack(3);
            secondList.AddFront(1);
            secondList.AddFront(2);

            // Assert
            Assert.AreEqual(5, _linkedList.Head.Data);
            Assert.AreEqual(2, secondList.Head.Data);
        }
        
        [Test]
        public void Tail_ShouldAlwaysPointToTheBackOfTheList()
        {
            // Arrange
            var secondList = new LinkedList<int>();

            // Act
            _linkedList.AddFront(5);
            _linkedList.AddFront(3);
            secondList.AddBack(9);
            secondList.AddBack(7);

            // Assert
            Assert.AreEqual(5, _linkedList.Tail.Data);
            Assert.AreEqual(7, secondList.Tail.Data);
        }
    }
}
