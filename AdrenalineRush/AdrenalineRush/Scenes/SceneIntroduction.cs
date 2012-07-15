
namespace AdrenalineRush.Scenes
{
    using System;
    using System.Diagnostics;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SceneIntroduction : DrawableGameComponent, IScene
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Effect effect;
        private float fadeMultiplier;
        private double stepTotal;

        public SceneIntroduction(Game game) : base(game)
        {
            this.graphics = (GraphicsDeviceManager)game.Services.GetService(typeof(IGraphicsDeviceManager));
        }

        public override void Initialize()
        {
            base.Initialize();
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.CompleteSceneDuration = 3000;
        }

        protected override void LoadContent()
        {
            this.texture = Game.Content.Load<Texture2D>(@"Pictures\Resurrection");
            this.effect = Game.Content.Load<Effect>(@"Shaders\PS_Fade");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            this.fadeMultiplier = this.VaryingFadeMultiplier(gameTime.ElapsedGameTime.TotalMilliseconds);
            this.effect.Parameters["fadeMultiplier"].SetValue(this.fadeMultiplier);
            Debug.WriteLine(gameTime.TotalGameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin(0, BlendState.Opaque, null, null, null, this.effect);
            this.spriteBatch.Draw(this.texture, new Rectangle(0, 0, this.graphics.PreferredBackBufferWidth, this.graphics.PreferredBackBufferHeight), Color.White);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        private float VaryingFadeMultiplier(double elapsedTime)
        {
            double step = elapsedTime / 1000;
            this.stepTotal += step;
            return (float)Math.Pow(Math.Sin(this.stepTotal), 2) * 0.9f;
        }

        /// <summary>
        /// Gets the complete scene duration in milliseconds.
        /// </summary>
        public int CompleteSceneDuration { get; private set; }

        /// <summary>
        /// Gets the order of the scene beginning from the lowest
        /// </summary>
        public int SceneOrder { get; private set; }

        /// <summary>
        /// Gets the duration of the scene transition in the beginning.
        /// </summary>
        public int SceneBeginTransitionDuration { get; private set; }

        /// <summary>
        /// Gets the duration of the scene transition in the end.
        /// </summary>
        public int SceneEndTransitionDuration { get; private set; }
    }
}
