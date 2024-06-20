using Newtonsoft.Json;

namespace TrainTimings.Core.DtoClasses;

public class PasswordChangeRequest
{
    [JsonProperty("type")]
    public string Type { get; set; } = "password";

    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("temporary")]
    public bool Temporary { get; set; } = false;
}