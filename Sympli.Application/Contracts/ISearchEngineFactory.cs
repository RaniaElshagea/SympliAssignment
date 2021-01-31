namespace Sympli.Application.Contracts
{
    public interface ISearchEngineFactory
    {
        /// <summary>
        /// Creates at run time the right search engine to be injected to the service
        /// </summary>
        /// <param name="engineName">engine name</param>
        /// <returns></returns>
        ISearchEngine Create(string engineName);
    }
}
