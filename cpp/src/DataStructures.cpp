#include <iostream>

#include "CircularBuffer.hpp"

int main()
{
	auto* buffer = new CircularBuffer<int, 5>();

	for (size_t i = 0; i < 15; i++)
	{
		buffer->Write(i);
	}

	while (true)
		std::cout << buffer->Read() << std::endl;

	delete buffer;
}
