namespace DataStructures.UnitTests
{
    using NUnit.Framework;
    using DataStructures.Implementations;

    [TestFixture]
    public class QueueTests
    {
        private Queue<int> _queue;
        private ArrayQueue<int> _arrayQueue;

        [SetUp]
        public void SetUp()
        {
            _queue = new Queue<int>();
            _arrayQueue = new ArrayQueue<int>();
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

        [Test]
        public void EnqueueForArrayQueue_ShouldAddItemToTeQueue()
        {
            // Arrange
            _arrayQueue.Enqueue(3);

            // Act
            // Assert
            Assert.IsFalse(_arrayQueue.IsEmpty);
        }

        [Test]
        public void Dequeue_ShouldReturnItemThatWasMostRecentlyAddedToTheQueue()
        {
            // Arrange
            _arrayQueue.Enqueue(3);
            Assert.IsFalse(_arrayQueue.IsEmpty);

            // Act
            var actual = _arrayQueue.Dequeue();

            // Assert
            Assert.AreEqual(3, actual);
        }

        [TestCase(new int[0], true)]
        [TestCase(new[] {1}, false)]
        public void IsEmptyForArrayQueue_ShouldReturnValueAccordingly(int[] items, bool expected)
        {
            // Arrange
            foreach (var item in items)
            {
                _arrayQueue.Enqueue(item); 
            }

            // Act
            // Assert
            Assert.AreEqual(_arrayQueue.IsEmpty, expected);
        }

        [TestCase(new [] { 1 }, false, 3)]
        [TestCase(new [] { 1 }, true, 1)]
        public void IsFullForArrayQueue_ShouldReturnValueAccordingly(int[] items, bool expected, int size)
        {
            // Arrange
            var arrayQueue = new ArrayQueue<int>(size);

            // Act
            foreach (var item in items)
            {
                arrayQueue.Enqueue(item);    
            }

            // Assert
            Assert.AreEqual(expected, arrayQueue.IsFull);
        }
    }
}
