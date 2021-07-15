#include "Demos.h"
#include "SceneEditor.h"

void Demo05(UIContext* ctx)
{
	Palette* editorPal = new Palette();
	editorPal->Clear();
	editorPal->Set(0, 0x000000);
	editorPal->Set(1, 0x202020);
	editorPal->Set(2, 0xe0e0e0);
	Charset* editorChars = new Charset();
	editorChars->InitDefaultCharset();

	Palette* scenePal = new Palette();
	scenePal->InitDefaultColors();
	Charset* sceneChars = new Charset();
	sceneChars->InitDefaultCharset();

	Graphics* gr = ctx->Gr;
	gr->Clear(0x000000);

	Scene* scene = new Scene();
	SceneEditor* editor = new SceneEditor(scene, gr, editorChars, editorPal, sceneChars, scenePal);
	editor->Run();

	delete editor;
	delete scene;
	delete editorPal;
	delete editorChars;
}
