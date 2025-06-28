using System;


namespace URLshortener.Functions
{
    public class UrlFunctions
    {
        //shortenURL - simple base64 encode
        /*
         this is very simple "encoder"
         it takes the given url - removes http:// or https:// if present,
         encodes it to base64 and takes the first 7 chars from the result :)
         */
        public static string toShort(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            if (input.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Substring("http://".Length);
            }
            else if (input.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Substring("https://".Length);
            }

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(input);
            string urlShort = Convert.ToBase64String(plainTextBytes);

            urlShort = urlShort.Substring(0, 7);

            return urlShort;
        }

    }
}
