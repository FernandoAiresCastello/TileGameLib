#include "Demos.h"

void Demo04(UIContext* ctx)
{
	Palette* pal = new Palette();
	pal->InitDefaultColors();
	Charset* chr = new Charset();
	chr->InitDefaultCharset();
	Graphics* gr = ctx->Gr;
	gr->Clear(0x000000);

	Scene* scene = new Scene();
	ObjectAnim anim = ObjectAnim();
	anim.Clear();
	anim.AddFrame(ObjectChar('=', 10, 11));
	anim.AddFrame(ObjectChar('-', 10, 11));
	scene->SetBackObject(anim);

	SceneView* view = new SceneView(gr, chr, pal, 250);
	view->SetPosition(5, 5);
	view->SetSize(gr->Cols - 10, gr->Rows - 10);
	view->SetScene(scene);

	SceneObject* o = new SceneObject();
	o->SetPosition(0, 0, 0);
	o->GetObj()->GetAnimation().AddFrame(ObjectChar(2, 1, 5));
	o->GetObj()->GetAnimation().AddFrame(ObjectChar(2, 3, 5));
	scene->AddObject(o);
	SceneObject* o2 = new SceneObject();
	o2->SetPosition(10, 10, 1);
	o2->GetObj()->GetAnimation().AddFrame(ObjectChar(1, 1, 5));
	o2->GetObj()->GetAnimation().AddFrame(ObjectChar(1, 3, 5));
	scene->AddObject(o2);

	bool running = true;
	while (running) {

		view->Draw();
		gr->ClearRows(0, 1, 0x000000);
		gr->Print(chr, 0, 0, 0xffffff, 0x000000, String::Format("PX:%i PY:%i", o->GetX(), o->GetY()));
		gr->Print(chr, 0, 1, 0xffffff, 0x000000, String::Format("VX:%i VY:%i", view->GetScrollX(), view->GetScrollY()));
		gr->Update();

		SDL_Event e = { 0 };
		SDL_PollEvent(&e);
		bool ctrl = Key::Ctrl();

		if (e.type == SDL_KEYDOWN) {
			auto key = e.key.keysym.sym;
			if (key == SDLK_ESCAPE) {
				running = false;
			}
			else if (key == SDLK_RIGHT) {
				if (ctrl)
					view->Scroll(1, 0);
				else
					o->Move(1, 0);
			}
			else if (key == SDLK_LEFT) {
				if (ctrl)
					view->Scroll(-1, 0);
				else
					o->Move(-1, 0);
			}
			else if (key == SDLK_DOWN) {
				if (ctrl)
					view->Scroll(0, 1);
				else
					o->Move(0, 1);
			}
			else if (key == SDLK_UP) {
				if (ctrl)
					view->Scroll(0, -1);
				else
					o->Move(0, -1);
			}
			else if (key == SDLK_z) {
				scene->ClearLayer(0);
			}
			else if (key == SDLK_x) {
				scene->ClearLayer(1);
			}
		}
	}

	delete view;
	delete scene;
	delete pal;
	delete chr;
}
