#pragma once

extern "C" {
	const char* AllocCppString();
	void FreeCppString(const char* str);
}