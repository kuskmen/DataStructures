#include <iostream>

#include "CircularBuffer.hpp"
#include "HashTable.hpp"

struct Node {
};

int main()
{
    auto* stringHashTable = new HashTable<std::string>(3);
    auto* nodeHashTable = new HashTable<Node>(3);

    stringHashTable->Insert("alabala");
    stringHashTable->Insert("alabalb");
    stringHashTable->Insert("alabalc");
    stringHashTable->Remove("alabalb");

    delete stringHashTable;
}
