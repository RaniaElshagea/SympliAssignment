using System.Collections.Generic;
using System.Threading.Tasks;
using Sympli.Models;

namespace Sympli.Application.Contracts
{
    public interface ISearchService
    {
        ISearchEngine SearchEngine { get; set; }
        Task<IList<SearchResult>> ScrapSearchEngine(SearchInput searchInput);
        SearchOutputResults SiteOccurences(IList<SearchResult> searchResults, string site);
    }
}
 