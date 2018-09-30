using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace CTAAPIWrapper.Models
{
    public abstract class CTARequestBase
    {
        [JsonIgnore]
        [Required]
        public abstract string Endpoint { get; }

        //[Required]
        //public string Key { get; internal set; }

        [JsonProperty("outputType")]
        public string OutputType => "JSON";

        [Required]
        //[JsonProperty("key")]
        [JsonIgnore]
        public string Token { get; internal set; }

        [JsonIgnore]
        public string QueryString
        {
            get
            {
                IEnumerable<KeyValuePair<string, string>> values = CTARequestBase.GetQueryString(this);

                IEnumerable<string> keyValues = values.Select<KeyValuePair<string, string>, string>(pair => string.Format("{0}={1}", pair.Key, pair.Value));

                return string.Join("&", keyValues);
            }
        }

        private static IEnumerable<KeyValuePair<string, string>> GetQueryString(object value, string startingName = null)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            IEnumerable<PropertyInfo> properties = value.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(property =>
                    property.CanRead
                    && property.GetGetMethod(false) != null
                    && property.GetCustomAttribute<JsonIgnoreAttribute>(true) == null);

            foreach (PropertyInfo property in properties)
            {
                JsonPropertyAttribute attribute = property.GetCustomAttribute<JsonPropertyAttribute>(true);
                string name = attribute == null
                    ? property.Name
                    : attribute.PropertyName;

                name = string.Format("{0}{1}", startingName, name);

                if (value != null)
                {
                    object propertyValue = property.GetValue(value);

                    if (propertyValue == null)
                    {
                        values.Add(name, string.Empty);
                    }
                    else if (propertyValue.GetType() == typeof(List<string>))
                    {
                        // //TODO: Eh Clean this up
                        // foreach(var theValue in  propertyValue as List<string>)
                        // {
                        //     values.Add(name, theValue.ToString());
                        // }
                        var listOfStrings = propertyValue as List<string>;
                        values.Add(name, listOfStrings.FirstOrDefault());
                    }
                    else if (!propertyValue.GetType().IsByRef)
                    {
                        values.Add(name, propertyValue.ToString());
                    }
                    else
                    {
                        IEnumerable<KeyValuePair<string, string>> flattenedValues = CTARequestBase.GetQueryString(propertyValue, name + ".");

                        foreach (KeyValuePair<string, string> flattenedValue in flattenedValues)
                        {
                            values.Add(flattenedValue.Key, flattenedValue.Value);
                        }
                    }
                }
            }

            return values;
        }
    }
}