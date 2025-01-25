namespace TileGameLib.Core;

/// <summary>
///		Collection of key-value pairs for storing arbitrary data.
/// </summary>
public class Dataset
{
	private readonly Dictionary<DataKey, object> Data = [];

	public int Count => Data.Count;

	public void Clear() => Data.Clear();

	public void Set(DataKey key, object value) => Data[key.Normalize()] = value;

	public bool Has(DataKey key) => Data.ContainsKey(key.Normalize());

	public bool Has(DataKey key, string value) => 
		Has(key) && GetString(key) == value.ToString();

	public bool Has(DataKey key, int value) =>
		Has(key) && GetNumber(key) == value;

	public T Get<T>(DataKey key) => Has(key) ? (T)Data[key] : default;

	public object GetObject(DataKey key) =>
		Data.TryGetValue(key.Normalize(), out var value) ? value : default;

	public string GetString(DataKey key) =>
		Data.TryGetValue(key.Normalize(), out var value) ? value.ToString() : default;

	public int GetNumber(DataKey key) =>
		Data.TryGetValue(key.Normalize(), out var value) ? int.Parse(value.ToString()) : default;
}
