
namespace AdrenalineRush
{
    using System;

    using AdrenalineRush.Scenes;
    using AdrenalineRush.Sound;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Demo : Game
    {
        private readonly ISound sound;

        private const int WorkingResolutionWidth = 1024;
        private const int WorkingResolutionHeight = 768;

        // Used to skip to next effect, music not in sync yet.
        private readonly TimeSpan timeLineOffset = TimeSpan.FromMilliseconds(10000);

        private GraphicsDeviceManager graphics;

        private int frameRate;
        private int frameCounter;

        private TimeSpan elapsedTime = TimeSpan.Zero;
        private TimeSpan timeLine = TimeSpan.Zero;

        private SceneIntroduction sceneIntroduction;
        private SceneTunnel sceneTunnel;
        private SceneCube sceneCube;

        private Effect sceneCubeFx;

        private KeyboardState lastKeyboardState;
        private KeyboardState currentKeyboardState;

        private bool isDemoPaused;

        public Demo()
        {
            graphics = new GraphicsDeviceManager(this);
            this.sound = new SoundBASS();
            
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            this.sound.Init();

            graphics.PreferMultiSampling = false;
            graphics.SynchronizeWithVerticalRetrace = false;
            graphics.PreferredBackBufferWidth = WorkingResolutionWidth;
            graphics.PreferredBackBufferHeight = WorkingResolutionHeight;
            graphics.ApplyChanges();

            this.sceneIntroduction = new SceneIntroduction(this) { Enabled = false, Visible = false };
            this.Components.Add(this.sceneIntroduction);

            this.sceneTunnel = new SceneTunnel(this) { Enabled = false, Visible = false };
            this.Components.Add(this.sceneTunnel);

            this.sceneCube = new SceneCube(this) { Enabled = false, Visible = false };
            this.Components.Add(this.sceneCube);

            Resolution.Init(ref graphics);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.sound.Load("music.wav");
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

            // elapsedTime += gameTime.ElapsedGameTime; // To FPS?

            if (isDemoPaused == false)
            {
                timeLine += gameTime.ElapsedGameTime;

                if (sound.PlaybackPaused)
                {
                    sound.Play();
                }
            }
            else
            {
                sound.Pause();
            }
            
            // Skip in timeline
            var timeLineTemp = timeLine + timeLineOffset;

            this.Window.Title = "Time Line: " + ((int)timeLineTemp.TotalMilliseconds).ToString() + " || FPS: " + frameRate.ToString();
            base.Update(new GameTime(timeLineTemp, gameTime.ElapsedGameTime));
            // base.Update(new GameTime(timeLine, elapsedTime));
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            var time = timeLine + timeLineOffset;


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
            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.Space) && !lastKeyboardState.IsKeyDown(Keys.Space))
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
            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }

            frameCounter++;
            elapsedTime += elapsedGameTime; // To FPS?
        }
    }
}
