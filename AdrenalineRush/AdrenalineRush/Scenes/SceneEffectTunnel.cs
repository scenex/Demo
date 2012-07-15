
namespace AdrenalineRush.Scenes
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class SceneTunnel : DrawableGameComponent, IScene
    {    
        private readonly Game game;
        private const int FramesPerFlash = 8;
        private const bool IsWireframe = false;

        private readonly GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;
        private float cameraAxisZ;

        private RasterizerState wireFrameState;       

        private RenderTarget2D renderTarget;
        private Model modelTunnel;

        private Effect shader_PS_Fade;
        private Effect shader_VS_PS_TextureAndColors;

        private Texture2D modelTexture;

        private SpriteFont spriteFont;

        private bool isDemoEffectStarting;
        private float fadeMultiplier;

        private int currentFrameOfFlash;
        private bool isFlashScreenPending;

        private float cameraSpeedMultiplier = 1;

        private KeyboardState previousKeyboardState;

        private bool isFirstUpdate = true;

        private double runningTime;

        private double offset;

        public SceneTunnel(Game game) : base(game)
        {
            this.game = game;
            graphics = (GraphicsDeviceManager)this.game.Services.GetService(typeof(IGraphicsDeviceManager));
            isDemoEffectStarting = true;

            this.Enabled = false;
            this.Visible = false;
        }
        
        public override void Initialize()
        {          
            base.Initialize();

            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.renderTarget = new RenderTarget2D(GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            
            wireFrameState = new RasterizerState()
            {
                FillMode = FillMode.WireFrame,
                CullMode = CullMode.None,
            };

            this.CompleteSceneDuration = 7000;
        }


        protected override void LoadContent()
        {
            this.modelTunnel = game.Content.Load<Model>(@"Models\Tunnel");
            modelTexture = game.Content.Load<Texture2D>(@"Pictures\MarbleGreen512x512");
            spriteFont = game.Content.Load<SpriteFont>(@"SpriteFonts\Font");
            shader_PS_Fade = game.Content.Load<Effect>(@"Shaders\PS_Fade");

            shader_VS_PS_TextureAndColors = game.Content.Load<Effect>(@"Shaders\VS_PS_TexturesAndColors");
                    
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (isFirstUpdate)
            {
                isFirstUpdate = false;
                offset = gameTime.TotalGameTime.TotalMilliseconds;
            }

            this.runningTime = gameTime.TotalGameTime.TotalMilliseconds - offset;
            this.cameraAxisZ = (float)runningTime / 50;
            this.cameraSpeedMultiplier += 0.0001f;

            // Todo: Make time dependent
            if (isDemoEffectStarting == true)
            {
                if (fadeMultiplier < 1.0f)
                {
                    fadeMultiplier += 0.001f;
                }
                else
                {
                    isDemoEffectStarting = false;
                }
            }

            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) && previousKeyboardState.IsKeyUp(Keys.Up))
            {
                isFlashScreenPending = true;
            }

            this.previousKeyboardState = keyboardState;
            this.ScreenFlash(isFlashScreenPending);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {         
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.White);

            this.GraphicsDevice.RasterizerState = IsWireframe ? this.wireFrameState : RasterizerState.CullCounterClockwise;

            var cameraPosition = new Vector3(0, 0, cameraAxisZ * cameraSpeedMultiplier);

            float aspect = GraphicsDevice.Viewport.AspectRatio;

            Matrix world = Matrix.CreateFromYawPitchRoll(0, 0, 0);
            Matrix view = Matrix.CreateLookAt(cameraPosition, new Vector3(0, 0, 5000), Vector3.Up);
            Matrix projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 1, 400);

            shader_VS_PS_TextureAndColors.Parameters["world"].SetValue(world);
            shader_VS_PS_TextureAndColors.Parameters["view"].SetValue(view);
            shader_VS_PS_TextureAndColors.Parameters["projection"].SetValue(projection);
            shader_VS_PS_TextureAndColors.Parameters["lightColor"].SetValue(Color.White.ToVector4());
            shader_VS_PS_TextureAndColors.Parameters["lightDirection"].SetValue(new Vector3(0, 1, 1));
            shader_VS_PS_TextureAndColors.Parameters["ambientColor"].SetValue(Color.White.ToVector4());
            shader_VS_PS_TextureAndColors.Parameters["modelTexture"].SetValue(modelTexture);


            foreach (ModelMesh mesh in this.modelTunnel.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    part.Effect = shader_VS_PS_TextureAndColors;
                }
            }

            foreach (ModelMesh mesh in this.modelTunnel.Meshes)
            {
                foreach (Effect effect in mesh.Effects)
                {
                    mesh.Draw();
                }
            }

            GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;

            GraphicsDevice.SetRenderTarget(null);


            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);

                shader_PS_Fade.Parameters["fadeMultiplier"].SetValue(fadeMultiplier);
                shader_PS_Fade.CurrentTechnique.Passes[0].Apply();
                spriteBatch.Draw(renderTarget, Vector2.Zero, Color.White);
                spriteBatch.DrawString(spriteFont, fadeMultiplier.ToString(), new Vector2(10, 10), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);           
        }

        private void ScreenFlash(bool pending)
        {
            if (pending)
            {
                if (currentFrameOfFlash < FramesPerFlash / 2)
                {
                    fadeMultiplier += 0.2f;
                    currentFrameOfFlash++;
                }
                else if ((currentFrameOfFlash >= FramesPerFlash / 2) && (currentFrameOfFlash != FramesPerFlash))
                {
                    fadeMultiplier -= 0.2f;
                    currentFrameOfFlash++;
                }
                else
                {
                    currentFrameOfFlash = 0;
                    isFlashScreenPending = false;
                }
            }
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
