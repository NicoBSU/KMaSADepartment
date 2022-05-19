using System.Runtime.Serialization;

namespace KMaSA.Models.Enums;

public enum UserType
{
    [EnumMember(Value = "Преподаватель")]
    Mentor,
    [EnumMember(Value = "Студент")]
    Student
}