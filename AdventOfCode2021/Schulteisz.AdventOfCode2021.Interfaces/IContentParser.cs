namespace Schulteisz.AdventOfCode2021.Interfaces
{
    /// <summary>
    /// Parse the manifest files
    /// </summary>
    public interface IContentParser
    {
        /// <summary>
        /// Get all lines from the manifest file
        /// </summary>
        /// <param name="manifestName"></param>
        /// <returns>List of the lines</returns>
        List<string> GetLines(string manifestName);
    }
}
