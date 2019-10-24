#pragma once

template <typename _Type, unsigned int _Length = 4>
class CircularBuffer
{
private:
	_Type _elements[_Length];
	int _writeIndex = 0;
	int _readIndex = 0;

public:
	const _Type Read();
	void Write(const _Type);
};

template <typename _Type, unsigned int _Length>
void CircularBuffer<_Type, _Length>::Write(const _Type element)
{
	_elements[_writeIndex] = element;
	_writeIndex = (_writeIndex + 1) % _Length;
}

template <typename _Type, unsigned int _Length>
const _Type CircularBuffer<_Type, _Length>::Read()
{
	_Type ret = _elements[_readIndex];
	_readIndex = (_readIndex + 1) % _Length;
	return ret;
}