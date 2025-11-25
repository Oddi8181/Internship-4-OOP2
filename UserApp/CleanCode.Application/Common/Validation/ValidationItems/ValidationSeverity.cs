using System.Text.Json.Serialization;

namespace UserApp.Application.Common.Validation
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ValidationSeverity
    {
        Error,
        Warning,
        Info
    }
}
