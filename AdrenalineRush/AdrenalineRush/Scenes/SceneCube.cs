using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using AdrenalineRush.GeometricPrimitives;


namespace AdrenalineRush.DemoEffects
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SceneCube : Microsoft.Xna.Framework.DrawableGameComponent
    {
        GraphicsDeviceManager graphics;
        Game game;
        SpriteBatch spriteBatch;

        // Store a list of primitive models, plus which one is currently selected.
        List<GeometricPrimitive> primitives = new List<GeometricPrimitive>();

        int currentPrimitiveIndex = 0;

        // store a wireframe rasterize state
        RasterizerState wireFrameState;
        RenderTarget2D renderTarget;
        Texture2D texturePrimitive;
        Effect shader;

        // Store a list of tint colors, plus which one is currently selected.
        List<Color> colors = new List<Color>
        {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.White,
            Color.Black,
        };

        int currentColorIndex = 2;

        Effect _postProcessEffect;
        float size = 0;
        // Are we rendering in wireframe mode
        bool isWireframe = false;

        // TODO: REFACTOR LOAD SHADER LOCALLY FROM COMPONENT
        public SceneCube(Game game, Effect postProcessEffect) : base(game)
        {
            this.game = game;
            this._postProcessEffect = postProcessEffect;            
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {          
            base.Initialize();
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            primitives.Add(new CubePrimitive(GraphicsDevice));
            //primitives.Add(new SpherePrimitive(GraphicsDevice));
            //primitives.Add(new CylinderPrimitive(GraphicsDevice));
            //primitives.Add(new TorusPrimitive(GraphicsDevice));
            //primitives.Add(new TeapotPrimitive(GraphicsDevice));

            wireFrameState = new RasterizerState()
            {
                FillMode = FillMode.WireFrame,
                CullMode = CullMode.None,
            };
            renderTarget = new RenderTarget2D(GraphicsDevice, 1024, 768);
            
            //texturePrimitive = game.Content.Load<Texture2D>("StartupLogo");
            shader = game.Content.Load<Effect>("TestEffect");
            base.LoadContent();
        }



        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            size += 0.1f;

            //GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.Black);

            if (isWireframe)
            {
                GraphicsDevice.RasterizerState = wireFrameState;
            }
            else
            {
                GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            }

            // Create camera matrices, making the object spin.
            float time = (float)gameTime.TotalGameTime.TotalSeconds;

            float yaw = time * 0.4f;
            float pitch = time * 0.7f;
            float roll = time * 1.1f;

            Vector3 cameraPosition = new Vector3(0, 0, 2.5f);

            float aspect = GraphicsDevice.Viewport.AspectRatio;

            Matrix world = Matrix.CreateFromYawPitchRoll(yaw, pitch, roll);
            Matrix view = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            Matrix projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 1, 10);

            // Draw the current primitive.
            GeometricPrimitive currentPrimitive = primitives[currentPrimitiveIndex];
            Color color = colors[currentColorIndex];

            //currentPrimitive.Draw(world, view, projection, color, texturePrimitive);

            shader.Parameters["matWorldViewProj"].SetValue(world * view * projection);
            shader.Parameters["matWorld"].SetValue(world);
            shader.Parameters["vLightDirection"].SetValue(Vector4.Zero);
            shader.Parameters["vecEye"].SetValue(new Vector4(cameraPosition.X, cameraPosition.Y, cameraPosition.Z, 0));
            
            shader.Parameters["vAmbient"].SetValue(new Vector4(0.2f, 0.2f, 0f, 0.2f));
            shader.Parameters["vDiffuseColor"].SetValue(new Vector4(0.7f, 0.7f, 0.7f, 1.0f));
            shader.Parameters["vSpecularColor"].SetValue(new Vector4(1.0f, 1.0f, 1.0f, 1.0f));
            

            currentPrimitive.Draw(shader);
            GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;

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
