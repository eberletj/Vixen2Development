using System;
namespace FMOD
{
	internal class Error
	{
		public static string String(RESULT errcode)
		{
			string result;
			switch (errcode)
			{
			case RESULT.OK:
				result = "No errors.";
				return result;
			case RESULT.ERR_ALREADYLOCKED:
				result = "Tried to call lock a second time before unlock was called. ";
				return result;
			case RESULT.ERR_BADCOMMAND:
				result = "Tried to call a function on a data type that does not allow this type of functionality (ie calling Sound::lock on a streaming sound). ";
				return result;
			case RESULT.ERR_CDDA_DRIVERS:
				result = "Neither NTSCSI nor ASPI could be initialised. ";
				return result;
			case RESULT.ERR_CDDA_INIT:
				result = "An error occurred while initialising the CDDA subsystem. ";
				return result;
			case RESULT.ERR_CDDA_INVALID_DEVICE:
				result = "Couldn't find the specified device. ";
				return result;
			case RESULT.ERR_CDDA_NOAUDIO:
				result = "No audio tracks on the specified disc. ";
				return result;
			case RESULT.ERR_CDDA_NODEVICES:
				result = "No CD/DVD devices were found. ";
				return result;
			case RESULT.ERR_CDDA_NODISC:
				result = "No disc present in the specified drive. ";
				return result;
			case RESULT.ERR_CDDA_READ:
				result = "A CDDA read error occurred. ";
				return result;
			case RESULT.ERR_CHANNEL_ALLOC:
				result = "Error trying to allocate a channel. ";
				return result;
			case RESULT.ERR_CHANNEL_STOLEN:
				result = "The specified channel has been reused to play another sound. ";
				return result;
			case RESULT.ERR_COM:
				result = "A Win32 COM related error occured. COM failed to initialize or a QueryInterface failed meaning a Windows codec or driver was not installed properly. ";
				return result;
			case RESULT.ERR_DMA:
				result = "DMA Failure.  See debug output for more information. ";
				return result;
			case RESULT.ERR_DSP_CONNECTION:
				result = "DSP connection error.  Connection possibly caused a cyclic dependancy. ";
				return result;
			case RESULT.ERR_DSP_FORMAT:
				result = "DSP Format error.  A DSP unit may have attempted to connect to this network with the wrong format. ";
				return result;
			case RESULT.ERR_DSP_NOTFOUND:
				result = "DSP connection error.  Couldn't find the DSP unit specified. ";
				return result;
			case RESULT.ERR_DSP_RUNNING:
				result = "DSP error.  Cannot perform this operation while the network is in the middle of running.  This will most likely happen if a connection or disconnection is attempted in a DSP callback. ";
				return result;
			case RESULT.ERR_DSP_TOOMANYCONNECTIONS:
				result = "DSP connection error.  The unit being connected to or disconnected should only have 1 input or output. ";
				return result;
			case RESULT.ERR_FILE_BAD:
				result = "Error loading file. ";
				return result;
			case RESULT.ERR_FILE_COULDNOTSEEK:
				result = "Couldn't perform seek operation.  This is a limitation of the medium (ie netstreams) or the file format. ";
				return result;
			case RESULT.ERR_FILE_EOF:
				result = "End of file unexpectedly reached while trying to read essential data (truncated data?). ";
				return result;
			case RESULT.ERR_FILE_NOTFOUND:
				result = "File not found. ";
				return result;
			case RESULT.ERR_FILE_UNWANTED:
				result = "Unwanted file access occured.";
				return result;
			case RESULT.ERR_FORMAT:
				result = "Unsupported file or audio format. ";
				return result;
			case RESULT.ERR_HTTP:
				result = "A HTTP error occurred. This is a catch-all for HTTP errors not listed elsewhere. ";
				return result;
			case RESULT.ERR_HTTP_ACCESS:
				result = "The specified resource requires authentication or is forbidden. ";
				return result;
			case RESULT.ERR_HTTP_PROXY_AUTH:
				result = "Proxy authentication is required to access the specified resource. ";
				return result;
			case RESULT.ERR_HTTP_SERVER_ERROR:
				result = "A HTTP server error occurred. ";
				return result;
			case RESULT.ERR_HTTP_TIMEOUT:
				result = "The HTTP request timed out. ";
				return result;
			case RESULT.ERR_INITIALIZATION:
				result = "FMOD was not initialized correctly to support this function. ";
				return result;
			case RESULT.ERR_INITIALIZED:
				result = "Cannot call this command after System::init. ";
				return result;
			case RESULT.ERR_INTERNAL:
				result = "An error occured that wasnt supposed to.  Contact support. ";
				return result;
			case RESULT.ERR_INVALID_HANDLE:
				result = "An invalid object handle was used. ";
				return result;
			case RESULT.ERR_INVALID_PARAM:
				result = "An invalid parameter was passed to this function. ";
				return result;
			case RESULT.ERR_INVALID_SPEAKER:
				result = "An invalid speaker was passed to this function based on the current speaker mode. ";
				return result;
			case RESULT.ERR_IRX:
				result = "PS2 only.  fmodex.irx failed to initialize.  This is most likely because you forgot to load it. ";
				return result;
			case RESULT.ERR_MEMORY:
				result = "Not enough memory or resources. ";
				return result;
			case RESULT.ERR_MEMORY_IOP:
				result = "PS2 only.  Not enough memory or resources on PlayStation 2 IOP ram. ";
				return result;
			case RESULT.ERR_MEMORY_SRAM:
				result = "Not enough memory or resources on console sound ram. ";
				return result;
			case RESULT.ERR_NEEDS2D:
				result = "Tried to call a command on a 3d sound when the command was meant for 2d sound. ";
				return result;
			case RESULT.ERR_NEEDS3D:
				result = "Tried to call a command on a 2d sound when the command was meant for 3d sound. ";
				return result;
			case RESULT.ERR_NEEDSHARDWARE:
				result = "Tried to use a feature that requires hardware support.  (ie trying to play a VAG compressed sound in software on PS2). ";
				return result;
			case RESULT.ERR_NEEDSSOFTWARE:
				result = "Tried to use a feature that requires the software engine.  Software engine has either been turned off, or command was executed on a hardware channel which does not support this feature. ";
				return result;
			case RESULT.ERR_NET_CONNECT:
				result = "Couldn't connect to the specified host. ";
				return result;
			case RESULT.ERR_NET_SOCKET_ERROR:
				result = "A socket error occurred.  This is a catch-all for socket-related errors not listed elsewhere. ";
				return result;
			case RESULT.ERR_NET_URL:
				result = "The specified URL couldn't be resolved. ";
				return result;
			case RESULT.ERR_NOTREADY:
				result = "Operation could not be performed because specified sound is not ready. ";
				return result;
			case RESULT.ERR_OUTPUT_ALLOCATED:
				result = "Error initializing output device, but more specifically, the output device is already in use and cannot be reused. ";
				return result;
			case RESULT.ERR_OUTPUT_CREATEBUFFER:
				result = "Error creating hardware sound buffer. ";
				return result;
			case RESULT.ERR_OUTPUT_DRIVERCALL:
				result = "A call to a standard soundcard driver failed, which could possibly mean a bug in the driver or resources were missing or exhausted. ";
				return result;
			case RESULT.ERR_OUTPUT_FORMAT:
				result = "Soundcard does not support the minimum features needed for this soundsystem (16bit stereo output). ";
				return result;
			case RESULT.ERR_OUTPUT_INIT:
				result = "Error initializing output device. ";
				return result;
			case RESULT.ERR_OUTPUT_NOHARDWARE:
				result = "FMOD_HARDWARE was specified but the sound card does not have the resources nescessary to play it. ";
				return result;
			case RESULT.ERR_OUTPUT_NOSOFTWARE:
				result = "Attempted to create a software sound but no software channels were specified in System::init. ";
				return result;
			case RESULT.ERR_PAN:
				result = "Panning only works with mono or stereo sound sources. ";
				return result;
			case RESULT.ERR_PLUGIN:
				result = "An unspecified error has been returned from a 3rd party plugin. ";
				return result;
			case RESULT.ERR_PLUGIN_MISSING:
				result = "A requested output, dsp unit type or codec was not available. ";
				return result;
			case RESULT.ERR_PLUGIN_RESOURCE:
				result = "A resource that the plugin requires cannot be found. (ie the DLS file for MIDI playback) ";
				return result;
			case RESULT.ERR_RECORD:
				result = "An error occured trying to initialize the recording device. ";
				return result;
			case RESULT.ERR_REVERB_INSTANCE:
				result = "Specified Instance in FMOD_REVERB_PROPERTIES couldn't be set. Most likely because another application has locked the EAX4 FX slot. ";
				return result;
			case RESULT.ERR_SUBSOUND_ALLOCATED:
				result = "This subsound is already being used by another sound, you cannot have more than one parent to a sound.  Null out the other parent's entry first. ";
				return result;
			case RESULT.ERR_SUBSOUNDS:
				result = " The error occured because the sound referenced contains subsounds.  (ie you cannot play the parent sound as a static sample, only its subsounds.)";
				return result;
			case RESULT.ERR_TAGNOTFOUND:
				result = "The specified tag could not be found or there are no tags. ";
				return result;
			case RESULT.ERR_TOOMANYCHANNELS:
				result = "The sound created exceeds the allowable input channel count.  This can be increased with System::setMaxInputChannels. ";
				return result;
			case RESULT.ERR_UNIMPLEMENTED:
				result = "Something in FMOD hasn't been implemented when it should be! contact support! ";
				return result;
			case RESULT.ERR_UNINITIALIZED:
				result = "This command failed because System::init or System::setDriver was not called. ";
				return result;
			case RESULT.ERR_UNSUPPORTED:
				result = "A command issued was not supported by this object.  Possibly a plugin without certain callbacks specified. ";
				return result;
			case RESULT.ERR_UPDATE:
				result = "On PS2, System::update was called twice in a row when System::updateFinished must be called first. ";
				return result;
			case RESULT.ERR_VERSION:
				result = "The version number of this file format is not supported. ";
				return result;
			}
			result = "Unknown error.";
			return result;
		}
	}
}
