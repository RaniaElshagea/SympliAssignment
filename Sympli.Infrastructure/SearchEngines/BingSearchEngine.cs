using System;
using System.Collections.Generic;
using Sympli.Application.Contracts;
using Sympli.Models;

namespace Sympli.InfrastructureSearchEngines
{
    public class BingSearchEngine : ISearchEngine
    {
        public string URLBuilder(string url, string keywords, int? numberOfResults = 100)
        {
            throw new NotImplementedException();
        }

        public IList<SearchResult> GetSearchResults(string htmlString)
        {
            throw new NotImplementedException();
        }

        public bool WhichEngineToHandle(string engineName)
        {
            return engineName.Contains("bing", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
