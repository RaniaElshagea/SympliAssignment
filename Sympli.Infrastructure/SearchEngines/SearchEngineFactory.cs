using System.Collections.Generic;
using System.Linq;
using Sympli.Application.Contracts;

namespace Sympli.InfrastructureSearchEngines
{
    public class SearchEngineFactory: ISearchEngineFactory
    {
        private IList<ISearchEngine> _searchEngines = new List<ISearchEngine>();
        public SearchEngineFactory()//ISearchEngine[] searchEngines
        {
            _searchEngines.Add(new GoogleSearchEngine());
            _searchEngines.Add(new BingSearchEngine());
        }

        public ISearchEngine Create(string engineName)
        {
            return _searchEngines.Single(s => s.WhichEngineToHandle(engineName));
        }
    }
}
