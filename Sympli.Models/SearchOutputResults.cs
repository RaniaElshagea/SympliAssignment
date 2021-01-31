namespace Sympli.Models
{
    public class SearchOutputResults
    {
        /// <summary>
        /// Occurences Positions
        /// </summary>
        public int[] Occurences { get; set; }

        /// <summary>
        /// Occurences in a string format
        /// </summary>
        public string OccurencesResult => string.Join(",", Occurences);
    }
}
