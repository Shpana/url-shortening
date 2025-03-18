using System.Text.Json.Serialization;

namespace URLShortening;

public class CreateShortenedUrlRequest
{
    [JsonPropertyName("url")]
    public string OriginalUrl { get; set; }
}