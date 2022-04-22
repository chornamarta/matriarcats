using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Data.Models.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum Years
    {
        [EnumMember(Value = "3")]
        Third,

        [EnumMember(Value = "4")]
        Fourth
    }
}