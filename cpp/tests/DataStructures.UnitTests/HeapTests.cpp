#include "pch.h"
#include "../../src/Heap.hpp"

namespace HeapTests
{
    TEST(HeapPropertyTest, 
        HeapPropertyWhenAddingAndRemovingShouldBeMaintaiedThroughWholeFlow) 
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
