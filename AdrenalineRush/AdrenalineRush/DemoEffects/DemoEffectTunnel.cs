
namespace AdrenalineRush.DemoEffects
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class DemoEffectTunnel : Microsoft.Xna.Framework.DrawableGameComponent
    {
        GraphicsDeviceManager graphics;
        Game game;

        SpriteBatch spriteBatch;
        float cameraAxisZ = 0.0f;

        RasterizerState wireFrameState;
        bool isWireframe = false;

        RenderTarget2D renderTarget;
        Model model_Tunnel;

        Effect shader_PS_Fade;

        Effect shader_VS_PS_TextureAndColors;
        Texture2D modelTexture;

        SpriteFont spriteFont;

        bool isDemoEffectStarting;
        float fadeMultiplier = 0.0f;

        int framesPerFlash = 8;
        int currentFrameOfFlash = 0;
        bool isFlashScreenPending = false;

        float cameraSpeedMultiplier = 1;

        KeyboardState previousKeyboardState;

        private int demoEffectDuration;
        private float currentAbsolutePosition;

        public DemoEffectTunnel(Game game) : base(game)
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
        }


        protected override void LoadContent()
        {
            model_Tunnel = game.Content.Load<Model>(@"Models\Tunnel");
            modelTexture = game.Content.Load<Texture2D>(@"Pictures\MarbleGreen512x512");
            spriteFont = game.Content.Load<SpriteFont>(@"SpriteFonts\Font");
            shader_PS_Fade = game.Content.Load<Effect>(@"Shaders\PS_Fade");

            shader_VS_PS_TextureAndColors = game.Content.Load<Effect>(@"Shaders\VS_PS_TexturesAndColors");
                    
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            cameraAxisZ = (currentAbsolutePosition / demoEffectDuration) * 3629;

            cameraSpeedMultiplier += 0.0001f;

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


            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) && previousKeyboardState.IsKeyUp(Keys.Up))
            {
                isFlashScreenPending = true;
            }

            previousKeyboardState = keyboardState;          

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {         
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.White);

            if (isWireframe)
            {
                GraphicsDevice.RasterizerState = wireFrameState;
            }
            else
            {
                GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            }

            Vector3 cameraPosition = new Vector3(0, 0, cameraAxisZ * cameraSpeedMultiplier);

            float aspect = GraphicsDevice.Viewport.AspectRatio;

            Matrix world = Matrix.CreateFromYawPitchRoll(0, 0, 0);
            Matrix view = Matrix.CreateLookAt(cameraPosition, new Vector3(0, 0, 5000), Vector3.Up);
            Matrix projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 1, 400);


            //fadeInShader.Parameters["World"].SetValue(world);
            //fadeInShader.Parameters["View"].SetValue(view);
            //fadeInShader.Parameters["Projection"].SetValue(projection);

            //specularShader.Parameters["matWorldViewProj"].SetValue(world * view * projection);
            //specularShader.Parameters["matWorld"].SetValue(world);
            //specularShader.Parameters["vLightDirection"].SetValue(new Vector4(0, 0, 1, 0));
            //specularShader.Parameters["vecEye"].SetValue(new Vector4(cameraPosition.X, cameraPosition.Y, cameraPosition.Z, 0));

            //specularShader.Parameters["vAmbient"].SetValue(new Vector4(0.2f, 0.2f, 0.2f, 0.2f));
            //specularShader.Parameters["vDiffuseColor"].SetValue(new Vector4(0.7f, 0.7f, 0.7f, 1.0f));
            //specularShader.Parameters["vSpecularColor"].SetValue(new Vector4(1.0f, 1.0f, 1.0f, 1.0f));


            shader_VS_PS_TextureAndColors.Parameters["world"].SetValue(world);
            shader_VS_PS_TextureAndColors.Parameters["view"].SetValue(view);
            shader_VS_PS_TextureAndColors.Parameters["projection"].SetValue(projection);
            shader_VS_PS_TextureAndColors.Parameters["lightColor"].SetValue(Color.White.ToVector4());
            shader_VS_PS_TextureAndColors.Parameters["lightDirection"].SetValue(new Vector3(0, 1, 1));
            shader_VS_PS_TextureAndColors.Parameters["ambientColor"].SetValue(Color.White.ToVector4());
            shader_VS_PS_TextureAndColors.Parameters["modelTexture"].SetValue(modelTexture);


            foreach (ModelMesh mesh in model_Tunnel.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    part.Effect = shader_VS_PS_TextureAndColors;
                }
            }

            foreach (ModelMesh mesh in model_Tunnel.Meshes)
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

        public void RunDemoEffect(TimeSpan timeLine, int startTime, int endTime)
        {
            if (((int)timeLine.TotalMilliseconds > startTime) && ((int)timeLine.TotalMilliseconds < endTime))
            {
                this.Enabled = true;
                this.Visible = true;

                demoEffectDuration = endTime - startTime;
                currentAbsolutePosition = (float)timeLine.TotalMilliseconds - startTime;

                //Insert screen flashes here

                if (isFlashScreenPending)
                {
                    if (currentFrameOfFlash < framesPerFlash / 2)
                    {
                        //fadeMultiplier += 0.8f;
                        fadeMultiplier += 0.2f;
                        currentFrameOfFlash++;
                    }
                    else if ((currentFrameOfFlash >= framesPerFlash / 2) && (currentFrameOfFlash != framesPerFlash))
                    {
                        //fadeMultiplier -= 0.8f;
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
            else
            {
                this.Enabled = false;
                this.Visible = false;
            }
        }
    }
}
