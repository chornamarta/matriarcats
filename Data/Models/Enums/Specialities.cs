using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Data.Models.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum Specialities
    {
        [EnumMember(Value ="Computer Science")]
        ComputerScience,

        [EnumMember(Value = "Applied Mathematics")]
        AppliedMathematics,

        [EnumMember(Value ="Secondary Education")]
        SecondaryEducation,

        [EnumMember(Value = "Cybersecurity")]
        Cybersecurity,

        [EnumMember(Value = "System Analysis")]
        SystemAnalysis
    }
}
