using Microsoft.AspNetCore.Mvc;
using URLShortening.Models.Requests;

namespace URLShortening.Controller;

[Route("shorten/v1")]
[ApiController]
public class UrlShorteningController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateShortenedUrl([FromBody] CreateShortenedUrlRequest request)
    {
        return Ok(request.OriginalUrl);
    }

    [HttpGet]
    [Route("{shortenedUrl}")]
    public IActionResult GetOriginalUrl(string shortenedUrl)
    {
        return Ok(shortenedUrl);
    }

    [HttpPut]
    [Route("{shortenedUrl}")]
    public IActionResult UpdateShortenedUrl(string shortenedUrl, [FromBody] UpdateShortenedUrlRequest request)
    {
        return Ok($"{shortenedUrl}, {request.OriginalUrl}");
    }

    [HttpDelete]
    [Route("{shortenedUrl}")]
    public IActionResult DeleteShortenedUrl(string shortenedUrl)
    {
        return Ok(shortenedUrl);
    }

    [HttpGet]
    [Route("{shortenedUrl}/stats")]
    public IActionResult GetStatistics(string shortenedUrl)
    {
        return Ok(shortenedUrl);
    }
}