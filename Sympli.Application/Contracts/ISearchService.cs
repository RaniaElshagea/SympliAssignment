using System.Collections.Generic;
using System.Threading.Tasks;
using Sympli.Models;

namespace Sympli.Application.Contracts
{
    public interface ISearchService
    {
        /// <summary>
        /// Scrap Search engine based on input data
        /// </summary>
        /// <param name="searchInput">searchInput model</param>
        /// <returns>List of search results</returns>
        Task<IList<SearchResult>> ScrapSearchEngine(SearchInput searchInput);

        /// <summary>
        /// Method to check search Results to search for site occurences
        /// </summary>
        /// <param name="searchResults">search results</param>
        /// <param name="site">site name</param>
        /// <returns>Search output results with occurences</returns>
        SearchOutputResults SiteOccurences(IList<SearchResult> searchResults, string site);
    }
}
 