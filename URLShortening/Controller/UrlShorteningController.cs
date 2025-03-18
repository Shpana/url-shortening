using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace URLShortening;

[Route("shorten/v1")]
[ApiController]
public class UrlShorteningController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public UrlShorteningController(ApplicationDbContext context)
    {
        _context = context;
    } 
    
    [HttpPost]
    public async Task<IActionResult> CreateShortenedUrl([FromBody] CreateShortenedUrlRequest request)
    {
        if (await _context.ShortenedUrls
                .AnyAsync(item => item.OriginalUrl == request.OriginalUrl))
            return Conflict();
        
        var item = new ShortenedUrlItem()
        {
            OriginalUrl = request.OriginalUrl,
            ShortenedUrl = GenerateShortenedUrl(),
            CreatedAt = DateTime.Now.ToUniversalTime(),
            UpdatedAt = DateTime.Now.ToUniversalTime()
        };
        await _context.ShortenedUrls.AddAsync(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOriginalUrl), 
            new {shortenedUrl = item.ShortenedUrl}, item.ToShortenedUrlResponse());
    }

    [HttpGet]
    [Route("{shortenedUrl}")]
    public async Task<IActionResult> GetOriginalUrl(string shortenedUrl)
    {
        var item = await GetItemByShortenedUrl(shortenedUrl);
        if (item == null)
            return NotFound();
        item.AccessCount++;
        await _context.SaveChangesAsync();
        return Ok(item.ToShortenedUrlResponse());
    }

    [HttpPut]
    [Route("{shortenedUrl}")]
    public async Task<IActionResult> UpdateShortenedUrl(string shortenedUrl, [FromBody] UpdateShortenedUrlRequest request)
    {
        if (await _context.ShortenedUrls
                .AnyAsync(item => item.OriginalUrl == request.OriginalUrl))
            return Conflict();
        
        var item = await GetItemByShortenedUrl(shortenedUrl);
        if (item == null)
            return NotFound();
        
        item.OriginalUrl = request.OriginalUrl;
        item.UpdatedAt = DateTime.Now.ToUniversalTime();
        await _context.SaveChangesAsync();
        return Ok(item.ToShortenedUrlResponse());
    }

    [HttpDelete]
    [Route("{shortenedUrl}")]
    public async Task<IActionResult> DeleteShortenedUrl(string shortenedUrl)
    {
        var item = await GetItemByShortenedUrl(shortenedUrl);
        if (item == null)
            return NotFound();
        _context.ShortenedUrls.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet]
    [Route("{shortenedUrl}/stats")]
    public async Task<IActionResult> GetStatistics(string shortenedUrl)
    {
        var item = await GetItemByShortenedUrl(shortenedUrl);
        if (item == null) 
            return NotFound();
        return Ok(item.ToShortenedUrlStatsResponse());
    }

    private async Task<ShortenedUrlItem?> GetItemByShortenedUrl(string shortenedUrl)
    {
        return await _context.ShortenedUrls
            .Where(item => item.ShortenedUrl == shortenedUrl)
            .FirstOrDefaultAsync();
    }
    
    private static string GenerateShortenedUrl()
    {
        return Guid.NewGuid().ToString();
    }
}