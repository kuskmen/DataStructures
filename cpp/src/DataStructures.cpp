#include <iostream>

#include "CircularBuffer.hpp"

int main()
{
	auto* buffer = new CircularBuffer<int32_t>();
	
	for (size_t i = 0; i <= 1022; i++)
		buffer->Write(i);

	std::cout << buffer->GetCount() << std::endl;
	std::cout << buffer->Peek() << std::endl;

	while (!buffer->IsEmpty())
		std::cout << buffer->Read() << ", ";

	delete buffer;
}
