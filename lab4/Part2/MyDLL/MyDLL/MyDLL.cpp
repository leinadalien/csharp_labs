#include "pch.h"
#include <utility>
#include <limits.h>
#include "MyDLL.h"
static unsigned long long Previous;
static unsigned long long Current;
static unsigned Index;

void  FibonacciInit(const unsigned long long a, const unsigned long long b)
{
    Index = 0;
    Current = a;
    Previous = b;
}
bool  FibonacciNext()
{
    if ((ULLONG_MAX - Previous < Current) || (UINT_MAX == Index))
    {
        return false;
    }
    if (Index > 0)
    {
        Previous += Current;
    }
    std::swap(Current, Previous);
    ++Index;
    return true;
}
unsigned long long FibonacciCurrent()
{
    return Current;
}
unsigned FibonacciIndex()
{
    return Index;
}