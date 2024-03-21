using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.App.Attributes
{
    public class AutoSpeicherAttribute : Attribute
    {
        private readonly string _schlüssel;

        public AutoSpeicherAttribute(string schlüssel)
        {
            _schlüssel = schlüssel;

        }

        public object GetValue(Type eigenschaftsTyp)
        {
            string serialisierterWert = SecureStorage.GetAsync(_schlüssel).Result;
            return Deserialize(serialisierterWert, eigenschaftsTyp);
        }
        public void SetValue(object value)
        {
            string serialisierterWert = Serialize(value);
            SecureStorage.SetAsync(_schlüssel, serialisierterWert);
        }

        private string Serialize(object value)
        {
            // Implement serialization logic (e.g., using JSON serialization)
            return value.ToString(); // Example: using ToString() for simplicity
        }

        private object Deserialize(string serializedValue, Type propertyType)
        {
            // Implement deserialization logic (e.g., using JSON deserialization)
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
