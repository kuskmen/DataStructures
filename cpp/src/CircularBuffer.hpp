#pragma once

#include "utilities.h"

template <typename Type, unsigned int Length = MEMORY_PAGE_SIZE / sizeof(Type)>
class CircularBuffer
{
private:
	Type* _elements;
	int _writeIndex = 0;
	int _readIndex = 0;
	bool _is_full = false;

public:

	explicit CircularBuffer();
	~CircularBuffer();

	const Type Read();
	Type Peek();
	const int GetCount();
	const bool IsEmpty();
	void Add(const Type);
};

template<typename Type, unsigned int Length>
CircularBuffer<Type, Length>::CircularBuffer()
{
	_elements = (Type*) malloc(MEMORY_PAGE_SIZE);

	if (_elements == nullptr) 
		exit(1);
}

template<typename Type, unsigned int Length>
CircularBuffer<Type, Length>::~CircularBuffer()
{
	free(_elements);
}

template <typename Type, unsigned int Length>
void CircularBuffer<Type, Length>::Add(const Type element)
{
	_elements[_writeIndex] = element;
	_writeIndex = (_writeIndex + 1) % Length;

	_is_full = _writeIndex == 0 && _readIndex == 0;
}

template <typename Type, unsigned int Length>
const Type CircularBuffer<Type, Length>::Read()
{
	Type ret = _elements[_readIndex];
	_readIndex = (_readIndex + 1) % Length;
	_is_full = false;
	return ret;
}


template<typename Type, unsigned int Length>
inline Type CircularBuffer<Type, Length>::Peek()
{
	if(_writeIndex > 0)
		return _elements[_writeIndex - 1 % Length];
	return NULL;
}

template<typename Type, unsigned int Length>
inline const int CircularBuffer<Type, Length>::GetCount()
{
	if (_writeIndex > _readIndex)
		return _writeIndex - _readIndex;

	return Length - _readIndex + _writeIndex;
}

template <typename Type, unsigned int Length>
inline const bool CircularBuffer<Type, Length>::IsEmpty()
{
	return _writeIndex == _readIndex && !_is_full;
}
