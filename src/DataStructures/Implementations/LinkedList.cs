namespace DataStructures.Implementations
{
    using DataStructures.Abstractions;

    public class LinkedList<T> : ILinkedList<T> 
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }

        public LinkedList()
        {
            Head = new Node<T>();
            Tail = Head;
        }

        public void AddLast(T data)
        {
           var newNode = new Node<T> { Data = data };
            Tail.Next = newNode;
            Tail = newNode;
            Count++;
        }

        public void AddStart(T data)
        {
            var newNode = new Node<T>
            {
                Data = data,
                Next = Head
            };
            Head = newNode;
            Count++;
        }
    }
}
