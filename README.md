# URL Shortener API
This is smiple URL Shortener API project.
It allows you to shorten long URLs anbd redirect users to the original URL when accessing to the shortend link.

* **`GET /{shortcode}`:** Redirects to the original URL. Replace '{shortcode}' with the shortened URL.
* **`GET /api/grtAll`:** Return all shortened URLs from the database.

## Technologies Used

* ** .NET 7 (or later) Framework- for building the API.
* ** C#: The programming language.
* ** ASP.NET: for the web API.
* ** Entity Framework Core: for ineracting with the database.
* ** In-Memory Database: Simple RAM database.
* ** Swagger/OpenAPI: Dealing with the API and testing it.

## Prerequisites
* **.NET SDK 7 (or later): Download and install the .NET SDK.
* ** IDE (optinal): Visual studio (MVC- recommended)

## Setup Instructions

`git clone https://github.com/talroz532/URLshortener.git`
`cd URLshortener`
Run it to if using MVC or enter `dotnet run` at the terminal command

Enter to `https://localhost:5001/swagger` in order to the test API

