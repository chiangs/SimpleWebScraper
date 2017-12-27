using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;

namespace SimpleWebScraper
{
    class Program
    {
        // Take 2 inputs from user (city and category)
        // User WebClient to make http call to address and download content result as string
        // Use scrape criteria to go through content
        // Using builder pattern to set the criteria
        // REGEX to match by inspecting the HTML from the site
        // Instantiate new scraper and scrape on the criteria that was built
        // If there was anything scraped, display, otherwise console write that there were no matches
        // Handle exceptions by wrapping the entire program in a try/catch

        private const string Method = "search";

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter city to scrape from: ");
                var clCity = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Enter category to scrape from: ");
                var clCategory = Console.ReadLine() ?? string.Empty;

                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString($"http://{clCity.Replace(" ", string.Empty)}.craigslist.org/{Method}/{clCategory}");

                    ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                        .WithData(content)
                        .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\ class=\""result-title hldrlink\"">(.*?)</a>")
                        .WithRegexOption(RegexOptions.ExplicitCapture)
                        // grab description then 
                        .WithPart(new ScrapeCriteriaPartBuilder()
                                  .WithRegex(@">(.*?)</a>")
                                  .WithRegexOption(RegexOptions.Singleline)
                                  .Build())
                        // grab link
                        .WithPart(new ScrapeCriteriaPartBuilder()
                                  .WithRegex(@"href=\""(.*?)\""")
                                  .WithRegexOption(RegexOptions.Singleline)
                                  .Build())
                        .Build();

                    Scraper scraper = new Scraper();

                    var scrapedElements = scraper.Scrape(scrapeCriteria);

                    if (scrapedElements.Any())
                    {
                        foreach (var scrapedElement in scrapedElements) Console.WriteLine(scrapedElement);
                    }
                    else
                    {
                        Console.WriteLine("There were no matches for specified scrape criteria.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
