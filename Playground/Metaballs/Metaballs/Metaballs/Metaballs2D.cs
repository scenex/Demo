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
    using System.Diagnostics;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Metaballs2D : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        uint[] data;

        private bool runOnce = false;

        private double threshold_max = 1.02f;

        private double threshold_min = 0.98f;

        private Metaball[] metaballs;

        private Texture2D texture;

        public Metaballs2D()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";           
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.texture = new Texture2D(graphics.GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, false, SurfaceFormat.Color);
            this.data = new uint[graphics.PreferredBackBufferWidth * graphics.PreferredBackBufferHeight];

            metaballs = new Metaball[3];
            metaballs[0] = new Metaball { CenterX = 400, CenterY = 240, Radius = 40 };
            metaballs[1] = new Metaball { CenterX = 300, CenterY = 150, Radius = 30 };
            metaballs[2] = new Metaball { CenterX = 350, CenterY = 375, Radius = 20 };
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            metaballs[1].CenterX++;

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (this.runOnce != true)
            {
                for (uint i = 0; i < graphics.PreferredBackBufferHeight; i++)
                {
                    for (uint j = 0; j < graphics.PreferredBackBufferWidth; j++)
                    {
                        var sum = this.metaballs.Sum(metaball => this.Calculate(j, i, metaball.CenterX, metaball.CenterY, metaball.Radius));

                        if (sum >= threshold_min && sum <= threshold_max)
                        {
                            data[i * graphics.PreferredBackBufferWidth + j] = 100;
                        }
                    }
                }
            }

            this.runOnce = true;

            GraphicsDevice.Textures[0] = null;
            this.texture.SetData(this.data);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.texture, new Vector2(0f, 0f), Color.White);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        public double Calculate(double x, double y, double x0, double y0, double radius)
        {
            return radius / Math.Sqrt(((x - x0) * (x - x0)) + ((y - y0) * (y - y0)));
        }
    }
}
