#include "pch.h"
#include "../src/CircularBuffer.hpp"

namespace CircularBufferTests
{
	TEST(CircularBuffer, DefaultConstructor)
	{
		auto* ring = new CircularBuffer<int32_t>();

		ASSERT_TRUE(ring->IsEmpty());
	}

	TEST(CircularBufferIsEmpty, IsEmptyTest)
	{
		auto* ring = new CircularBuffer<int32_t>(3);
		ring->Add(1);
		ring->Add(2);

		ASSERT_FALSE(ring->IsEmpty());
	}

	TEST(CircularBufferIsEmpty, 
		IsEmptyTestWhenInternalReadWritePointersOverlap)
	{
		auto* ring = new CircularBuffer<int32_t>(2);
		ring->Add(1);
		ring->Add(2);

		ASSERT_FALSE(ring->IsEmpty());
	}

	TEST(CircularBufferIsEmpty, 
		IsEmptyTestWhenReadingInternalIsFullStateShouldBeUpdatedAsWell)
	{
		auto* ring = new CircularBuffer<int32_t>(2);
		ring->Add(1);
		ring->Add(2);

		ring->Read();
		ring->Read();

		ASSERT_TRUE(ring->IsEmpty());
	}

	TEST(CircularBufferIsEmpty, 
		IsEmptyTestShouldNotBeAffectedByPeeking)
	{
		auto* ring = new CircularBuffer<int32_t>(1);
		ring->Add(1);

		ring->Peek();

		ASSERT_FALSE(ring->IsEmpty());
	}

	TEST(CircularBufferGetCount, 
		GetCountTestWhenWritePointerIsBiggerThanReadPointer)
	{
		auto* ring = new CircularBuffer<int32_t>(1);
		ring->Add(1);

		ASSERT_EQ(1, ring->GetCount());
	}

	TEST(CircularBufferGetCount, 
		GetCountTestWhenReadPointerIsBiggerTHanWritePointer)
	{
		auto* ring = new CircularBuffer<int32_t>(3);
		ring->Add(1);
		ring->Add(2);
		ring->Add(3);
		ring->Read();
		ring->Add(4);

		ASSERT_EQ(3, ring->GetCount());
	}
}