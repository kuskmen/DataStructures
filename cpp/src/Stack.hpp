#pragma once
#include "utilities.h"

template <typename Type>
class Stack
{
private:
    Type* _elements;
    int _current_index;
    const int MAX_SIZE;

public:
    explicit Stack();
    explicit Stack(size_t);
    ~Stack();

    inline const int GetCount();
    inline const bool IsEmpty();
    inline void Push(const Type&);
    inline Type Pop();
    inline const Type& Peek(int) const;
};

template<typename Type>
inline Stack<Type>::Stack() 
    : Stack(MEMORY_PAGE_SIZE / sizeof(Type))
{
}

template<typename Type>
inline Stack<Type>::Stack(size_t size) : MAX_SIZE(size)
{
    assert(size >= 0);

    _elements = new Type[MAX_SIZE];
    _current_index = 0;
}

template<typename Type>
inline Stack<Type>::~Stack()
{
    delete[] _elements;
}

template<typename Type>
inline void Stack<Type>::Push(const Type& item)
{
    assert(_current_index < MAX_SIZE);

    _elements[_current_index++] = item;
}

template<typename Type>
inline Type Stack<Type>::Pop()
{
    assert(_current_index > 0);

    return _elements[--_current_index];
}

template<typename Type>
inline const Type& Stack<Type>::Peek(int depth) const
{
    assert(depth < _current_index);

    return _elements[_current_index - (depth + 1)];
}

template<typename Type>
inline const bool Stack<Type>::IsEmpty()
{
    assert(_current_index >= 0);

    return _current_index == 0;
}

template<typename Type>
inline const int Stack<Type>::GetCount()
{
    assert(_current_index >= 0);

    return _current_index;
}
