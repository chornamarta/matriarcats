using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;

namespace Data.Models.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter<,,>))]
    public enum Semester
    {
        [EnumMember(Value ="1")]
        First,

        [EnumMember(Value ="2")]
        Second
    }
}