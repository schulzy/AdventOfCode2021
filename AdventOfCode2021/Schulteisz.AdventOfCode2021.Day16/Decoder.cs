using System;
using System.Linq;
namespace Schulteisz.AdventOfCode2021.Day16
{
	public class Decoder : IDecoder
    {
		private string _hexaCode;
		private string _binarystring;

        public Decoder(string hexaCode)
		{
			_hexaCode = hexaCode;
			_binarystring = String.Join(String.Empty,
				hexaCode.Select(
				c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'))
			);
        }

        public string BinaryCode => _binarystring;
    }

	public interface IDecoder
	{
		public string BinaryCode { get; }
	}
}

