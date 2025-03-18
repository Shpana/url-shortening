using System.Text.Json.Serialization;

namespace URLShortening.Models.Requests;

public class UpdateShortenedUrlRequest
{
    [JsonPropertyName("url")]
    public string OriginalUrl { get; set; }
}