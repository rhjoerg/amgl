
#include "frame.h"

namespace amgl
{
	LRESULT CALLBACK FrameWndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
	{
		switch (message)
		{
		case WM_DESTROY:
			PostQuitMessage(0);
			break;

		default:
			return ::DefWindowProc(hWnd, message, wParam, lParam);
		}

		return 0;
	}

	Frame::Frame(HINSTANCE hInstance)
	{
		WNDCLASSEXW wcex;

		wcex.cbSize = sizeof(WNDCLASSEX);
		wcex.style = CS_HREDRAW | CS_VREDRAW;
		wcex.lpfnWndProc = FrameWndProc;
		wcex.cbClsExtra = 0;
		wcex.cbWndExtra = 0;
		wcex.hInstance = hInstance;
		wcex.hIcon = nullptr;
		wcex.hCursor = ::LoadCursor(nullptr, IDC_ARROW);
		wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
		wcex.lpszMenuName = nullptr;
		wcex.lpszClassName = L"AMGLFRAME";
		wcex.hIconSm = nullptr;

		::RegisterClassExW(&wcex);

		int screenWidth = ::GetSystemMetrics(SM_CXSCREEN);
		int screenHeight = ::GetSystemMetrics(SM_CYSCREEN);
		int windowWidth = 3 * 256;
		int windowHeight = 256;
		int x = (screenWidth - screenHeight) / 2;
		int y = (screenHeight - windowHeight) / 3;

		HWND hWnd = ::CreateWindowExW(
			WS_EX_APPWINDOW,
			L"AMGLFRAME", L"AMGL Launcher",
			WS_OVERLAPPEDWINDOW,
			x, y, windowWidth, windowHeight,
			nullptr, nullptr, hInstance, this);

		::ShowWindow(hWnd, SW_SHOW);
		::UpdateWindow(hWnd);
	}

	Frame::~Frame()
	{
	}

	void Frame::Run()
	{
		MSG msg;

		while (::GetMessage(&msg, nullptr, 0, 0))
		{
			::TranslateMessage(&msg);
			::DispatchMessage(&msg);
		}
	}
}
