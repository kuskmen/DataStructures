namespace DataStructures.UnitTests
{
    using NUnit.Framework;
    using DataStructures.Implementations;

    [TestFixture]
    public class QueueTests
    {
        private Queue<int> _queue;

        [SetUp]
        public void SetUp()
        {
            _queue = new Queue<int>();
        }

        [Test]
        public void Enqueue_ShouldAddItemToTheQueueAtTheFront()
        {
            // Arrange
            _queue.Enqueue(3);

            // Act
            // Assert
            Assert.IsFalse(_queue.IsEmpty);
        }

        [Test]
        public void Dequeue_ShouldReturnItemThatWasFirstAddedToTheQueue()
        {
            // Arrange
            _queue.Enqueue(3);
            _queue.Enqueue(4);
            _queue.Enqueue(5);
            
            // Act
            var actual = _queue.Dequeue();

            // Assert
            Assert.AreEqual(3, actual);
        }
    }
}
