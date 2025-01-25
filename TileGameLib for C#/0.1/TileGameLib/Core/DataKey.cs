namespace TileGameLib.Core;

public readonly struct DataKey(string value)
{
	private readonly string _value = value.ToLower().Trim();
	public override string ToString() => _value.ToLower().Trim();
	public DataKey Normalize() => _value.ToLower().Trim();

	// Implicit string conversions
	public static implicit operator string(DataKey dataKey) => dataKey._value.ToLower().Trim();
	public static implicit operator DataKey(string value) => new(value.ToLower().Trim());
}
