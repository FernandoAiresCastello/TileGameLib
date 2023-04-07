/*=============================================================================

	TGL.c

	Part of the TileGameLib toolkit:
	https://github.com/FernandoAiresCastello/TileGameLib

	Copyright (c) 2019-2023 Fernando Aires Castello

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and /or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.

//============================================================================*/
#include <SDL.h>
#include <limits.h>
#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <time.h>
#include "TGL.h"

//==============================================================================
//      PRIVATE API
//==============================================================================
#define TGL_TILESIZE    8
#define TGL_TILELENGTH  (TGL_TILESIZE * TGL_TILESIZE)

typedef enum {
    TGL_MODE_RGB, TGL_MODE_BINARY
} tgl_screen_mode;

struct {
    SDL_Window* wnd;
    SDL_Renderer* rend;
    SDL_Texture* tx;
    rgb* buf;
    int buf_len;
    int buf_w;
    int buf_h;
    rgb back_color;
    int pixel_w;
    int pixel_h;
    tgl_screen_mode mode;
    struct {
        bool enabled;
        int x1, y1, x2, y2;
    } clip;
    bool transparency;
} screen;

struct {
    rgb fg;
    rgb bg;
} binary_color;

typedef struct {
    int data[TGL_TILELENGTH];
} tgl_tiledef;

struct {
    tgl_tiledef* tiles;
} tileset;

void tgl_proc_default_events() {
    SDL_Event e = { 0 };
    while (SDL_PollEvent(&e)) {
        if (e.type == SDL_QUIT) {
            tgl_exit();
            return;
        } else if (e.type == SDL_KEYDOWN) {
            const SDL_Keycode key = e.key.keysym.sym;
            if (key == SDLK_ESCAPE) {
                tgl_exit();
                return;
            } else if (key == SDLK_RETURN && (SDL_GetModState() & KMOD_ALT)) {
                tgl_toggle_fullscreen();
            }
        }
    }
}
void tgl_clear_to_rgb(rgb rgb) {
    for (int i = 0; i < screen.buf_len; i++) {
        screen.buf[i] = screen.back_color;
    }
}
void tgl_fillrect(int x, int y, int w, int h, rgb rgb) {
    int px = x * w;
    int py = y * h;
    const int prevX = px;
    for (int iy = 0; iy < w; iy++) {
        for (int ix = 0; ix < h; ix++) {
            if (screen.clip.enabled) {
                if (px >= screen.clip.x1 && py >= screen.clip.y1 && 
                    px <= screen.clip.x2 && py <= screen.clip.y2) {
                    screen.buf[py * screen.buf_w + px] = rgb;
                }
            } else {
                if (px >= 0 && py >= 0 && px < screen.buf_w && py < screen.buf_h) {
                    screen.buf[py * screen.buf_w + px] = rgb;
                }
            }
            px++;
        }
        px = prevX;
        py++;
    }
}
void tgl_pset(int x, int y, rgb rgb) {
    tgl_fillrect(x, y, screen.pixel_w, screen.pixel_h, rgb);
}

// MTwister C Library (https://github.com/ESultanik/mtwister)

#define STATE_VECTOR_LENGTH 624
#define STATE_VECTOR_M      397
#define UPPER_MASK		    0x80000000
#define LOWER_MASK		    0x7fffffff
#define TEMPERING_MASK_B	0x9d2c5680
#define TEMPERING_MASK_C	0xefc60000

typedef struct tagMTRand {
    unsigned long mt[STATE_VECTOR_LENGTH];
    int index;
} MTRand;

MTRand rng;

