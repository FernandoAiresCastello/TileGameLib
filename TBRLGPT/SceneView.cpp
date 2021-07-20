/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "SceneView.h"
#include "Scene.h"
#include "SceneObject.h"
#include "Graphics.h"
#include "Palette.h"
#include "Charset.h"

namespace TBRLGPT
{
	SceneView::SceneView(Graphics* g, Charset* chars, Palette* pal, int animationDelay)
	{
		Gr = g;
		Chars = chars;
		Pal = pal;
		Scene = NULL;
		X = 0;
		Y = 0;
		Width = 0;
		Height = 0;
		ScrollX = 0;
		ScrollY = 0;
		AnimationDelay = animationDelay;
		Animating = true;
		AnimationFrame = 0;
		AnimationThread = std::thread(&SceneView::AdvanceAnimationFrameThread, this);
	}

	SceneView::~SceneView()
	{
		Animating = false;
		if (AnimationThread.native_handle() != NULL) {
			AnimationThread.join();
		}
	}

	void SceneView::SetScene(class Scene* scene)
	{
		Scene = scene;
	}

	void SceneView::SetPosition(int x, int y)
	{
		X = x;
		Y = y;
	}

	void SceneView::SetSize(int width, int height)
	{
		Width = width;
		Height = height;
	}

	void SceneView::SetScroll(int scx, int scy)
	{
		ScrollX = scx;
		ScrollY = scy;
	}

	void SceneView::Scroll(int dx, int dy)
	{
		ScrollX += dx;
		ScrollY += dy;
	}

	int SceneView::GetX()
	{
		return X;
	}

	int SceneView::GetY()
	{
		return Y;
	}

	int SceneView::GetWidth()
	{
		return Width;
	}

	int SceneView::GetHeight()
	{
		return Height;
	}

	int SceneView::GetScrollX()
	{
		return ScrollX;
	}

	int SceneView::GetScrollY()
	{
		return ScrollY;
	}

	void SceneView::AdvanceAnimationFrameThread()
	{
		while (Animating) {
			AnimationFrame++;
			std::this_thread::sleep_for(std::chrono::milliseconds(AnimationDelay));
		}
	}

	void SceneView::DrawLayers(int count)
	{
		DrawBackObjs();
		for (int i = 0; i < count; i++)
			DrawLayer(i);
	}

	void SceneView::DrawLayer(int layer)
	{
		for (auto it = Scene->GetObjs().begin(); it != Scene->GetObjs().end(); ++it) {
			SceneObject* o = it->second;
			if (o->GetLayer() == layer) {
				DrawObject(o);
			}
		}
	}

	void SceneView::DrawBackObjs()
	{
		ObjectAnim& anim = Scene->GetBackObject();

		for (int py = 0; py < Height; py++) {
			for (int px = 0; px < Width; px++) {
				ObjectChar& ch = anim.GetFrame(AnimationFrame);
				Gr->PutChar(Chars, ch.Index, 
					X + px, 
					Y + py,
					Pal->GetRGB(ch.ForeColorIx), 
					Pal->GetRGB(ch.BackColorIx));
			}
		}
	}

	void SceneView::DrawObject(SceneObject* o)
	{
		if (!o->GetObj()->IsVisible())
			return;

		const int x = o->GetX();
		const int y = o->GetY();

		if (x < ScrollX || y < ScrollY || x >= ScrollX + Width || y >= ScrollY + Height)
			return;

		ObjectChar& ch = o->GetObj()->GetAnimation().GetFrame(AnimationFrame);
		Gr->PutChar(Chars, ch.Index, 
			(x - ScrollX) + X, 
			(y - ScrollY) + Y, 
			Pal->GetRGB(ch.ForeColorIx),
			Pal->GetRGB(ch.BackColorIx));
	}
}
