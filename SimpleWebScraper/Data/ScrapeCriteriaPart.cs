using System;
using System.Text.RegularExpressions;

namespace SimpleWebScraper.Data
{
    public class ScrapeCriteriaPart
    {
        public ScrapeCriteriaPart()
        {
        }

        public string Regex { get; set; }
        public RegexOptions Regexoption { get; set; }
    }
}
