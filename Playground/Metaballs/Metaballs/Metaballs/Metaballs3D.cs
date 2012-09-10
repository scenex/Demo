﻿using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Metaballs
{
    using VertexLightingSample;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Metaballs3D : Game
    {
        private bool runOnce;

        private SampleGrid grid;

        //private double threshold_max = 1.02f;
        //private double threshold_min = 0.98f;
        
        private double threshold_min = 0.7f;
        private double threshold_max = 10.2f;
     

        private Metaball[] metaballs;

        private MarchingCubeAlgorithm marchingCubeAlgorithm;

        private GridCell[] gridCells = new GridCell[50*50*50];

        private double[] pointCloud;

        GraphicsDeviceManager graphics;

        VertexBuffer vertexBuffer;

        BasicEffect basicEffect;
        Matrix world = Matrix.CreateTranslation(0, 0, 0);
        Matrix view = Matrix.CreateLookAt(new Vector3(150,100,150), new Vector3(0,0,0), new Vector3(0, 1, 0));
        Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, 500f);

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
            //Set up the reference grid and sample camera
            grid = new SampleGrid { GridColor = Color.LimeGreen, GridScale = 10.0f, GridSize = 100 };
            grid.LoadGraphicsContent(graphics.GraphicsDevice);

            // Create a new SpriteBatch, which can be used to draw textures.
            basicEffect = new BasicEffect(GraphicsDevice);

            metaballs = new Metaball[2];
            metaballs[0] = new Metaball { CenterX = 40, CenterY = 50, CenterZ = 50, Radius = 30 };
            metaballs[1] = new Metaball { CenterX = 130, CenterY = 60, CenterZ = 70, Radius = 20 };
            //metaballs[2] = new Metaball { CenterX = 350, CenterY = 375, CenterZ = 100, Radius = 20 };

            marchingCubeAlgorithm = new MarchingCubeAlgorithm();

            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 3, BufferUsage.WriteOnly);
            //vertexBuffer.SetData<VertexPositionColor>(vertices);

            //grid requires a projection matrix to draw correctly
            grid.ProjectionMatrix = projection;

            //Set the grid to draw on the x/z plane around the origin
            grid.WorldMatrix = Matrix.Identity;
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
            //metaballs[0].CenterZ += 1;
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            grid.ViewMatrix = view;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            //grid.Draw();
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

                for (int z = 0; z < 50; z++)
                {
                    for (int y = 0; y < 50; y++)
                    {
                        for (int x = 0; x < 50; x++)
                        {
                            var index = z * 50 * 50 + y * 50 + x;
                            
                            // Grid edge length 
                            var g = 5;

                            gridCells[index] = new GridCell();

                            gridCells[index].point[0] = new Vector3(x*g    , y*g    , z*g);
                            gridCells[index].point[1] = new Vector3(x*g + g, y*g    , z*g);
                            gridCells[index].point[2] = new Vector3(x*g + g, y*g    , z*g + g);
                            gridCells[index].point[3] = new Vector3(x*g    , y*g    , z*g + g);
                            gridCells[index].point[4] = new Vector3(x*g    , y*g + g, z*g);
                            gridCells[index].point[5] = new Vector3(x*g + g, y*g + g, z*g);
                            gridCells[index].point[6] = new Vector3(x*g + g, y*g + g, z*g + g);
                            gridCells[index].point[7] = new Vector3(x*g    , y*g + g, z*g + g);                           

                            gridCells[index].value[0] = this.ComputeMetaballs(
                                gridCells[index].point[0].X,
                                gridCells[index].point[0].Y,
                                gridCells[index].point[0].Z);

                            gridCells[index].value[1] = this.ComputeMetaballs(
                                gridCells[index].point[1].X,
                                gridCells[index].point[1].Y,
                                gridCells[index].point[1].Z);

                            gridCells[index].value[2] = this.ComputeMetaballs(
                                gridCells[index].point[2].X,
                                gridCells[index].point[2].Y,
                                gridCells[index].point[2].Z);

                            gridCells[index].value[3] = this.ComputeMetaballs(
                                gridCells[index].point[3].X,
                                gridCells[index].point[3].Y,
                                gridCells[index].point[3].Z);

                            gridCells[index].value[4] = this.ComputeMetaballs(
                                gridCells[index].point[4].X,
                                gridCells[index].point[4].Y,
                                gridCells[index].point[4].Z);

                            gridCells[index].value[5] = this.ComputeMetaballs(
                                gridCells[index].point[5].X,
                                gridCells[index].point[5].Y,
                                gridCells[index].point[5].Z);

                            gridCells[index].value[6] = this.ComputeMetaballs(
                                gridCells[index].point[6].X,
                                gridCells[index].point[6].Y,
                                gridCells[index].point[6].Z);

                            gridCells[index].value[7] = this.ComputeMetaballs(
                                gridCells[index].point[7].X,
                                gridCells[index].point[7].Y,
                                gridCells[index].point[7].Z);

                            var numberOfTriangles = this.marchingCubeAlgorithm.Polygonise(gridCells[index], 0.9, out triangles);

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

        public double Calculate(double x, double y, double z, double x0, double y0, double z0, double radius)
        {
            return radius / Math.Sqrt(((x - x0) * (x - x0)) + ((y - y0) * (y - y0)) + ((z - z0) * (z - z0)));
        }

        public double ComputeMetaballs(double x, double y, double z)
        {
            return this.metaballs.Sum(metaball => metaball.Radius / Math.Sqrt(((x - metaball.CenterX) * (x - metaball.CenterX)) + ((y - metaball.CenterY) * (y - metaball.CenterY)) + ((z - metaball.CenterZ) * (z - metaball.CenterZ))));
        }
    }
}