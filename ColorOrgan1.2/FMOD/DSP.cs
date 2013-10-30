using System;
using System.Runtime.InteropServices;
using System.Text;
namespace FMOD
{
	public class DSP
	{
		private IntPtr dspraw;
		public RESULT release()
		{
			return DSP.FMOD_DSP_Release(dspraw);
		}
		public RESULT getSystemObject(ref _System system)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = DSP.FMOD_DSP_GetSystemObject(dspraw, ref raw);
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
				if (system == null)
				{
					_System system2 = new _System();
					system2.setRaw(dspraw);
					system = system2;
				}
				else
				{
					system.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT addInput(DSP target, ref DSPConnection dspconnection)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = DSP.FMOD_DSP_AddInput(dspraw, target.getRaw(), ref raw);
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
				if (dspconnection == null)
				{
					DSPConnection dSPConnection = new DSPConnection();
					dSPConnection.setRaw(raw);
					dspconnection = dSPConnection;
				}
				else
				{
					dspconnection.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT disconnectFrom(DSP target)
		{
			return DSP.FMOD_DSP_DisconnectFrom(dspraw, target.getRaw());
		}
		public RESULT disconnectAll(bool inputs, bool outputs)
		{
			return DSP.FMOD_DSP_DisconnectAll(dspraw, inputs ? 1 : 0, outputs ? 1 : 0);
		}
		public RESULT remove()
		{
			return DSP.FMOD_DSP_Remove(dspraw);
		}
		public RESULT getNumInputs(ref int numinputs)
		{
			return DSP.FMOD_DSP_GetNumInputs(dspraw, ref numinputs);
		}
		public RESULT getNumOutputs(ref int numoutputs)
		{
			return DSP.FMOD_DSP_GetNumOutputs(dspraw, ref numoutputs);
		}
		public RESULT getInput(int index, ref DSP input, ref DSPConnection inputconnection)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			IntPtr raw2 = IntPtr.Zero;
			try
			{
				rESULT = DSP.FMOD_DSP_GetInput(dspraw, index, ref raw, ref raw2);
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
				if (inputconnection == null)
				{
					DSPConnection dSPConnection = new DSPConnection();
					dSPConnection.setRaw(raw2);
					inputconnection = dSPConnection;
				}
				else
				{
					inputconnection.setRaw(raw2);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT getOutput(int index, ref DSP output, ref DSPConnection outputconnection)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			IntPtr raw2 = IntPtr.Zero;
			try
			{
				rESULT = DSP.FMOD_DSP_GetOutput(dspraw, index, ref raw, ref raw2);
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
				if (outputconnection == null)
				{
					DSPConnection dSPConnection = new DSPConnection();
					dSPConnection.setRaw(raw2);
					outputconnection = dSPConnection;
				}
				else
				{
					outputconnection.setRaw(raw2);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT setActive(bool active)
		{
			return DSP.FMOD_DSP_SetActive(dspraw, active ? 1 : 0);
		}
		public RESULT getActive(ref bool active)
		{
			int num = 0;
			RESULT result = DSP.FMOD_DSP_GetActive(dspraw, ref num);
			active = (num != 0);
			return result;
		}
		public RESULT setBypass(bool bypass)
		{
			return DSP.FMOD_DSP_SetBypass(dspraw, bypass ? 1 : 0);
		}
		public RESULT getBypass(ref bool bypass)
		{
			int num = 0;
			RESULT result = DSP.FMOD_DSP_GetBypass(dspraw, ref num);
			bypass = (num != 0);
			return result;
		}
		public RESULT reset()
		{
			return DSP.FMOD_DSP_Reset(dspraw);
		}
		public RESULT setParameter(int index, float val)
		{
			return DSP.FMOD_DSP_SetParameter(dspraw, index, val);
		}
		public RESULT getParameter(int index, ref float val, StringBuilder valuestr, int valuestrlen)
		{
			return DSP.FMOD_DSP_GetParameter(dspraw, index, ref val, valuestr, valuestrlen);
		}
		public RESULT getNumParameters(ref int numparams)
		{
			return DSP.FMOD_DSP_GetNumParameters(dspraw, ref numparams);
		}
		public RESULT getParameterInfo(int index, StringBuilder name, StringBuilder label, StringBuilder description, int descriptionlen, ref float min, ref float max)
		{
			return DSP.FMOD_DSP_GetParameterInfo(dspraw, index, name, label, description, descriptionlen, ref min, ref max);
		}
		public RESULT showConfigDialog(IntPtr hwnd, bool show)
		{
			return DSP.FMOD_DSP_ShowConfigDialog(dspraw, hwnd, show);
		}
		public RESULT getInfo(StringBuilder name, ref uint version, ref int channels, ref int configwidth, ref int configheight)
		{
			return DSP.FMOD_DSP_GetInfo(dspraw, name, ref version, ref channels, ref configwidth, ref configheight);
		}
		public RESULT getType(ref DSP_TYPE type)
		{
			return DSP.FMOD_DSP_GetType(dspraw, ref type);
		}
		public RESULT setDefaults(float frequency, float volume, float pan, int priority)
		{
			return DSP.FMOD_DSP_SetDefaults(dspraw, frequency, volume, pan, priority);
		}
		public RESULT getDefaults(ref float frequency, ref float volume, ref float pan, ref int priority)
		{
			return DSP.FMOD_DSP_GetDefaults(dspraw, ref frequency, ref volume, ref pan, ref priority);
		}
		public RESULT setUserData(IntPtr userdata)
		{
			return DSP.FMOD_DSP_SetUserData(dspraw, userdata);
		}
		public RESULT getUserData(ref IntPtr userdata)
		{
			return DSP.FMOD_DSP_GetUserData(dspraw, ref userdata);
		}
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_Release(IntPtr dsp);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetSystemObject(IntPtr dsp, ref IntPtr system);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_AddInput(IntPtr dsp, IntPtr target, ref IntPtr dspconnection);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_DisconnectFrom(IntPtr dsp, IntPtr target);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_DisconnectAll(IntPtr dsp, int inputs, int outputs);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_Remove(IntPtr dsp);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetNumInputs(IntPtr dsp, ref int numinputs);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetNumOutputs(IntPtr dsp, ref int numoutputs);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetInput(IntPtr dsp, int index, ref IntPtr input, ref IntPtr inputconnection);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetOutput(IntPtr dsp, int index, ref IntPtr output, ref IntPtr outputconnection);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_SetActive(IntPtr dsp, int active);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetActive(IntPtr dsp, ref int active);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_SetBypass(IntPtr dsp, int bypass);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetBypass(IntPtr dsp, ref int bypass);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_Reset(IntPtr dsp);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_SetParameter(IntPtr dsp, int index, float val);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetParameter(IntPtr dsp, int index, ref float val, StringBuilder valuestr, int valuestrlen);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetNumParameters(IntPtr dsp, ref int numparams);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetParameterInfo(IntPtr dsp, int index, StringBuilder name, StringBuilder label, StringBuilder description, int descriptionlen, ref float min, ref float max);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_ShowConfigDialog(IntPtr dsp, IntPtr hwnd, bool show);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetInfo(IntPtr dsp, StringBuilder name, ref uint version, ref int channels, ref int configwidth, ref int configheight);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetType(IntPtr dsp, ref DSP_TYPE type);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_SetDefaults(IntPtr dsp, float frequency, float volume, float pan, int priority);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetDefaults(IntPtr dsp, ref float frequency, ref float volume, ref float pan, ref int priority);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_SetUserData(IntPtr dsp, IntPtr userdata);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_DSP_GetUserData(IntPtr dsp, ref IntPtr userdata);
		public void setRaw(IntPtr dsp)
		{
			dspraw = IntPtr.Zero;
			dspraw = dsp;
		}
		public IntPtr getRaw()
		{
			return dspraw;
		}
	}
}
