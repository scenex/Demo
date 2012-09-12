using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Metaballs
{
    public class FrameRateCounter : DrawableGameComponent
    {
        ContentManager content;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        int frameRate = 0;
        int frameCounter = 0;
        TimeSpan elapsedTime = TimeSpan.Zero;


        public FrameRateCounter(Game game)
            : base(game)
        {
            this.content = new ContentManager(game.Services);
        }


        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.spriteFont = this.content.Load<SpriteFont>(@"Content\font");
        }


        protected override void UnloadContent()
        {
            this.content.Unload();
        }


        public override void Update(GameTime gameTime)
        {
            this.elapsedTime += gameTime.ElapsedGameTime;

            if (this.elapsedTime > TimeSpan.FromSeconds(1))
            {
                this.elapsedTime -= TimeSpan.FromSeconds(1);
                this.frameRate = this.frameCounter;
                this.frameCounter = 0;
            }
        }


        public override void Draw(GameTime gameTime)
        {
            this.frameCounter++;

            string fps = string.Format("fps: {0}", this.frameRate);

            this.spriteBatch.Begin();

            this.spriteBatch.DrawString(this.spriteFont, fps, new Vector2(33, 33), Color.Black);
            this.spriteBatch.DrawString(this.spriteFont, fps, new Vector2(32, 32), Color.White);

            this.spriteBatch.End();
        }
    }
}