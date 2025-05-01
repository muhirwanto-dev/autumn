using SingleScope.Common.Attributes;

namespace Autumn.Wasm.Common.Enums
{
    [EnumTypeNames]
    public enum DataSourceType
    {
        [EnumName("experiences")]
        Experiences,

        [EnumName("profile")]
        Profile,

        [EnumName("projects")]
        Projects,

        [EnumName("skills")]
        Skills,
    }
}
