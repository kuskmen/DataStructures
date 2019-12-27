#include "pch.h"
#include "../src/Stack.hpp"

namespace StackTests 
{
    TEST(Stack, DefaultConstructor) 
    {
        auto* stack = new Stack<int32_t>();

        ASSERT_EQ(0, stack->GetCount());
        ASSERT_TRUE(stack->IsEmpty());
    }

    TEST(StackIsEmpty,
        IsEmptyWhenAddingItemsShouldReturnFalse)
    {
        auto* stack = new Stack<int32_t>();
        stack->Push(1);
        stack->Push(2);
        
        ASSERT_FALSE(stack->IsEmpty());
    }

    TEST(SackIsEmpty,
        IsEmptyWhenAddingItemsAndRemovingThemShouldReturnTrue)
    {
        auto* stack = new Stack<int32_t>();
        stack->Push(1);
        stack->Pop();

        ASSERT_TRUE(stack->IsEmpty());
    }

    TEST(StackGetCount,
        GetCountWhenAddingAndRemovingItemsShouldReturnHowManyItemsAreInStack)
    {
        auto* stack = new Stack<int32_t>();
        stack->Push(1);
        stack->Push(2);


        ASSERT_EQ(2, stack->GetCount());
        stack->Pop();

        ASSERT_EQ(1, stack->GetCount());
    }

    TEST(StackPeek,
        PeekShouldShowElementAtDepthIndexOfTheStack)
    {
        auto* stack = new Stack<int32_t>();
        int expected = 3;

        stack->Push(expected);
        stack->Push(2);
        stack->Push(1);

        ASSERT_EQ(expected, stack->Peek(2));
    }
}
