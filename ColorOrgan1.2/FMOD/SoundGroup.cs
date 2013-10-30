using System;
using System.Runtime.InteropServices;
using System.Text;
namespace FMOD
{
	public class SoundGroup
	{
		private IntPtr soundgroupraw;
		public RESULT release()
		{
			return SoundGroup.FMOD_SoundGroup_Release(soundgroupraw);
		}
		public RESULT getSystemObject(ref _System system)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = SoundGroup.FMOD_SoundGroup_GetSystemObject(soundgroupraw, ref raw);
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
		public RESULT setMaxAudible(int maxaudible)
		{
			return SoundGroup.FMOD_SoundGroup_SetMaxAudible(soundgroupraw, maxaudible);
		}
		public RESULT getMaxAudible(ref int maxaudible)
		{
			return SoundGroup.FMOD_SoundGroup_GetMaxAudible(soundgroupraw, ref maxaudible);
		}
		public RESULT setMaxAudibleBehavior(SOUNDGROUP_BEHAVIOR behavior)
		{
			return SoundGroup.FMOD_SoundGroup_SetMaxAudibleBehavior(soundgroupraw, behavior);
		}
		public RESULT getMaxAudibleBehavior(ref SOUNDGROUP_BEHAVIOR behavior)
		{
			return SoundGroup.FMOD_SoundGroup_GetMaxAudibleBehavior(soundgroupraw, ref behavior);
		}
		public RESULT setMuteFadeSpeed(float speed)
		{
			return SoundGroup.FMOD_SoundGroup_SetMuteFadeSpeed(soundgroupraw, speed);
		}
		public RESULT getMuteFadeSpeed(ref float speed)
		{
			return SoundGroup.FMOD_SoundGroup_GetMuteFadeSpeed(soundgroupraw, ref speed);
		}
		public RESULT getName(StringBuilder name, int namelen)
		{
			return SoundGroup.FMOD_SoundGroup_GetName(soundgroupraw, name, namelen);
		}
		public RESULT getNumSounds(ref int numsounds)
		{
			return SoundGroup.FMOD_SoundGroup_GetNumSounds(soundgroupraw, ref numsounds);
		}
		public RESULT getSound(int index, ref Sound sound)
		{
			RESULT rESULT = RESULT.OK;
			IntPtr raw = IntPtr.Zero;
			try
			{
				rESULT = SoundGroup.FMOD_SoundGroup_GetSound(soundgroupraw, index, ref raw);
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
		public RESULT getNumPlaying(ref int numplaying)
		{
			return SoundGroup.FMOD_SoundGroup_GetNumPlaying(soundgroupraw, ref numplaying);
		}
		public RESULT setUserData(IntPtr userdata)
		{
			return SoundGroup.FMOD_SoundGroup_SetUserData(soundgroupraw, userdata);
		}
		public RESULT getUserData(ref IntPtr userdata)
		{
			return SoundGroup.FMOD_SoundGroup_GetUserData(soundgroupraw, ref userdata);
		}
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_Release(IntPtr soundgroupraw);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_GetSystemObject(IntPtr soundgroupraw, ref IntPtr system);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_SetMaxAudible(IntPtr soundgroupraw, int maxaudible);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_GetMaxAudible(IntPtr soundgroupraw, ref int maxaudible);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_SetMaxAudibleBehavior(IntPtr soundgroupraw, SOUNDGROUP_BEHAVIOR behavior);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_GetMaxAudibleBehavior(IntPtr soundgroupraw, ref SOUNDGROUP_BEHAVIOR behavior);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_SetMuteFadeSpeed(IntPtr soundgroupraw, float speed);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_GetMuteFadeSpeed(IntPtr soundgroupraw, ref float speed);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_GetName(IntPtr soundgroupraw, StringBuilder name, int namelen);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_GetNumSounds(IntPtr soundgroupraw, ref int numsounds);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_GetSound(IntPtr soundgroupraw, int index, ref IntPtr sound);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_GetNumPlaying(IntPtr soundgroupraw, ref int numplaying);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_SetUserData(IntPtr soundgroupraw, IntPtr userdata);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_SoundGroup_GetUserData(IntPtr soundgroupraw, ref IntPtr userdata);
		public void setRaw(IntPtr soundgroup)
		{
			soundgroupraw = IntPtr.Zero;
			soundgroupraw = soundgroup;
		}
		public IntPtr getRaw()
		{
			return soundgroupraw;
		}
	}
}
