using System;
using System.Runtime.InteropServices;
namespace FMOD
{
	public class Memory
	{
		public static RESULT GetStats(ref int currentalloced, ref int maxalloced)
		{
			return Memory.FMOD_Memory_GetStats(ref currentalloced, ref maxalloced);
		}
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Memory_GetStats(ref int currentalloced, ref int maxalloced);
	}
}
