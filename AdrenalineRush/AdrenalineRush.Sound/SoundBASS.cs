
namespace AdrenalineRush.Sound
{
    using System;
    using Un4seen.Bass;

    public class SoundBASS : ISound, IDisposable
    {
        #region Fields

        private int fileHandle;
        private bool fileLoaded;      
        private bool libraryInitialized;
        private bool playbackStarted;
        private bool playbackPaused;

        #endregion

        #region Constructor

        public SoundBASS()
        {
            this.fileHandle = 0;
            this.fileLoaded = false;
            this.libraryInitialized = false;
            this.playbackStarted = false;
            this.playbackPaused = false;
        }

        #endregion

        #region Properties

        public bool FileLoaded
        {
            get { return fileLoaded; }
        }

        public bool LibraryInitialized
        {
            get { return libraryInitialized; }
        }

        public bool PlaybackStarted
        {
            get { return this.playbackStarted; }
        }

        public bool PlaybackPaused
        {
            get { return this.playbackPaused; }
        }

        public double CurrentSongPosition
        {
            get
            {
                if (fileHandle != 0)
                {
                    return Bass.BASS_ChannelBytes2Seconds(fileHandle, Bass.BASS_ChannelGetPosition(fileHandle, BASSMode.BASS_POS_BYTES));
                }

                return 0;
            }
        }

        public int SongLength
        {
            get
            {
                if (fileHandle != 0)
                {
                    return (int)Bass.BASS_ChannelBytes2Seconds(fileHandle, Bass.BASS_ChannelGetLength(fileHandle, BASSMode.BASS_POS_BYTES)) * 1000;
                }

                return 0;           
            }
        }

        #endregion

        #region Methods

        public void Init()
        {
            libraryInitialized = Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
        }

        public void Load(string path)
        {           
            fileHandle = Bass.BASS_StreamCreateFile(path, 0, 0, BASSFlag.BASS_DEFAULT);
      
            if (libraryInitialized == true && (fileHandle != 0))
            {
               this.fileLoaded = true; 
            }
            else
            {
                this.fileLoaded = false;
            }            
        }

        public void Play()
        {
            if (Bass.BASS_ChannelPlay(fileHandle, false))
            {
                this.playbackStarted = true;
                this.playbackPaused = false;
            }
            else
            {
                this.playbackStarted = false;
            }
        }

        public void Pause()
        {
            if (fileHandle != 0)
            {
                Bass.BASS_ChannelPause(fileHandle);
                this.playbackPaused = true;
            }
        }

        public void Stop()
        {
            if (fileHandle != 0)
            {
                Bass.BASS_ChannelStop(fileHandle);
                this.playbackStarted = false;                
            }           
        }

        public void Seek(double position)
        {
            if (fileHandle != 0)
            {
                Bass.BASS_ChannelSetPosition(fileHandle, position);
            }            
        }

        public void Dispose()
        {
            Bass.BASS_Free();
        }

        #endregion

    }
}
