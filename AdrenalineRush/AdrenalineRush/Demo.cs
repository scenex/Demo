
namespace AdrenalineRush
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using AdrenalineRush.DemoEffects;
    using Sound;
    public class Demo : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int workingResolutionWidth = 1024;
        int workingResolutionHeight = 768;

        int frameRate = 0;
        int frameCounter = 0;

        TimeSpan elapsedTime = TimeSpan.Zero;
        TimeSpan timeLine = TimeSpan.Zero;

        ISound sound;

        DemoEffectBeginning demoEffectBeginning;
        DemoEffectTunnel demoEffectTunnel;

        private bool isDemoPaused;

        public Demo()
        {
            graphics = new GraphicsDeviceManager(this);
            this.sound = new SoundBASS();

            Content.RootDirectory = "Content";

            //Resolution.Init(ref graphics);
            //Resolution.SetVirtualResolution(workingResolutionWidth, workingResolutionHeight);
        }


        protected override void Initialize()
        {
            //graphics.PreferMultiSampling = DemoSettings.GetAntiAlias();
            //graphics.SynchronizeWithVerticalRetrace = DemoSettings.GetVSync();

            //Resolution.SetResolution(DemoSettings.GetDemoResolution().GetDemoWidth(),
            //                         DemoSettings.GetDemoResolution().GetDemoHeight(),
            //                         DemoSettings.GetFullscreen());

            //Resolution.SetResolution(1680, 1050, false);

            this.sound.Init();
            //this.sound.Load("music.wav");
            //this.sound.Play();

            graphics.PreferMultiSampling = false;
            graphics.SynchronizeWithVerticalRetrace = false;
            graphics.PreferredBackBufferWidth = workingResolutionWidth;
            graphics.PreferredBackBufferHeight = workingResolutionHeight;
            graphics.ApplyChanges();
          
            spriteBatch = new SpriteBatch(GraphicsDevice);

            demoEffectBeginning = new DemoEffectBeginning(this);
            demoEffectTunnel = new DemoEffectTunnel(this);

            this.Components.Add(demoEffectBeginning);
            this.Components.Add(demoEffectTunnel);

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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                this.isDemoPaused = this.isDemoPaused != true;
            }
                       
            elapsedTime += gameTime.ElapsedGameTime;

            if (isDemoPaused == false)
            {
                timeLine += gameTime.ElapsedGameTime;
            }
            

            // FPS
            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }

            GameTime temp = new GameTime(timeLine, elapsedTime);

            base.Update(temp);
        }

        protected override void Draw(GameTime gameTime)
        {
            frameCounter++;
            this.Window.Title = "Time Line: " + ((int)timeLine.TotalMilliseconds).ToString() + " || FPS: " + frameRate.ToString();

            GraphicsDevice.Clear(Color.Black);

            demoEffectBeginning.RunDemoEffect(timeLine, 0, 2500);
            demoEffectTunnel.RunDemoEffect(timeLine, 2501, 63000);

            base.Draw(gameTime);
        }
    }
}
