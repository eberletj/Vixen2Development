using System;
using System.Runtime.InteropServices;
using System.Text;
namespace FMOD
{
	public class _System
	{
		private IntPtr systemraw;
		public RESULT release()
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_Release_64(systemraw);
			}
			else
			{
				result = _System.FMOD_System_Release_32(systemraw);
			}
			return result;
		}
		public RESULT setOutput(OUTPUTTYPE output)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_SetOutput_64(systemraw, output);
			}
			else
			{
				result = _System.FMOD_System_SetOutput_32(systemraw, output);
			}
			return result;
		}
		public RESULT getOutput(ref OUTPUTTYPE output)
		{
			return _System.FMOD_System_GetOutput(systemraw, ref output);
		}
		public RESULT getNumDrivers(ref int numdrivers)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_GetNumDrivers_64(systemraw, ref numdrivers);
			}
			else
			{
				result = _System.FMOD_System_GetNumDrivers_32(systemraw, ref numdrivers);
			}
			return result;
		}
		public RESULT getDriverInfo(int id, StringBuilder name, int namelen, ref GUID guid)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_GetDriverInfo_64(systemraw, id, name, namelen, ref guid);
			}
			else
			{
				result = _System.FMOD_System_GetDriverInfo_32(systemraw, id, name, namelen, ref guid);
			}
			return result;
		}
		public RESULT getDriverCaps(int id, ref CAPS caps, ref int minfrequency, ref int maxfrequency, ref SPEAKERMODE controlpanelspeakermode)
		{
			return _System.FMOD_System_GetDriverCaps(systemraw, id, ref caps, ref minfrequency, ref maxfrequency, ref controlpanelspeakermode);
		}
		public RESULT setDriver(int driver)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_SetDriver_64(systemraw, driver);
			}
			else
			{
				result = _System.FMOD_System_SetDriver_32(systemraw, driver);
			}
			return result;
		}
		public RESULT getDriver(ref int driver)
		{
			return _System.FMOD_System_GetDriver(systemraw, ref driver);
		}
		public RESULT setHardwareChannels(int min2d, int max2d, int min3d, int max3d)
		{
			return _System.FMOD_System_SetHardwareChannels(systemraw, min2d, max2d, min3d, max3d);
		}
		public RESULT setSoftwareChannels(int numsoftwarechannels)
		{
			return _System.FMOD_System_SetSoftwareChannels(systemraw, numsoftwarechannels);
		}
		public RESULT getSoftwareChannels(ref int numsoftwarechannels)
		{
			return _System.FMOD_System_GetSoftwareChannels(systemraw, ref numsoftwarechannels);
		}
		public RESULT setSoftwareFormat(int samplerate, SOUND_FORMAT format, int numoutputchannels, int maxinputchannels, DSP_RESAMPLER resamplemethod)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_SetSoftwareFormat_64(systemraw, samplerate, format, numoutputchannels, maxinputchannels, resamplemethod);
			}
			else
			{
				result = _System.FMOD_System_SetSoftwareFormat_32(systemraw, samplerate, format, numoutputchannels, maxinputchannels, resamplemethod);
			}
			return result;
		}
		public RESULT getSoftwareFormat(ref int samplerate, ref SOUND_FORMAT format, ref int numoutputchannels, ref int maxinputchannels, ref DSP_RESAMPLER resamplemethod, ref int bits)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_GetSoftwareFormat_64(systemraw, ref samplerate, ref format, ref numoutputchannels, ref maxinputchannels, ref resamplemethod, ref bits);
			}
			else
			{
				result = _System.FMOD_System_GetSoftwareFormat_32(systemraw, ref samplerate, ref format, ref numoutputchannels, ref maxinputchannels, ref resamplemethod, ref bits);
			}
			return result;
		}
		public RESULT setDSPBufferSize(uint bufferlength, int numbuffers)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_SetDSPBufferSize_64(systemraw, bufferlength, numbuffers);
			}
			else
			{
				result = _System.FMOD_System_SetDSPBufferSize_32(systemraw, bufferlength, numbuffers);
			}
			return result;
		}
		public RESULT getDSPBufferSize(ref uint bufferlength, ref int numbuffers)
		{
			return _System.FMOD_System_GetDSPBufferSize(systemraw, ref bufferlength, ref numbuffers);
		}
		public RESULT setFileSystem(FILE_OPENCALLBACK useropen, FILE_CLOSECALLBACK userclose, FILE_READCALLBACK userread, FILE_SEEKCALLBACK userseek, int buffersize)
		{
			return _System.FMOD_System_SetFileSystem(systemraw, useropen, userclose, userread, userseek, buffersize);
		}
		public RESULT attachFileSystem(FILE_OPENCALLBACK useropen, FILE_CLOSECALLBACK userclose, FILE_READCALLBACK userread, FILE_SEEKCALLBACK userseek)
		{
			return _System.FMOD_System_AttachFileSystem(systemraw, useropen, userclose, userread, userseek);
		}
		public RESULT setAdvancedSettings(ref ADVANCEDSETTINGS settings)
		{
			return _System.FMOD_System_SetAdvancedSettings(systemraw, ref settings);
		}
		public RESULT getAdvancedSettings(ref ADVANCEDSETTINGS settings)
		{
			return _System.FMOD_System_GetAdvancedSettings(systemraw, ref settings);
		}
		public RESULT setSpeakerMode(SPEAKERMODE speakermode)
		{
			return _System.FMOD_System_SetSpeakerMode(systemraw, speakermode);
		}
		public RESULT getSpeakerMode(ref SPEAKERMODE speakermode)
		{
			return _System.FMOD_System_GetSpeakerMode(systemraw, ref speakermode);
		}
		public RESULT setPluginPath(string path)
		{
			return _System.FMOD_System_SetPluginPath(systemraw, path);
		}
		public RESULT loadPlugin(string filename, ref uint handle, uint priority)
		{
			return _System.FMOD_System_LoadPlugin(systemraw, filename, ref handle, priority);
		}
		public RESULT unloadPlugin(uint handle)
		{
			return _System.FMOD_System_UnloadPlugin(systemraw, handle);
		}
		public RESULT getNumPlugins(PLUGINTYPE plugintype, ref int numplugins)
		{
			return _System.FMOD_System_GetNumPlugins(systemraw, plugintype, ref numplugins);
		}
		public RESULT getPluginHandle(PLUGINTYPE plugintype, int index, ref uint handle)
		{
			return _System.FMOD_System_GetPluginHandle(systemraw, plugintype, index, ref handle);
		}
		public RESULT getPluginInfo(uint handle, ref PLUGINTYPE plugintype, StringBuilder name, int namelen, ref uint version)
		{
			return _System.FMOD_System_GetPluginInfo(systemraw, handle, ref plugintype, name, namelen, ref version);
		}
		public RESULT setOutputByPlugin(uint handle)
		{
			return _System.FMOD_System_SetOutputByPlugin(systemraw, handle);
		}
		public RESULT getOutputByPlugin(ref uint handle)
		{
			return _System.FMOD_System_GetOutputByPlugin(systemraw, ref handle);
		}
		public RESULT createDSPByPlugin(uint handle, ref IntPtr dsp)
		{
			return _System.FMOD_System_CreateDSPByPlugin(systemraw, handle, ref dsp);
		}
		public RESULT createCodec(IntPtr codecdescription, uint priority)
		{
			return _System.FMOD_System_CreateCodec(systemraw, codecdescription, priority);
		}
		public RESULT init(int maxchannels, INITFLAG flags, IntPtr extradata)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_Init_64(systemraw, maxchannels, flags, extradata);
			}
			else
			{
				result = _System.FMOD_System_Init_32(systemraw, maxchannels, flags, extradata);
			}
			return result;
		}
		public RESULT close()
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_Close_64(systemraw);
			}
			else
			{
				result = _System.FMOD_System_Close_32(systemraw);
			}
			return result;
		}
		public RESULT update()
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_Update_64(systemraw);
			}
			else
			{
				result = _System.FMOD_System_Update_32(systemraw);
			}
			return result;
		}
		public RESULT set3DSettings(float dopplerscale, float distancefactor, float rolloffscale)
		{
			return _System.FMOD_System_Set3DSettings(systemraw, dopplerscale, distancefactor, rolloffscale);
		}
		public RESULT get3DSettings(ref float dopplerscale, ref float distancefactor, ref float rolloffscale)
		{
			return _System.FMOD_System_Get3DSettings(systemraw, ref dopplerscale, ref distancefactor, ref rolloffscale);
		}
		public RESULT set3DNumListeners(int numlisteners)
		{
			return _System.FMOD_System_Set3DNumListeners(systemraw, numlisteners);
		}
		public RESULT get3DNumListeners(ref int numlisteners)
		{
			return _System.FMOD_System_Get3DNumListeners(systemraw, ref numlisteners);
		}
		public RESULT set3DListenerAttributes(int listener, ref VECTOR pos, ref VECTOR vel, ref VECTOR forward, ref VECTOR up)
		{
			return _System.FMOD_System_Set3DListenerAttributes(systemraw, listener, ref pos, ref vel, ref forward, ref up);
		}
		public RESULT get3DListenerAttributes(int listener, ref VECTOR pos, ref VECTOR vel, ref VECTOR forward, ref VECTOR up)
		{
			return _System.FMOD_System_Get3DListenerAttributes(systemraw, listener, ref pos, ref vel, ref forward, ref up);
		}
		public RESULT set3DRolloffCallback(CB_3D_ROLLOFFCALLBACK callback)
		{
			return _System.FMOD_System_Set3DRolloffCallback(systemraw, callback);
		}
		public RESULT set3DSpeakerPosition(SPEAKER speaker, float x, float y, bool active)
		{
			return _System.FMOD_System_Set3DSpeakerPosition(systemraw, speaker, x, y, active ? 1 : 0);
		}
		public RESULT get3DSpeakerPosition(SPEAKER speaker, ref float x, ref float y, ref bool active)
		{
			int num = 0;
			RESULT result = _System.FMOD_System_Get3DSpeakerPosition(systemraw, speaker, ref x, ref y, ref num);
			active = (num != 0);
			return result;
		}
		public RESULT setStreamBufferSize(uint filebuffersize, TIMEUNIT filebuffersizetype)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_SetStreamBufferSize_64(systemraw, filebuffersize, filebuffersizetype);
			}
			else
			{
				result = _System.FMOD_System_SetStreamBufferSize_32(systemraw, filebuffersize, filebuffersizetype);
			}
			return result;
		}
		public RESULT getStreamBufferSize(ref uint filebuffersize, ref TIMEUNIT filebuffersizetype)
		{
			return _System.FMOD_System_GetStreamBufferSize(systemraw, ref filebuffersize, ref filebuffersizetype);
		}
		public RESULT getVersion(ref uint version)
		{
			return _System.FMOD_System_GetVersion(systemraw, ref version);
		}
		public RESULT getOutputHandle(ref IntPtr handle)
		{
			return _System.FMOD_System_GetOutputHandle(systemraw, ref handle);
		}
		public RESULT getChannelsPlaying(ref int channels)
		{
			return _System.FMOD_System_GetChannelsPlaying(systemraw, ref channels);
		}
		public RESULT getHardwareChannels(ref int num2d, ref int num3d, ref int total)
		{
			return _System.FMOD_System_GetHardwareChannels(systemraw, ref num2d, ref num3d, ref total);
		}
		public RESULT getCPUUsage(ref float dsp, ref float stream, ref float update, ref float total)
		{
			return _System.FMOD_System_GetCPUUsage(systemraw, ref dsp, ref stream, ref update, ref total);
		}
		public RESULT getSoundRam(ref int currentalloced, ref int maxalloced, ref int total)
		{
			return _System.FMOD_System_GetSoundRAM(systemraw, ref currentalloced, ref maxalloced, ref total);
		}
		public RESULT getNumCDROMDrives(ref int numdrives)
		{
			return _System.FMOD_System_GetNumCDROMDrives(systemraw, ref numdrives);
		}
		public RESULT getCDROMDriveName(int drive, StringBuilder drivename, int drivenamelen, StringBuilder scsiname, int scsinamelen, StringBuilder devicename, int devicenamelen)
		{
			return _System.FMOD_System_GetCDROMDriveName(systemraw, drive, drivename, drivenamelen, scsiname, scsinamelen, devicename, devicenamelen);
		}
		public RESULT getSpectrum(float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = _System.FMOD_System_GetSpectrum_64(systemraw, spectrumarray, numvalues, channeloffset, windowtype);
			}
			else
			{
				result = _System.FMOD_System_GetSpectrum_32(systemraw, spectrumarray, numvalues, channeloffset, windowtype);
			}
			return result;
		}
		public RESULT getWaveData(float[] wavearray, int numvalues, int channeloffset)
		{
			return _System.FMOD_System_GetWaveData(systemraw, wavearray, numvalues, channeloffset);
		}
		public RESULT createSound(string name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref Sound sound)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				if (VERSION.platform == Platform.X64)
				{
					rESULT = _System.FMOD_System_CreateSound_64(systemraw, name_or_data, mode, ref exinfo, ref raw);
				}
				else
				{
					rESULT = _System.FMOD_System_CreateSound_32(systemraw, name_or_data, mode, ref exinfo, ref raw);
				}
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
		public RESULT createSound(byte[] data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref Sound sound)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				if (VERSION.platform == Platform.X64)
				{
					rESULT = _System.FMOD_System_CreateSound_64(systemraw, data, mode, ref exinfo, ref raw);
				}
				else
				{
					rESULT = _System.FMOD_System_CreateSound_32(systemraw, data, mode, ref exinfo, ref raw);
				}
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
		public RESULT createSound(string name_or_data, MODE mode, ref Sound sound)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				if (VERSION.platform == Platform.X64)
				{
					rESULT = _System.FMOD_System_CreateSound_64(systemraw, name_or_data, mode, 0, ref raw);
				}
				else
				{
					rESULT = _System.FMOD_System_CreateSound_32(systemraw, name_or_data, mode, 0, ref raw);
				}
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
		public RESULT createStream(string name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref Sound sound)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = _System.FMOD_System_CreateStream(systemraw, name_or_data, mode, ref exinfo, ref raw);
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
		public RESULT createStream(byte[] data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref Sound sound)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = _System.FMOD_System_CreateStream(systemraw, data, mode, ref exinfo, ref raw);
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
		public RESULT createStream(string name_or_data, MODE mode, ref Sound sound)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				if (VERSION.platform == Platform.X64)
				{
					rESULT = _System.FMOD_System_CreateStream_64(systemraw, name_or_data, mode, 0, ref raw);
				}
				else
				{
					rESULT = _System.FMOD_System_CreateStream_32(systemraw, name_or_data, mode, 0, ref raw);
				}
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
		public RESULT createDSP(ref DSP_DESCRIPTION description, ref DSP dsp)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = _System.FMOD_System_CreateDSP(systemraw, ref description, ref raw);
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
		public RESULT createDSPByType(DSP_TYPE type, ref DSP dsp)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = _System.FMOD_System_CreateDSPByType(systemraw, type, ref raw);
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
		public RESULT createDSPByIndex(int index, ref DSP dsp)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = _System.FMOD_System_CreateDSPByIndex(systemraw, index, ref raw);
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
		public RESULT createChannelGroup(string name, ref ChannelGroup channelgroup)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = _System.FMOD_System_CreateChannelGroup(systemraw, name, ref raw);
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
		public RESULT playSound(CHANNELINDEX channelid, Sound sound, bool paused, ref Channel channel)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw;
			if (channel != null)
			{
				raw = channel.getRaw();
			}
			else
			{
				raw = IntPtr.Zero;
			}
			try
			{
				if (VERSION.platform == Platform.X64)
				{
					rESULT = _System.FMOD_System_PlaySound_64(systemraw, channelid, sound.getRaw(), paused ? 1 : 0, ref raw);
				}
				else
				{
					rESULT = _System.FMOD_System_PlaySound_32(systemraw, channelid, sound.getRaw(), paused ? 1 : 0, ref raw);
				}
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
		public RESULT playDSP(CHANNELINDEX channelid, DSP dsp, bool paused, ref Channel channel)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw;
			if (channel != null)
			{
				raw = channel.getRaw();
			}
			else
			{
				raw = IntPtr.Zero;
			}
			try
			{
				rESULT = _System.FMOD_System_PlayDSP(systemraw, channelid, dsp.getRaw(), paused ? 1 : 0, ref raw);
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
		public RESULT getChannel(int channelid, ref Channel channel)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = _System.FMOD_System_GetChannel(systemraw, channelid, ref raw);
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
		public RESULT getMasterChannelGroup(ref ChannelGroup channelgroup)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = _System.FMOD_System_GetMasterChannelGroup(systemraw, ref raw);
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
		public RESULT getMasterSoundGroup(ref SoundGroup soundgroup)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = _System.FMOD_System_GetMasterSoundGroup(systemraw, ref raw);
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
				if (soundgroup == null)
				{
					SoundGroup soundGroup = new SoundGroup();
					soundGroup.setRaw(raw);
					soundgroup = soundGroup;
				}
				else
				{
					soundgroup.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT setReverbProperties(ref REVERB_PROPERTIES prop)
		{
			return _System.FMOD_System_SetReverbProperties(systemraw, ref prop);
		}
		public RESULT getReverbProperties(ref REVERB_PROPERTIES prop)
		{
			return _System.FMOD_System_GetReverbProperties(systemraw, ref prop);
		}
		public RESULT setReverbAmbientProperties(ref REVERB_PROPERTIES prop)
		{
			return _System.FMOD_System_SetReverbAmbientProperties(systemraw, ref prop);
		}
		public RESULT getReverbAmbientProperties(ref REVERB_PROPERTIES prop)
		{
			return _System.FMOD_System_GetReverbAmbientProperties(systemraw, ref prop);
		}
		public RESULT getDSPHead(ref DSP dsp)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = _System.FMOD_System_GetDSPHead(systemraw, ref raw);
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
				rESULT = _System.FMOD_System_AddDSP(systemraw, dsp.getRaw(), ref raw);
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
		public RESULT lockDSP()
		{
			return _System.FMOD_System_LockDSP(systemraw);
		}
		public RESULT unlockDSP()
		{
			return _System.FMOD_System_UnlockDSP(systemraw);
		}
		public RESULT setRecordDriver(int driver)
		{
			return _System.FMOD_System_SetRecordDriver(systemraw, driver);
		}
		public RESULT getRecordDriver(ref int driver)
		{
			return _System.FMOD_System_GetRecordDriver(systemraw, ref driver);
		}
		public RESULT getRecordNumDrivers(ref int numdrivers)
		{
			return _System.FMOD_System_GetRecordNumDrivers(systemraw, ref numdrivers);
		}
		public RESULT getRecordDriverInfo(int id, StringBuilder name, int namelen, ref GUID guid)
		{
			return _System.FMOD_System_GetRecordDriverInfo(systemraw, id, name, namelen, ref guid);
		}
		public RESULT getRecordPosition(ref uint position)
		{
			return _System.FMOD_System_GetRecordPosition(systemraw, ref position);
		}
		public RESULT recordStart(Sound sound, bool loop)
		{
			return _System.FMOD_System_RecordStart(systemraw, sound.getRaw(), loop);
		}
		public RESULT recordStop()
		{
			return _System.FMOD_System_RecordStop(systemraw);
		}
		public RESULT isRecording(ref bool recording)
		{
			return _System.FMOD_System_IsRecording(systemraw, ref recording);
		}
		public RESULT createGeometry(int maxpolygons, int maxvertices, ref Geometry geometryf)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = _System.FMOD_System_CreateGeometry(systemraw, maxpolygons, maxvertices, ref raw);
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
				if (geometryf == null)
				{
					Geometry geometry = new Geometry();
					geometry.setRaw(raw);
					geometryf = geometry;
				}
				else
				{
					geometryf.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT setGeometrySettings(float maxworldsize)
		{
			return _System.FMOD_System_SetGeometrySettings(systemraw, maxworldsize);
		}
		public RESULT getGeometrySettings(ref float maxworldsize)
		{
			return _System.FMOD_System_GetGeometrySettings(systemraw, ref maxworldsize);
		}
		public RESULT loadGeometry(IntPtr data, int datasize, ref Geometry geometry)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = _System.FMOD_System_LoadGeometry(systemraw, data, datasize, ref raw);
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
				if (geometry == null)
				{
					Geometry geometry2 = new Geometry();
					geometry2.setRaw(raw);
					geometry = geometry2;
				}
				else
				{
					geometry.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT setNetworkProxy(string proxy)
		{
			return _System.FMOD_System_SetNetworkProxy(systemraw, proxy);
		}
		public RESULT getProxy(StringBuilder proxy, int proxylen)
		{
			return _System.FMOD_System_GetNetworkProxy(systemraw, proxy, proxylen);
		}
		public RESULT setNetworkTimeout(int timeout)
		{
			return _System.FMOD_System_SetNetworkTimeout(systemraw, timeout);
		}
		public RESULT getNetworkTimeout(ref int timeout)
		{
			return _System.FMOD_System_GetNetworkTimeout(systemraw, ref timeout);
		}
		public RESULT setUserData(IntPtr userdata)
		{
			return _System.FMOD_System_SetUserData(systemraw, userdata);
		}
		public RESULT getUserData(ref IntPtr userdata)
		{
			return _System.FMOD_System_GetUserData(systemraw, ref userdata);
		}
		[DllImport("fmodex", EntryPoint = "FMOD_System_Release")]
		private static extern RESULT FMOD_System_Release_32(IntPtr system);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_Release")]
		private static extern RESULT FMOD_System_Release_64(IntPtr system);
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetOutput")]
		private static extern RESULT FMOD_System_SetOutput_32(IntPtr system, OUTPUTTYPE output);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_SetOutput")]
		private static extern RESULT FMOD_System_SetOutput_64(IntPtr system, OUTPUTTYPE output);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetOutput(IntPtr system, ref OUTPUTTYPE output);
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetNumDrivers")]
		private static extern RESULT FMOD_System_GetNumDrivers_32(IntPtr system, ref int numdrivers);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_GetNumDrivers")]
		private static extern RESULT FMOD_System_GetNumDrivers_64(IntPtr system, ref int numdrivers);
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDriverInfo")]
		private static extern RESULT FMOD_System_GetDriverInfo_32(IntPtr system, int id, StringBuilder name, int namelen, ref GUID guid);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_GetDriverInfo")]
		private static extern RESULT FMOD_System_GetDriverInfo_64(IntPtr system, int id, StringBuilder name, int namelen, ref GUID guid);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetDriverCaps(IntPtr system, int id, ref CAPS caps, ref int minfrequency, ref int maxfrequency, ref SPEAKERMODE controlpanelspeakermode);
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetDriver")]
		private static extern RESULT FMOD_System_SetDriver_32(IntPtr system, int driver);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_SetDriver")]
		private static extern RESULT FMOD_System_SetDriver_64(IntPtr system, int driver);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetDriver(IntPtr system, ref int driver);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetHardwareChannels(IntPtr system, int min2d, int max2d, int min3d, int max3d);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetHardwareChannels(IntPtr system, ref int num2d, ref int num3d, ref int total);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetSoftwareChannels(IntPtr system, int numsoftwarechannels);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetSoftwareChannels(IntPtr system, ref int numsoftwarechannels);
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetSoftwareFormat")]
		private static extern RESULT FMOD_System_SetSoftwareFormat_32(IntPtr system, int samplerate, SOUND_FORMAT format, int numoutputchannels, int maxinputchannels, DSP_RESAMPLER resamplemethod);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_SetSoftwareFormat")]
		private static extern RESULT FMOD_System_SetSoftwareFormat_64(IntPtr system, int samplerate, SOUND_FORMAT format, int numoutputchannels, int maxinputchannels, DSP_RESAMPLER resamplemethod);
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetSoftwareFormat")]
		private static extern RESULT FMOD_System_GetSoftwareFormat_32(IntPtr system, ref int samplerate, ref SOUND_FORMAT format, ref int numoutputchannels, ref int maxinputchannels, ref DSP_RESAMPLER resamplemethod, ref int bits);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_GetSoftwareFormat")]
		private static extern RESULT FMOD_System_GetSoftwareFormat_64(IntPtr system, ref int samplerate, ref SOUND_FORMAT format, ref int numoutputchannels, ref int maxinputchannels, ref DSP_RESAMPLER resamplemethod, ref int bits);
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetDSPBufferSize")]
		private static extern RESULT FMOD_System_SetDSPBufferSize_32(IntPtr system, uint bufferlength, int numbuffers);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_SetDSPBufferSize")]
		private static extern RESULT FMOD_System_SetDSPBufferSize_64(IntPtr system, uint bufferlength, int numbuffers);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetDSPBufferSize(IntPtr system, ref uint bufferlength, ref int numbuffers);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetFileSystem(IntPtr system, FILE_OPENCALLBACK useropen, FILE_CLOSECALLBACK userclose, FILE_READCALLBACK userread, FILE_SEEKCALLBACK userseek, int buffersize);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_AttachFileSystem(IntPtr system, FILE_OPENCALLBACK useropen, FILE_CLOSECALLBACK userclose, FILE_READCALLBACK userread, FILE_SEEKCALLBACK userseek);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetPluginPath(IntPtr system, string path);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_LoadPlugin(IntPtr system, string filename, ref uint handle, uint priority);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_UnloadPlugin(IntPtr system, uint handle);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetNumPlugins(IntPtr system, PLUGINTYPE plugintype, ref int numplugins);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetPluginHandle(IntPtr system, PLUGINTYPE plugintype, int index, ref uint handle);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetPluginInfo(IntPtr system, uint handle, ref PLUGINTYPE plugintype, StringBuilder name, int namelen, ref uint version);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_CreateDSPByPlugin(IntPtr system, uint handle, ref IntPtr dsp);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_CreateCodec(IntPtr system, IntPtr codecdescription, uint priority);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetOutputByPlugin(IntPtr system, uint handle);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetOutputByPlugin(IntPtr system, ref uint handle);
		[DllImport("fmodex", EntryPoint = "FMOD_System_Init")]
		private static extern RESULT FMOD_System_Init_32(IntPtr system, int maxchannels, INITFLAG flags, IntPtr extradata);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_Init")]
		private static extern RESULT FMOD_System_Init_64(IntPtr system, int maxchannels, INITFLAG flags, IntPtr extradata);
		[DllImport("fmodex", EntryPoint = "FMOD_System_Close")]
		private static extern RESULT FMOD_System_Close_32(IntPtr system);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_Close")]
		private static extern RESULT FMOD_System_Close_64(IntPtr system);
		[DllImport("fmodex", EntryPoint = "FMOD_System_Update")]
		private static extern RESULT FMOD_System_Update_32(IntPtr system);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_Update")]
		private static extern RESULT FMOD_System_Update_64(IntPtr system);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_UpdateFinished(IntPtr system);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetAdvancedSettings(IntPtr system, ref ADVANCEDSETTINGS settings);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetAdvancedSettings(IntPtr system, ref ADVANCEDSETTINGS settings);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetSpeakerMode(IntPtr system, SPEAKERMODE speakermode);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetSpeakerMode(IntPtr system, ref SPEAKERMODE speakermode);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_Set3DRolloffCallback(IntPtr system, CB_3D_ROLLOFFCALLBACK callback);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_Set3DSpeakerPosition(IntPtr system, SPEAKER speaker, float x, float y, int active);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_Get3DSpeakerPosition(IntPtr system, SPEAKER speaker, ref float x, ref float y, ref int active);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_Set3DSettings(IntPtr system, float dopplerscale, float distancefactor, float rolloffscale);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_Get3DSettings(IntPtr system, ref float dopplerscale, ref float distancefactor, ref float rolloffscale);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_Set3DNumListeners(IntPtr system, int numlisteners);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_Get3DNumListeners(IntPtr system, ref int numlisteners);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_Set3DListenerAttributes(IntPtr system, int listener, ref VECTOR pos, ref VECTOR vel, ref VECTOR forward, ref VECTOR up);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_Get3DListenerAttributes(IntPtr system, int listener, ref VECTOR pos, ref VECTOR vel, ref VECTOR forward, ref VECTOR up);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetFileBufferSize(IntPtr system, int sizebytes);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetFileBufferSize(IntPtr system, ref int sizebytes);
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetStreamBufferSize")]
		private static extern RESULT FMOD_System_SetStreamBufferSize_32(IntPtr system, uint filebuffersize, TIMEUNIT filebuffersizetype);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_SetStreamBufferSize")]
		private static extern RESULT FMOD_System_SetStreamBufferSize_64(IntPtr system, uint filebuffersize, TIMEUNIT filebuffersizetype);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetStreamBufferSize(IntPtr system, ref uint filebuffersize, ref TIMEUNIT filebuffersizetype);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetVersion(IntPtr system, ref uint version);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetOutputHandle(IntPtr system, ref IntPtr handle);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetChannelsPlaying(IntPtr system, ref int channels);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetCPUUsage(IntPtr system, ref float dsp, ref float stream, ref float update, ref float total);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetSoundRAM(IntPtr system, ref int currentalloced, ref int maxalloced, ref int total);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetNumCDROMDrives(IntPtr system, ref int numdrives);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetCDROMDriveName(IntPtr system, int drive, StringBuilder drivename, int drivenamelen, StringBuilder scsiname, int scsinamelen, StringBuilder devicename, int devicenamelen);
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetSpectrum")]
		private static extern RESULT FMOD_System_GetSpectrum_32(IntPtr system, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_GetSpectrum")]
		private static extern RESULT FMOD_System_GetSpectrum_64(IntPtr system, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetWaveData(IntPtr system, [MarshalAs(UnmanagedType.LPArray)] float[] wavearray, int numvalues, int channeloffset);
		[DllImport("fmodex", CharSet = CharSet.Unicode, EntryPoint = "FMOD_System_CreateSound")]
		private static extern RESULT FMOD_System_CreateSound_32(IntPtr system, string name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref IntPtr sound);
		[DllImport("fmodex64", CharSet = CharSet.Unicode, EntryPoint = "FMOD_System_CreateSound")]
		private static extern RESULT FMOD_System_CreateSound_64(IntPtr system, string name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref IntPtr sound);
		[DllImport("fmodex", CharSet = CharSet.Unicode)]
		private static extern RESULT FMOD_System_CreateStream(IntPtr system, string name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref IntPtr sound);
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateSound")]
		private static extern RESULT FMOD_System_CreateSound_32(IntPtr system, string name_or_data, MODE mode, int exinfo, ref IntPtr sound);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_CreateSound")]
		private static extern RESULT FMOD_System_CreateSound_64(IntPtr system, string name_or_data, MODE mode, int exinfo, ref IntPtr sound);
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateStream")]
		private static extern RESULT FMOD_System_CreateStream_32(IntPtr system, string name_or_data, MODE mode, int exinfo, ref IntPtr sound);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_CreateStream")]
		private static extern RESULT FMOD_System_CreateStream_64(IntPtr system, string name_or_data, MODE mode, int exinfo, ref IntPtr sound);
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateSound")]
		private static extern RESULT FMOD_System_CreateSound_32(IntPtr system, byte[] name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref IntPtr sound);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_CreateSound")]
		private static extern RESULT FMOD_System_CreateSound_64(IntPtr system, byte[] name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref IntPtr sound);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_CreateStream(IntPtr system, byte[] name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref IntPtr sound);
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateSound")]
		private static extern RESULT FMOD_System_CreateSound_32(IntPtr system, byte[] name_or_data, MODE mode, int exinfo, ref IntPtr sound);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_CreateSound")]
		private static extern RESULT FMOD_System_CreateSound_64(IntPtr system, byte[] name_or_data, MODE mode, int exinfo, ref IntPtr sound);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_CreateStream(IntPtr system, byte[] name_or_data, MODE mode, int exinfo, ref IntPtr sound);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_CreateDSP(IntPtr system, ref DSP_DESCRIPTION description, ref IntPtr dsp);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_CreateDSPByType(IntPtr system, DSP_TYPE type, ref IntPtr dsp);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_CreateDSPByIndex(IntPtr system, int index, ref IntPtr dsp);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_CreateChannelGroup(IntPtr system, string name, ref IntPtr channelgroup);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_CreateSoundGroup(IntPtr system, StringBuilder name, ref SoundGroup soundgroup);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_CreateReverb(IntPtr system, ref IntPtr reverb);
		[DllImport("fmodex", EntryPoint = "FMOD_System_PlaySound")]
		private static extern RESULT FMOD_System_PlaySound_32(IntPtr system, CHANNELINDEX channelid, IntPtr sound, int paused, ref IntPtr channel);
		[DllImport("fmodex64", EntryPoint = "FMOD_System_PlaySound")]
		private static extern RESULT FMOD_System_PlaySound_64(IntPtr system, CHANNELINDEX channelid, IntPtr sound, int paused, ref IntPtr channel);
		[DllImport("fmodex")]
		public static extern RESULT FMOD_System_PlayDSP(IntPtr system, CHANNELINDEX channelid, IntPtr dsp, int paused, ref IntPtr channel);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetChannel(IntPtr system, int channelid, ref IntPtr channel);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetMasterChannelGroup(IntPtr system, ref IntPtr channelgroup);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetMasterSoundGroup(IntPtr system, ref IntPtr soundgroup);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetReverbProperties(IntPtr system, ref REVERB_PROPERTIES prop);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetReverbProperties(IntPtr system, ref REVERB_PROPERTIES prop);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetReverbAmbientProperties(IntPtr system, ref REVERB_PROPERTIES prop);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetReverbAmbientProperties(IntPtr system, ref REVERB_PROPERTIES prop);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetDSPHead(IntPtr system, ref IntPtr dsp);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_AddDSP(IntPtr system, IntPtr dsp, ref IntPtr dspconnection);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_LockDSP(IntPtr system);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_UnlockDSP(IntPtr system);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetRecordDriver(IntPtr system, int driver);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetRecordDriver(IntPtr system, ref int driver);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetRecordNumDrivers(IntPtr system, ref int numdrivers);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetRecordDriverInfo(IntPtr system, int id, StringBuilder name, int namelen, ref GUID guid);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetRecordPosition(IntPtr system, ref uint position);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_RecordStart(IntPtr system, IntPtr sound, bool loop);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_RecordStop(IntPtr system);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_IsRecording(IntPtr system, ref bool recording);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_CreateGeometry(IntPtr system, int maxPolygons, int maxVertices, ref IntPtr geometryf);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetGeometrySettings(IntPtr system, float maxWorldSize);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetGeometrySettings(IntPtr system, ref float maxWorldSize);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_LoadGeometry(IntPtr system, IntPtr data, int dataSize, ref IntPtr geometry);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetNetworkProxy(IntPtr system, string proxy);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetNetworkProxy(IntPtr system, StringBuilder proxy, int proxylen);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetNetworkTimeout(IntPtr system, int timeout);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetNetworkTimeout(IntPtr system, ref int timeout);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_SetUserData(IntPtr system, IntPtr userdata);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_System_GetUserData(IntPtr system, ref IntPtr userdata);
		public void setRaw(IntPtr system)
		{
			systemraw = IntPtr.Zero;
			systemraw = system;
		}
		public IntPtr getRaw()
		{
			return systemraw;
		}
	}
}
