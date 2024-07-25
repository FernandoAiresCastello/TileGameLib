#include "TGL.h"

TGL::TGL()
{
}

TGL::~TGL()
{
}

void TGL::Test()
{
	InitWindow(640, 360, "Hello World!");

	while (!WindowShouldClose()) {

		BeginDrawing();
		ClearBackground({ 0x10,0x10,0x10,0xff });
		DrawCircle(320, 180, 100, { 255,0,0,255 });
		EndDrawing();
	}

	CloseWindow();
}
