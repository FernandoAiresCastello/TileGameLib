using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLibTest;

public class GameObjectTests
{
    [Fact]
    public void CreateObjectWithDefaultValues()
    {
        GameObject o = new GameObject();

        Assert.True(o.Visible);
		Assert.False(o.Transparent);
        Assert.Empty(o.Properties.Entries);
        Assert.Single(o.Animation.Frames);
	}

	[Fact]
	public void CreateObjectWithSingleTile()
	{
		GameObject o = new GameObject(new Tile(1, 2, 3));

		Assert.Single(o.Animation.Frames);
		Assert.Equal(o.Animation.FirstFrame, new Tile(1, 2, 3));
	}
	
	[Fact]
    public void CreateObjectCopyUsingConstructor()
    {
		GameObject o1 = CreateCustomTestObject();
		GameObject o2 = new GameObject(o1);

        Assert.Equal(o1, o2);
	}

	[Fact]
	public void CreateObjectFromCopy()
	{
		GameObject o1 = CreateCustomTestObject();
		GameObject o2 = o1.Copy();

		Assert.Equal(o1, o2);
	}

	[Fact]
    public void SetObjectToLogicalNull()
    {
		GameObject o = CreateCustomTestObject();

		o.SetNull();

		Assert.True(o.Visible);
		Assert.False(o.Transparent);
		Assert.Empty(o.Properties.Entries);
		Assert.Single(o.Animation.Frames);
	}

	[Fact]
	public void TestPropertiesEquality()
	{
		GameObject o1 = CreateCustomTestObject();
		GameObject o2 = new GameObject(o1);

		Assert.True(o1.PropertiesEqual(o2));
	}

	[Fact]
	public void TestPropertiesInequality()
	{
		GameObject o1 = CreateCustomTestObject();
		GameObject o2 = new GameObject(o1);
		o2.Properties.Set("prop1", "xxxx");

		Assert.False(o1.PropertiesEqual(o2));
	}

	private GameObject CreateCustomTestObject()
	{
		GameObject o = new GameObject();
		o.Visible = false;
		o.Transparent = true;
		o.Animation.SetFrame(0, new Tile(1, 2, 3));
		o.Animation.AddFrame(new Tile(4, 5, 6));
		o.Properties.Set("prop1", "abcd");
		o.Properties.Set("prop2", "efgh");
		return o;
	}
}
