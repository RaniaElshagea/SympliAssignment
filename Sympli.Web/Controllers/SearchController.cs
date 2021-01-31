using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sympli.Application.Contracts;
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
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)] // Caching is done now for 1 minutes rather than 1 hour
        public async Task<IActionResult> SearchSiteOccurences([FromBody] SearchInput searchInput)
        {
            try
            {
                if (searchInput.IsValid())
                { 
                    var searchResults = await _searchService.ScrapSearchEngine(searchInput);
                    var searchOutputResults = _searchService.SiteOccurences(searchResults, searchInput.SiteName);
                    return Ok(searchOutputResults);
                }
                return BadRequest(searchInput.GetValidationMessages());
            }
            catch (System.Exception ex)
            {
                // ILogger could be used or any other custom or 3d type validation
                return BadRequest(ex.Message);
            }
        }
    }
}
