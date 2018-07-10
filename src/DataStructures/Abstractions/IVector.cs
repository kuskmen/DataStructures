using System;

namespace DataStructures.Abstractions
{
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

        void Remove(Func<T, bool> predicate);

        int Find(Func<T, bool> predicate);

    }
}
