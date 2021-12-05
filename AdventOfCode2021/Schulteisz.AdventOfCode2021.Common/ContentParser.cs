using Schulteisz.AdventOfCode2021.Interfaces;
using System.Reflection;

namespace Schulteisz.AdventOfCode2021.Common
{
    public class ContentParser : IContentParser
    {
        public List<string> GetLines(string manifestName)
        {
            var lines = new List<string>();
            var assembly = Assembly.GetCallingAssembly();
            var manifest = assembly.GetManifestResourceNames().FirstOrDefault(x=> x.EndsWith(manifestName));
            if (manifest == null)
                return lines;
            using (var stream = assembly.GetManifestResourceStream(manifest))
            {
                if (stream == null)
                    return lines;

                StreamReader reader = new StreamReader(stream);
                while (reader.Peek() >= 0)
                {
                    string? line = reader.ReadLine();
                    if(!string.IsNullOrEmpty(line))
                        lines.Add(line);
                }
            }
            return lines;
        }
    }
}
