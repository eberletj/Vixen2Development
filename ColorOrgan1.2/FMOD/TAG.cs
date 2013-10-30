using System;
namespace FMOD
{
	public struct TAG
	{
		public TAGTYPE type;
		public TAGDATATYPE datatype;
		public string name;
		public IntPtr data;
		public uint datalen;
		public bool updated;
	}
}
