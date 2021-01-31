using System.ComponentModel.DataAnnotations;

namespace Sympli.Models
{
    public class SearchInput
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
        [RegularExpression(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$",
            ErrorMessage = "URL not in a correct format")]
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
