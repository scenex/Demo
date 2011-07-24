
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
        private SpriteBatch spriteBatch;

        private Texture2D texture;

        private GraphicsDeviceManager graphics;

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
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }



        public void RunDemoEffect(TimeSpan gameTime, int startTime, int endTime)
        {
            if (((int)gameTime.TotalMilliseconds > startTime) && ((int)gameTime.TotalMilliseconds < endTime))
            {
                this.Enabled = true;
                this.Visible = true;
            }
            else
            {
                this.Enabled = false;
                this.Visible = false;
            }
        }
    }
}
