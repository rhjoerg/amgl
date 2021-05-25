#include <SDKDDKVer.h>
#define WIN32_LEAN_AND_MEAN
#include <windows.h>

int APIENTRY wWinMain(_In_ HINSTANCE hInstance, _In_opt_ HINSTANCE hPrevInstance, _In_ LPWSTR lpCmdLine, _In_ int nCmdShow)
{
	::MessageBoxW(NULL, L"Hello, world!", L"AMGL Launcher", MB_OK | MB_ICONINFORMATION);
	return 0;
}
