using DataStructures.Abstractions;

namespace DataStructures.Implementations
{
    public class LinkedList<T> : ILinkedList<T> 
    {
        public Node<T> Head { get; }
        public Node<T> Current { get; private set; }
        public int Count { get; private set; }

        public LinkedList()
        {
            Head = new Node<T>();
            Current = Head;
        }

        public void AddLast(T data)
        {
           var newNode = new Node<T> { Data = data };
            Current.Next = newNode;
            Current = newNode;
            Count++;
        }

        public void AddStart(T data)
        {
            var newNode = new Node<T>
            {
                Data = data,
                Next = Head.Next
            };
            newNode.Next = Head.Next;
            Head.Next = newNode.Next;
            Count++;
        }
    }
}
