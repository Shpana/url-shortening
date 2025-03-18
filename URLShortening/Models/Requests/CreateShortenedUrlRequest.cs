using System.Text.Json.Serialization;

namespace URLShortening.Models.Requests;

public class CreateShortenedUrlRequest
{
    [JsonPropertyName("url")]
    public string OriginalUrl { get; set; }
}