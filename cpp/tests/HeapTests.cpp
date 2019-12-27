#include "pch.h"
#include "../src/Heap.hpp"

namespace HeapTests
{
    class HeapTests : public ::testing::Test
    {
    protected:
        Heap<int32_t>* sut_;

    };

    TEST_F(HeapTests,
        HeapPropertyWhenAddingShouldBeMaintaiedThroughWholeFlow) 
    {
        auto* heap = new Heap<int32_t>(5);

        heap->Add(1);
        heap->Add(18);
        heap->Add(14);
        heap->Add(8);
        heap->Add(3);

        //          1
        //         / \
        //        3  14
        //       / \
        //      18  8

        ASSERT_TRUE(std::is_heap(heap->begin(), heap->end(), std::greater<>()));
    }
}
