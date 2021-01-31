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
        public ISearchEngine SearchEngine { get; set; }

        public async Task<IList<SearchResult>> ScrapSearchEngine(SearchInput searchInput)
        {
            var html = string.Empty;
            using (var httpClient = new HttpClient())
            {
                var siteUrl = SearchEngine.URLBuilder(searchInput.URL, searchInput.Keywords, searchInput.NumberOfResults);
                html = await httpClient.GetStringAsync(siteUrl);
            }
            var foundSearchResults = SearchEngine.GetSearchResults(html);
            return foundSearchResults;
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
