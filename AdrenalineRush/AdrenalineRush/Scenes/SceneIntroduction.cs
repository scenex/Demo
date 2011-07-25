
namespace AdrenalineRush.Scenes
{
    using System.Diagnostics;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SceneIntroduction : DrawableGameComponent
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Effect effect;
        private float fadeMultiplier;

        private double runningTime;

        public SceneIntroduction(Game game) : base(game)
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
            this.runningTime = gameTime.TotalGameTime.TotalMilliseconds;
            Debug.WriteLine(this.runningTime);

            fadeMultiplier = (float)runningTime * 0.0002f;
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
    }
}
