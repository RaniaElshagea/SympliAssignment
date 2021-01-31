using System;
using System.Collections.Generic;
using System.Linq;
using Sympli.Application.Contracts;

namespace Sympli.InfrastructureSearchEngines
{
    public class SearchEngineFactory: ISearchEngineFactory
    {
        private IEnumerable<ISearchEngine> searchEngines => GetSearchEngines();

        public ISearchEngine Create(string engineName)
        {
            return searchEngines.Single(s => s.WhichEngineToHandle(engineName));
        }

        private IEnumerable<ISearchEngine> GetSearchEngines()
        {
            var engineTypes = System.Reflection.Assembly.GetExecutingAssembly().ExportedTypes
                             .Where(t => t.GetInterfaces().Contains(typeof(ISearchEngine)));
            List<ISearchEngine> searchEngines = new List<ISearchEngine>(); 
            foreach (var type in engineTypes)
            {
                searchEngines.Add(type.GetConstructor(Type.EmptyTypes)?.Invoke(new object[0]) as ISearchEngine);
            }
            return searchEngines;
        }
    }
}
