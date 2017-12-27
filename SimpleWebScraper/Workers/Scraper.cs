using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SimpleWebScraper.Data;

namespace SimpleWebScraper.Workers
{
    public class Scraper
    {
        //This us the builders to scrape by matching on regex
        //Takes in a list of scrape criteria as strings and returns a list of scraped elements
        //Use regular expression engine Regex to match

        public List<string> Scrape(ScrapeCriteria scrapeCriteria) {
            List<string> scrapedElements = new List<string>();

            //Takes 3 args needed to match, the data, the regex, and optional options
            MatchCollection matches = Regex.Matches(scrapeCriteria.Data, scrapeCriteria.Regex, scrapeCriteria.RegexOption);

            //After machting complete, iterate through list to decide whether to add to the returned list
            //If the match doesnt have parts to go through, then just add to the list
            //If there is sub part in match, then iterate and match using regex and then add to list
            //finally return the complete list
            foreach (Match match in matches) {
                if (!scrapeCriteria.Parts.Any()) {
                    scrapedElements.Add(match.Groups[0].Value);
                }
                else {
                    foreach (var part in scrapeCriteria.Parts) {
                        Match matchedPart = Regex.Match(match.Groups[0].Value, part.Regex, part.Regexoption);

                        if (matchedPart.Success) {
                            scrapedElements.Add(matchedPart.Groups[1].Value);
                        }
                    }
                }
            }

            return scrapedElements;
        }
    }
}