inline static void m_seedRand(MTRand* rand, unsigned long seed) {
    rand->mt[0] = seed & 0xffffffff;
    for(rand->index=1; rand->index<STATE_VECTOR_LENGTH; rand->index++) {
        rand->mt[rand->index] = (6069 * rand->mt[rand->index-1]) & 0xffffffff;
    }
}
MTRand seedRand(unsigned long seed) {
    MTRand rand;
    m_seedRand(&rand, seed);
    return rand;
}
unsigned long genRandLong(MTRand* rand) {
  unsigned long y;
  static unsigned long mag[2] = {0x0, 0x9908b0df};
  if(rand->index >= STATE_VECTOR_LENGTH || rand->index < 0) {
    int kk;
    if (rand->index >= STATE_VECTOR_LENGTH+1 || rand->index < 0) {
      m_seedRand(rand, 4357);
    }
    for (kk=0; kk<STATE_VECTOR_LENGTH-STATE_VECTOR_M; kk++) {
      y = (rand->mt[kk] & UPPER_MASK) | (rand->mt[kk+1] & LOWER_MASK);
      rand->mt[kk] = rand->mt[kk+STATE_VECTOR_M] ^ (y >> 1) ^ mag[y & 0x1];
    }
    for (; kk<STATE_VECTOR_LENGTH-1; kk++) {
      y = (rand->mt[kk] & UPPER_MASK) | (rand->mt[kk+1] & LOWER_MASK);
      rand->mt[kk] = rand->mt[kk+(STATE_VECTOR_M-STATE_VECTOR_LENGTH)] ^ (y >> 1) ^ mag[y & 0x1];
    }
    y = (rand->mt[STATE_VECTOR_LENGTH-1] & UPPER_MASK) | (rand->mt[0] & LOWER_MASK);
    rand->mt[STATE_VECTOR_LENGTH-1] = rand->mt[STATE_VECTOR_M-1] ^ (y >> 1) ^ mag[y & 0x1];
    rand->index = 0;
  }
  y = rand->mt[rand->index++];
  y ^= (y >> 11);
  y ^= (y << 7) & TEMPERING_MASK_B;
  y ^= (y << 15) & TEMPERING_MASK_C;
  y ^= (y >> 18);
  return y;
}
double genRand(MTRand* rand) {
  return (double)genRandLong(rand) / (unsigned long)0xffffffff;
}

