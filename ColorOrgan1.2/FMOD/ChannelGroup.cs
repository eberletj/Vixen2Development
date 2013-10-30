using System;
using System.Runtime.InteropServices;
using System.Text;
namespace FMOD
{
	public class ChannelGroup
	{
		private IntPtr channelgroupraw;
		public RESULT release()
		{
			return ChannelGroup.FMOD_ChannelGroup_Release(channelgroupraw);
		}
		public RESULT getSystemObject(ref _System system)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = ChannelGroup.FMOD_ChannelGroup_GetSystemObject(channelgroupraw, ref raw);
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
					system2.setRaw(raw);
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
		public RESULT setVolume(float volume)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = ChannelGroup.FMOD_ChannelGroup_SetVolume_64(channelgroupraw, volume);
			}
			else
			{
				result = ChannelGroup.FMOD_ChannelGroup_SetVolume_32(channelgroupraw, volume);
			}
			return result;
		}
		public RESULT getVolume(ref float volume)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = ChannelGroup.FMOD_ChannelGroup_GetVolume_64(channelgroupraw, ref volume);
			}
			else
			{
				result = ChannelGroup.FMOD_ChannelGroup_GetVolume_32(channelgroupraw, ref volume);
			}
			return result;
		}
		public RESULT setPitch(float pitch)
		{
			return ChannelGroup.FMOD_ChannelGroup_SetPitch(channelgroupraw, pitch);
		}
		public RESULT getPitch(ref float pitch)
		{
			return ChannelGroup.FMOD_ChannelGroup_GetPitch(channelgroupraw, ref pitch);
		}
		public RESULT setPaused(bool paused)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = ChannelGroup.FMOD_ChannelGroup_SetPaused_64(channelgroupraw, paused ? 1 : 0);
			}
			else
			{
				result = ChannelGroup.FMOD_ChannelGroup_SetPaused_32(channelgroupraw, paused ? 1 : 0);
			}
			return result;
		}
		public RESULT getPaused(ref bool paused)
		{
			int num = 0;
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = ChannelGroup.FMOD_ChannelGroup_GetPaused_64(channelgroupraw, ref num);
			}
			else
			{
				result = ChannelGroup.FMOD_ChannelGroup_GetPaused_32(channelgroupraw, ref num);
			}
			paused = (num != 0);
			return result;
		}
		public RESULT setMute(bool mute)
		{
			return ChannelGroup.FMOD_ChannelGroup_SetMute(channelgroupraw, mute ? 1 : 0);
		}
		public RESULT getMute(ref bool mute)
		{
			int num = 0;
			RESULT result = ChannelGroup.FMOD_ChannelGroup_GetMute(channelgroupraw, ref num);
			mute = (num != 0);
			return result;
		}
		public RESULT stop()
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = ChannelGroup.FMOD_ChannelGroup_Stop_64(channelgroupraw);
			}
			else
			{
				result = ChannelGroup.FMOD_ChannelGroup_Stop_32(channelgroupraw);
			}
			return result;
		}
		public RESULT overrideVolume(float volume)
		{
			return ChannelGroup.FMOD_ChannelGroup_OverrideVolume(channelgroupraw, volume);
		}
		public RESULT overrideFrequency(float frequency)
		{
			return ChannelGroup.FMOD_ChannelGroup_OverrideFrequency(channelgroupraw, frequency);
		}
		public RESULT overridePan(float pan)
		{
			return ChannelGroup.FMOD_ChannelGroup_OverridePan(channelgroupraw, pan);
		}
		public RESULT overrideReverbProperties(ref REVERB_CHANNELPROPERTIES prop)
		{
			return ChannelGroup.FMOD_ChannelGroup_OverrideReverbProperties(channelgroupraw, ref prop);
		}
		public RESULT override3DAttributes(ref VECTOR pos, ref VECTOR vel)
		{
			return ChannelGroup.FMOD_ChannelGroup_Override3DAttributes(channelgroupraw, ref pos, ref vel);
		}
		public RESULT overrideSpeakerMix(float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright)
		{
			return ChannelGroup.FMOD_ChannelGroup_OverrideSpeakerMix(channelgroupraw, frontleft, frontright, center, lfe, backleft, backright, sideleft, sideright);
		}
		public RESULT addGroup(ChannelGroup group)
		{
			return ChannelGroup.FMOD_ChannelGroup_AddGroup(channelgroupraw, group.getRaw());
		}
		public RESULT getNumGroups(ref int numgroups)
		{
			return ChannelGroup.FMOD_ChannelGroup_GetNumGroups(channelgroupraw, ref numgroups);
		}
		public RESULT getGroup(int index, ref ChannelGroup group)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = ChannelGroup.FMOD_ChannelGroup_GetGroup(channelgroupraw, index, ref raw);
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
				if (group == null)
				{
					ChannelGroup channelGroup = new ChannelGroup();
					channelGroup.setRaw(raw);
					group = channelGroup;
				}
				else
				{
					group.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT getParentGroup(ref ChannelGroup group)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = ChannelGroup.FMOD_ChannelGroup_GetParentGroup(channelgroupraw, ref raw);
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
				if (group == null)
				{
					ChannelGroup channelGroup = new ChannelGroup();
					channelGroup.setRaw(raw);
					group = channelGroup;
				}
				else
				{
					group.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT getDSPHead(ref DSP dsp)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = ChannelGroup.FMOD_ChannelGroup_GetDSPHead(channelgroupraw, ref raw);
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
				if (dsp == null)
				{
					DSP dSP = new DSP();
					dSP.setRaw(raw);
					dsp = dSP;
				}
				else
				{
					dsp.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT addDSP(DSP dsp, ref DSPConnection dspconnection)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = ChannelGroup.FMOD_ChannelGroup_AddDSP(channelgroupraw, dsp.getRaw(), ref raw);
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
		public RESULT getName(StringBuilder name, int namelen)
		{
			return ChannelGroup.FMOD_ChannelGroup_GetName(channelgroupraw, name, namelen);
		}
		public RESULT getNumChannels(ref int numchannels)
		{
			return ChannelGroup.FMOD_ChannelGroup_GetNumChannels(channelgroupraw, ref numchannels);
		}
		public RESULT getChannel(int index, ref Channel channel)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = ChannelGroup.FMOD_ChannelGroup_GetChannel(channelgroupraw, index, ref raw);
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
				if (channel == null)
				{
					Channel channel2 = new Channel();
					channel2.setRaw(raw);
					channel = channel2;
				}
				else
				{
					channel.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT getSpectrum(float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype)
		{
			return ChannelGroup.FMOD_ChannelGroup_GetSpectrum(channelgroupraw, spectrumarray, numvalues, channeloffset, windowtype);
		}
		public RESULT getWaveData(float[] wavearray, int numvalues, int channeloffset)
		{
			return ChannelGroup.FMOD_ChannelGroup_GetWaveData(channelgroupraw, wavearray, numvalues, channeloffset);
		}
		public RESULT setUserData(IntPtr userdata)
		{
			return ChannelGroup.FMOD_ChannelGroup_SetUserData(channelgroupraw, userdata);
		}
		public RESULT getUserData(ref IntPtr userdata)
		{
			return ChannelGroup.FMOD_ChannelGroup_GetUserData(channelgroupraw, ref userdata);
		}
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_Release(IntPtr channelgroup);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetSystemObject(IntPtr channelgroup, ref IntPtr system);
		[DllImport("fmodex", EntryPoint = "FMOD_ChannelGroup_SetVolume")]
		private static extern RESULT FMOD_ChannelGroup_SetVolume_32(IntPtr channelgroup, float volume);
		[DllImport("fmodex64", EntryPoint = "FMOD_ChannelGroup_SetVolume")]
		private static extern RESULT FMOD_ChannelGroup_SetVolume_64(IntPtr channelgroup, float volume);
		[DllImport("fmodex", EntryPoint = "FMOD_ChannelGroup_GetVolume")]
		private static extern RESULT FMOD_ChannelGroup_GetVolume_32(IntPtr channelgroup, ref float volume);
		[DllImport("fmodex64", EntryPoint = "FMOD_ChannelGroup_GetVolume")]
		private static extern RESULT FMOD_ChannelGroup_GetVolume_64(IntPtr channelgroup, ref float volume);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_SetPitch(IntPtr channelgroup, float pitch);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetPitch(IntPtr channelgroup, ref float pitch);
		[DllImport("fmodex", EntryPoint = "FMOD_ChannelGroup_SetPaused")]
		private static extern RESULT FMOD_ChannelGroup_SetPaused_32(IntPtr channelgroup, int paused);
		[DllImport("fmodex64", EntryPoint = "FMOD_ChannelGroup_SetPaused")]
		private static extern RESULT FMOD_ChannelGroup_SetPaused_64(IntPtr channelgroup, int paused);
		[DllImport("fmodex", EntryPoint = "FMOD_ChannelGroup_GetPaused")]
		private static extern RESULT FMOD_ChannelGroup_GetPaused_32(IntPtr channelgroup, ref int paused);
		[DllImport("fmodex64", EntryPoint = "FMOD_ChannelGroup_GetPaused")]
		private static extern RESULT FMOD_ChannelGroup_GetPaused_64(IntPtr channelgroup, ref int paused);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_SetMute(IntPtr channelgroup, int mute);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetMute(IntPtr channelgroup, ref int mute);
		[DllImport("fmodex", EntryPoint = "FMOD_ChannelGroup_Stop")]
		private static extern RESULT FMOD_ChannelGroup_Stop_32(IntPtr channelgroup);
		[DllImport("fmodex64", EntryPoint = "FMOD_ChannelGroup_Stop")]
		private static extern RESULT FMOD_ChannelGroup_Stop_64(IntPtr channelgroup);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_OverridePaused(IntPtr channelgroup, bool paused);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_OverrideVolume(IntPtr channelgroup, float volume);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_OverrideFrequency(IntPtr channelgroup, float frequency);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_OverridePan(IntPtr channelgroup, float pan);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_OverrideMute(IntPtr channelgroup, bool mute);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_OverrideReverbProperties(IntPtr channelgroup, ref REVERB_CHANNELPROPERTIES prop);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_Override3DAttributes(IntPtr channelgroup, ref VECTOR pos, ref VECTOR vel);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_OverrideSpeakerMix(IntPtr channelgroup, float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_AddGroup(IntPtr channelgroup, IntPtr group);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetNumGroups(IntPtr channelgroup, ref int numgroups);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetGroup(IntPtr channelgroup, int index, ref IntPtr group);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetParentGroup(IntPtr channelgroup, ref IntPtr group);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetDSPHead(IntPtr channelgroup, ref IntPtr dsp);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_AddDSP(IntPtr channelgroup, IntPtr dsp, ref IntPtr dspconnection);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetName(IntPtr channelgroup, StringBuilder name, int namelen);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetNumChannels(IntPtr channelgroup, ref int numchannels);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetChannel(IntPtr channelgroup, int index, ref IntPtr channel);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetSpectrum(IntPtr channelgroup, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetWaveData(IntPtr channelgroup, [MarshalAs(UnmanagedType.LPArray)] float[] wavearray, int numvalues, int channeloffset);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_SetUserData(IntPtr channelgroup, IntPtr userdata);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_ChannelGroup_GetUserData(IntPtr channelgroup, ref IntPtr userdata);
		public void setRaw(IntPtr channelgroup)
		{
			channelgroupraw = IntPtr.Zero;
			channelgroupraw = channelgroup;
		}
		public IntPtr getRaw()
		{
			return channelgroupraw;
		}
	}
}
