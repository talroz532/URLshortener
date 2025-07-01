using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URLshortener.Data;
using URLshortener.Functions;
using URLshortener.Models;

namespace URLshortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly ApiContext _context;

        public UrlShortenerController(ApiContext context)
        {
            _context = context;
        }

        // POST: api/UrlShortener/shorten
        [HttpPost("shorten")]
        public IActionResult Shorten([FromBody] Urllist urls)
        {
            // Validate if the long URL is provided
            if (string.IsNullOrWhiteSpace(urls.UrlLong))
            {
                return BadRequest("URL is required.");
            }

            // Validate URL format
            if (!urls.UrlLong.StartsWith("http://") && !urls.UrlLong.StartsWith("https://"))
            {
                return BadRequest("Invalid URL. URL must start with http:// or https://");
            }

            // Check if the long URL already exists in the database
            var urlInDb = _context.Urls.FirstOrDefault(u => u.UrlLong == urls.UrlLong);
            if (urlInDb != null)
            {
                // Return existing short URL if found
                return Ok(new { urlShort = urlInDb.UrlShort });
            }

            // Generate a short URL
            urls.UrlShort = UrlFunctions.toShort(urls.UrlLong);

            // Save new entry to the database
            _context.Urls.Add(urls);
            _context.SaveChanges();

            // Return newly created short URL
            return Ok(urls);
        }

        // GET: /{shortUrl}
        [HttpGet("/api/{shortUrl}")]
        public IActionResult RedirectToLongUrl(string shortUrl)
        {
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                return BadRequest("Short URL is required.");
            }

            // Look for the short URL in the database
            var urlRecord = _context.Urls.FirstOrDefault(u => u.UrlShort == shortUrl);
            if (urlRecord == null)
            {
                return NotFound("Short URL not found.");
            }

            // Redirect to the original long URL
            return Redirect(urlRecord.UrlLong);
        }

        // GET: api/UrlShortener/all
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _context.Urls.ToList();
            return Ok(result);
        }
    }
}
