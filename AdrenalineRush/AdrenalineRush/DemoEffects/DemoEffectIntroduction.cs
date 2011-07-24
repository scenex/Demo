
namespace AdrenalineRush.DemoEffects
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class DemoEffectIntroduction : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Effect effect;
        private float fadeMultiplier;
        private int demoEffectDuration;
        private float demoEffectAbsolutePosition;

        public DemoEffectIntroduction(Game game) : base(game)
        {
            graphics = (GraphicsDeviceManager)game.Services.GetService(typeof(IGraphicsDeviceManager));
        }

        public override void Initialize()
        {
            base.Initialize();
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            texture = Game.Content.Load<Texture2D>(@"Pictures\Resurrection");
            effect = Game.Content.Load<Effect>(@"Shaders\PS_Fade");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            fadeMultiplier = this.GetDemoEffectProgress();
            effect.Parameters["fadeMultiplier"].SetValue(fadeMultiplier);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(0, BlendState.Opaque, null, null, null, effect);
            spriteBatch.Draw(texture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);        
            spriteBatch.End();

            base.Draw(gameTime);
        }



        public void RunDemoEffect(TimeSpan timeLine, int startTime, int endTime)
        {
            if (((int)timeLine.TotalMilliseconds > startTime) && ((int)timeLine.TotalMilliseconds < endTime))
            {
                this.Enabled = true;
                this.Visible = true;

                this.DetermineCurrentAbsolutePosition(timeLine, startTime, endTime);
            }
            else
            {
                this.Enabled = false;
                this.Visible = false;
            }
        }

        private void DetermineCurrentAbsolutePosition(TimeSpan timeLine, int startTime, int endTime)
        {
            this.demoEffectDuration = endTime - startTime;
            this.demoEffectAbsolutePosition = (float)timeLine.TotalMilliseconds - startTime;
        }

        private float GetDemoEffectProgress()
        {
            return this.demoEffectAbsolutePosition / this.demoEffectDuration;
        }
    }
}
