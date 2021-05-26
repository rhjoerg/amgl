
#include "frame.h"

using namespace amgl;

int APIENTRY wWinMain(
	_In_ HINSTANCE hInstance,
	_In_opt_ HINSTANCE hPrevInstance,
	_In_ LPWSTR lpCmdLine,
	_In_ int nCmdShow)
{
	Frame frame(hInstance);

	frame.Run();

	return 0;
}
