#pragma once

#include <assert.h>

// TODO(memory_page_size): Take this from
// GetNativeSysInfo(LPSYSTEM_INFO) for Windows
// getpagesize(void) for linux
// 4KB default page size
#define MEMORY_PAGE_SIZE 4096

class default_type
{
 public:
    template<typename Type>
    operator Type () const { return Type(); }
};
