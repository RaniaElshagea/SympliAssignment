using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void SiteOccurencesShouldReturnOccurencesWithValidInput()
        {
            var searchResults = new List<SearchResult>();
            searchResults.Add(new SearchResult()
            {
                Occurence = 1,
                ResultingURLSearchOutput = "www.sympli.com"
            });
            searchResults.Add(new SearchResult()
            {
                Occurence = 2,
                ResultingURLSearchOutput = "www.pexa.com"
            });
            searchResults.Add(new SearchResult()
            {
                Occurence = 3,
                ResultingURLSearchOutput = "www.sympli.com"
            });

            var result = service.SiteOccurences(searchResults, searchInput.SiteName);
            Assert.IsNotNull(result.Occurences);
            Assert.AreEqual(result.OccurencesResult, "1,3");
        }
    }
}
