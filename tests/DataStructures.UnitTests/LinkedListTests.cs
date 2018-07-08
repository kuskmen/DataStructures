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
        public void PopFront_WhenThereIsNoItemsInTheList_ShouldThrowOperationException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => _linkedList.PopFront());
        }

        [Test]
        public void PopFront_WhenThereAreItemsInTheList_ShouldReturnTheHeadOfTheList()
        {
            // Arrange
            // Act
            _linkedList.AddFront(5);
            _linkedList.AddFront(3);

            // Assert
            Assert.AreEqual(3, _linkedList.PopFront());
        }

        [Test]
        public void PopFromEnd_WhenListIsEmty_ShouldThrowInvalidOperationException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => _linkedList.PopFromEnd(3));
        }

        [Test]
        public void PopFromEnd_WhenIndexIsLargerThanItemsInList_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            _linkedList.AddFront(2);

            // Act
            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => _linkedList.PopFromEnd(3));
        }

        [TestCase(new[] { 1 }, 1)]
        [TestCase(new[] { 1, 2, 3 }, 2)]
        public void PopFromEnd_ShouldPopItemThatIsIndexItemsFromBackOfTheList(int[] items, int expected)
        {
            // Arrange
            foreach (var item in items)
            {
                _linkedList.AddFront(item);
            }

            // Act
            // Assert
            Assert.AreEqual(expected, _linkedList.PopFromEnd(1));
        }

        [Test]
        public void PopBack_WhenThereIsNoItemsInTheList_ShouldThrowOperationException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => _linkedList.PopBack());
        }

        [Test]
        public void PopBack_WhenThereAreItemsInTheList_ShouldReturnTheBackdOfTheList()
        {
            // Arrange
            // Act
            _linkedList.AddFront(5);
            _linkedList.AddFront(3);

            // Assert
            Assert.AreEqual(5, _linkedList.PopBack());
        }

        [Test]
        public void AddLast_ShouldAddItemsInTheEndOfTheList()
        {
            // Arrange
            // Act
            _linkedList.AddBack(7);
            _linkedList.AddBack(6);

            // Assert
            Assert.AreEqual(6, _linkedList.Tail());
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
        public void Reverse_ShouldReverseTheListWhenItIsNotEmpty()
        {
            // Arrange
            var items = new[] { 1, 2, 3 };
            foreach (var item in items)
            {
                _linkedList.AddBack(item);
            }

            // Act
            _linkedList.Reverse();

            // Assert
            var current = _linkedList.Head;
            var index = items.Length - 1;
            while (current.Next != null && index >= 0)
            {
                Assert.AreEqual(items[index], current.Data);
                index--;
                current = current.Next;
            }
        }

        [Test]
        public void Reverse_WhenListIsEmpty_ShouldNotThrowException()
        {
            // Arrange
            // Act
            // Assert
            Assert.DoesNotThrow(() => _linkedList.Reverse());
        }

        [Test]
        public void InsertAt_WhenIndexIsOutOfRange_ShouldThrowOutOfRangeException()
        {
            // Arrange
            // Act
            _linkedList.AddFront(3);

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => _linkedList.InsertAt(5, 7));
        }

        [Test]
        public void InsertAt_ShouldInsertItemAtGiveIndex()
        {
            // Arrange
            _linkedList.AddFront(1);
            _linkedList.AddFront(2);
            _linkedList.AddFront(3);

            // Act
            _linkedList.InsertAt(4, 1);

            // Assert
            Assert.AreEqual(4, _linkedList.Head.Next.Data);
        }

        [Test]
        public void EraseAt_WhenIndexIsOutOfRange_ShouldThrowOutOfRangeException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => _linkedList.EraseAt(8));
        }

        [Test]
        public void EraseAt_ShouldEraseItemAtGivenIndex()
        {
            // Arrange
            _linkedList.AddFront(1);
            _linkedList.AddFront(2);
            _linkedList.AddFront(3);

            // Act
            _linkedList.EraseAt(1);

            // Assert
            Assert.AreEqual(1, _linkedList.Head.Next.Data);
        }

        [Test]
        public void Remove_ShouldReturnFalseWhenListIsEmptyOrThereIsNoSuchItem()
        {
            // Arrange
            var emptyList = new LinkedList<int>();
            _linkedList.AddFront(3);

            // Act
            // Assert
            Assert.IsFalse(emptyList.Remove(i => i == 5));
            Assert.IsFalse(_linkedList.Remove(i => i == 5));
        }

        [TestCase(new[] { 5 }, 5)]
        [TestCase(new[] { 1, 2, 3 }, 3)]
        public void Remove_ShouldReturnTrueIfItemIsPresentInTheList(int[] items, int expected)
        {
            // Arrange
            foreach (var item in items)
            {
                _linkedList.AddFront(item);
            }

            // Act
            // Assert
            Assert.IsTrue(_linkedList.Remove(i => i == expected));
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
            Assert.AreEqual(5, _linkedList.Tail());
            Assert.AreEqual(7, secondList.Tail());
        }
    }
}
