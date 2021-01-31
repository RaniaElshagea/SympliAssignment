using System.Collections.Generic;
using Sympli.Models;

namespace Sympli.Application.Contracts
{
    public interface ISearchEngine
    {
        /// <summary>
        /// URL Builder to concatenate the required search engine with right query parameters
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="keywords">keywords</param>
        /// <param name="numberOfResults">number of results</param>
        /// <returns>url search string</returns>
        string URLBuilder(string keywords, int? numberOfResults);

        /// <summary>
        /// Retrieves the search results in an Html string
        /// </summary>
        /// <param name="htmlString">html as a s string</param>
        /// <returns></returns>
        IList<SearchResult> GetSearchResults(string htmlString);

        /// <summary>
        /// Checks if the factory engine can handle the search url input
        /// </summary>
        /// <param name="engineName">engine name</param>
        /// <returns></returns>
        bool WhichEngineToHandle(string engineName);
    }
}
