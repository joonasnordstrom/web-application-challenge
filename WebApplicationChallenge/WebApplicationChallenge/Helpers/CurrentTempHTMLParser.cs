using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VincitWebApplication.Helpers
{
    /// <summary>
    /// Handles retreiving current temperature in Helsinki from "http://wttr.in/Helsinki"
    /// </summary>
    public class CurrentTempHTMLParser
    {
        private string Url => "http://wttr.in/Helsinki";
        private HtmlWeb HTML => new HtmlWeb();
        public CurrentTempHTMLParser()
        { }

        /// <summary>
        /// Returns current temperature in Helsinki 
        /// </summary>
        public async Task<double> GetCurrentTempAsync()
        {
            HtmlDocument doc = await HTML.LoadFromWebAsync(Url);
            HtmlNode response = doc.DocumentNode.SelectSingleNode("(//span/following-sibling::text()[contains(., '°C')])[1]/preceding-sibling::span[1]");
            
            if (response == null) throw new ArgumentNullException("HTML structure has changed.");
            if (!double.TryParse(response.InnerText, out double currentTemp)) throw new InvalidCastException("HTML Data changed");

            return currentTemp;
        }
    }
}