//==============================================================================
//      PUBLIC API
//==============================================================================
void tgl_init() {
    rng = seedRand(time(0));
}
void tgl_exit() {
    free(tileset.tiles);                tileset.tiles = NULL;
    free(screen.buf);                   screen.buf = NULL;
    SDL_DestroyTexture(screen.tx);      screen.tx = NULL;
    SDL_DestroyRenderer(screen.rend);   screen.rend = NULL;
    SDL_DestroyWindow(screen.wnd);      screen.wnd = NULL;
    SDL_Quit();
    exit(0);
}
void tgl_halt() {
    while (true) {
        tgl_update();
    }
}
void tgl_update_screen() {
    static int pitch;
    static void* pixels;
    SDL_LockTexture(screen.tx, NULL, &pixels, &pitch);
    SDL_memcpy(pixels, screen.buf, screen.buf_len);
    SDL_UnlockTexture(screen.tx);
    SDL_RenderClear(screen.rend);
    SDL_RenderCopy(screen.rend, screen.tx, NULL, NULL);
    SDL_RenderPresent(screen.rend);
}
void tgl_update() {
    tgl_update_screen();
    tgl_proc_default_events();
}
void tgl_screen(int buf_width, int buf_height, int wnd_size, rgb back_color) {
    screen.buf_w = buf_width;
    screen.buf_h = buf_height;
    screen.buf_len = sizeof(rgb) * buf_width * buf_height;
    screen.buf = calloc(screen.buf_len, sizeof(rgb));
    screen.back_color = back_color;
    tgl_clear();
    screen.pixel_w = 1;
    screen.pixel_h = 1;
    screen.mode = TGL_MODE_BINARY;
    screen.clip.enabled = false;
    screen.clip.x1 = 0;
    screen.clip.y1 = 0;
    screen.clip.x2 = 0;
    screen.clip.y2 = 0;
    screen.transparency = false;
    binary_color.fg = 0xffffff;
    binary_color.bg = 0x000000;

    SDL_Init(SDL_INIT_EVERYTHING);
    SDL_SetHint(SDL_HINT_RENDER_DRIVER, "direct3d");
    SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");
    screen.wnd = SDL_CreateWindow("", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, wnd_size * buf_width, wnd_size * buf_height, 0);
    screen.rend = SDL_CreateRenderer(screen.wnd, -1, SDL_RENDERER_PRESENTVSYNC | SDL_RENDERER_ACCELERATED | SDL_RENDERER_TARGETTEXTURE);
    SDL_RenderSetLogicalSize(screen.rend, buf_width, buf_height);
    screen.tx = SDL_CreateTexture(screen.rend, SDL_PIXELFORMAT_ARGB8888, SDL_TEXTUREACCESS_STREAMING, buf_width, buf_height);
    SDL_SetTextureBlendMode(screen.tx, SDL_BLENDMODE_NONE);
    SDL_SetRenderDrawBlendMode(screen.rend, SDL_BLENDMODE_NONE);
    SDL_SetRenderDrawColor(screen.rend, 0, 0, 0, 255);
    SDL_RenderClear(screen.rend);
    SDL_RenderPresent(screen.rend);
    SDL_SetWindowPosition(screen.wnd, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);
    SDL_RaiseWindow(screen.wnd);
}
void tgl_screen_128x128(int wnd_size, rgb back_color) {
    tgl_screen(128, 128, wnd_size, back_color);
}
void tgl_screen_160x144(int wnd_size, rgb back_color) {
    tgl_screen(160, 144, wnd_size, back_color);
}
void tgl_screen_256x192(int wnd_size, rgb back_color) {
    tgl_screen(256, 192, wnd_size, back_color);
}
void tgl_screen_360x200(int wnd_size, rgb back_color) {
    tgl_screen(360, 200, wnd_size, back_color);
}
void* tgl_window() {
    return screen.wnd;
}
void tgl_fullscreen(bool full) {
    Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
    Uint32 isFullscreen = SDL_GetWindowFlags(screen.wnd) & fullscreenFlag;
    if ((full && isFullscreen) || (!full && !isFullscreen)) return;
    SDL_SetWindowFullscreen(screen.wnd, full ? fullscreenFlag : 0);
    tgl_update();
}
void tgl_toggle_fullscreen() {
    Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
    Uint32 isFullscreen = SDL_GetWindowFlags(screen.wnd) & fullscreenFlag;
    SDL_SetWindowFullscreen(screen.wnd, isFullscreen ? 0 : fullscreenFlag);
    tgl_update();
}
void tgl_backcolor(rgb color) {
    screen.back_color = color;
}
void tgl_clear() {
    tgl_clear_to_rgb(screen.back_color);
}
int tgl_width() {
    return screen.buf_w;
}
int tgl_height() {
    return screen.buf_h;
}
int tgl_cols() {
    return screen.buf_w / TGL_TILESIZE;
}
int tgl_rows() {
    return screen.buf_h / TGL_TILESIZE;
}
void tgl_clip(int x1, int y1, int x2, int y2) {
    screen.clip.enabled = true;
    screen.clip.x1 = x1;
    screen.clip.y1 = y1;
    screen.clip.x2 = x2;
    screen.clip.y2 = y2;
}
void tgl_unclip() {
    screen.clip.enabled = false;
    screen.clip.x1 = 0;
    screen.clip.y1 = 0;
    screen.clip.x2 = 0;
    screen.clip.y2 = 0;
}
byte tgl_color_r(rgb color) {
    return (color & 0xff0000) >> 16;
}
byte tgl_color_g(rgb color) {
    return (color & 0x00ff00) >> 8;
}
byte tgl_color_b(rgb color) {
    return (color & 0x0000ff);
}
rgb tgl_color_rgb(byte r, byte g, byte b) {
    return b | (g << CHAR_BIT) | (r << CHAR_BIT * 2);
}
void tgl_color(rgb fore_color, rgb back_color) {
    binary_color.fg = fore_color;
    binary_color.bg = back_color;
}
void tgl_transparent(bool flag) {
    screen.transparency = flag;
}
int tgl_rnd(int min, int max) {
    return min + genRandLong(&rng) % (max - min + 1);
}
void tgl_test_static() {
    rgb pal[] = { 0x101010, 0x404040, 0x808080, 0xd0d0d0 };
    for (int y = 0; y < tgl_height(); y++) {
        for (int x = 0; x < tgl_width(); x++) {
            tgl_pset(x, y, pal[tgl_rnd(0, 3)]);
        }
    }
}
void tgl_mode_rgb() {
    screen.mode = TGL_MODE_RGB;
}
void tgl_mode_bin() {
    screen.mode = TGL_MODE_BINARY;
}
void tgl_tileset(int size) {
    tileset.tiles = (tgl_tiledef*)calloc(size, sizeof(tgl_tiledef));
}
void tgl_tile_rgb(int index, int* data) {
    for (int i = 0; i < TGL_TILELENGTH; i++) {
        tileset.tiles[index].data[i] = data[i];
    }
}
void tgl_tile_bin(int index, char* data) {
    for (int i = 0; i < TGL_TILELENGTH; i++) {
        tileset.tiles[index].data[i] = data[i];
    }
}
void tgl_draw_tiled(int tile_index, int x, int y) {
    tgl_draw_free(tile_index, x * TGL_TILESIZE, y * TGL_TILESIZE);
}
void tgl_draw_free(int tile_index, int x, int y) {
    int px = x;
    int py = y;
    tgl_tiledef* tile = &tileset.tiles[tile_index];
    for (int i = 0; i < TGL_TILELENGTH; i++) {
        if (screen.mode == TGL_MODE_RGB) {
            tgl_pset(px, py, tile->data[i]);
        } else if (screen.mode == TGL_MODE_BINARY) {
            if (tile->data[i] == '1') {
                tgl_pset(px, py, binary_color.fg);
            } else if (tile->data[i] == '0') {
                if (!screen.transparency) {
                    tgl_pset(px, py, binary_color.bg);
                }
            } else {
                // invalid binary tile
            }
        }
        px++;
        if (px >= x + TGL_TILESIZE) {
            px = x;
            py++;
        }
    }
}
