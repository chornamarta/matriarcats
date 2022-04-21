using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Data.Models.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum TeacherStatus
    {
        [EnumMember(Value = "Кандидат наук")]
        PhD,
        [EnumMember(Value = "Доктор наук")]
        PHD,
        [EnumMember(Value = "Доцент")]
        Docent,
        [EnumMember(Value = "Старший викладач")]
        SeniorLecturer,
        [EnumMember(Value = "Професор")]
        Professor
    }
}
