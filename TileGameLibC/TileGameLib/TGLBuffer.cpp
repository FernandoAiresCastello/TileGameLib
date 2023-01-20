/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#include "TGLBuffer.h"

void TGLBuffer::init(TBufferedWindow* pwnd)
{
	wnd = pwnd;
	sel_buf = wnd->GetBuffer(0);
	buffers["default"] = sel_buf;
}
void TGLBuffer::newb(string id, int cols, int rows, int layers)
{
	buffers[id] = wnd->AddBuffer(layers, cols, rows);
}
void TGLBuffer::sel(string id)
{
	sel_buf = buffers[id];
}
void TGLBuffer::show()
{
	sel_buf->View.Visible = true;
}
void TGLBuffer::hide()
{
	sel_buf->View.Visible = false;
}
void TGLBuffer::view(int x, int y, int cols, int rows)
{
	sel_buf->SetView(x, y, cols, rows);
}
void TGLBuffer::scrl(int dx, int dy)
{
	sel_buf->View.ScrollX += dx;
	sel_buf->View.ScrollY += dy;
}
int TGLBuffer::cols()
{
	return sel_buf->Cols;
}
int TGLBuffer::rows()
{
	return sel_buf->Rows;
}
