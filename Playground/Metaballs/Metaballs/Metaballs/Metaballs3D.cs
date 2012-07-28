// -----------------------------------------------------------------------
// <copyright file="Metaballs3D.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Metaballs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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

    namespace Metaballs
    {
        public class Metaballs3D : Microsoft.Xna.Framework.Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
            GraphicsDevice device;

            Effect effect;
            VertexPositionColor[] vertices;

            public Metaballs3D()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }

            protected override void Initialize()
            {
                graphics.PreferredBackBufferWidth = 500;
                graphics.PreferredBackBufferHeight = 500;
                graphics.IsFullScreen = false;
                graphics.ApplyChanges();

                base.Initialize();
            }

            protected override void LoadContent()
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);

                device = graphics.GraphicsDevice;

                effect = Content.Load<Effect>("effects");

                SetUpVertices();
            }

            protected override void UnloadContent()
            {
            }

            private void SetUpVertices()
            {
                vertices = new VertexPositionColor[3];

                vertices[0].Position = new Vector3(-0.5f, -0.5f, 0f);
                vertices[0].Color = Color.Red;
                vertices[1].Position = new Vector3(0, 0.5f, 0f);
                vertices[1].Color = Color.Green;
                vertices[2].Position = new Vector3(0.5f, -0.5f, 0f);
                vertices[2].Color = Color.Yellow;
            }

            protected override void Update(GameTime gameTime)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();

                base.Update(gameTime);
            }

            protected override void Draw(GameTime gameTime)
            {
                device.Clear(Color.DarkSlateBlue);

                effect.CurrentTechnique = effect.Techniques["Pretransformed"];

                foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();

                    device.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 1, VertexPositionColor.VertexDeclaration);
                }

                base.Draw(gameTime);
            }
        }
    }
}
