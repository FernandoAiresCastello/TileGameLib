using System.ComponentModel;
using TileGameLib.ExtensionMethods;

namespace TileGameLib.Controls;

/// <summary>
///		A window that displays a grid of colors and allows selection of a color with a mouse click.
/// </summary>
public partial class ColorPickerWindow : Form
{
	/// <summary>
	///		Callback for when a color gets selected.
	///		The selected color and mouse button that was pressed, 
	///		along with a reference to this window, are passed as arguments.
	/// </summary>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Action<Form, Color, MouseButtons> OnColorClicked { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string Title;

	private readonly ColorPickerDisplay PaletteDisplay;

	public ColorPickerWindow(Size bufSize, Size canvasGridSize, Size canvasCellSize, Color emptyColor, Point viewOffset, int zoomLevel)
	{
		InitializeComponent();

		Size = new Size(286, 309);
		Padding = new Padding(5);

		RootPanel.Dock = DockStyle.Fill;
		RootPanel.BorderStyle = BorderStyle.Fixed3D;

		PaletteDisplay = new ColorPickerDisplay(bufSize, canvasGridSize, canvasCellSize, emptyColor, viewOffset, zoomLevel);
		PaletteDisplay.MouseMove += PalettePanel_MouseMove;
		PaletteDisplay.MouseClick += PalettePanel_MouseClick;
		PaletteDisplay.MouseLeave += PalettePanel_MouseLeave;
		PaletteDisplay.Parent = RootPanel;
		
		Shown += ColorPaletteWindow_Shown;
	}

	public void LoadColors(string path) => PaletteDisplay.LoadColors(path);
	public void SetColors(List<string> hexColors) => PaletteDisplay.SetColors(hexColors);
	public void SetColors(List<Color> colors) => PaletteDisplay.SetColors(colors);

	private void PalettePanel_MouseMove(object sender, MouseEventArgs e)
	{
		int cellIndex = PaletteDisplay.GetCellIndexFromMousePos(e.Location);
		Text = $"Index: {cellIndex} (#{cellIndex:X2})";

		Color color = PaletteDisplay.GetColorAtMousePos(e.Location);
		Text += $" | RGB: #{color.ToHex()}";
	}

	private void PalettePanel_MouseClick(object sender, MouseEventArgs e)
	{
		Color color = PaletteDisplay.GetColorAtMousePos(e.Location);
		OnColorClicked?.Invoke(this, color, e.Button);
	}

	private void PalettePanel_MouseLeave(object sender, EventArgs e)
	{
		Text = Title;
	}

	private void ColorPaletteWindow_Shown(object sender, EventArgs e)
	{
		Text = Title;
	}
}
