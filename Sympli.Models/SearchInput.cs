using System.ComponentModel.DataAnnotations;
using Sympli.Common.Validations;

namespace Sympli.Models
{
    public class SearchInput: ValidatingObject
    {
        /// <summary>
        /// string of Keywords to search for
        /// </summary>
        [Required]
        public string Keywords { get; set; }

        /// <summary>
        /// URL to search in
        /// </summary>
        [Required]
        public string URL { get; set; }
        
        /// <summary>
        /// SiteName to search for occurences
        /// </summary>
        [Required]
        public string SiteName { get; set; }

        /// <summary>
        /// Number of Results to scrap
        /// </summary>
        public int NumberOfResults { get; set; } = 100;
    }
}
