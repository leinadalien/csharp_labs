#pragma once

#ifdef MYDLL_API_EXPORTS
#define MYDLL_API_API __declspec(dllexport)
#else
#define MYDLL_API __declspec(dllimport)
#endif
extern "C" MYDLL_API void FibonacciInit(const unsigned long long a, const unsigned long long b);
extern "C" MYDLL_API bool FibonacciNext();
extern "C" MYDLL_API unsigned long long FibonacciCurrent();
extern "C" MYDLL_API unsigned FibonacciIndex();