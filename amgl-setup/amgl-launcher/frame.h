#pragma once

#include "amgl.h"

namespace amgl
{
	class Frame
	{
	public:
		Frame(HINSTANCE hInstance);
		virtual ~Frame();

	public:
		void Run();
	};
}
