using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleWebScraper.Data
{
    public class ScrapeCriteria
    {
        public ScrapeCriteria()
        {
            Parts = new List<ScrapeCriteriaPart>();
        }

        //Data is the data retrieved to scrape - what to scrape
        //Regex is how to scrape
        //Options is
        //Parts defines how granular of each element scraped desired to scrape (part within the main element)
        public string Data { get; set; }
        public string Regex { get; set; }
        public RegexOptions RegexOption { get; set; }
        public List<ScrapeCriteriaPart> Parts { get; set; }
    }
}