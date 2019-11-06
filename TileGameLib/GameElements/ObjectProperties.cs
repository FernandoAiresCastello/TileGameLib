using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.GameElements
{
    public class ObjectProperties
    {
        public Dictionary<string, string> Entries { get; set; } = new Dictionary<string, string>();

        public ObjectProperties()
        {
        }

        public string GetAsString(string property)
        {
            if (Has(property))
                return Entries[property];

            throw new TileGameLibException($"Property {property} not found");
        }

        public int GetAsNumber(string property)
        {
            if (Has(property))
            {
                bool isNumeric = int.TryParse(GetAsString(property), out int numericValue);
                if (!isNumeric)
                    throw new TileGameLibException($"Property {property} is not a numeric property");

                return numericValue;
            }

            throw new TileGameLibException($"Property {property} not found");
        }

        public void Set(string property, object value)
        {
            Entries[property] = value.ToString();
        }

        public bool Has(string property)
        {
            return Entries.ContainsKey(property);
        }

        public bool HasValue(string property, object value)
        {
            if (Has(property) && GetAsString(property).Equals(value.ToString()))
                return true;

            return false;
        }

        public void Remove(string property)
        {
            if (Has(property))
                Entries.Remove(property);
        }

        public void RemoveAll()
        {
            Entries.Clear();
        }

        public void SetEqual(ObjectProperties other)
        {
            RemoveAll();
            foreach (var property in other.Entries)
                Entries[property.Key] = property.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ObjectProperties other = (ObjectProperties)obj;

            if (other.Entries.Count != Entries.Count)
                return false;

            foreach (var property in other.Entries)
            {
                if (Entries[property.Key] != property.Value)
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder properties = new StringBuilder();
            foreach (var property in Entries)
                properties.Append(property.Key + " = " + property.Value + "\r\n");

            return properties.ToString();
        }

        public void Parse(string propertiesAsString)
        {
            RemoveAll();
            string[] properties = propertiesAsString.Trim().Split('\n');
            foreach (string propertyAndValue in properties)
            {
                string[] propertyValue = propertyAndValue.Trim().Split('=');

                if (propertyValue.Length == 2)
                {
                    string property = propertyValue[0].Trim();
                    string value = propertyValue[1].Trim();
                    if (!string.IsNullOrWhiteSpace(property) && !string.IsNullOrWhiteSpace(value))
                        Set(property, value);
                }
            }
        }

        public void AddNumeric(string property, int amount)
        {
            if (!Has(property))
                return;
            
            Set(property, GetAsNumber(property) + amount);
        }

        public override int GetHashCode()
        {
            return Entries.GetHashCode();
        }
    }
}
