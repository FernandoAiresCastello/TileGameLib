using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.GameElements
{
    public class ObjectProperties
    {
        public Dictionary<string, string> Entries { get; set; } = new Dictionary<string, string>();

        public ObjectProperties()
        {
        }

        public string GetProperty(string property)
        {
            if (HasProperty(property))
                return Entries[property];

            return null;
        }

        public void SetProperty(string property, string value)
        {
            Entries[property] = value;
        }

        public bool HasProperty(string property)
        {
            return Entries.ContainsKey(property);
        }

        public bool HasPropertyValue(string property, string value)
        {
            if (HasProperty(property) && GetProperty(property).Equals(value))
                return true;

            return false;
        }

        public void RemoveAllProperties()
        {
            Entries.Clear();
        }

        public void SetEqual(ObjectProperties other)
        {
            RemoveAllProperties();
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
            RemoveAllProperties();
            string[] properties = propertiesAsString.Trim().Split('\n');
            foreach (string propertyAndValue in properties)
            {
                string[] propertyValue = propertyAndValue.Trim().Split('=');

                if (propertyValue.Length == 2)
                {
                    string property = propertyValue[0].Trim();
                    string value = propertyValue[1].Trim();
                    if (!string.IsNullOrWhiteSpace(property) && !string.IsNullOrWhiteSpace(value))
                        SetProperty(property, value);
                }
            }
        }

        public override int GetHashCode()
        {
            return Entries.GetHashCode();
        }
    }
}
