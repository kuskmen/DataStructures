namespace DataStructures.Abstractions
{
    using System;

    public interface IVector<T>
    {
        int Count { get; }

        int Capacity { get; }

        bool IsEmpty { get; }

        T this[int index] { get; }

        void Push(T item);

        void Insert(T item, int index);

        T Pop();

        void Delete(int index);

        void Remove(Predicate<T> predicate);

        int Find(Predicate<T> predicate);

    }
}
