// Type: Un4seen.Bass.Bass
// Assembly: Bass.Net, Version=2.4.7.4, Culture=neutral, PublicKeyToken=b7566c273e6ef480
// Assembly location: C:\Users\scenex\Documents\Visual Studio 2010\Projects\AdrenalineRush\AdrenalineRush\Libs\Bass.Net.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

using Un4seen.Bass.AddOn.Tags;

namespace Un4seen.Bass
{
    [SuppressUnmanagedCodeSecurity]
    public sealed class Bass
    {
        #region Constants and Fields

        public const int BASSVERSION = 516;

        public const int ERROR = -1;

        public const int FALSE = 0;

        public const int TRUE = 1;

        public static string SupportedMusicExtensions;

        public static string SupportedStreamExtensions;

        public static string SupportedStreamName;

        #endregion

        #region Constructors and Destructors

        public Bass();

        #endregion

        #region Public Methods

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static void BASS_Apply3D();

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static double BASS_ChannelBytes2Seconds(int handle, long pos);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static BASSFlag BASS_ChannelFlags(int handle, BASSFlag flags, BASSFlag mask);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelGet3DAttributes(
            int handle,
            ref BASS3DMode mode,
            ref float min,
            ref float max,
            ref int iangle,
            ref int oangle,
            ref int outvol);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelGet3DAttributes(
            int handle,
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object mode,
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object min,
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object max,
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object iangle,
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object oangle,
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object outvol);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelGet3DPosition(
            int handle, [In] [Out] BASS_3DVECTOR pos, [In] [Out] BASS_3DVECTOR orient, [In] [Out] BASS_3DVECTOR vel);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelGetAttribute(int handle, BASSAttribute attrib, ref float value);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_ChannelGetData(int handle, IntPtr buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_ChannelGetData(int handle, [In] [Out] float[] buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_ChannelGetData(int handle, [In] [Out] short[] buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_ChannelGetData(int handle, [In] [Out] int[] buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_ChannelGetData(int handle, [In] [Out] byte[] buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_ChannelGetDevice(int handle);

        public static bool BASS_ChannelGetInfo(int handle, BASS_CHANNELINFO info);

        public static BASS_CHANNELINFO BASS_ChannelGetInfo(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static long BASS_ChannelGetLength(int handle, BASSMode mode);

        public static long BASS_ChannelGetLength(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_ChannelGetLevel(int handle);

        public static bool BASS_ChannelGetLevel(int handle, float[] level);

        public static string[] BASS_ChannelGetMidiTrackText(int handle, int track);

        public static string BASS_ChannelGetMusicInstrument(int handle, int instrument);

        public static string BASS_ChannelGetMusicMessage(int handle);

        public static string BASS_ChannelGetMusicName(int handle);

        public static string BASS_ChannelGetMusicSample(int handle, int sample);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static long BASS_ChannelGetPosition(int handle, BASSMode mode);

        public static long BASS_ChannelGetPosition(int handle);

        public static string BASS_ChannelGetTagLyrics3v2(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static IntPtr BASS_ChannelGetTags(int handle, BASSTag tags);

        public static string[] BASS_ChannelGetTagsAPE(int handle);

        public static BASS_TAG_APE_BINARY[] BASS_ChannelGetTagsAPEBinary(int handle);

        public static TagPicture[] BASS_ChannelGetTagsAPEPictures(int handle);

        public static string[] BASS_ChannelGetTagsArrayNullTermAnsi(int handle, BASSTag format);

        public static string[] BASS_ChannelGetTagsArrayNullTermUtf8(int handle, BASSTag format);

        public static string[] BASS_ChannelGetTagsBWF(int handle);

        public static BASS_TAG_CACODEC BASS_ChannelGetTagsCA(int handle);

        public static BASS_TAG_FLAC_CUE BASS_ChannelGetTagsFLACCuesheet(int handle);

        public static BASS_TAG_FLAC_PICTURE[] BASS_ChannelGetTagsFLACPictures(int handle);

        public static string[] BASS_ChannelGetTagsHTTP(int handle);

        public static string[] BASS_ChannelGetTagsICY(int handle);

        public static string[] BASS_ChannelGetTagsID3V1(int handle);

        public static string[] BASS_ChannelGetTagsID3V2(int handle);

        public static string[] BASS_ChannelGetTagsMETA(int handle);

        public static string[] BASS_ChannelGetTagsMP4(int handle);

        public static string[] BASS_ChannelGetTagsOGG(int handle);

        public static string[] BASS_ChannelGetTagsRIFF(int handle);

        public static string[] BASS_ChannelGetTagsWMA(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static BASSActive BASS_ChannelIsActive(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelIsSliding(int handle, BASSAttribute attrib);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelLock(int handle, [MarshalAs(UnmanagedType.Bool)] bool state);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelPause(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelPlay(int handle, [MarshalAs(UnmanagedType.Bool)] bool restart);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelRemoveDSP(int handle, int dsp);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelRemoveFX(int handle, int fx);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelRemoveLink(int handle, int chan);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelRemoveSync(int handle, int sync);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static long BASS_ChannelSeconds2Bytes(int handle, double pos);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelSet3DAttributes(
            int handle, BASS3DMode mode, float min, float max, int iangle, int oangle, int outvol);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelSet3DPosition(
            int handle, [In] BASS_3DVECTOR pos, [In] BASS_3DVECTOR orient, [In] BASS_3DVECTOR vel);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelSetAttribute(int handle, BASSAttribute attrib, float value);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_ChannelSetDSP(int handle, DSPPROC proc, IntPtr user, int priority);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelSetDevice(int handle, int device);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_ChannelSetFX(int handle, BASSFXType type, int priority);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelSetLink(int handle, int chan);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelSetPosition(int handle, long pos, BASSMode mode);

        public static bool BASS_ChannelSetPosition(int handle, long pos);

        public static bool BASS_ChannelSetPosition(int handle, double seconds);

        public static bool BASS_ChannelSetPosition(int handle, int order, int row);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_ChannelSetSync(int handle, BASSSync type, long param, SYNCPROC proc, IntPtr user);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelSlideAttribute(int handle, BASSAttribute attrib, float value, int time);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelStop(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_ChannelUpdate(int handle, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static BASSError BASS_ErrorGetCode();

        public static bool BASS_FXGetParameters(int handle, object par);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_FXReset(int handle);

        public static bool BASS_FXSetParameters(int handle, object par);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_Free();

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_Get3DFactors(ref float distf, ref float rollf, ref float doppf);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_Get3DFactors(
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object distf,
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object rollf,
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object doppf);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_Get3DPosition(
            [In] [Out] BASS_3DVECTOR pos,
            [In] [Out] BASS_3DVECTOR vel,
            [In] [Out] BASS_3DVECTOR front,
            [In] [Out] BASS_3DVECTOR top);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static float BASS_GetCPU();

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_GetConfig(BASSConfig option);

        [DllImport("bass.dll", EntryPoint = "BASS_GetConfig", CharSet = CharSet.Auto)]
        public static bool BASS_GetConfigBool(BASSConfig option);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static IntPtr BASS_GetConfigPtr(BASSConfig option);

        public static string BASS_GetConfigString(BASSConfig option);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static IntPtr BASS_GetDSoundObject(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static IntPtr BASS_GetDSoundObject(BASSDirectSound dsobject);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_GetDevice();

        public static int BASS_GetDeviceCount();

        public static bool BASS_GetDeviceInfo(int device, BASS_DEVICEINFO info);

        public static BASS_DEVICEINFO BASS_GetDeviceInfo(int device);

        public static BASS_DEVICEINFO[] BASS_GetDeviceInfos();

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_GetEAXParameters(ref EAXEnvironment env, ref float vol, ref float decay, ref float damp);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_GetEAXParameters(
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object env,
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object vol,
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object decay,
            [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object damp);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_GetInfo([In] [Out] BASS_INFO info);

        public static BASS_INFO BASS_GetInfo();

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_GetVersion();

        public static Version BASS_GetVersion(int fieldcount);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static float BASS_GetVolume();

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_Init(int device, int freq, BASSInit flags, IntPtr win, Guid clsid);

        public static bool BASS_Init(int device, int freq, BASSInit flags, IntPtr win);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_MusicFree(int handle);

        public static int BASS_MusicLoad(string file, long offset, int length, BASSFlag flags, int freq);

        public static int BASS_MusicLoad(IntPtr memory, long offset, int length, BASSFlag flags, int freq);

        public static int BASS_MusicLoad(byte[] memory, long offset, int length, BASSFlag flags, int freq);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_Pause();

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_PluginFree(int handle);

        public static BASS_PLUGININFO BASS_PluginGetInfo(int handle);

        public static int BASS_PluginLoad(string file);

        public static Dictionary<int, string> BASS_PluginLoadDirectory(string dir);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_RecordFree();

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_RecordGetDevice();

        public static int BASS_RecordGetDeviceCount();

        public static bool BASS_RecordGetDeviceInfo(int device, BASS_DEVICEINFO info);

        public static BASS_DEVICEINFO BASS_RecordGetDeviceInfo(int device);

        public static BASS_DEVICEINFO[] BASS_RecordGetDeviceInfos();

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_RecordGetInfo([In] [Out] BASS_RECORDINFO info);

        public static BASS_RECORDINFO BASS_RecordGetInfo();

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_RecordGetInput(int input, ref float volume);

        public static BASSInput BASS_RecordGetInput(int input);

        public static string BASS_RecordGetInputName(int input);

        public static string[] BASS_RecordGetInputNames();

        public static BASSInputType BASS_RecordGetInputType(int input);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_RecordInit(int device);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_RecordSetDevice(int device);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_RecordSetInput(int input, BASSInput setting, float volume);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_RecordStart(int freq, int chans, BASSFlag flags, RECORDPROC proc, IntPtr user);

        public static int BASS_RecordStart(
            int freq, int chans, BASSFlag flags, int period, RECORDPROC proc, IntPtr user);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_SampleCreate(int length, int freq, int chans, int max, BASSFlag flags);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleFree(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_SampleGetChannel(int handle, [MarshalAs(UnmanagedType.Bool)] bool onlynew);

        public static int BASS_SampleGetChannelCount(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_SampleGetChannels(int handle, int[] channels);

        public static int[] BASS_SampleGetChannels(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleGetData(int handle, IntPtr buffer);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleGetData(int handle, float[] buffer);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleGetData(int handle, int[] buffer);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleGetData(int handle, short[] buffer);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleGetData(int handle, byte[] buffer);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleGetInfo(int handle, [In] [Out] BASS_SAMPLE info);

        public static BASS_SAMPLE BASS_SampleGetInfo(int handle);

        public static int BASS_SampleLoad(string file, long offset, int length, int max, BASSFlag flags);

        public static int BASS_SampleLoad(IntPtr memory, long offset, int length, int max, BASSFlag flags);

        public static int BASS_SampleLoad(byte[] memory, long offset, int length, int max, BASSFlag flags);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleSetData(int handle, IntPtr buffer);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleSetData(int handle, float[] buffer);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleSetData(int handle, int[] buffer);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleSetData(int handle, short[] buffer);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleSetData(int handle, byte[] buffer);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleSetInfo(int handle, [In] BASS_SAMPLE info);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SampleStop(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_Set3DFactors(float distf, float rollf, float doppf);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_Set3DPosition(
            [In] BASS_3DVECTOR pos, [In] BASS_3DVECTOR vel, [In] BASS_3DVECTOR front, [In] BASS_3DVECTOR top);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SetConfig(BASSConfig option, int newvalue);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SetConfig(BASSConfig option, [MarshalAs(UnmanagedType.Bool)] [In] bool newvalue);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SetConfigPtr(BASSConfig option, IntPtr newvalue);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SetDevice(int device);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SetEAXParameters(EAXEnvironment env, float vol, float decay, float damp);

        public static bool BASS_SetEAXParameters(EAXPreset preset);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_SetVolume(float volume);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_Start();

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_Stop();

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_StreamCreate(int freq, int chans, BASSFlag flags, STREAMPROC proc, IntPtr user);

        public static int BASS_StreamCreate(int freq, int chans, BASSFlag flags, BASSStreamProc proc);

        public static int BASS_StreamCreateDummy(int freq, int chans, BASSFlag flags, IntPtr user);

        public static int BASS_StreamCreateFile(string file, long offset, long length, BASSFlag flags);

        public static int BASS_StreamCreateFile(IntPtr memory, long offset, long length, BASSFlag flags);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_StreamCreateFileUser(
            BASSStreamSystem system, BASSFlag flags, BASS_FILEPROCS procs, IntPtr user);

        public static int BASS_StreamCreatePush(int freq, int chans, BASSFlag flags, IntPtr user);

        public static int BASS_StreamCreateURL(string url, int offset, BASSFlag flags, DOWNLOADPROC proc, IntPtr user);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_StreamFree(int handle);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static long BASS_StreamGetFilePosition(int handle, BASSStreamFilePosition mode);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_StreamPutData(int handle, IntPtr buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_StreamPutData(int handle, float[] buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_StreamPutData(int handle, int[] buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_StreamPutData(int handle, short[] buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_StreamPutData(int handle, byte[] buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_StreamPutFileData(int handle, IntPtr buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_StreamPutFileData(int handle, float[] buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_StreamPutFileData(int handle, int[] buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_StreamPutFileData(int handle, short[] buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static int BASS_StreamPutFileData(int handle, byte[] buffer, int length);

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        public static bool BASS_Update(int length);

        public static bool FreeMe();

        public static bool LoadMe();

        public static bool LoadMe(string path);

        #endregion
    }
}
