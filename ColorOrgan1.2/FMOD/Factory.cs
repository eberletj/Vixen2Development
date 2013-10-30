using System;
using System.Runtime.InteropServices;
namespace FMOD
{
	public class Factory
	{
		public static RESULT System_Create(ref _System system)
		{
			IntPtr raw = IntPtr.Zero;
			RESULT rESULT;
			if (VERSION.platform == Platform.X64)
			{
				rESULT = Factory.FMOD_System_Create_64(ref raw);
			}
			else
			{
				rESULT = Factory.FMOD_System_Create_32(ref raw);
			}
			RESULT result;
			if (rESULT != RESULT.OK)
			{
				result = rESULT;
			}
			else
			{
				_System system2 = new _System();
				system2.setRaw(raw);
				system = system2;
				result = rESULT;
			}
			return result;
		}
		[DllImport("fmodex", EntryPoint = "FMOD_System_Create")]
		private static extern RESULT FMOD_System_Create_32(ref IntPtr system);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_Create")]
		private static extern RESULT FMOD_System_Create_64(ref IntPtr system);
	}
}
