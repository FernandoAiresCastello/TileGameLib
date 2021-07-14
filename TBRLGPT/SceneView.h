/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <thread>
#include "Global.h"

namespace TBRLGPT
{
	class Scene;
	class SceneObject;
	class Graphics;
	class Charset;
	class Palette;

	class TBRLGPT_API SceneView
	{
	public:
		SceneView(Graphics* g, Charset* chars, Palette* pal, int animationDelay);
		~SceneView();

		void SetScene(class Scene* scene);
		void SetPosition(int x, int y);
		void SetSize(int width, int height);
		void SetScroll(int scx, int scy);
		void Scroll(int dx, int dy);
		int GetX();
		int GetY();
		int GetWidth();
		int GetHeight();
		int GetScrollX();
		int GetScrollY();
		void Draw();

	private:
		Graphics* Gr;
		Charset* Chars;
		Palette* Pal;
		class Scene* Scene;
		int X;
		int Y;
		int Width;
		int Height;
		int ScrollX;
		int ScrollY;
		bool Animating;
		int AnimationFrame;
		std::thread AnimationThread;
		int AnimationDelay;

		void DrawLayer(int layer);
		void DrawBackObjs();
		void DrawObject(SceneObject* o);
		void AdvanceAnimationFrameThread();
	};
}
