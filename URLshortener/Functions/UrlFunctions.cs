using System;

namespace URLshortener.Functions
{
    public class UrlFunctions
    {
        // Simple method to "shorten" a URL using base64 encoding
        public static string toShort(string input)
        {
            // Return empty if input is null or empty
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // Remove "http://" or "https://" from the start
            if (input.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Substring("http://".Length);
            }
            else if (input.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Substring("https://".Length);
            }

            // encode to Base64
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(input);
            string urlShort = Convert.ToBase64String(plainTextBytes);

            // Take the first 7 characters as the short code
            urlShort = urlShort.Substring(0, 7);

            return urlShort;
        }
    }
}
