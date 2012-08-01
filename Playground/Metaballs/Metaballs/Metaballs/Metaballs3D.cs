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
    using System.Threading;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Metaballs3D : Microsoft.Xna.Framework.Game
    {
        private bool runOnce;

        private double threshold_max = 1.02f;
        private double threshold_min = 0.98f;

        private Metaball[] metaballs;

        private MarchingCubeAlgorithm marchingCubeAlgorithm;

        private GridCell[] gridCells = new GridCell[10*10*10];

        private uint[] pointCloud;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        VertexBuffer vertexBuffer;

        BasicEffect basicEffect;
        Matrix world = Matrix.CreateTranslation(0, 0, 0);
        Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 40), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, 200f);

        public Metaballs3D()
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
            basicEffect = new BasicEffect(GraphicsDevice);

            this.pointCloud = new uint[100*100*100];

            metaballs = new Metaball[1];
            metaballs[0] = new Metaball { CenterX = 50, CenterY = 50, CenterZ = 50, Radius = 70 };
            //metaballs[1] = new Metaball { CenterX = 300, CenterY = 150, CenterZ = 100, Radius = 30 };
            //metaballs[2] = new Metaball { CenterX = 350, CenterY = 375, CenterZ = 100, Radius = 20 };

            marchingCubeAlgorithm = new MarchingCubeAlgorithm();

            //VertexPositionColor[] vertices = new VertexPositionColor[3];
            //vertices[0] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Red);
            //vertices[1] = new VertexPositionColor(new Vector3(+0.5f, 0, 0), Color.Green);
            //vertices[2] = new VertexPositionColor(new Vector3(-0.5f, 0, 0), Color.Blue);

            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 3, BufferUsage.WriteOnly);
            //vertexBuffer.SetData<VertexPositionColor>(vertices);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // metaballs[0].CenterZ += 1;
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (this.runOnce != true)
            {
                for (uint z = 0; z < 100; z++)
                {
                    for (uint y = 0; y < 100; y++)
                    {
                        for (uint x = 0; x < 100; x++)
                        {
                            var index = z * 100 * 100 + y * 100 + x;

                            var sum = this.metaballs.Sum(metaball => this.Calculate(x, y, z, metaball.CenterX, metaball.CenterY, metaball.CenterZ, metaball.Radius));

                            if (sum >= threshold_min && sum <= threshold_max)
                            {
                                this.pointCloud[index] = 1;
                            }
                        }
                    }
                }
            }

            var amountOfPointsCoveredByIsosurface = this.pointCloud.Count(point => point != 0);

            runOnce = true;


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            basicEffect.World = world;
            basicEffect.View = view;
            basicEffect.Projection = projection;
            basicEffect.VertexColorEnabled = true;

            GraphicsDevice.SetVertexBuffer(vertexBuffer);

            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = rasterizerState;

            Triangle[] triangles;
            

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply(); 

                for (int z = 0; z < 10; z++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                            var index = z * 10 * 10 + y * 10 + x;
                            var p = 10;

                            gridCells[index] = new GridCell();

                            gridCells[index].point[0] = new Vector3(0, 0, 0);
                            gridCells[index].point[1] = new Vector3(10, 0, 0);
                            gridCells[index].point[2] = new Vector3(10, 0, 10);
                            gridCells[index].point[3] = new Vector3(0, 0, 10);
                            gridCells[index].point[4] = new Vector3(0, 10, 0);
                            gridCells[index].point[5] = new Vector3(10, 10, 0);
                            gridCells[index].point[6] = new Vector3(10, 10, 10);
                            gridCells[index].point[7] = new Vector3(0, 10, 10);

                            gridCells[index].value[0] = pointCloud[x + y*100 + z*100*100];
                            gridCells[index].value[1] = pointCloud[x+p + y*100 + z*100*100];
                            gridCells[index].value[2] = pointCloud[x+p + y*100 + z*100*100*p];
                            gridCells[index].value[3] = pointCloud[x + y*100 + z*100*100*p];
                            gridCells[index].value[4] = pointCloud[x + y*100*p + z*100*100];
                            gridCells[index].value[5] = pointCloud[x+p + y*100*p + z*100*100];
                            gridCells[index].value[6] = pointCloud[x+p + y*100*p + z*100*100*p];
                            gridCells[index].value[7] = pointCloud[x + y*100*p + z*100*100*p];

                            var numberOfTriangles = this.marchingCubeAlgorithm.Polygonise(gridCells[index], 0.2, out triangles);

                            if (numberOfTriangles > 0)
                            {
                                for (int i = 0; i < numberOfTriangles; i++)
                                {
                                    var vertices = new VertexPositionColor[3];
                                    vertices[0] = new VertexPositionColor(triangles[i].p[0], Color.Red);
                                    vertices[1] = new VertexPositionColor(triangles[i].p[1], Color.Green);
                                    vertices[2] = new VertexPositionColor(triangles[i].p[2], Color.Blue);

                                    //vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 3, BufferUsage.WriteOnly);
                                    //vertexBuffer.SetData<VertexPositionColor>(vertices);
                                    
                                    GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 1);
                                    
                                }
                            }
                        }
                    }
                }
            }

            base.Draw(gameTime);
        }

        public double Calculate(uint x, uint y, uint z, uint x0, uint y0, uint z0, uint radius)
        {
            return radius / Math.Sqrt(((x - x0) * (x - x0)) + ((y - y0) * (y - y0)) + ((z - z0) * (z - z0)));
        }
    }
}