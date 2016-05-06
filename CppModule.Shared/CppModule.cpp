#include <stdio.h>
#include <stdlib.h>

#if defined(__ANDROID__)
const char* const ModuleName = "CppModule.Android";
#elif defined(__APPLE__)
const char* const ModuleName = "CppModule.iOS";
#endif

extern "C" const char* AllocCppString()
{
	char* p = NULL;
	asprintf(&p, "Hello, Xamarin! This is %s", ModuleName);
	return p;
}

extern "C" void FreeCppString(const char* str)
{
	free((void*)str);
}


