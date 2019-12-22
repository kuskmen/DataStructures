#pragma once

template <typename Type>
struct DoublyLinkedListNode
{
public:
	Type data;
	DoublyLinkedListNode<Type>* next;
	DoublyLinkedListNode<Type>* previous;
};

template <typename Type>
class DoublyLinkedList
{
private:
	DoublyLinkedListNode<Type>* _head;
    DoublyLinkedListNode<Type>* _tail;
    void removeNode(DoublyLinkedListNode<Type>*);

public:
	explicit DoublyLinkedList();
    ~DoublyLinkedList();

    void AddBack(const Type);
    void AddFront(const Type);
    
    bool RemoveElement(Type);
    DoublyLinkedListNode<Type>* RemoveFront();
    DoublyLinkedListNode<Type>* RemoveBack();
    
    inline const DoublyLinkedListNode<Type>* PeekBack() const;
    inline const DoublyLinkedListNode<Type>* PeekFront() const;
	
    inline const bool IsEmpty() const;
    void Reverse();
};

template<typename Type>
inline DoublyLinkedList<Type>::DoublyLinkedList()
{
	_head = nullptr;
    _tail = _head;
}

template<typename Type>
inline DoublyLinkedList<Type>::~DoublyLinkedList()
{
    delete _head;
    delete _tail;
}

template<typename Type>
void DoublyLinkedList<Type>::AddBack(const Type element)
{
    auto* new_node = new DoublyLinkedListNode<Type>();
    new_node->data = element;
    new_node->next = nullptr;

    auto* old_tail = _tail;
    _tail = new_node;

    if (_head == nullptr)
    {
        new_node->previous = nullptr;
        _head = _tail;
        return;
    }
    
    old_tail->next = _tail;
    _tail->previous = old_tail;
}

template<typename Type>
void DoublyLinkedList<Type>::AddFront(const Type element)
{
    auto* new_node = new DoublyLinkedListNode<Type>();
    new_node->data = element;
    new_node->previous = nullptr;

    auto* old_head = _head;
    _head = new_node;

    if (_tail == nullptr)
    {
        new_node->next = nullptr;
        _tail = _head;
        return;
    }

    old_head->previous = _head;
    _head->next = old_head;
}

template<typename Type>
inline const DoublyLinkedListNode<Type>* DoublyLinkedList<Type>::PeekBack() const
{
    return _tail;
}

template<typename Type>
inline const DoublyLinkedListNode<Type>* DoublyLinkedList<Type>::PeekFront() const
{
    return _head;
}

template<typename Type>
inline const bool DoublyLinkedList<Type>::IsEmpty() const
{
	return _head == nullptr;
}

template<typename Type>
bool DoublyLinkedList<Type>::RemoveElement(Type element)
{
    auto* current = _head;
    while (current != nullptr && current->data != element)
        current = current->next;

    if (current != nullptr)
    {
        removeNode(current);
        return true;
    }
    else
        return false;
}

template<typename Type>
DoublyLinkedListNode<Type>* DoublyLinkedList<Type>::RemoveBack()
{
    if (_tail == nullptr)
        return nullptr;
    else
    {
        if (_tail == _head)
            _head = nullptr;

        auto* result = _tail;
        _tail = _tail->previous;
        return result;
    }
}

template<typename Type>
DoublyLinkedListNode<Type>* DoublyLinkedList<Type>::RemoveFront()
{
    if (_head == nullptr)
        return nullptr;
    else
    {
        auto* result = _head;
        _head = _head->next;
        return result;
    }
}

template<typename Type>
void DoublyLinkedList<Type>::Reverse()
{
    auto* current = _tail;

    while (current != nullptr)
    {
        auto* temp = current->next;
        current->next = current->previous;
        current->previous = temp;

        current = current->next;
    }

    auto* temp = _tail;
    _tail = _head;
    _head = temp;
}

template<typename Type>
void DoublyLinkedList<Type>::removeNode(DoublyLinkedListNode<Type>* node)
{
    if (node->previous == nullptr)
        _head = node->next;
    else
        node->previous->next = node->next;
    if (node->next == nullptr)
        _tail = node->previous;
    else
        node->next->previous = node->previous;
}


