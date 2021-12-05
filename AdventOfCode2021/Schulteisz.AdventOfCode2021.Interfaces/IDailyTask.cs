namespace Schulteisz.AdventOfCode2021.Interfaces
{
    /// <summary>
    /// Interface for the daily tasks
    /// </summary>
    public interface IDailyTask
    {
        /// <summary>
        /// Run daily task
        /// </summary>
        /// <returns>return value</returns>
        long Run();

        /// <summary>
        /// Name of the task
        /// </summary>
        string Name { get; }
    }
}
