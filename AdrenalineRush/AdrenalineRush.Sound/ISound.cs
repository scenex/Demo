
namespace AdrenalineRush.Sound
{
    public interface ISound
    {
        #region Properties

        int SongLength { get; }

        double CurrentSongPosition { get; }

        bool FileLoaded { get; }

        bool LibraryInitialized { get; }

        bool PlaybackStarted { get; }

        bool PlaybackPaused { get; }

        #endregion

        #region Methods

        void Load(string path);

        void Init();

        void Play();

        void Pause();

        void Stop();

        void Seek(double position);

        void Dispose();

        #endregion
    }
}
