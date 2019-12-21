#pragma once
#include "utilities.h"

template <typename Type>
class Stack
{
public:
    Stack();
    Stack(size_t);
    Stack(const Stack<Type>&);
    ~Stack();

    inline void Push(const Type&);
    inline Type Pop();
    inline const Type& Peek(int) const;

protected:
    Type* data;
    int current;
    const int MAX_SIZE;        
};

template<typename Type>
inline Stack<Type>::Stack() : this(MEMORY_PAGE_SIZE / size(Type))
{
}

template<typename Type>
inline Stack<Type>::Stack(size_t size) : MAX_SIZE(size)
{
    current = 0;
}

template<typename Type>
inline Stack<Type>::Stack(const Stack<Type>& other)
{
}

template<typename Type>
inline Stack<Type>::~Stack()
{
    delete[] data;
}

template<typename Type>
inline void Stack<Type>::Push(const Type& item)
{
    std::assert(current < MAX_SIZE);

    data[current++] = item;
}

template<typename Type>
inline Type Stack<Type>::Pop()
{
    std::assert(current > 0);

    return data[--current];
}

template<typename Type>
inline const Type& Stack<Type>::Peek(int depth) const
{
    std::assert(depth < current);

    return data[current - (depth + 1)];
}
