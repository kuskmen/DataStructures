#pragma once

#include "utilities.h"

template <typename Type>
class CircularBuffer
{
private:
	Type* _elements;
	int _writeIndex;
	int _readIndex;
	bool _is_full;
	const int SIZE;

public:

	explicit CircularBuffer();
	explicit CircularBuffer(size_t);
	~CircularBuffer();

	void Add(const Type);
	
	Type Read();
	inline Type Peek() const;
	
	inline int GetCount() const;
	inline bool IsEmpty() const;
};

template<typename Type>
inline CircularBuffer<Type>::CircularBuffer() 
	: CircularBuffer(MEMORY_PAGE_SIZE / sizeof(Type))
{
}

template<typename Type>
inline CircularBuffer<Type>::CircularBuffer(size_t size)
	: SIZE(size), _writeIndex(0), _readIndex(0), _is_full(false)
{
	assert(size >= 0);

	_elements = new Type[SIZE];
}

template<typename Type>
inline CircularBuffer<Type>::~CircularBuffer()
{
	delete[] _elements;
}

template <typename Type>
void CircularBuffer<Type>::Add(const Type element)
{
	assert(_writeIndex >= 0 && _writeIndex <= SIZE);

	_elements[_writeIndex] = element;
	_writeIndex = (_writeIndex + 1) % SIZE;

	assert(_writeIndex >= 0 && _writeIndex <= SIZE);

	_is_full = _writeIndex == 0 && _readIndex == 0;
}

template <typename Type>
Type CircularBuffer<Type>::Read()
{
	assert(_readIndex >= 0 && _readIndex <= SIZE);

	Type ret = _elements[_readIndex];
	_readIndex = (_readIndex + 1) % SIZE;
	
	assert(_readIndex >= 0 && _readIndex <= SIZE);

	_is_full = _writeIndex != 0 || _readIndex != 0;
	return ret;
}

template<typename Type>
inline Type CircularBuffer<Type>::Peek() const
{
	if(_writeIndex > 0)
		return _elements[_writeIndex - 1 % SIZE];
	return default_type();
}

template<typename Type>
inline int CircularBuffer<Type>::GetCount() const
{
	if (_writeIndex > _readIndex)
		return _writeIndex - _readIndex;

	return SIZE - _readIndex + _writeIndex;
}

template <typename Type>
inline bool CircularBuffer<Type>::IsEmpty() const
{
	return _writeIndex == _readIndex && !_is_full;
}
