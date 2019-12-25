#pragma once

#include "utilities.h"

template <typename Type>
class Heap
{
private:
	Type* _elements;
	const unsigned int _size;
	unsigned int _first_free_index;

	inline unsigned int parent(unsigned int);
	inline unsigned int left(unsigned int);
	inline unsigned int right(unsigned int);

	void upheap(Type);
	void downheap(Type);

public:
	explicit Heap();
	explicit Heap(size_t);
	~Heap();

	inline Type* begin() const { return _elements; }
	inline Type* end() const { return _elements + _size; }

	void Add(const Type);
	Type Remove();
};

template<typename Type>
inline unsigned int Heap<Type>::parent(unsigned int index)
{
	return index % 2 == 0 ? index / 2 - 1 : index / 2;
}

template<typename Type>
inline unsigned int Heap<Type>::left(unsigned int index)
{
	return index * 2 + 1;
}

template<typename Type>
inline unsigned int Heap<Type>::right(unsigned int index)
{
	return left(index) + 1;
}

template<typename Type>
void Heap<Type>::upheap(Type element)
{
	if (_first_free_index == 0)
		_elements[_first_free_index] = element;
	else
	{
		unsigned int index = _first_free_index;
		while (index > 0)
		{
			unsigned int current_index = index;

			index = parent(index);
			if (_elements[index] > element)
			{
				Type greater = _elements[index];
				_elements[index] = element;
				_elements[current_index] = greater;
			}
			else
				_elements[current_index] = element;

			// maintain the heap property
			assert(_elements[index] < _elements[current_index]);
		}
	}

	_first_free_index++;

	assert(_first_free_index <= _size);
}

template<typename Type>
void Heap<Type>::downheap(Type element)
{
	// starting from root
	unsigned int index = 0;
	unsigned int left_index = left(index);
	unsigned int right_index = right(index);

	while (index < _first_free_index
		&& left_index < _first_free_index
		&& right_index < _first_free_index
		&& (_elements[left_index] < element
			|| _elements[right_index] < element))
	{
		if (_elements[left_index] < _elements[right_index])
		{
			std::swap(_elements[index], _elements[left_index]);
			index = left_index;
		}
		else
		{
			std::swap(_elements[index], _elements[right_index]);
			index = right_index;
		}

		// maintain the heap property
		assert(_elements[left_index] > _elements[parent(left_index)]
			&& _elements[right_index] > _elements[parent(right_index)]);

		left_index = left(index);
		right_index = right(index);
	}
}

template<typename Type>
inline Heap<Type>::Heap()
	: Heap(MEMORY_PAGE_SIZE / sizeof(Type))
{
}

template<typename Type>
inline Heap<Type>::Heap(size_t size)
	: _first_free_index(0), _size(size)
{
	assert(size >= 0);

	_elements = new Type[size];
}

template<typename Type>
inline Heap<Type>::~Heap()
{
	delete[] _elements;
}

template<typename Type>
void Heap<Type>::Add(const Type element)
{
	return upheap(element);
}

template<typename Type>
Type Heap<Type>::Remove()
{
	if (_first_free_index > 0)
	{
		std::swap(_elements[0], _elements[--_first_free_index]);

		downheap(_elements[0]);
		return _elements[_first_free_index];
	}
	else
		return default_type();
}
