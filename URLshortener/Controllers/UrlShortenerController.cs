using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URLshortener.Data;
using URLshortener.Functions;
using URLshortener.Models;

namespace URLshortener.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly ApiContext _context;

        public UrlShortenerController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult shorten(Urllist urls)
        {

            var urlInDb = _context.Urls.FirstOrDefault(urlRecord => urlRecord.UrlLong == urls.UrlLong);

            


            if (string.IsNullOrWhiteSpace(urls.UrlLong)) // Check if the 'url' parameter is missing or empty
            {
                

                // If the URL is empty or just spaces, return an error response (400 Bad Request)
                return new JsonResult(BadRequest("URL is required."));

            } else if (!urls.UrlLong.StartsWith("http://") && !urls.UrlLong.StartsWith("https://")) { //check if its a real http/s URL

                return new JsonResult(BadRequest("Not a valid URL... \nURL must start with http:// or https://"));

            } 
            
            else if (urlInDb != null) // Check if the long URL already exists in the database
            {

                // If it exists, return the existing short URL
                return new JsonResult(Ok(urls.UrlShort));
            }
            
            urls.UrlShort = UrlFunctions.toShort(urls.UrlLong);


            _context.Urls.Add(urls);
            _context.SaveChanges();
            return new JsonResult(Ok(urls));

        }

        [HttpGet]
        [Route("/{giventUrl}")]
        public IActionResult RedirectToLongUrl(string giventUrl)
        {
            if (string.IsNullOrWhiteSpace(giventUrl))
            {
                return BadRequest("Short URL is required.");
            }

            var urlRecord = _context.Urls.FirstOrDefault(u => u.UrlShort == giventUrl);

            if (urlRecord == null)
            {
                return NotFound("Short URL not found.");
            }

            // This performs an actual HTTP 302 redirect to the original URL
            return Redirect(urlRecord.UrlLong);
        }



        // Get all
        [HttpGet()]
        public JsonResult GetAll()
        {
            var result = _context.Urls.ToList();

            return new JsonResult(Ok(result));
        }

    }
}
