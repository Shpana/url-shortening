using System.Text.Json.Serialization;

namespace URLShortening;

public class UpdateShortenedUrlRequest
{
    [JsonPropertyName("url")]
    public string OriginalUrl { get; set; }
}