using System.Text.Json.Serialization;
using URLShortening.Models.Internal;

namespace URLShortening.Models.Responses;

public class ShortenedUrlResponse
{
    public int Id { get; set; }
    [JsonPropertyName("url")]
    public string OriginalUrl { get; set; }
    [JsonPropertyName("shortCode")]
    public string ShortenedUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public static class ShortenedUrlResponseMapping
{
    public static ShortenedUrlResponse ToShortenedUrlResponse(this ShortenedUrlItem item)
    {
        return new ShortenedUrlResponse()
        {
            Id = item.Id,
            OriginalUrl = item.OriginalUrl,
            ShortenedUrl = item.ShortenedUrl,
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.UpdatedAt
        };
    }
}