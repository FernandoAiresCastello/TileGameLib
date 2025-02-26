#include "TGL_ImageTile.h"
#include "TGL_Graphics.h"
#include "TGL_ImageTileset.h"

namespace TGL
{
	ImageTile::ImageTile() :
		data(), frames(), anim()
	{
	}

	ImageTile::ImageTile(const ImageTile& other) :
		data(other.data), frames(other.frames), anim(other.anim)
	{
	}

	ImageTile::ImageTile(Index singleImage) :
		data(), frames(), anim()
	{
		frames.push_back(singleImage);
	}

	ImageTile::~ImageTile()
	{
		frames.clear();
	}

	ImageTile& ImageTile::operator=(const ImageTile& other)
	{
		if (this == &other)
			return *this;

		data = other.data;
		frames = other.frames;
		anim = other.anim;

		return *this;
	}

	int ImageTile::FrameCount() const
	{
		return frames.size();
	}

	Index ImageTile::GetFrame(int index)
	{
		return frames[index % frames.size()];
	}

	void ImageTile::AddFrame(Index imageIndex)
	{
		frames.push_back(imageIndex);
	}

	void ImageTile::SetFrame(int frameIndex, Index imageIndex)
	{
		frames[frameIndex] = imageIndex;
	}

	void ImageTile::RemoveAllFrames()
	{
		frames.clear();
	}

	void ImageTile::SetEmpty()
	{
		data.Clear();
		RemoveAllFrames();
	}

	bool ImageTile::IsEmpty() const
	{
		return HasNoData() && HasNoFrames();
	}

	bool ImageTile::HasAnyFrame() const
	{
		return !frames.empty();
	}

	bool ImageTile::HasNoFrames() const
	{
		return !HasAnyFrame();
	}

	bool ImageTile::HasAnyData() const
	{
		return !data.Empty();
	}

	bool ImageTile::HasNoData() const
	{
		return !HasAnyData();
	}

	void ImageTile::SetCurrentAnimFrame(int index)
	{
		anim.currentFrame = index;
	}

	void ImageTile::SetAnimationDelay(int delay)
	{
		anim.maxFrameCounter = delay;
	}

	void ImageTile::EnableAnimation(bool enable)
	{
		anim.enabled = enable;
	}

	Index& ImageTile::NextFrame()
	{
		Index& index = frames[anim.currentFrame % frames.size()];

		if (anim.enabled) {
			anim.frameCounter++;
			if (anim.frameCounter > anim.maxFrameCounter) {
				anim.frameCounter = 0;
				anim.currentFrame++;
			}
		}

		return index;
	}

	void ImageTile::Draw(Graphics* g, ImageTileset* tileset, const Point& pos)
	{
		Index curFrame = NextFrame();
		g->DrawImage(tileset->GetTile(curFrame), pos);
	}

	void ImageTile::Draw(Graphics* g, ImageTileset* tileset, int x, int y)
	{
		Draw(g, tileset, Point(x, y));
	}
}
