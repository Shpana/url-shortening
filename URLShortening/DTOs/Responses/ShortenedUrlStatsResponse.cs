using System.Text.Json.Serialization;

namespace URLShortening;

public class ShortenedUrlStatsResponse
{
    public int Id { get; set; }
    [JsonPropertyName("url")]
    public string OriginalUrl { get; set; }
    [JsonPropertyName("shortCode")]
    public string ShortenedUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int AccessCount { get; set; }
}

public static class ShortenedUrlStatsResponseMapping
{
    public static ShortenedUrlStatsResponse ToShortenedUrlStatsResponse(this ShortenedUrlItem item)
    {
        return new ShortenedUrlStatsResponse()
        {
            Id = item.Id,
            OriginalUrl = item.OriginalUrl,
            ShortenedUrl = item.ShortenedUrl,
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.UpdatedAt,
            AccessCount = item.AccessCount
        };
    }
}