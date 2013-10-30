using System;
using System.Runtime.InteropServices;
namespace FMOD
{
	public class REVERB_PROPERTIES
	{
		public int Instance;
		public uint Environment;
		public float EnvSize;
		public float EnvDiffusion;
		public int Room;
		public int RoomHF;
		public int RoomLF;
		public float DecayTime;
		public float DecayHFRatio;
		public float DecayLFRatio;
		public int Reflections;
		public float ReflectionsDelay;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public float[] ReflectionsPan;
		public int Reverb;
		public float ReverbDelay;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public float[] ReverbPan;
		public float EchoTime;
		public float EchoDepth;
		public float ModulationTime;
		public float ModulationDepth;
		public float AirAbsorptionHF;
		public float HFReference;
		public float LFReference;
		public float RoomRolloffFactor;
		public float Diffusion;
		public float Density;
		public uint Flags;
		public REVERB_PROPERTIES(int instance, uint environment, float envSize, float envDiffusion, int room, int roomHF, int roomLF, float decayTime, float decayHFRatio, float decayLFRatio, int reflections, float reflectionsDelay, float reflectionsPanx, float reflectionsPany, float reflectionsPanz, int reverb, float reverbDelay, float reverbPanx, float reverbPany, float reverbPanz, float echoTime, float echoDepth, float modulationTime, float modulationDepth, float airAbsorptionHF, float hfReference, float lfReference, float roomRolloffFactor, float diffusion, float density, uint flags)
		{
			ReflectionsPan = new float[3];
			ReverbPan = new float[3];
			Instance = instance;
			Environment = environment;
			EnvSize = envSize;
			EnvDiffusion = envDiffusion;
			Room = room;
			RoomHF = roomHF;
			RoomLF = roomLF;
			DecayTime = decayTime;
			DecayHFRatio = decayHFRatio;
			DecayLFRatio = decayLFRatio;
			Reflections = reflections;
			ReflectionsDelay = reflectionsDelay;
			ReflectionsPan[0] = reflectionsPanx;
			ReflectionsPan[1] = reflectionsPany;
			ReflectionsPan[2] = reflectionsPanz;
			Reverb = reverb;
			ReverbDelay = reverbDelay;
			ReverbPan[0] = reverbPanx;
			ReverbPan[1] = reverbPany;
			ReverbPan[2] = reverbPanz;
			EchoTime = echoTime;
			EchoDepth = echoDepth;
			ModulationTime = modulationTime;
			ModulationDepth = modulationDepth;
			AirAbsorptionHF = airAbsorptionHF;
			HFReference = hfReference;
			LFReference = lfReference;
			RoomRolloffFactor = roomRolloffFactor;
			Diffusion = diffusion;
			Density = density;
			Flags = flags;
		}
	}
}
