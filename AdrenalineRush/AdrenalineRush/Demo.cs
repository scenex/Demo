
namespace AdrenalineRush
{
    using System;
    using AdrenalineRush.Scenes;
    using AdrenalineRush.Sound;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    using Nuclex.Input;
    using Nuclex.UserInterface;

    public class Demo : Game
    {
        private readonly ISound sound;
        private readonly GuiManager guiManager;
        private readonly InputManager inputManager;
        private readonly GraphicsDeviceManager graphics;

        private const int WorkingResolutionWidth = 1024;
        private const int WorkingResolutionHeight = 768;

        private int frameRate;
        private int frameCounter;

        private TimeSpan elapsedTime = TimeSpan.Zero;
        private TimeSpan timeLine = TimeSpan.Zero;

        private SceneIntroduction sceneIntroduction;
        private SceneTunnel sceneTunnel;

        private KeyboardState lastKeyboardState;
        private KeyboardState currentKeyboardState;

        private bool isDemoPaused;

        private Screen mainScreen;

        public Demo()
        {
            graphics = new GraphicsDeviceManager(this);
            this.sound = new SoundBASS();

            this.guiManager = new GuiManager(this.Services);
            this.inputManager = new InputManager(this.Services);
            
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

            this.Components.Add(this.guiManager);
            this.Components.Add(this.inputManager);
            
            this.IsMouseVisible = true;
            mainScreen = new Screen(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            mainScreen.Desktop.Children.Add(new DemoController());
            
            this.guiManager.Screen = mainScreen;
            this.guiManager.Visible = false;

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
            this.CalculateFps();

            elapsedTime += gameTime.ElapsedGameTime;

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
            
            this.Window.Title = "Time Line: " + ((int)timeLine.TotalMilliseconds).ToString() + " || FPS: " + frameRate.ToString();
            base.Update(new GameTime(timeLine, elapsedTime));
        }

        protected override void Draw(GameTime gameTime)
        {
            guiManager.Draw(gameTime);
            GraphicsDevice.Clear(Color.Black);

            var time = timeLine.TotalMilliseconds;


            if (time > 0 && time <= 5000)
            {
                this.sceneIntroduction.Enabled = true;
                this.sceneIntroduction.Visible = true;
            }

            if (time > 5000 && time <= 63000)
            {
                this.sceneIntroduction.Enabled = false;
                this.sceneIntroduction.Visible = false;

                this.sceneTunnel.Enabled = true;
                this.sceneTunnel.Visible = true;
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

        private void CalculateFps()
        {
            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }

            frameCounter++;
        }
    }
}
