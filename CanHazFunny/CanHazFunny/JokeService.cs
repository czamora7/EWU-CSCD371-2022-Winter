global using System;
using System.Net.Http;

namespace CanHazFunny;
public class JokeService : IJokeable
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
#pragma warning disable CA2234 // This required passing the system uri objects instead of strings
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
#pragma warning restore CA2234 
        return joke;
    }
}