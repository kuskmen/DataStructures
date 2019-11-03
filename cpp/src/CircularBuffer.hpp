#pragma once

// TODO: Take this from GetNativeSysInfo(LPSYSTEM_INFO) for windows or getpagesize(void) for linux

// 4KB default page size
#define _MEMORY_PAGE_SIZE 4096

template <typename _Type, unsigned int Length = _MEMORY_PAGE_SIZE / sizeof(_Type)>
class CircularBuffer
{
private:
	_Type* _elements;
	int _writeIndex = 0;
	int _readIndex = 0;
	bool _is_full = false;

public:

	explicit CircularBuffer();
	~CircularBuffer();

	const _Type Read();
	_Type Peek();
	const int GetCount();
	const bool IsEmpty();
	void Write(const _Type);
};

template<typename _Type, unsigned int Length>
CircularBuffer<_Type, Length>::CircularBuffer()
{
	_elements = (_Type*) malloc(_MEMORY_PAGE_SIZE);

	if (_elements == nullptr) 
		exit(1);
}

template<typename _Type, unsigned int Length>
CircularBuffer<_Type, Length>::~CircularBuffer()
{
	free(_elements);
}

template <typename _Type, unsigned int Length>
void CircularBuffer<_Type, Length>::Write(const _Type element)
{
	_elements[_writeIndex] = element;
	_writeIndex = (_writeIndex + 1) % Length;

	_is_full = _writeIndex == 0 && _readIndex == 0;
}

template <typename _Type, unsigned int Length>
const _Type CircularBuffer<_Type, Length>::Read()
{
	_Type ret = _elements[_readIndex];
	_readIndex = (_readIndex + 1) % Length;
	_is_full = false;
	return ret;
}


template<typename _Type, unsigned int Length>
inline _Type CircularBuffer<_Type, Length>::Peek()
{
	if(_writeIndex > 0)
		return _elements[_writeIndex - 1 % Length];
	return NULL;
}

template<typename _Type, unsigned int Length>
inline const int CircularBuffer<_Type, Length>::GetCount()
{
	if (_writeIndex > _readIndex)
		return _writeIndex - _readIndex;

	return Length - _readIndex + _writeIndex;
}

template <typename _Type, unsigned int Length>
inline const bool CircularBuffer<_Type, Length>::IsEmpty()
{
	return _writeIndex == _readIndex && !_is_full;
}
