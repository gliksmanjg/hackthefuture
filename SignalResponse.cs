using System.Text.Json.Serialization;

namespace Hack_The_Future;

public class SignalResponse
{
    [JsonPropertyName("cipherText")]
    public string CipherText { get; set; }
    [JsonPropertyName("shift")]
    public int Shift { get; set; }
}