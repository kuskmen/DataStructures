#include "pch.h"
#include "../src/DoublyLinkedList.hpp"

namespace DoublyLinkedListTests
{
	TEST(DoublyLinkedListIsEmpty,
		IsEmptyWhenListIsCreatedWithDefaultConstructorShouldReturnTrue)
	{
		auto* list = new DoublyLinkedList<int32_t>();

		ASSERT_TRUE(list->IsEmpty());
	}

	TEST(DoublyLinkedListIsEmpty, 
		IsEmptyWhenAddedMultipleElementsShouldReturnFalse)
	{
		auto* list = new DoublyLinkedList<char>();
		list->AddBack('a');
		list->AddBack('b');
		list->AddBack('c');
		
		ASSERT_FALSE(list->IsEmpty());
	}

	TEST(DoublyLinkedListIsEmpty, 
		IsEmptyWhenAddedAndRemovedItemShouldReturnTrue)
	{
		auto* list = new DoublyLinkedList<char>();
		list->AddBack('a');
		
		ASSERT_FALSE(list->IsEmpty());

		list->RemoveFront();

		ASSERT_TRUE(list->IsEmpty());
	}

	TEST(DoublyLinkedListIsEmpty,
		IsEmptyWhenAddedAndRemovedItemFromBackShouldReturnTrue)
	{
		auto* list = new DoublyLinkedList<char>();
		list->AddBack('a');

		ASSERT_FALSE(list->IsEmpty());

		list->RemoveBack();

		ASSERT_TRUE(list->IsEmpty());
	}

	TEST(DoublyLinkedListAddFront,
		AddFrontWhenCalledMultipleTimesShouldAddElementsAtFront)
	{
		auto* list = new DoublyLinkedList<int>();
		list->AddFront(1);
		list->AddFront(2);
		list->AddFront(3);

		ASSERT_EQ(3, list->PeekFront());
	}

	TEST(DoublyLinkedListAddBack,
		AddBackWhenCalledMultipleTimesShouldAddElementsAtBack)
	{
		auto* list = new DoublyLinkedList<int>();
		list->AddBack(3);
		list->AddBack(2);
		list->AddBack(1);

		ASSERT_EQ(1, list->PeekBack());
	}

	TEST(DoublyLinkedListPeekBack, 
		PeekBackWhenMultipleItemsAreAddedShouldReturnTheTailOfTheList)
	{
		auto* list = new DoublyLinkedList<long>();
		auto expected = 1247;
		list->AddBack(1245);
		list->AddBack(1246);
		list->AddBack(expected);

		ASSERT_EQ(expected, list->PeekBack());
	}

	TEST(DoublyLinkedListPeekFront,
		PeekFrontWhenMultipleItemsAreAddedShouldReturnTheHeadOfTheList)
	{
		auto* list = new DoublyLinkedList<int16_t>();
		auto expected = 123;
		list->AddBack(expected);
		list->AddBack(124);
		list->AddBack(125);

		ASSERT_EQ(expected, list->PeekFront());
	}

	TEST(DoublyLinkedListPeekFrontAndBack,
		PeekFrontAndBackWhenThereIsOnlyOneElementShouldReturnSameResult)
	{
		auto* list = new DoublyLinkedList<int32_t>();
		list->AddBack(1);

		ASSERT_EQ(list->PeekBack(), list->PeekFront());
	}

	TEST(DoublyLinkedListRemoveElement,
		RemoveElementShouldReturnTrueIfElementIsFoundAndRemovedFromTheList)
	{
		auto* list = new DoublyLinkedList<int8_t>();
		list->AddFront(3);

		ASSERT_TRUE(list->RemoveElement(3));
		ASSERT_TRUE(list->IsEmpty());
	}

	TEST(DoublyLinkedListRemoveElement,
		RemoveElementShouldReturnFalseIfElementIsNotFoundInTheList)
	{
		auto* list = new DoublyLinkedList<int8_t>();
		list->AddFront(3);

		ASSERT_FALSE(list->RemoveElement(4));
		ASSERT_FALSE(list->IsEmpty());
	}

	TEST(DoublyLinkedListReverse,
		ReverseShouldReverseElementsInList)
	{
		auto* list = new DoublyLinkedList<int32_t>();
		
		// 1 -> 2 -> 3
		list->AddFront(3);
		list->AddFront(2);
		list->AddFront(1);

		// 3 -> 2 -> 1
		list->Reverse();

		ASSERT_EQ(3, list->RemoveFront());
		ASSERT_EQ(2, list->RemoveFront());
		ASSERT_EQ(1, list->RemoveFront());
	}
}