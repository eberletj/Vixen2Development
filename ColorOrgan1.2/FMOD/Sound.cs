using System;
using System.Runtime.InteropServices;
using System.Text;
namespace FMOD
{
	public class Sound
	{
		private IntPtr soundraw;
		public RESULT release()
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Sound.FMOD_Sound_Release_64(soundraw);
			}
			else
			{
				result = Sound.FMOD_Sound_Release_32(soundraw);
			}
			return result;
		}
		public RESULT getSystemObject(ref _System system)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = Sound.FMOD_Sound_GetSystemObject(soundraw, ref raw);
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
		public RESULT @lock(uint offset, uint length, ref IntPtr ptr1, ref IntPtr ptr2, ref uint len1, ref uint len2)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Sound.FMOD_Sound_Lock_64(soundraw, offset, length, ref ptr1, ref ptr2, ref len1, ref len2);
			}
			else
			{
				result = Sound.FMOD_Sound_Lock_32(soundraw, offset, length, ref ptr1, ref ptr2, ref len1, ref len2);
			}
			return result;
		}
		public RESULT unlock(IntPtr ptr1, IntPtr ptr2, uint len1, uint len2)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Sound.FMOD_Sound_Unlock_64(soundraw, ptr1, ptr2, len1, len2);
			}
			else
			{
				result = Sound.FMOD_Sound_Unlock_32(soundraw, ptr1, ptr2, len1, len2);
			}
			return result;
		}
		public RESULT setDefaults(float frequency, float volume, float pan, int priority)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Sound.FMOD_Sound_SetDefaults_64(soundraw, frequency, volume, pan, priority);
			}
			else
			{
				result = Sound.FMOD_Sound_SetDefaults_32(soundraw, frequency, volume, pan, priority);
			}
			return result;
		}
		public RESULT getDefaults(ref float frequency, ref float volume, ref float pan, ref int priority)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Sound.FMOD_Sound_GetDefaults_64(soundraw, ref frequency, ref volume, ref pan, ref priority);
			}
			else
			{
				result = Sound.FMOD_Sound_GetDefaults_32(soundraw, ref frequency, ref volume, ref pan, ref priority);
			}
			return result;
		}
		public RESULT setVariations(float frequencyvar, float volumevar, float panvar)
		{
			return Sound.FMOD_Sound_SetVariations(soundraw, frequencyvar, volumevar, panvar);
		}
		public RESULT getVariations(ref float frequencyvar, ref float volumevar, ref float panvar)
		{
			return Sound.FMOD_Sound_GetVariations(soundraw, ref frequencyvar, ref volumevar, ref panvar);
		}
		public RESULT set3DMinMaxDistance(float min, float max)
		{
			return Sound.FMOD_Sound_Set3DMinMaxDistance(soundraw, min, max);
		}
		public RESULT get3DMinMaxDistance(ref float min, ref float max)
		{
			return Sound.FMOD_Sound_Get3DMinMaxDistance(soundraw, ref min, ref max);
		}
		public RESULT set3DConeSettings(float insideconeangle, float outsideconeangle, float outsidevolume)
		{
			return Sound.FMOD_Sound_Set3DConeSettings(soundraw, insideconeangle, outsideconeangle, outsidevolume);
		}
		public RESULT get3DConeSettings(ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume)
		{
			return Sound.FMOD_Sound_Get3DConeSettings(soundraw, ref insideconeangle, ref outsideconeangle, ref outsidevolume);
		}
		public RESULT set3DCustomRolloff(ref VECTOR points, int numpoints)
		{
			return Sound.FMOD_Sound_Set3DCustomRolloff(soundraw, ref points, numpoints);
		}
		public RESULT get3DCustomRolloff(ref IntPtr points, ref int numpoints)
		{
			return Sound.FMOD_Sound_Get3DCustomRolloff(soundraw, ref points, ref numpoints);
		}
		public RESULT setSubSound(int index, Sound subsound)
		{
			IntPtr raw = subsound.getRaw();
			return Sound.FMOD_Sound_SetSubSound(soundraw, index, raw);
		}
		public RESULT getSubSound(int index, ref Sound subsound)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = Sound.FMOD_Sound_GetSubSound(soundraw, index, ref raw);
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
				if (subsound == null)
				{
					Sound sound = new Sound();
					sound.setRaw(raw);
					subsound = sound;
				}
				else
				{
					subsound.setRaw(raw);
				}
				result = rESULT;
			}
			return result;
		}
		public RESULT setSubSoundSentence(int[] subsoundlist, int numsubsounds)
		{
			return Sound.FMOD_Sound_SetSubSoundSentence(soundraw, subsoundlist, numsubsounds);
		}
		public RESULT getName(StringBuilder name, int namelen)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Sound.FMOD_Sound_GetName_64(soundraw, name, namelen);
			}
			else
			{
				result = Sound.FMOD_Sound_GetName_32(soundraw, name, namelen);
			}
			return result;
		}
		public RESULT getLength(ref uint length, TIMEUNIT lengthtype)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Sound.FMOD_Sound_GetLength_64(soundraw, ref length, lengthtype);
			}
			else
			{
				result = Sound.FMOD_Sound_GetLength_32(soundraw, ref length, lengthtype);
			}
			return result;
		}
		public RESULT getFormat(ref SOUND_TYPE type, ref SOUND_FORMAT format, ref int channels, ref int bits)
		{
			RESULT result;
			if (VERSION.platform == Platform.X64)
			{
				result = Sound.FMOD_Sound_GetFormat_64(soundraw, ref type, ref format, ref channels, ref bits);
			}
			else
			{
				result = Sound.FMOD_Sound_GetFormat_32(soundraw, ref type, ref format, ref channels, ref bits);
			}
			return result;
		}
		public RESULT getNumSubSounds(ref int numsubsounds)
		{
			return Sound.FMOD_Sound_GetNumSubSounds(soundraw, ref numsubsounds);
		}
		public RESULT getNumTags(ref int numtags, ref int numtagsupdated)
		{
			return Sound.FMOD_Sound_GetNumTags(soundraw, ref numtags, ref numtagsupdated);
		}
		public RESULT getTag(string name, int index, ref TAG tag)
		{
			IntPtr intPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(tag));
			RESULT rESULT = Sound.FMOD_Sound_GetTag(soundraw, name, index, intPtr);
			if (rESULT == RESULT.OK)
			{
				tag = (TAG)Marshal.PtrToStructure(intPtr, typeof(TAG));
			}
			return rESULT;
		}
		public RESULT getOpenState(ref OPENSTATE openstate, ref uint percentbuffered, ref bool starving)
		{
			return Sound.FMOD_Sound_GetOpenState(soundraw, ref openstate, ref percentbuffered, ref starving);
		}
		public RESULT readData(IntPtr buffer, uint lenbytes, ref uint read)
		{
			return Sound.FMOD_Sound_ReadData(soundraw, buffer, lenbytes, ref read);
		}
		public RESULT seekData(uint pcm)
		{
			return Sound.FMOD_Sound_SeekData(soundraw, pcm);
		}
		public RESULT setSoundGroup(SoundGroup soundgroup)
		{
			return Sound.FMOD_Sound_SetSoundGroup(soundraw, soundgroup.getRaw());
		}
		public RESULT getSoundGroup(ref SoundGroup soundgroup)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = Sound.FMOD_Sound_GetSoundGroup(soundraw, ref raw);
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
		public RESULT getNumSyncPoints(ref int numsyncpoints)
		{
			return Sound.FMOD_Sound_GetNumSyncPoints(soundraw, ref numsyncpoints);
		}
		public RESULT getSyncPoint(int index, ref IntPtr point)
		{
			return Sound.FMOD_Sound_GetSyncPoint(soundraw, index, ref point);
		}
		public RESULT getSyncPointInfo(IntPtr point, StringBuilder name, int namelen, ref uint offset, TIMEUNIT offsettype)
		{
			return Sound.FMOD_Sound_GetSyncPointInfo(soundraw, point, name, namelen, ref offset, offsettype);
		}
		public RESULT addSyncPoint(int offset, TIMEUNIT offsettype, string name, ref IntPtr point)
		{
			return Sound.FMOD_Sound_AddSyncPoint(soundraw, offset, offsettype, name, ref point);
		}
		public RESULT deleteSyncPoint(IntPtr point)
		{
			return Sound.FMOD_Sound_DeleteSyncPoint(soundraw, point);
		}
		public RESULT setMode(MODE mode)
		{
			return Sound.FMOD_Sound_SetMode(soundraw, mode);
		}
		public RESULT getMode(ref MODE mode)
		{
			return Sound.FMOD_Sound_GetMode(soundraw, ref mode);
		}
		public RESULT setLoopCount(int loopcount)
		{
			return Sound.FMOD_Sound_SetLoopCount(soundraw, loopcount);
		}
		public RESULT getLoopCount(ref int loopcount)
		{
			return Sound.FMOD_Sound_GetLoopCount(soundraw, ref loopcount);
		}
		public RESULT setLoopPoints(uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype)
		{
			return Sound.FMOD_Sound_SetLoopPoints(soundraw, loopstart, loopstarttype, loopend, loopendtype);
		}
		public RESULT getLoopPoints(ref uint loopstart, TIMEUNIT loopstarttype, ref uint loopend, TIMEUNIT loopendtype)
		{
			return Sound.FMOD_Sound_GetLoopPoints(soundraw, ref loopstart, loopstarttype, ref loopend, loopendtype);
		}
		public RESULT getMusicNumChannels(ref int numchannels)
		{
			return Sound.FMOD_Sound_GetMusicNumChannels(soundraw, ref numchannels);
		}
		public RESULT setMusicChannelVolume(int channel, float volume)
		{
			return Sound.FMOD_Sound_SetMusicChannelVolume(soundraw, channel, volume);
		}
		public RESULT getMusicChannelVolume(int channel, ref float volume)
		{
			return Sound.FMOD_Sound_GetMusicChannelVolume(soundraw, channel, ref volume);
		}
		public RESULT setUserData(IntPtr userdata)
		{
			return Sound.FMOD_Sound_SetUserData(soundraw, userdata);
		}
		public RESULT getUserData(ref IntPtr userdata)
		{
			return Sound.FMOD_Sound_GetUserData(soundraw, ref userdata);
		}
		[DllImport("fmodex", EntryPoint = "FMOD_Sound_Release")]
		private static extern RESULT FMOD_Sound_Release_32(IntPtr sound);
		[DllImport("fmodex64", EntryPoint = "FMOD_Sound_Release")]
		private static extern RESULT FMOD_Sound_Release_64(IntPtr sound);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetSystemObject(IntPtr sound, ref IntPtr system);
		[DllImport("fmodex", EntryPoint = "FMOD_Sound_Lock")]
		private static extern RESULT FMOD_Sound_Lock_32(IntPtr sound, uint offset, uint length, ref IntPtr ptr1, ref IntPtr ptr2, ref uint len1, ref uint len2);
		[DllImport("fmodex64", EntryPoint = "FMOD_Sound_Lock")]
		private static extern RESULT FMOD_Sound_Lock_64(IntPtr sound, uint offset, uint length, ref IntPtr ptr1, ref IntPtr ptr2, ref uint len1, ref uint len2);
		[DllImport("fmodex", EntryPoint = "FMOD_Sound_Unlock")]
		private static extern RESULT FMOD_Sound_Unlock_32(IntPtr sound, IntPtr ptr1, IntPtr ptr2, uint len1, uint len2);
		[DllImport("fmodex64", EntryPoint = "FMOD_Sound_Unlock")]
		private static extern RESULT FMOD_Sound_Unlock_64(IntPtr sound, IntPtr ptr1, IntPtr ptr2, uint len1, uint len2);
		[DllImport("fmodex", EntryPoint = "FMOD_Sound_SetDefaults")]
		private static extern RESULT FMOD_Sound_SetDefaults_32(IntPtr sound, float frequency, float volume, float pan, int priority);
		[DllImport("fmodex64", EntryPoint = "FMOD_Sound_SetDefaults")]
		private static extern RESULT FMOD_Sound_SetDefaults_64(IntPtr sound, float frequency, float volume, float pan, int priority);
		[DllImport("fmodex", EntryPoint = "FMOD_Sound_GetDefaults")]
		private static extern RESULT FMOD_Sound_GetDefaults_32(IntPtr sound, ref float frequency, ref float volume, ref float pan, ref int priority);
		[DllImport("fmodex64", EntryPoint = "FMOD_Sound_GetDefaults")]
		private static extern RESULT FMOD_Sound_GetDefaults_64(IntPtr sound, ref float frequency, ref float volume, ref float pan, ref int priority);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_SetVariations(IntPtr sound, float frequencyvar, float volumevar, float panvar);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetVariations(IntPtr sound, ref float frequencyvar, ref float volumevar, ref float panvar);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_Set3DMinMaxDistance(IntPtr sound, float min, float max);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_Get3DMinMaxDistance(IntPtr sound, ref float min, ref float max);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_Set3DConeSettings(IntPtr sound, float insideconeangle, float outsideconeangle, float outsidevolume);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_Get3DConeSettings(IntPtr sound, ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_Set3DCustomRolloff(IntPtr sound, ref VECTOR points, int numpoints);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_Get3DCustomRolloff(IntPtr sound, ref IntPtr points, ref int numpoints);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_SetSubSound(IntPtr sound, int index, IntPtr subsound);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetSubSound(IntPtr sound, int index, ref IntPtr subsound);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_SetSubSoundSentence(IntPtr sound, int[] subsoundlist, int numsubsounds);
		[DllImport("fmodex", EntryPoint = "FMOD_Sound_GetName")]
		private static extern RESULT FMOD_Sound_GetName_32(IntPtr sound, StringBuilder name, int namelen);
		[DllImport("fmodex64", EntryPoint = "FMOD_Sound_GetName")]
		private static extern RESULT FMOD_Sound_GetName_64(IntPtr sound, StringBuilder name, int namelen);
		[DllImport("fmodex", EntryPoint = "FMOD_Sound_GetLength")]
		private static extern RESULT FMOD_Sound_GetLength_32(IntPtr sound, ref uint length, TIMEUNIT lengthtype);
		[DllImport("fmodex64", EntryPoint = "FMOD_Sound_GetLength")]
		private static extern RESULT FMOD_Sound_GetLength_64(IntPtr sound, ref uint length, TIMEUNIT lengthtype);
		[DllImport("fmodex", EntryPoint = "FMOD_Sound_GetFormat")]
		private static extern RESULT FMOD_Sound_GetFormat_32(IntPtr sound, ref SOUND_TYPE type, ref SOUND_FORMAT format, ref int channels, ref int bits);
		[DllImport("fmodex64", EntryPoint = "FMOD_Sound_GetFormat")]
		private static extern RESULT FMOD_Sound_GetFormat_64(IntPtr sound, ref SOUND_TYPE type, ref SOUND_FORMAT format, ref int channels, ref int bits);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetNumSubSounds(IntPtr sound, ref int numsubsounds);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetNumTags(IntPtr sound, ref int numtags, ref int numtagsupdated);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetTag(IntPtr sound, string name, int index, IntPtr tag);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetOpenState(IntPtr sound, ref OPENSTATE openstate, ref uint percentbuffered, ref bool starving);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_ReadData(IntPtr sound, IntPtr buffer, uint lenbytes, ref uint read);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_SeekData(IntPtr sound, uint pcm);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_SetSoundGroup(IntPtr sound, IntPtr soundgroup);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetSoundGroup(IntPtr sound, ref IntPtr soundgroup);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetNumSyncPoints(IntPtr sound, ref int numsyncpoints);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetSyncPoint(IntPtr sound, int index, ref IntPtr point);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetSyncPointInfo(IntPtr sound, IntPtr point, StringBuilder name, int namelen, ref uint offset, TIMEUNIT offsettype);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_AddSyncPoint(IntPtr sound, int offset, TIMEUNIT offsettype, string name, ref IntPtr point);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_DeleteSyncPoint(IntPtr sound, IntPtr point);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_SetMode(IntPtr sound, MODE mode);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetMode(IntPtr sound, ref MODE mode);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_SetLoopCount(IntPtr sound, int loopcount);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetLoopCount(IntPtr sound, ref int loopcount);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_SetLoopPoints(IntPtr sound, uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetLoopPoints(IntPtr sound, ref uint loopstart, TIMEUNIT loopstarttype, ref uint loopend, TIMEUNIT loopendtype);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetMusicNumChannels(IntPtr sound, ref int numchannels);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_SetMusicChannelVolume(IntPtr sound, int channel, float volume);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetMusicChannelVolume(IntPtr sound, int channel, ref float volume);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_SetUserData(IntPtr sound, IntPtr userdata);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Sound_GetUserData(IntPtr sound, ref IntPtr userdata);
		public void setRaw(IntPtr sound)
		{
			soundraw = IntPtr.Zero;
			soundraw = sound;
		}
		public IntPtr getRaw()
		{
			return soundraw;
		}
	}
}
