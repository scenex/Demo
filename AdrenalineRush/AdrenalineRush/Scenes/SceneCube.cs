
namespace AdrenalineRush.Scenes
{
    using System;
    using System.Collections.Generic;
    using AdrenalineRush.GeometricPrimitives;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SceneCube : DrawableGameComponent
    {
        // Store a list of tint colors, plus which one is currently selected.
        private readonly List<Color> colors = new List<Color>
        {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.White,
            Color.Black,
        };

        // store a wireframe rasterize state
        private readonly RasterizerState wireFrameState = new RasterizerState()
        {
            FillMode = FillMode.WireFrame,
            CullMode = CullMode.None,
        };

        // Store a list of primitive models, plus which one is currently selected.
        private readonly List<GeometricPrimitive> primitives = new List<GeometricPrimitive>();
        private readonly Game game;

        // private const int CurrentPrimitiveIndex = 0;
        private const int CurrentColorIndex = 2;
        private const bool Wireframe = false;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private RenderTarget2D renderTarget;
        private Texture2D texturePrimitive;

        private Effect postProcessShader;
        private Effect regularShader;

        private float timeline;
        private Vector3 cameraPosition;
        private float aspectRatio;

        /// <summary>
        /// Initializes a new instance of the <see cref="SceneCube"/> class. 
        /// </summary>
        /// <param name="game">
        /// The game instance.
        /// </param>
        public SceneCube(Game game) : base(game)
        {
            this.game = game;     
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {          
            base.Initialize();
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.GraphicsDevice.RasterizerState = Wireframe ? this.wireFrameState : RasterizerState.CullCounterClockwise;
            cameraPosition = new Vector3(0, 0, 5f);
            this.aspectRatio = GraphicsDevice.Viewport.AspectRatio;
        }

        protected override void LoadContent()
        {            
            this.renderTarget = new RenderTarget2D(GraphicsDevice, 1024, 768);

            this.regularShader = game.Content.Load<Effect>(@"Shaders\VS_PS_Ambient_Diffuse_Specular");
            this.postProcessShader = game.Content.Load<Effect>(@"Shaders\PS_Trigonometry_Blur");

            this.primitives.Add(new CubePrimitive(GraphicsDevice));
            this.primitives.Add(new CubePrimitive(GraphicsDevice));
            this.primitives.Add(new CubePrimitive(GraphicsDevice));

            base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            this.timeline = (float)gameTime.TotalGameTime.TotalSeconds;
            base.Update(gameTime);
        }

        /// <summary>
        /// Called when the DrawableGameComponent needs to be drawn. Override this method with component-specific drawing code. Reference page contains links to related conceptual articles.
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Draw.</param>
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            var yaw = this.timeline * 0.4f;
            var pitch = this.timeline * 0.7f;
            var roll = this.timeline * 1.1f;

            var world = Matrix.CreateFromYawPitchRoll(yaw, pitch, roll);

            var view = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            var projection = Matrix.CreatePerspectiveFieldOfView(1, this.aspectRatio, 1, 10);

            this.regularShader.Parameters["matWorldViewProj"].SetValue(world * view * projection);
            this.regularShader.Parameters["matWorld"].SetValue(world);

            this.regularShader.Parameters["vLightDirection"].SetValue(Vector4.One);
            this.regularShader.Parameters["vecEye"].SetValue(new Vector4(cameraPosition.X, cameraPosition.Y, cameraPosition.Z, 0));
            
            this.regularShader.Parameters["vAmbient"].SetValue(new Vector4(0.2f, 0.2f, 0f, 0.2f));
            this.regularShader.Parameters["vDiffuseColor"].SetValue(new Vector4(0.7f, 0.7f, 0.7f, 1.0f));
            this.regularShader.Parameters["vSpecularColor"].SetValue(new Vector4(1.0f, 1.0f, 1.0f, 1.0f));

            var firstCube = primitives[0];
            firstCube.Draw(this.regularShader);

            world = Matrix.CreateFromYawPitchRoll(yaw, pitch, roll) * Matrix.CreateTranslation(1.8f, 0, 0);
            this.regularShader.Parameters["matWorldViewProj"].SetValue(world * view * projection);
            this.regularShader.Parameters["matWorld"].SetValue(world);

            var secondCube = primitives[1];
            secondCube.Draw(this.regularShader);

            world = Matrix.CreateFromYawPitchRoll(yaw, pitch, roll) * Matrix.CreateTranslation(-1.8f, 0, 0);
            this.regularShader.Parameters["matWorldViewProj"].SetValue(world * view * projection);
            this.regularShader.Parameters["matWorld"].SetValue(world);

            var thirdCube = primitives[1];
            thirdCube.Draw(this.regularShader);

            //size += 0.1f;
            //GraphicsDevice.SetRenderTarget(renderTarget);
            //GraphicsDevice.SetRenderTarget(null);
            //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, _postProcessEffect, Resolution.getTransformationMatrix());           
            //_postProcessEffect.CurrentTechnique.Passes[0].Apply();
            //_postProcessEffect.Parameters["size"].SetValue(size);
            //spriteBatch.Draw(renderTarget, Vector2.Zero, Color.White);
            //spriteBatch.End();

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
