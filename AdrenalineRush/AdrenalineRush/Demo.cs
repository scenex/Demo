
namespace AdrenalineRush
{
    using System;
    using System.Globalization;
    using AdrenalineRush.Sound;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class Demo : Game
    {
        private const int WorkingResolutionWidth = 1024;
        private const int WorkingResolutionHeight = 768;

        private const double StartTimeInSeconds = 10;
        private readonly TimeSpan timeLineOffsetInMilliseconds = TimeSpan.FromMilliseconds(StartTimeInSeconds * 1000);

        private readonly ISound sound;
        private readonly GraphicsDeviceManager graphics;
        private SceneManager sceneManager;
        
        private int frameRate;
        private int frameCounter;

        private TimeSpan elapsedTime = TimeSpan.Zero;
        private TimeSpan timeLine = TimeSpan.Zero;

        private KeyboardState lastKeyboardState;
        private KeyboardState currentKeyboardState;

        private bool isDemoPaused;

        public Demo()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.sound = new SoundBASS();
            
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.sound.Init();

            // Set up video adapter
            this.graphics.PreferMultiSampling = false;
            this.graphics.SynchronizeWithVerticalRetrace = false;
            this.graphics.PreferredBackBufferWidth = WorkingResolutionWidth;
            this.graphics.PreferredBackBufferHeight = WorkingResolutionHeight;
            this.graphics.ApplyChanges();

            this.sceneManager = new SceneManager(this, this.timeLineOffsetInMilliseconds);
            this.Components.Add(this.sceneManager);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.sound.Load("music.wav");
            this.sound.Seek(StartTimeInSeconds);
            this.sound.Play();

            base.LoadContent();
        }

        protected override void UnloadContent()
        {           
        }

        protected override void Update(GameTime gameTime)
        {
            this.HandleInput();
            this.CalculateFps(gameTime.ElapsedGameTime);

            if (this.isDemoPaused == false)
            {
                this.timeLine += gameTime.ElapsedGameTime;

                if (this.sound.PlaybackPaused)
                {
                    this.sound.Play();
                }
            }
            else
            {
                this.sound.Pause();
            }
            
            // Skip in timeline
            var timeLineTemp = this.timeLine + this.timeLineOffsetInMilliseconds;

            this.Window.Title = "Time Line: " + ((int)timeLineTemp.TotalMilliseconds).ToString(CultureInfo.InvariantCulture) + " || FPS: " + this.frameRate.ToString(CultureInfo.InvariantCulture);
            base.Update(new GameTime(timeLineTemp, gameTime.ElapsedGameTime));
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }

        private void HandleInput()
        {
            this.lastKeyboardState = this.currentKeyboardState;
            this.currentKeyboardState = Keyboard.GetState();

            if (this.currentKeyboardState.IsKeyDown(Keys.Space) && !this.lastKeyboardState.IsKeyDown(Keys.Space))
            {
                this.isDemoPaused = this.isDemoPaused != true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
        }

        private void CalculateFps(TimeSpan elapsedGameTime)
        {
            if (this.elapsedTime > TimeSpan.FromSeconds(1))
            {
                this.elapsedTime -= TimeSpan.FromSeconds(1);
                this.frameRate = this.frameCounter;
                this.frameCounter = 0;
            }

            this.frameCounter++;
            this.elapsedTime += elapsedGameTime; // To FPS?
        }
    }
}
