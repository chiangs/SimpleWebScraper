using System;

namespace SimpleWebScraper
{
    class Program
    {
        // CraigslistCity = user input
        // CrisglistCategory = user input
        // ifValid, then download Craigslist listing contents
        // grab HTML element using regex
        // for each HTML element in HTML elements
        // if no specified HTML parts, then add entire matched HTML element to scraped item list
        // otherwise, for each part in the specified parts, grab specified part from the element based on regex
        // if match found, then add to part to matched item list
        // otherwise show warning
        // if matched item list is not empty, show elements/parts, otherwise show no matches found

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
