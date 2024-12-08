#include "TGL_Sprite.h"
#include "TGL_Graphics.h"
#include "TGL_Image.h"
#include "TGL_TiledImage.h"

namespace TGL
{
	Sprite::Sprite() : tileset(nullptr), singleImage(nullptr), size(0, 0), 
		collisionRect(0, 0, 0, 0), pos(0, 0), visible(true), currentFrame(0)
	{
	}

	Sprite::~Sprite()
	{
	}

	void Sprite::SetTileset(TiledImage* img)
	{
		tileset = img;
		size = img->GetTileSize();
		collisionRect = img->GetTileSize().GetRect();

		singleImage = nullptr;
	}

	void Sprite::SetSingleImage(Image* img)
	{
		singleImage = img;
		size = img->GetSize();
		collisionRect = img->GetSize().GetRect();

		tileset = nullptr;
	}

	void Sprite::SetPos(const Point& pos)
	{
		this->pos = pos;
	}

	void Sprite::Move(int dx, int dy)
	{
		pos = pos.Move(dx, dy);
	}

	Size Sprite::GetSize() const
	{
		return size;
	}

	Point Sprite::GetPos() const
	{
		return pos;
	}

	void Sprite::SetVisible(bool visible)
	{
		this->visible = visible;
	}

	bool Sprite::IsVisible() const
	{
		return visible;
	}

	void Sprite::SetFrameSequence(const List<int>& frames)
	{
		this->frames = frames;
	}

	void Sprite::SetFrame(int index)
	{
		if (index >= 0 && index < frames.size())
			currentFrame = index;
	}

	void Sprite::NextFrame()
	{
		currentFrame++;
		if (currentFrame >= frames.size())
			currentFrame = 0;
	}

	void Sprite::PrevFrame()
	{
		currentFrame--;
		if (currentFrame < 0)
			currentFrame = frames.size() - 1;
	}

	void Sprite::EnableAutoAnimation(int frameLength)
	{
		autoAnimation.enabled = true;
		autoAnimation.frameLength = frameLength;
		autoAnimation.frameCount = 0;
	}

	void Sprite::DisableAutoAnimation()
	{
		autoAnimation.enabled = false;
	}

	bool Sprite::CollidesWith(Sprite* other)
	{
		return collisionRect.Intersects(other->collisionRect);
	}

	void Sprite::Draw(Graphics* gr)
	{
		if (!visible)
			return;

		if (tileset) {
			if (frames.empty())
				return;

			const int& frame = frames[currentFrame];
			if (frame > 0)
				gr->DrawImage(tileset->GetTile(frame), pos);

			if (autoAnimation.enabled) {
				autoAnimation.frameCount++;
				if (autoAnimation.frameCount >= autoAnimation.frameLength) {
					autoAnimation.frameCount = 0;
					NextFrame();
				}
			}
		}
		else if (singleImage) {
			gr->DrawImage(singleImage, pos);
		}
	}
}
