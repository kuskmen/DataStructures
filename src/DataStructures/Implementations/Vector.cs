using System;

namespace DataStructures.Implementations
{
    using DataStructures.Abstractions;

    public sealed class Vector<T> : IVector<T>
    {
        private T[] _data;

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public bool IsEmpty => Count == 0;

        public Vector()
        {
            _data = new T[16];
            Count = 0;
            Capacity = 16;
        }

        public Vector(int capacity)
        {
            _data = new T[capacity];
            Count = 0;
            Capacity = capacity;
        }

        public T this[int index]
        {
            get
            {
                if(index > Count || index < 0) throw new IndexOutOfRangeException();
                return _data[index];
            } 
        }

        public void Push(T item)
        {
            if (Count == Capacity)
            {
                Capacity *= 2;
                Array.Resize(ref _data, Capacity);
            }

            Count += 1;
            _data[Count] = item;
        }

        public void Insert(T item, int index)
        {
            if(index > Count || index < 0) throw new IndexOutOfRangeException();
             
        }

        public T Pop()
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public void Remove(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
