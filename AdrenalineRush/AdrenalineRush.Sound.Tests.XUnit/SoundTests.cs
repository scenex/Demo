using AdrenalineRush.Sound;

using FluentAssertions;
using Moq;
using Xunit;

public class SoundTests
{
    ISound soundBass;

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
        this.soundBass.Init();

        this.soundBass.Load("music.wav");

        this.soundBass.FileLoaded.Should().BeTrue();
        this.soundBass.Dispose();

        //this.soundBassMock.Object.Init();
        //this.soundBassMock.Object.Load("music.wav");

        //this.soundBassMock.Object.FileLoaded.Should().BeTrue();
        //this.soundBassMock.Object.Dispose();
    }

    [Fact]
    public void Sound_WhenPlay_ThenPlaySoundFile()
    {
        this.soundBass.Init();
        this.soundBass.Load("music.wav");

        this.soundBass.Play();

        this.soundBass.PlaybackStarted.Should().BeTrue();
        this.soundBass.Dispose();
    }

    [Fact]
    public void Sound_WhenStop_ThenStopPlayback()
    {
        this.soundBass.Init();
        this.soundBass.Load("music.wav");
        this.soundBass.Play();

        this.soundBass.Stop();

        this.soundBass.PlaybackStarted.Should().BeFalse();
        this.soundBass.Dispose();
    }

    [Fact]
    public void Sound_WhenPause_ThenPausePlayback()
    {
        this.soundBass.Init();
        this.soundBass.Load("music.wav");

        this.soundBass.Play();

        this.soundBass.Pause();

        this.soundBass.PlaybackPaused.Should().BeTrue();
        this.soundBass.Dispose();
    }

    [Fact]
    public void Sound_WhenSeek_ThenSeekGivenPosition()
    {
        this.soundBass.Init();
        this.soundBass.Load("music.wav");

        double expected = 3.0;

        this.soundBass.Play();
        this.soundBass.Seek(expected);

        this.soundBass.CurrentSongPosition.Should().BeGreaterOrEqualTo(expected);
        this.soundBass.Dispose();
    }
}