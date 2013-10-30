using System;
namespace FMOD
{
	public class ADVANCEDSETTINGS
	{
		public int cbsize;
		public int maxMPEGcodecs;
		public int maxADPCMcodecs;
		public int maxXMAcodecs;
		public int maxPCMcodecs;
		public int ASIONumChannels;
		public IntPtr ASIOChannelList;
		public IntPtr ASIOSpeakerList;
		public int max3DReverbDSPs;
		public float HRTFMinAngle;
		public float HRTFMaxAngle;
		public float HRTFFreq;
		public float vol0virtualvol;
		public int eventqueuesize;
		public uint defaultDecodeBufferSize;
	}
}
