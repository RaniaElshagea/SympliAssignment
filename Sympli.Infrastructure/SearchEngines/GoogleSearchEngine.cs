using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Sympli.Application.Contracts;
using Sympli.Models;

namespace Sympli.InfrastructureSearchEngines
{
    public class GoogleSearchEngine : ISearchEngine
    {
        private string _urlBuilder;

        public string URLBuilder(string url, string keywords, int? numberOfResults = 100)
        {
            _urlBuilder = string.Format("{0}/search?q={1}&num={2}", url, keywords, numberOfResults);
            return _urlBuilder;
        }

        public IList<SearchResult> GetSearchResults(string htmlString)
        {
            IList<SearchResult> foundSearchResults = new List<SearchResult>();
            try
            {
                string regCiteExp = "<div class=\"kCrYT\"><a href=\"/url?.*?sa=U&amp;";
                var urlExp = new Regex(regCiteExp);
                int positionIndex = 0;
                SearchResult result;
                var results = urlExp.Matches(htmlString);
                foreach (Match m in urlExp.Matches(htmlString))
                {
                    string embeddedCiteUrl = m.Value.Replace("<div class=\"kCrYT\"><a href=\"/url?q=", "").Replace("&amp;sa=U&amp;", "");

                    if (!string.IsNullOrEmpty(embeddedCiteUrl))
                    {
                        result = new SearchResult();
                        positionIndex++;
                        result.Occurence = positionIndex;
                        result.ResultingURLSearchOutput = embeddedCiteUrl;
                        foundSearchResults.Add(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // ILogger could be used or any other custom or 3d type validation
                throw ex;
            }
            return foundSearchResults;
        }

        public bool WhichEngineToHandle(string engineName)
        {
            return engineName.Contains("google", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
