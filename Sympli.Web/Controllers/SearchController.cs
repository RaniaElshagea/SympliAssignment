using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sympli.Application.Contracts;
using Sympli.Common.Extensions;
using Sympli.InfrastructureSearchEngines;
using Sympli.Models;

namespace Sympli.Web.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly ISearchEngineFactory _searchEngineFactory;

        public SearchController(ISearchService searchService, ISearchEngineFactory searchEngineFactory)
        {
            _searchService = searchService;
            _searchEngineFactory = searchEngineFactory;
        }

        [HttpPost("[action]")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> SearchSiteOccurences([FromBody] SearchInput searchInput)
        {
            try
            {
                if (searchInput.IsValid())
                { }
                //if (ModelState.IsValid) { }

                if (!searchInput.URL.IsValidUrl()) {
                    return BadRequest("error");
                }
                var searchResults = await _searchService.ScrapSearchEngine(searchInput);
                var occurencesString = _searchService.SiteOccurences(searchResults, searchInput.SiteName);
                return Ok(occurencesString);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
