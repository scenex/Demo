
namespace AdrenalineRush.Sound.Tests.XUnit
{
    using FluentAssertions;

    using Moq;
    using Un4seen.Bass;
    using Xunit;

    public class SoundTests
    {
        ISound soundBass;

        /// <summary>
        /// sdsd ddd ssss ss
        /// </summary>
        Mock<ISound> soundBassMock;

        public SoundTests()
        {
            this.soundBass = new SoundBASS();
            this.soundBassMock = new Mock<ISound>();
            this.soundBassMock.SetupAllProperties();
        }

        [Fact]
        public void Sound_WhenLoad_ThenLoadSoundFile()
        {
            //this.soundBass.Init();
            
            //this.soundBass.Load("demomusic.wav");

            //this.soundBass.FileLoaded.Should().BeTrue();
            //this.soundBass.Dispose();

            string expected = "supersong.wav";

            this.soundBassMock.Object.Init();
            this.soundBassMock.Object.Load(expected);

            this.soundBassMock.Object.FileLoaded.Should().BeTrue();
            this.soundBassMock.Object.Dispose();
        }

        [Fact]
        public void Sound_WhenPlay_ThenPlaySoundFile()
        {
            this.soundBass.Init();
            this.soundBass.Load("demomusic.wav");

            this.soundBass.Play();

            this.soundBass.PlaybackStarted.Should().BeTrue();
            this.soundBass.Dispose();
        }

        [Fact]
        public void Sound_WhenStop_ThenStopPlayback()
        {
            this.soundBass.Init();
            this.soundBass.Load("demomusic.wav");
            this.soundBass.Play();

            this.soundBass.Stop();

            this.soundBass.PlaybackStarted.Should().BeFalse();
            this.soundBass.Dispose();
        }

        [Fact]
        public void Sound_WhenPause_ThenPausePlayback()
        {
            this.soundBass.Init();
            this.soundBass.Load("demomusic.wav");

            this.soundBass.Play();

            this.soundBass.Pause();

            this.soundBass.PlaybackPaused.Should().BeTrue();
            this.soundBass.Dispose();
        }

        [Fact]
        public void Sound_WhenSeek_ThenSeekGivenPosition()
        {
            this.soundBass.Init();
            this.soundBass.Load("demomusic.wav");

            double expected = 3.0;
            
            this.soundBass.Play();
            this.soundBass.Seek(expected);

            this.soundBass.CurrentSongPosition.Should().BeGreaterOrEqualTo(expected);
            this.soundBass.Dispose();
        }
    }
}
