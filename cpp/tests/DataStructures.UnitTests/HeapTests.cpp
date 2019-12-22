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

        // std::is_heap TODO

        ASSERT_EQ(1, heap->Remove());
        ASSERT_EQ(3, heap->Remove());
        ASSERT_EQ(8, heap->Remove());
        ASSERT_EQ(14, heap->Remove());
        ASSERT_EQ(18, heap->Remove());
    }
}
