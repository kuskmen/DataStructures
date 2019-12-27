#pragma once

#include <vector>
#include <list>
#include <algorithm>
#include <string>

template <typename Type>
class HashTable
{
 private:
    std::vector<std::list<Type>> _elements;

    int Prehash(Type) const;

 public:
    explicit HashTable(size_t);

    void Insert(Type);
    void Remove(Type);
};

template<typename Type>
int HashTable<Type>::Prehash(Type) const
{
    static_assert(sizeof(Type) == 0,
        "Only specializations of Prehash can be used.");

    return 0;
}

template<>
int HashTable<std::string>::Prehash(std::string element) const
{
    std::hash<std::string> _hash{};
    return _hash(element) % _elements.size();
}

template<typename Type>
HashTable<Type>::HashTable(size_t length)
{
    assert(length >= 0);

    for (int i = 0; i < length; ++i)
        _elements.push_back(std::list<Type>{});
}

template<typename Type>
void HashTable<Type>::Insert(Type element)
{
    int hash = Prehash(element);

    _elements[hash].emplace_front(element);
}

template<typename Type>
void HashTable<Type>::Remove(Type element)
{
    int hash = Prehash(element);

    _elements[hash].erase(
        std::remove(_elements[hash].begin(),
                    _elements[hash].end(),
                    element),
        _elements[hash].end());
}
