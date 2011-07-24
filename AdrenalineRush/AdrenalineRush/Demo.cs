
namespace AdrenalineRush
{
    using System;
    using AdrenalineRush.DemoEffects;
    using AdrenalineRush.Sound;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    using Nuclex.Input;
    using Nuclex.UserInterface;

    public class Demo : Microsoft.Xna.Framework.Game
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

        private DemoEffectIntroduction demoEffectIntroduction;
        private DemoEffectTunnel demoEffectTunnel;

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
         
            this.demoEffectIntroduction = new DemoEffectIntroduction(this);
            demoEffectTunnel = new DemoEffectTunnel(this);

            this.Components.Add(this.demoEffectIntroduction);
            this.Components.Add(demoEffectTunnel);

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
            HandleInput();

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

            // FPS
            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }

            base.Update(new GameTime(timeLine, elapsedTime));
        }

        protected override void Draw(GameTime gameTime)
        {
            guiManager.Draw(gameTime);

            frameCounter++;
            this.Window.Title = "Time Line: " + ((int)timeLine.TotalMilliseconds).ToString() + " || FPS: " + frameRate.ToString();

            GraphicsDevice.Clear(Color.Black);

            this.demoEffectIntroduction.RunDemoEffect(timeLine, 0, 5000);
            this.demoEffectTunnel.RunDemoEffect(timeLine, 5001, 63000);

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
    }
}
