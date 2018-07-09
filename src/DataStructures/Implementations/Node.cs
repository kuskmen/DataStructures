namespace DataStructures.Implementations
{
    public sealed class Node<T>
    {
        public Node<T> Next { get; set; }

        public T Data { get; set; }
    }
}
