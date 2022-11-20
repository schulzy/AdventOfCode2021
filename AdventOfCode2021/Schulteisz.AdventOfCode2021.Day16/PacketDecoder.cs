using System;
using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day16
{
	public class PacketDecoder : IDailyTask
    {
        private IContentParser _contentParser;

        public PacketDecoder(IContentParser contentParser)
		{
            _contentParser = contentParser;
        }

        public string Name => "Packet Decoder";

        public long Run()
        {
            IDecoder decoder = new Decoder(_contentParser.GetLines("Task.txt").First());

            return 0;
        }
    }
}

