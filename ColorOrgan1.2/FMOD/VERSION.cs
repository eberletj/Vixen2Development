using System;
using System.Runtime.InteropServices;
namespace FMOD
{
	public class VERSION
	{
		internal struct SYSTEM_INFO
		{
			public ushort wProcessorArchitecture;
			public ushort wReserved;
			public uint dwPageSize;
			public IntPtr lpMinimumApplicationAddress;
			public IntPtr lpMaximumApplicationAddress;
			public UIntPtr dwActiveProcessorMask;
			public uint dwNumberOfProcessors;
			public uint dwProcessorType;
			public uint dwAllocationGranularity;
			public ushort wProcessorLevel;
			public ushort wProcessorRevision;
		}
		public const int number = 268292;
		public const string dll = "fmodex";
		public const string dll32 = "fmodex";
		public const string dll64 = "fmodex64";
		internal const ushort PROCESSOR_ARCHITECTURE_INTEL = 0;
		internal const ushort PROCESSOR_ARCHITECTURE_IA64 = 6;
		internal const ushort PROCESSOR_ARCHITECTURE_AMD64 = 9;
		internal const ushort PROCESSOR_ARCHITECTURE_UNKNOWN = 65535;
		public static Platform platform = VERSION.GetPlatform();
		[DllImport("kernel32.dll")]
		internal static extern void GetNativeSystemInfo(ref VERSION.SYSTEM_INFO lpSystemInfo);
		private static Platform GetPlatform()
		{
			VERSION.SYSTEM_INFO sYSTEM_INFO = default(VERSION.SYSTEM_INFO);
			VERSION.GetNativeSystemInfo(ref sYSTEM_INFO);
			ushort wProcessorArchitecture = sYSTEM_INFO.wProcessorArchitecture;
			Platform result;
			if (wProcessorArchitecture != 0)
			{
				if (wProcessorArchitecture != 9)
				{
					result = Platform.Unknown;
				}
				else
				{
					result = Platform.X64;
				}
			}
			else
			{
				result = Platform.X86;
			}
			return result;
		}
	}
}
