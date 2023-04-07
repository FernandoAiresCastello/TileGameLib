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
#define TGL_FONTSIZE    256
#define TGL_MAXSOUNDS   256
#define TGL_STRFMT_LEN  1024

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
    rgb transparency_key;
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
} tileset = { NULL };

struct {
    tgl_tiledef tiles[TGL_FONTSIZE];
} font;

typedef struct {
    bool loaded;
    SDL_AudioDeviceID device;
    SDL_AudioSpec spec;
    Uint32 length;
    Uint8 *buffer;
} tgl_sound_data;

struct {
    tgl_sound_data sounds[TGL_MAXSOUNDS];
} sound_pool;

struct {
    int last_key;
} input;

struct {
    char fmt_buf[TGL_STRFMT_LEN];
} strings;

void tgl_proc_default_events() {
    SDL_Event e = { 0 };
    while (SDL_PollEvent(&e)) {
        if (e.type == SDL_QUIT) {
            tgl_exit();
            return;
        } else if (e.type == SDL_KEYDOWN) {
            input.last_key = e.key.keysym.sym;
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
void tgl_font_default() {
    tgl_font_clear();
    tgl_font(32, "0000000000000000000000000000000000000000000000000000000000000000"); // 32 Space
    tgl_font(33, "0011000000110000001100000011000000110000000000000011000000000000"); // 33 !
    tgl_font(34, "0110110001101100011011000000000000000000000000000000000000000000"); // 34 "
    tgl_font(35, "0000000000010100001111100001010000111110000101000000000000000000"); // 35 #
    tgl_font(36, "0001000011111110110100001111111000010110110101101111111000010000"); // 36 $
    tgl_font(37, "0000000001100010011001000000100000010000001001100100011000000000"); // 37 %
    tgl_font(38, "0001000001111100011000000011100001100000011111000001000000000000"); // 38 &
    tgl_font(39, "0000000000011000000110000011000000000000000000000000000000000000"); // 39 '
    tgl_font(40, "0000110000011000001100000011000000110000000110000000110000000000"); // 40 (
    tgl_font(41, "0011000000011000000011000000110000001100000110000011000000000000"); // 41 )
    tgl_font(42, "0000000001101100001110001111111000111000011011000000000000000000"); // 42 *
    tgl_font(43, "0000000000011000000110000111111000011000000110000000000000000000"); // 43 +
    tgl_font(44, "0000000000000000000000000000000000011000000110000011000000000000"); // 44 ,
    tgl_font(45, "0000000000000000000000000111111000000000000000000000000000000000"); // 45 -
    tgl_font(46, "0000000000000000000000000000000000000000000110000001100000000000"); // 46 .
    tgl_font(47, "0000000100000010000001000000100000010000001000000100000010000000"); // 47 /
    tgl_font(48, "0000000011111110110001101101011011010110110001101111111000000000"); // 48 Digit 0
    tgl_font(49, "0000000000111000000110000001100000011000000110000111111000000000"); // 49 Digit 1
    tgl_font(50, "0000000001111110011001100000011001111110011000000111111000000000"); // 50 Digit 2
    tgl_font(51, "0000000001111110000001100011110000000110000001100111111000000000"); // 51 Digit 3
    tgl_font(52, "0000000001100110011001100110011001111110000001100000011000000000"); // 52 Digit 4
    tgl_font(53, "0000000001111110011000000111111000000110011001100111111000000000"); // 53 Digit 5
    tgl_font(54, "0000000001111110011000000111111001100110011001100111111000000000"); // 54 Digit 6
    tgl_font(55, "0000000001111110000001100000110000011000001100000011000000000000"); // 55 Digit 7
    tgl_font(56, "0000000001111110011001100011110001100110011001100111111000000000"); // 56 Digit 8
    tgl_font(57, "0000000001111110011001100110011001111110000001100111111000000000"); // 57 Digit 9
    tgl_font(58, "0000000000000000000110000001100000000000000110000001100000000000"); // 58 :
    tgl_font(59, "0000000000000000000110000001100000000000000110000001100000001000"); // 59 ;
    tgl_font(60, "0000000000000110000110000110000000011000000001100000000000000000"); // 60 <
    tgl_font(61, "0000000000000000011111100000000001111110000000000000000000000000"); // 61 =
    tgl_font(62, "0000000001100000000110000000011000011000011000000000000000000000"); // 62 >
    tgl_font(63, "0111111001100110000001100001111000011000000000000001100000000000"); // 63 ?
    tgl_font(64, "1111111010000010101110101010101010111110100000001111111000000000"); // 64 @
    tgl_font(65, "0111111001100110011001100110011001111110011001100110011000000000"); // 65 Letter A
    tgl_font(66, "0111111001100110011001100111110001100110011001100111111000000000"); // 66 Letter B
    tgl_font(67, "0111111001100110011000000110000001100000011001100111111000000000"); // 67 Letter C
    tgl_font(68, "0111110001100110011001100110011001100110011001100111110000000000"); // 68 Letter D
    tgl_font(69, "0111111001100000011000000111110001100000011000000111111000000000"); // 69 Letter E
    tgl_font(70, "0111111001100000011000000111110001100000011000000110000000000000"); // 70 Letter F
    tgl_font(71, "0111111001100110011000000110111001100110011001100111111000000000"); // 71 Letter G
    tgl_font(72, "0110011001100110011001100111111001100110011001100110011000000000"); // 72 Letter H
    tgl_font(73, "0111111000011000000110000001100000011000000110000111111000000000"); // 73 Letter I
    tgl_font(74, "0000011000000110000001100000011001100110011001100111111000000000"); // 74 Letter J
    tgl_font(75, "0110011001100110011011000111100001100110011001100110011000000000"); // 75 Letter K
    tgl_font(76, "0110000001100000011000000110000001100000011000000111111000000000"); // 76 Letter L
    tgl_font(77, "1000001011000110111011101111111011010110110101101100011000000000"); // 77 Letter M
    tgl_font(78, "0100011001100110011101100111111001101110011001100110001000000000"); // 78 Letter N
    tgl_font(79, "0111111001100110011001100110011001100110011001100111111000000000"); // 79 Letter O
    tgl_font(80, "0111111001100110011001100110011001111110011000000110000000000000"); // 80 Letter P
    tgl_font(81, "0111111001100110011001100110011001100110011011100111111000000011"); // 81 Letter Q
    tgl_font(82, "0111111001100110011001100110011001111100011001100110011000000000"); // 82 Letter R
    tgl_font(83, "0111111001100110011000000111111000000110011001100111111000000000"); // 83 Letter S
    tgl_font(84, "0111111000011000000110000001100000011000000110000001100000000000"); // 84 Letter T
    tgl_font(85, "0110011001100110011001100110011001100110011001100111111000000000"); // 85 Letter U
    tgl_font(86, "0110011001100110011001100010010000111100000110000001100000000000"); // 86 Letter V
    tgl_font(87, "1100011011000110110101101101011011111110011011000110110000000000"); // 87 Letter W
    tgl_font(88, "0110011001100110001111000001100000111100011001100110011000000000"); // 88 Letter X
    tgl_font(89, "0110011001100110011001100110011001111110000110000001100000000000"); // 89 Letter Y
    tgl_font(90, "0111111000000110000011000001100000110000011000000111111000000000"); // 90 Letter Z
    tgl_font(91, "0001111000011000000110000001100000011000000110000001100000011110"); // 91 [
    tgl_font(92, "1000000001000000001000000001000000001000000001000000001000000001"); // 92 Backslash (\)
    tgl_font(93, "0111100000011000000110000001100000011000000110000001100001111000"); // 93 ]
    tgl_font(94, "1111111111111111111111111111111111111111111111111111111111111111"); // 94 Solid box (^)
    tgl_font(95, "0000000000000000000000000000000000000000000000000111111000000000"); // 95 _
    tgl_font(96, "0000000000011000000110000011000000000000000000000000000000000000"); // 96 Backtick (`)
    tgl_font(97, "0000000000000000011111000000110001111100011011000111111000000000"); // 97 Letter a
    tgl_font(98, "0111000000110000001111100011011000110110001101100011111000000000"); // 98 Letter b
    tgl_font(99, "0000000000000000011111100110011001100000011000000111111000000000"); // 99 Letter c
    tgl_font(100, "0000111000001100011111000110110001101100011011000111110000000000"); // 100 Letter d
    tgl_font(101, "0000000000000000011111100110011001111110011000000111111000000000"); // 101 Letter e
    tgl_font(102, "0000000000111110001100000111110000110000001100000011000000000000"); // 102 Letter f
    tgl_font(103, "0000000000000000011111100110110001101100011111000000110001111100"); // 103 Letter g
    tgl_font(104, "0110000001100000011111000110110001101100011011000110111000000000"); // 104 Letter h
    tgl_font(105, "0001100000000000001110000001100000011000000110000111111000000000"); // 105 Letter i
    tgl_font(106, "0000011000000000000001100000011000000110001101100011011000111110"); // 106 Letter j
    tgl_font(107, "0110000001100000011001100110110001111000011001100110011000000000"); // 107 Letter k
    tgl_font(108, "0011100000011000000110000001100000011000000110000111111000000000"); // 108 Letter l
    tgl_font(109, "0000000000000000111111101101011011010110110101101101011000000000"); // 109 Letter m
    tgl_font(110, "0000000000000000011111100011011000110110001101100011011000000000"); // 110 Letter n
    tgl_font(111, "0000000000000000011111100110011001100110011001100111111000000000"); // 111 Letter o
    tgl_font(112, "0000000000000000011111100011011000110110001111100011000000110000"); // 112 Letter p
    tgl_font(113, "0000000000000000011111000110110001101100011111000000110000001110"); // 113 Letter q
    tgl_font(114, "0000000000000000011111100011011000110000001100000011000000000000"); // 114 Letter r
    tgl_font(115, "0000000000000000011111100110000001111110000001100111111000000000"); // 115 Letter s
    tgl_font(116, "0000000000110000011111100011000000110000001100000011111000000000"); // 116 Letter t
    tgl_font(117, "0000000000000000011011000110110001101100011011000111111000000000"); // 117 Letter u
    tgl_font(118, "0000000000000000011001100110011001100110001111000001100000000000"); // 118 Letter v
    tgl_font(119, "0000000000000000110101101101011011010110111111100110110000000000"); // 119 Letter w
    tgl_font(120, "0000000000000000011001100011110000011000001111000110011000000000"); // 120 Letter x
    tgl_font(121, "0000000000000000011101100011011000110110001111100000011000111110"); // 121 Letter y
    tgl_font(122, "0000000000000000011111100000011000011000011000000111111000000000"); // 122 Letter z
    tgl_font(123, "0000111000001000000010000011000000001000000010000000111000000000"); // 123 {
    tgl_font(124, "0001100000011000000110000001100000011000000110000001100000011000"); // 124 |
    tgl_font(125, "0111000000010000000100000000110000010000000100000111000000000000"); // 125 }
    tgl_font(126, "0000000001101100111111101111111001111100001110000001000000000000"); // 126 Heart (~)
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
    SDL_Init(SDL_INIT_EVERYTHING);
    rng = seedRand(time(0));
    input.last_key = 0;
}
void tgl_exit() {
    for (int i = 0; i < TGL_MAXSOUNDS; i++) {
        if (sound_pool.sounds[i].loaded) {
            SDL_CloseAudioDevice(sound_pool.sounds[i].device);
            SDL_FreeWAV(sound_pool.sounds[i].buffer);
            sound_pool.sounds[i].buffer = NULL;
            sound_pool.sounds[i].loaded = false;
        }
    }
    free(tileset.tiles);                tileset.tiles = NULL;
    free(screen.buf);                   screen.buf = NULL;
    SDL_DestroyTexture(screen.tx);      screen.tx = NULL;
    SDL_DestroyRenderer(screen.rend);   screen.rend = NULL;
    SDL_DestroyWindow(screen.wnd);      screen.wnd = NULL;
    SDL_Quit();
    exit(0);
}
void tgl_abort(char* msg) {
    SDL_ShowSimpleMessageBox(SDL_MESSAGEBOX_ERROR, "Error", msg, screen.wnd);
    tgl_exit();
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
void tgl_hcf() {
    rgb pal[] = { 0x101010, 0x404040, 0x808080, 0xd0d0d0 };
    while (tgl_window()) {
        for (int y = 0; y < tgl_height(); y++) {
            for (int x = 0; x < tgl_width(); x++) {
                tgl_pset(x, y, pal[tgl_rnd(0, 3)]);
            }
        }
        tgl_update();
    }
}
void tgl_title(char* title) {
    SDL_SetWindowTitle(screen.wnd, title);
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
    screen.transparency_key = 0xffffff;
    binary_color.fg = 0xffffff;
    binary_color.bg = 0x000000;
    tgl_font_default();

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
void tgl_mode_rgb() {
    screen.mode = TGL_MODE_RGB;
}
void tgl_mode_bin() {
    screen.mode = TGL_MODE_BINARY;
}
void tgl_tileset(int size) {
    if (tileset.tiles) {
        free(tileset.tiles);
    }
    tileset.tiles = (tgl_tiledef*)calloc(size, sizeof(tgl_tiledef));
}
void tgl_tile_rgb(int index, rgb* pixels) {
    for (int i = 0; i < TGL_TILELENGTH; i++) {
        tileset.tiles[index].data[i] = pixels[i];
    }
}
void tgl_tile_bin(int index, char* pixels) {
    for (int i = 0; i < TGL_TILELENGTH; i++) {
        tileset.tiles[index].data[i] = pixels[i];
    }
}
void tgl_tile_rgb_load(int index, char* file) {
    SDL_Surface* bmp = SDL_LoadBMP(file);
    if (!bmp) {
        tgl_abort("Could not load RGB tile: bitmap file not found");
        return;
    }
    const Uint8 bpp = bmp->format->BytesPerPixel;
    int width = bmp->w;
    int height = bmp->h;
    int i = 0;
    for (int y = 0; y < height; y++) {
        for (int x = 0; x < width; x++) {
            Uint8* ptr_pixel = (Uint8*)bmp->pixels + y * bmp->pitch + x * bpp;
            Uint32 pixel_data = *(Uint32*)ptr_pixel;
            SDL_Color color = { 0x00, 0x00, 0x00, SDL_ALPHA_OPAQUE };
            SDL_GetRGB(pixel_data, bmp->format, &color.r, &color.g, &color.b);
            tileset.tiles[index].data[i++] = tgl_color_rgb(color.r, color.g, color.b);
        }
    }
    SDL_FreeSurface(bmp);
}
void tgl_draw_tile(tgl_tiledef* tile, int x, int y, tgl_screen_mode mode) {
    int px = x;
    int py = y;
    for (int i = 0; i < TGL_TILELENGTH; i++) {
        if (mode == TGL_MODE_RGB) {
            if (!screen.transparency || tile->data[i] != screen.transparency_key) {
                tgl_pset(px, py, tile->data[i]);
            }
        } else if (mode == TGL_MODE_BINARY) {
            if (tile->data[i] == '1') {
                tgl_pset(px, py, binary_color.fg);
            } else if (tile->data[i] == '0') {
                if (!screen.transparency) {
                    tgl_pset(px, py, binary_color.bg);
                }
            } else {
                tgl_abort("Invalid binary tile");
            }
        }
        px++;
        if (px >= x + TGL_TILESIZE) {
            px = x;
            py++;
        }
    }
}
void tgl_draw_tiled(int tile_index, int x, int y) {
    tgl_draw_free(tile_index, x * TGL_TILESIZE, y * TGL_TILESIZE);
}
void tgl_draw_free(int tile_index, int x, int y) {
    tgl_tiledef* tile = &tileset.tiles[tile_index];
    tgl_draw_tile(tile, x, y, screen.mode);
}
void tgl_font(int char_index, char* pixels) {
    for (int i = 0; i < TGL_TILELENGTH; i++) {
        font.tiles[char_index].data[i] = pixels[i];
    }
}
void tgl_font_clear() {
    for (int i = 0; i < TGL_FONTSIZE; i++) {
        tgl_font(i, "0000000000000000000000000000000000000000000000000000000000000000");
    }
}
void tgl_print_tiled(char* str, int x, int y) {
    tgl_print_free(str, x * TGL_TILESIZE, y * TGL_TILESIZE);
}
void tgl_print_free(char* str, int x, int y) {
    for (int i = 0; i < SDL_strlen(str); i++) {
        tgl_tiledef* tile = &font.tiles[str[i]];
        tgl_draw_tile(tile, x, y, TGL_MODE_BINARY);
        x += TGL_TILESIZE;
    }
}
char* tgl_fmt(char* str, ...) {
    SDL_memset(strings.fmt_buf, 0, TGL_STRFMT_LEN);
	va_list arg;
	va_start(arg, str);
	vsprintf(strings.fmt_buf, str, arg);
	va_end(arg);
    return strings.fmt_buf;
}
void tgl_sound_load(int index, char* file) {
    if (sound_pool.sounds[index].loaded) {
        tgl_abort("Duplicate sound index");
        return;
    }
    tgl_sound_data* data = &sound_pool.sounds[index];
    if (SDL_LoadWAV(file, &data->spec, &data->buffer, &data->length) == NULL) {
        tgl_abort("Could not load WAV sound: file not found");
        return;
    }
    data->device = SDL_OpenAudioDevice(NULL, 0, &data->spec, NULL, 0);
    if (data->device <= 0) {
        tgl_abort("Could not open audio device");
        return;
    }
    data->loaded = true;
}
void tgl_sound_play(int index) {
    tgl_sound_data* data = &sound_pool.sounds[index];
    if (!data->loaded) {
        tgl_abort("Sound not found at index");
        return;
    }
    int success = SDL_QueueAudio(data->device, data->buffer, data->length);
    if (success < 0) {
        tgl_abort("Could not queue audio");
        return;
    }
    SDL_PauseAudioDevice(data->device, 0);
}
int tgl_inkey() {
    int key = input.last_key;
    input.last_key = 0;
    return key;
}
bool tgl_key(int scancode) {
    SDL_PumpEvents();
    const Uint8* state = SDL_GetKeyboardState(NULL);
    return state[scancode];
}
bool tgl_kshift() {
    return SDL_GetModState() & KMOD_SHIFT;
}
bool tgl_kctrl() {
    return SDL_GetModState() & KMOD_CTRL;
}
bool tgl_kalt() {
    return SDL_GetModState() & KMOD_ALT;
}
bool tgl_kcaps() {
    return SDL_GetModState() & KMOD_CAPS;
}
