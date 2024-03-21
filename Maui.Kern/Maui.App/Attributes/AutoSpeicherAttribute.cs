using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.App.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class AutoSpeicherAttribute(string schlüssel) : Attribute
    {
        private readonly string _schlüssel = schlüssel;

        public object? GetValue(Type eigenschaftsTyp)
        {
            string? serialisierterWert = SecureStorage.GetAsync(_schlüssel).Result;

            return serialisierterWert != null ? Deserialize(serialisierterWert, eigenschaftsTyp) : null;
        }
        public void SetValue(object value)
        {
            string? serialisierterWert = Serialize(value);
            if (serialisierterWert != null)
                SecureStorage.SetAsync(_schlüssel, serialisierterWert);
        }

        private static string? Serialize(object value) =>
            // TODO: Implement serialization logic (e.g., using JSON serialization)
            value.ToString() ?? string.Empty; 

        private static object Deserialize(string serializedValue, Type propertyType)
        {
            // TODO: Implement deserialization logic (e.g., using JSON deserialization)
            if (propertyType == typeof(string))
            {
                return serializedValue;
            }
            else if (propertyType == typeof(int))
            {
                return int.Parse(serializedValue);
            }
            // Add support for other data types as needed
            else
            {
                throw new ArgumentException("Unsupported property type");
            }
        }
    }
}
