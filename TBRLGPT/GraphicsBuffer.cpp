/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "GraphicsBuffer.h"

namespace TBRLGPT
{
	GraphicsBuffer::GraphicsBuffer(int width, int height) : Width(width), Height(height), Size(width * height)
	{
		for (int i = 0; i < Size; i++) {
			Buffer.push_back(GraphicsBufferChar());
		}
	}

	GraphicsBuffer::~GraphicsBuffer()
	{	
	}

	int GraphicsBuffer::GetWidth()
	{
		return Width;
	}

	int GraphicsBuffer::GetHeight()
	{
		return Height;
	}

	int GraphicsBuffer::GetSize()
	{
		return Size;
	}

	void GraphicsBuffer::Put(GraphicsBufferChar ch, int x, int y)
	{
		Put(ch.CharIx, ch.ForeColorIx, ch.BackColorIx, x, y);
	}

	void GraphicsBuffer::Put(int ix, int fgc, int bgc, int x, int y)
	{
		GraphicsBufferChar& target = Buffer[y * Width + x];
		target.CharIx = ix;
		target.ForeColorIx = fgc;
		target.BackColorIx = bgc;
	}

	GraphicsBufferChar* GraphicsBuffer::Get(int x, int y)
	{
		return &(Buffer[y * Width + x]);
	}

	void GraphicsBuffer::Fill(GraphicsBufferChar ch)
	{
		Fill(ch.CharIx, ch.ForeColorIx, ch.BackColorIx);
	}

	void GraphicsBuffer::Fill(int ix, int fgc, int bgc)
	{
		for (int i = 0; i < Size; i++) {
			GraphicsBufferChar& target = Buffer[i];
			target.CharIx = ix;
			target.ForeColorIx = fgc;
			target.BackColorIx = bgc;
		}
	}
}
