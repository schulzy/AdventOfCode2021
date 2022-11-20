using System;
using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day16
{
	public class PacketDecoderHard : IDailyTask
    {
        private IContentParser _contentParser;

        public PacketDecoderHard(IContentParser contentParser)
		{
            _contentParser = contentParser;
        }

        public string Name => "Packet Decoder Hard";

        public long Run()
        {
            IDecoder decoder = new Decoder(_contentParser.GetLines("Task.txt").First());

            return 0;
        }
    }
}

