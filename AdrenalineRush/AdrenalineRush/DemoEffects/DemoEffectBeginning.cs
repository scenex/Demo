
namespace AdrenalineRush.DemoEffects
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class DemoEffectBeginning : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        private SpriteFont spriteFont;

        public DemoEffectBeginning(Game game) : base(game)
        {
            // TODO: Construct any child components here
        }

        public override void Initialize()
        {
            base.Initialize();
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            spriteFont = Game.Content.Load<SpriteFont>(@"SpriteFonts\Font");
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
            spriteBatch.DrawString(spriteFont, "Demo Intro Screen (title, heartbeats, white noise)", new Vector2(100, 50), Color.White);
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
