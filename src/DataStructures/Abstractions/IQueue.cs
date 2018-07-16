﻿namespace DataStructures.Abstractions
{
    public interface IQueue<T>
    {
        bool IsEmpty { get; }

        void Enqueue(T item);

        T Dequeue();
    }
}
