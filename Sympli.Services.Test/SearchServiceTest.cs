using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sympli.Application.Contracts;
using Sympli.InfrastructureSearchEngines;
using Sympli.Models;

namespace Sympli.Services.Test
{
    [TestClass]
    public class SearchServiceTest
    {
        private Mock<ISearchEngineFactory> _mockSearchEngineFactory = new Mock<ISearchEngineFactory>();
        private SearchInput searchInput;
        private ISearchService service;

        [TestInitialize]
        public void Initialize()
        {
            searchInput = new SearchInput();
            searchInput.URL = "https://www.google.com";
            searchInput.Keywords = "e-settlment";
            searchInput.SiteName = "sympli";

            _mockSearchEngineFactory.Setup(mock => mock.Create(searchInput.URL)).Returns(new GoogleSearchEngine());
            service = new SearchService(_mockSearchEngineFactory.Object);
        }

        [TestMethod]
        public async Task ScrapSearchEngineShouldReturnResultWithValidInput()
        {
            var result = await service.ScrapSearchEngine(searchInput);
            Assert.IsNotNull(result);
        }
    }
}
