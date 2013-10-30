using System;
using System.Runtime.InteropServices;
namespace FMOD
{
	public class Channel
	{
		private IntPtr channelraw;
		public RESULT getSystemObject(ref _System system)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = Channel.FMOD_Channel_GetSystemObject(channelraw, ref raw);
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
		public RESULT stop()
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Channel.FMOD_Channel_Stop_64(channelraw);
			}
			else
			{
				result = Channel.FMOD_Channel_Stop_32(channelraw);
			}
			return result;
		}
		public RESULT setPaused(bool paused)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Channel.FMOD_Channel_SetPaused_64(channelraw, paused ? 1 : 0);
			}
			else
			{
				result = Channel.FMOD_Channel_SetPaused_32(channelraw, paused ? 1 : 0);
			}
			return result;
		}
		public RESULT getPaused(ref bool paused)
		{
			int num = 0;
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Channel.FMOD_Channel_GetPaused_64(channelraw, ref num);
			}
			else
			{
				result = Channel.FMOD_Channel_GetPaused_32(channelraw, ref num);
			}
			paused = (num != 0);
			return result;
		}
		public RESULT setVolume(float volume)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Channel.FMOD_Channel_SetVolume_64(channelraw, volume);
			}
			else
			{
				result = Channel.FMOD_Channel_SetVolume_32(channelraw, volume);
			}
			return result;
		}
		public RESULT getVolume(ref float volume)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Channel.FMOD_Channel_GetVolume_64(channelraw, ref volume);
			}
			else
			{
				result = Channel.FMOD_Channel_GetVolume_32(channelraw, ref volume);
			}
			return result;
		}
		public RESULT setFrequency(float frequency)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Channel.FMOD_Channel_SetFrequency_64(channelraw, frequency);
			}
			else
			{
				result = Channel.FMOD_Channel_SetFrequency_32(channelraw, frequency);
			}
			return result;
		}
		public RESULT getFrequency(ref float frequency)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Channel.FMOD_Channel_GetFrequency_64(channelraw, ref frequency);
			}
			else
			{
				result = Channel.FMOD_Channel_GetFrequency_32(channelraw, ref frequency);
			}
			return result;
		}
		public RESULT setPan(float pan)
		{
			return Channel.FMOD_Channel_SetPan(channelraw, pan);
		}
		public RESULT getPan(ref float pan)
		{
			return Channel.FMOD_Channel_GetPan(channelraw, ref pan);
		}
		public RESULT setDelay(DELAYTYPE delaytype, uint delayhi, uint delaylo)
		{
			return Channel.FMOD_Channel_SetDelay(channelraw, delaytype, delayhi, delaylo);
		}
		public RESULT getDelay(DELAYTYPE delaytype, ref uint delayhi, ref uint delaylo)
		{
			return Channel.FMOD_Channel_GetDelay(channelraw, delaytype, ref delayhi, ref delaylo);
		}
		public RESULT setSpeakerMix(float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright)
		{
			return Channel.FMOD_Channel_SetSpeakerMix(channelraw, frontleft, frontright, center, lfe, backleft, backright, sideleft, sideright);
		}
		public RESULT getSpeakerMix(ref float frontleft, ref float frontright, ref float center, ref float lfe, ref float backleft, ref float backright, ref float sideleft, ref float sideright)
		{
			return Channel.FMOD_Channel_GetSpeakerMix(channelraw, ref frontleft, ref frontright, ref center, ref lfe, ref backleft, ref backright, ref sideleft, ref sideright);
		}
		public RESULT setSpeakerLevels(SPEAKER speaker, float[] levels, int numlevels)
		{
			return Channel.FMOD_Channel_SetSpeakerLevels(channelraw, speaker, levels, numlevels);
		}
		public RESULT getSpeakerLevels(SPEAKER speaker, float[] levels, int numlevels)
		{
			return Channel.FMOD_Channel_GetSpeakerLevels(channelraw, speaker, levels, numlevels);
		}
		public RESULT setInputChannelMix(ref float levels, int numlevels)
		{
			return Channel.FMOD_Channel_SetInputChannelMix(channelraw, ref levels, numlevels);
		}
		public RESULT getInputChannelMix(ref float levels, int numlevels)
		{
			return Channel.FMOD_Channel_GetInputChannelMix(channelraw, ref levels, numlevels);
		}
		public RESULT setMute(bool mute)
		{
			return Channel.FMOD_Channel_SetMute(channelraw, mute ? 1 : 0);
		}
		public RESULT getMute(ref bool mute)
		{
			int num = 0;
			RESULT result = Channel.FMOD_Channel_GetMute(channelraw, ref num);
			mute = (num != 0);
			return result;
		}
		public RESULT setPriority(int priority)
		{
			return Channel.FMOD_Channel_SetPriority(channelraw, priority);
		}
		public RESULT getPriority(ref int priority)
		{
			return Channel.FMOD_Channel_GetPriority(channelraw, ref priority);
		}
		public RESULT setPosition(uint position, TIMEUNIT postype)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Channel.FMOD_Channel_SetPosition_64(channelraw, position, postype);
			}
			else
			{
				result = Channel.FMOD_Channel_SetPosition_32(channelraw, position, postype);
			}
			return result;
		}
		public RESULT getPosition(ref uint position, TIMEUNIT postype)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Channel.FMOD_Channel_GetPosition_64(channelraw, ref position, postype);
			}
			else
			{
				result = Channel.FMOD_Channel_GetPosition_32(channelraw, ref position, postype);
			}
			return result;
		}
		public RESULT setReverbProperties(ref REVERB_CHANNELPROPERTIES prop)
		{
			return Channel.FMOD_Channel_SetReverbProperties(channelraw, ref prop);
		}
		public RESULT getReverbProperties(ref REVERB_CHANNELPROPERTIES prop)
		{
			return Channel.FMOD_Channel_GetReverbProperties(channelraw, ref prop);
		}
		public RESULT setChannelGroup(ChannelGroup channelgroup)
		{
			return Channel.FMOD_Channel_SetChannelGroup(channelraw, channelgroup.getRaw());
		}
		public RESULT getChannelGroup(ref ChannelGroup channelgroup)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = Channel.FMOD_Channel_GetChannelGroup(channelraw, ref raw);
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
				if (channelgroup == null)
				{
					ChannelGroup channelGroup = new ChannelGroup();
					channelGroup.setRaw(raw);
					channelgroup = channelGroup;
				}
				else
				{
					channelgroup.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT setCallback(CHANNEL_CALLBACKTYPE type, CHANNEL_CALLBACK callback, int command)
		{
			return Channel.FMOD_Channel_SetCallback(channelraw, type, callback, command);
		}
		public RESULT set3DAttributes(ref VECTOR pos, ref VECTOR vel)
		{
			return Channel.FMOD_Channel_Set3DAttributes(channelraw, ref pos, ref vel);
		}
		public RESULT get3DAttributes(ref VECTOR pos, ref VECTOR vel)
		{
			return Channel.FMOD_Channel_Get3DAttributes(channelraw, ref pos, ref vel);
		}
		public RESULT set3DMinMaxDistance(float mindistance, float maxdistance)
		{
			return Channel.FMOD_Channel_Set3DMinMaxDistance(channelraw, mindistance, maxdistance);
		}
		public RESULT get3DMinMaxDistance(ref float mindistance, ref float maxdistance)
		{
			return Channel.FMOD_Channel_Get3DMinMaxDistance(channelraw, ref mindistance, ref maxdistance);
		}
		public RESULT set3DConeSettings(float insideconeangle, float outsideconeangle, float outsidevolume)
		{
			return Channel.FMOD_Channel_Set3DConeSettings(channelraw, insideconeangle, outsideconeangle, outsidevolume);
		}
		public RESULT get3DConeSettings(ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume)
		{
			return Channel.FMOD_Channel_Get3DConeSettings(channelraw, ref insideconeangle, ref outsideconeangle, ref outsidevolume);
		}
		public RESULT set3DConeOrientation(ref VECTOR orientation)
		{
			return Channel.FMOD_Channel_Set3DConeOrientation(channelraw, ref orientation);
		}
		public RESULT get3DConeOrientation(ref VECTOR orientation)
		{
			return Channel.FMOD_Channel_Get3DConeOrientation(channelraw, ref orientation);
		}
		public RESULT set3DCustomRolloff(ref VECTOR points, int numpoints)
		{
			return Channel.FMOD_Channel_Set3DCustomRolloff(channelraw, ref points, numpoints);
		}
		public RESULT get3DCustomRolloff(ref IntPtr points, ref int numpoints)
		{
			return Channel.FMOD_Channel_Get3DCustomRolloff(channelraw, ref points, ref numpoints);
		}
		public RESULT set3DOcclusion(float directOcclusion, float reverbOcclusion)
		{
			return Channel.FMOD_Channel_Set3DOcclusion(channelraw, directOcclusion, reverbOcclusion);
		}
		public RESULT get3DOcclusion(ref float directOcclusion, ref float reverbOcclusion)
		{
			return Channel.FMOD_Channel_Get3DOcclusion(channelraw, ref directOcclusion, ref reverbOcclusion);
		}
		public RESULT set3DSpread(float angle)
		{
			return Channel.FMOD_Channel_Set3DSpread(channelraw, angle);
		}
		public RESULT get3DSpread(ref float angle)
		{
			return Channel.FMOD_Channel_Get3DSpread(channelraw, ref angle);
		}
		public RESULT set3DPanLevel(float level)
		{
			return Channel.FMOD_Channel_Set3DPanLevel(channelraw, level);
		}
		public RESULT get3DPanLevel(ref float level)
		{
			return Channel.FMOD_Channel_Get3DPanLevel(channelraw, ref level);
		}
		public RESULT set3DDopplerLevel(float level)
		{
			return Channel.FMOD_Channel_Set3DDopplerLevel(channelraw, level);
		}
		public RESULT get3DDopplerLevel(ref float level)
		{
			return Channel.FMOD_Channel_Get3DDopplerLevel(channelraw, ref level);
		}
		public RESULT isPlaying(ref bool isplaying)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Channel.FMOD_Channel_IsPlaying_64(channelraw, ref isplaying);
			}
			else
			{
				result = Channel.FMOD_Channel_IsPlaying_32(channelraw, ref isplaying);
			}
			return result;
		}
		public RESULT isVirtual(ref bool isvirtual)
		{
			return Channel.FMOD_Channel_IsVirtual(channelraw, ref isvirtual);
		}
		public RESULT getAudibility(ref float audibility)
		{
			return Channel.FMOD_Channel_GetAudibility(channelraw, ref audibility);
		}
		public RESULT getCurrentSound(ref Sound sound)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = Channel.FMOD_Channel_GetCurrentSound(channelraw, ref raw);
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
				if (sound == null)
				{
					Sound sound2 = new Sound();
					sound2.setRaw(raw);
					sound = sound2;
				}
				else
				{
					sound.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT getSpectrum(float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype)
		{
			return Channel.FMOD_Channel_GetSpectrum(channelraw, spectrumarray, numvalues, channeloffset, windowtype);
		}
		public RESULT getWaveData(float[] wavearray, int numvalues, int channeloffset)
		{
			return Channel.FMOD_Channel_GetWaveData(channelraw, wavearray, numvalues, channeloffset);
		}
		public RESULT getIndex(ref int index)
		{
			return Channel.FMOD_Channel_GetIndex(channelraw, ref index);
		}
		public RESULT getDSPHead(ref DSP dsp)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = Channel.FMOD_Channel_GetDSPHead(channelraw, ref raw);
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
				DSP dSP = new DSP();
				dSP.setRaw(raw);
				dsp = dSP;
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
				rESULT = Channel.FMOD_Channel_AddDSP(channelraw, dsp.getRaw(), ref raw);
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
		public RESULT setMode(MODE mode)
		{
			return Channel.FMOD_Channel_SetMode(channelraw, mode);
		}
		public RESULT getMode(ref MODE mode)
		{
			return Channel.FMOD_Channel_GetMode(channelraw, ref mode);
		}
		public RESULT setLoopCount(int loopcount)
		{
			return Channel.FMOD_Channel_SetLoopCount(channelraw, loopcount);
		}
		public RESULT getLoopCount(ref int loopcount)
		{
			return Channel.FMOD_Channel_GetLoopCount(channelraw, ref loopcount);
		}
		public RESULT setLoopPoints(uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype)
		{
			return Channel.FMOD_Channel_SetLoopPoints(channelraw, loopstart, loopstarttype, loopend, loopendtype);
		}
		public RESULT getLoopPoints(ref uint loopstart, TIMEUNIT loopstarttype, ref uint loopend, TIMEUNIT loopendtype)
		{
			return Channel.FMOD_Channel_GetLoopPoints(channelraw, ref loopstart, loopstarttype, ref loopend, loopendtype);
		}
		public RESULT setUserData(IntPtr userdata)
		{
			return Channel.FMOD_Channel_SetUserData(channelraw, userdata);
		}
		public RESULT getUserData(ref IntPtr userdata)
		{
			return Channel.FMOD_Channel_GetUserData(channelraw, ref userdata);
		}
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetSystemObject(IntPtr channel, ref IntPtr system);
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Stop")]
		private static extern RESULT FMOD_Channel_Stop_32(IntPtr channel);
		[DllImport("fmodex64", EntryPoint = "FMOD_Channel_Stop")]
		private static extern RESULT FMOD_Channel_Stop_64(IntPtr channel);
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetPaused")]
		private static extern RESULT FMOD_Channel_SetPaused_32(IntPtr channel, int paused);
		[DllImport("fmodex64", EntryPoint = "FMOD_Channel_SetPaused")]
		private static extern RESULT FMOD_Channel_SetPaused_64(IntPtr channel, int paused);
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetPaused")]
		private static extern RESULT FMOD_Channel_GetPaused_32(IntPtr channel, ref int paused);
		[DllImport("fmodex64", EntryPoint = "FMOD_Channel_GetPaused")]
		private static extern RESULT FMOD_Channel_GetPaused_64(IntPtr channel, ref int paused);
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetVolume")]
		private static extern RESULT FMOD_Channel_SetVolume_32(IntPtr channel, float volume);
		[DllImport("fmodex64", EntryPoint = "FMOD_Channel_SetVolume")]
		private static extern RESULT FMOD_Channel_SetVolume_64(IntPtr channel, float volume);
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetVolume")]
		private static extern RESULT FMOD_Channel_GetVolume_32(IntPtr channel, ref float volume);
		[DllImport("fmodex64", EntryPoint = "FMOD_Channel_GetVolume")]
		private static extern RESULT FMOD_Channel_GetVolume_64(IntPtr channel, ref float volume);
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetFrequency")]
		private static extern RESULT FMOD_Channel_SetFrequency_32(IntPtr channel, float frequency);
		[DllImport("fmodex64", EntryPoint = "FMOD_Channel_SetFrequency")]
		private static extern RESULT FMOD_Channel_SetFrequency_64(IntPtr channel, float frequency);
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetFrequency")]
		private static extern RESULT FMOD_Channel_GetFrequency_32(IntPtr channel, ref float frequency);
		[DllImport("fmodex64", EntryPoint = "FMOD_Channel_GetFrequency")]
		private static extern RESULT FMOD_Channel_GetFrequency_64(IntPtr channel, ref float frequency);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetPan(IntPtr channel, float pan);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetPan(IntPtr channel, ref float pan);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetDelay(IntPtr channel, DELAYTYPE delaytype, uint delayhi, uint delaylo);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetDelay(IntPtr channel, DELAYTYPE delaytype, ref uint delayhi, ref uint delaylo);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetSpeakerMix(IntPtr channel, float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetSpeakerMix(IntPtr channel, ref float frontleft, ref float frontright, ref float center, ref float lfe, ref float backleft, ref float backright, ref float sideleft, ref float sideright);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetSpeakerLevels(IntPtr channel, SPEAKER speaker, float[] levels, int numlevels);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetSpeakerLevels(IntPtr channel, SPEAKER speaker, [MarshalAs(UnmanagedType.LPArray)] float[] levels, int numlevels);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetInputChannelMix(IntPtr channel, ref float levels, int numlevels);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetInputChannelMix(IntPtr channel, ref float levels, int numlevels);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetMute(IntPtr channel, int mute);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetMute(IntPtr channel, ref int mute);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetPriority(IntPtr channel, int priority);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetPriority(IntPtr channel, ref int priority);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Set3DAttributes(IntPtr channel, ref VECTOR pos, ref VECTOR vel);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Get3DAttributes(IntPtr channel, ref VECTOR pos, ref VECTOR vel);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Set3DMinMaxDistance(IntPtr channel, float mindistance, float maxdistance);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Get3DMinMaxDistance(IntPtr channel, ref float mindistance, ref float maxdistance);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Set3DConeSettings(IntPtr channel, float insideconeangle, float outsideconeangle, float outsidevolume);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Get3DConeSettings(IntPtr channel, ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Set3DConeOrientation(IntPtr channel, ref VECTOR orientation);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Get3DConeOrientation(IntPtr channel, ref VECTOR orientation);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Set3DCustomRolloff(IntPtr channel, ref VECTOR points, int numpoints);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Get3DCustomRolloff(IntPtr channel, ref IntPtr points, ref int numpoints);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Set3DOcclusion(IntPtr channel, float directOcclusion, float reverbOcclusion);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Get3DOcclusion(IntPtr channel, ref float directOcclusion, ref float reverbOcclusion);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Set3DSpread(IntPtr channel, float angle);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Get3DSpread(IntPtr channel, ref float angle);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Set3DPanLevel(IntPtr channel, float level);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Get3DPanLevel(IntPtr channel, ref float level);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Set3DDopplerLevel(IntPtr channel, float level);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_Get3DDopplerLevel(IntPtr channel, ref float level);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetReverbProperties(IntPtr channel, ref REVERB_CHANNELPROPERTIES prop);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetReverbProperties(IntPtr channel, ref REVERB_CHANNELPROPERTIES prop);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetChannelGroup(IntPtr channel, IntPtr channelgroup);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetChannelGroup(IntPtr channel, ref IntPtr channelgroup);
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_IsPlaying")]
		private static extern RESULT FMOD_Channel_IsPlaying_32(IntPtr channel, ref bool isplaying);
		[DllImport("fmodex64", EntryPoint = "FMOD_Channel_IsPlaying")]
		private static extern RESULT FMOD_Channel_IsPlaying_64(IntPtr channel, ref bool isplaying);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_IsVirtual(IntPtr channel, ref bool isvirtual);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetAudibility(IntPtr channel, ref float audibility);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetCurrentSound(IntPtr channel, ref IntPtr sound);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetSpectrum(IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetWaveData(IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] wavearray, int numvalues, int channeloffset);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetIndex(IntPtr channel, ref int index);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetCallback(IntPtr channel, CHANNEL_CALLBACKTYPE type, CHANNEL_CALLBACK callback, int command);
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetPosition")]
		private static extern RESULT FMOD_Channel_SetPosition_32(IntPtr channel, uint position, TIMEUNIT postype);
		[DllImport("fmodex64", EntryPoint = "FMOD_Channel_SetPosition")]
		private static extern RESULT FMOD_Channel_SetPosition_64(IntPtr channel, uint position, TIMEUNIT postype);
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetPosition")]
		private static extern RESULT FMOD_Channel_GetPosition_32(IntPtr channel, ref uint position, TIMEUNIT postype);
		[DllImport("fmodex64", EntryPoint = "FMOD_Channel_GetPosition")]
		private static extern RESULT FMOD_Channel_GetPosition_64(IntPtr channel, ref uint position, TIMEUNIT postype);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetDSPHead(IntPtr channel, ref IntPtr dsp);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_AddDSP(IntPtr channel, IntPtr dsp, ref IntPtr dspconnection);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetMode(IntPtr channel, MODE mode);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetMode(IntPtr channel, ref MODE mode);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetLoopCount(IntPtr channel, int loopcount);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetLoopCount(IntPtr channel, ref int loopcount);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetLoopPoints(IntPtr channel, uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetLoopPoints(IntPtr channel, ref uint loopstart, TIMEUNIT loopstarttype, ref uint loopend, TIMEUNIT loopendtype);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_SetUserData(IntPtr channel, IntPtr userdata);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Channel_GetUserData(IntPtr channel, ref IntPtr userdata);
		public void setRaw(IntPtr channel)
		{
			channelraw = IntPtr.Zero;
			channelraw = channel;
		}
		public IntPtr getRaw()
		{
			return channelraw;
		}
	}
}
