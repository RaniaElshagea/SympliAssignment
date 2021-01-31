using System.Collections.Generic;
using Sympli.Models;

namespace Sympli.Application.Contracts
{
    public interface ISearchEngine
    {
        string URLBuilder(string url, string keywords, int? numberOfResults);
        IList<SearchResult> GetSearchResults(string htmlString);
        bool WhichEngineToHandle(string engineName);
    }
}
