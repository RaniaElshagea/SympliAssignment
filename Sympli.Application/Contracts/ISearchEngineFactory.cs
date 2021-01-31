namespace Sympli.Application.Contracts
{
    public interface ISearchEngineFactory
    {
        ISearchEngine Create(string engineName);
    }
}
