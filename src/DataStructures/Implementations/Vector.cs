namespace DataStructures.Implementations
{
    using System;
    using DataStructures.Abstractions;

    public sealed class Vector<T> : IVector<T>
    {
        private T[] _data;
        private const int DefaultCapacity = 16;

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public bool IsEmpty => Count == 0;

        public Vector() : this(DefaultCapacity) { }

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

            _data[Count] = item;
            Count += 1;
        }

        public void Insert(T item, int index)
        {
            if(index > Count || index < 0) throw new IndexOutOfRangeException();
            if (Count == Capacity)
            {
                Capacity *= 2;
                Array.Resize(ref _data, Capacity);
            }

            Array.ConstrainedCopy(_data, index, _data, index + 1, Count - index);
            _data[index] = item;
        }

        public T Pop()
        {
            Count -= 1;
            var last = _data[Count];
            _data[Count] = default;
            return last;
        }

        public void Delete(int index)
        {
            if(index > Count || index < 0) throw new IndexOutOfRangeException();

            Array.ConstrainedCopy(_data, index + 1, _data, index, Count - index);
        }

        public void Remove(Predicate<T> predicate)
        {
            for (var i = 0; i < _data.Length; i++)
            {
                if(predicate(_data[i])) Delete(i); 
            }
        }

        public int Find(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
