
namespace AdrenalineRush
{
    using System;
    using System.Globalization;

    using AdrenalineRush.Scenes;
    using AdrenalineRush.Sound;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class Demo : Game
    {
        private const int WorkingResolutionWidth = 1024;
        private const int WorkingResolutionHeight = 768;

        private const double DemoStartTimeInSeconds = 0;
        private readonly TimeSpan timeLineOffset = TimeSpan.FromMilliseconds(DemoStartTimeInSeconds * 1000);

        private readonly ISound sound;
        private GraphicsDeviceManager graphics;
        
        private int frameRate;
        private int frameCounter;

        private TimeSpan elapsedTime = TimeSpan.Zero;
        private TimeSpan timeLine = TimeSpan.Zero;

        private SceneIntroduction sceneIntroduction;
        private SceneTunnel sceneTunnel;
        private SceneCube sceneCube;

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

            // Initialize and add scenes to GameComponentCollection
            this.sceneIntroduction = new SceneIntroduction(this) { Enabled = false, Visible = false };
            this.Components.Add(this.sceneIntroduction);

            this.sceneTunnel = new SceneTunnel(this) { Enabled = false, Visible = false };
            this.Components.Add(this.sceneTunnel);

            this.sceneCube = new SceneCube(this) { Enabled = false, Visible = false };
            this.Components.Add(this.sceneCube);

            Resolution.Init(ref this.graphics);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.sound.Load("music.wav");
            this.sound.Seek(DemoStartTimeInSeconds);
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
            var timeLineTemp = this.timeLine + this.timeLineOffset;

            this.Window.Title = "Time Line: " + ((int)timeLineTemp.TotalMilliseconds).ToString(CultureInfo.InvariantCulture) + " || FPS: " + this.frameRate.ToString(CultureInfo.InvariantCulture);
            base.Update(new GameTime(timeLineTemp, gameTime.ElapsedGameTime));
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            var time = this.timeLine + this.timeLineOffset;

            if (time.TotalMilliseconds > 0 && time.TotalMilliseconds <= 3000)
            {
                this.sceneIntroduction.Enabled = true;
                this.sceneIntroduction.Visible = true;
            }

            if (time.TotalMilliseconds > 3000 && time.TotalMilliseconds <= 10000)
            {
                this.sceneIntroduction.Enabled = false;
                this.sceneIntroduction.Visible = false;

                this.sceneTunnel.Enabled = true;
                this.sceneTunnel.Visible = true;
            }

            if (time.TotalMilliseconds > 10000 && time.TotalMilliseconds <= 30000)
            {
                this.sceneTunnel.Enabled = false;
                this.sceneTunnel.Visible = false;

                this.sceneCube.Enabled = true;
                this.sceneCube.Visible = true;
            }

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
