using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Sympli.Application.Contracts;
using Sympli.Models;

namespace Sympli.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchEngineFactory _searchEngineFactory;

        public SearchService(ISearchEngineFactory searchEngineFactory)
        {
            _searchEngineFactory = searchEngineFactory;
        }

        public async Task<IList<SearchResult>> ScrapSearchEngine(SearchInput searchInput)
        {
            var html = string.Empty;

            var searchEngine = _searchEngineFactory.Create(searchInput.URL);
            if (searchEngine != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var siteUrl = searchEngine.URLBuilder(searchInput.URL, searchInput.Keywords, searchInput.NumberOfResults);
                    html = await httpClient.GetStringAsync(siteUrl);
                }
                var foundSearchResults = searchEngine.GetSearchResults(html);
                return foundSearchResults;
            }
            throw new ArgumentNullException("Search engine not declared");
        }

        public SearchOutputResults SiteOccurences(IList<SearchResult> searchResults, string site)
        {
            var occurences = searchResults.Where(s => s.ResultingURLSearchOutput.ToLower().Contains(site.ToLower()))
                            .Select(x => x.Occurence).ToArray();
            var outputResults = new SearchOutputResults()
            {
                Occurences = occurences
            };
            return outputResults;
        }
    }
}
