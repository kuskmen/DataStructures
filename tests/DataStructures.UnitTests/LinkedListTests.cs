namespace DataStructures.UnitTests
{
    using NUnit.Framework;
    using DataStructures.Implementations;

    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void AddStart_ShouldAddItemsAtStartOfTheList()
        {
            // Arrange
            var linkedList = new LinkedList<int>();

            // Act
            linkedList.AddStart(5);

            // Assert
            Assert.AreEqual(5, linkedList.Head.Data);
        }

        [Test]
        public void AddLast_ShouldAddItemsInTheEndOfTheList()
        {
            // Arrange
            var linkedList = new LinkedList<int>();

            // Act
            linkedList.AddLast(7);
            linkedList.AddLast(6);

            // Assert
            Assert.AreEqual(6, linkedList.Tail.Data);
        }

        [Test]
        public void Count_ShouldReturnHowManyItemsAreInTheList()
        {
            // Arrange
            var linkedList = new LinkedList<int>();

            // Act
            linkedList.AddLast(7);
            linkedList.AddStart(5);

            // Assert
            Assert.AreEqual(2, linkedList.Count);
        }
    }
}
