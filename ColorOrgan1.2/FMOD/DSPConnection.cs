using System;
using System.Runtime.InteropServices;
namespace FMOD
{
	public class DSPConnection
	{
		private IntPtr dspconnectionraw;
		public RESULT getInput(ref DSP input)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = DSPConnection.FMOD_DSPConnection_GetInput(dspconnectionraw, ref raw);
			}
			catch
			{
				rESULT = RESULT.ERR_INVALID_PARAM;
			}
			RESULT result;
			if (rESULT != RESULT.OK)
			{
				result = rESULT;
			}
			else
			{
				if (input == null)
				{
					DSP dSP = new DSP();
					dSP.setRaw(raw);
					input = dSP;
				}
				else
				{
					input.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT getOutput(ref DSP output)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = DSPConnection.FMOD_DSPConnection_GetOutput(dspconnectionraw, ref raw);
			}
			catch
			{
				rESULT = RESULT.ERR_INVALID_PARAM;
			}
			RESULT result;
			if (rESULT != RESULT.OK)
			{
				result = rESULT;
			}
			else
			{
				if (output == null)
				{
					DSP dSP = new DSP();
					dSP.setRaw(raw);
					output = dSP;
				}
				else
				{
					output.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT setMix(float volume)
		{
			return DSPConnection.FMOD_DSPConnection_SetMix(dspconnectionraw, volume);
		}
		public RESULT getMix(ref float volume)
		{
			return DSPConnection.FMOD_DSPConnection_GetMix(dspconnectionraw, ref volume);
		}
		public RESULT setLevels(SPEAKER speaker, float[] levels, int numlevels)
		{
			return DSPConnection.FMOD_DSPConnection_SetLevels(dspconnectionraw, speaker, levels, numlevels);
		}
		public RESULT getLevels(SPEAKER speaker, float[] levels, int numlevels)
		{
			return DSPConnection.FMOD_DSPConnection_GetLevels(dspconnectionraw, speaker, levels, numlevels);
		}
		public RESULT setUserData(IntPtr userdata)
		{
			return DSPConnection.FMOD_DSPConnection_SetUserData(dspconnectionraw, userdata);
		}
		public RESULT getUserData(ref IntPtr userdata)
		{
			return DSPConnection.FMOD_DSPConnection_GetUserData(dspconnectionraw, ref userdata);
		}
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSPConnection_GetInput(IntPtr dspconnection, ref IntPtr input);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSPConnection_GetOutput(IntPtr dspconnection, ref IntPtr output);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSPConnection_SetMix(IntPtr dspconnection, float volume);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSPConnection_GetMix(IntPtr dspconnection, ref float volume);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSPConnection_SetLevels(IntPtr dspconnection, SPEAKER speaker, float[] levels, int numlevels);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSPConnection_GetLevels(IntPtr dspconnection, SPEAKER speaker, float[] levels, int numlevels);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSPConnection_SetUserData(IntPtr dspconnection, IntPtr userdata);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSPConnection_GetUserData(IntPtr dspconnection, ref IntPtr userdata);
		public void setRaw(IntPtr dspconnection)
		{
			dspconnectionraw = IntPtr.Zero;
			dspconnectionraw = dspconnection;
		}
		public IntPtr getRaw()
		{
			return dspconnectionraw;
		}
	}
}
