using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Primitives3D
{
    using System;

    /// <summary>
    /// This sample shows how to draw 3D geometric primitives
    /// such as cubes, spheres, and cylinders.
    /// </summary>
    public class Primitives3DGame : Game
    {
        readonly List<GeometricPrimitive> primitives = new List<GeometricPrimitive>();

        private static readonly float Gravitation = 6.674f * (float)Math.Pow(10, -11);

        GraphicsDeviceManager graphics;

        public Primitives3DGame()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
        }

        /// <summary>
        /// Load your graphics content.
        /// </summary>
        protected override void LoadContent()
        {
            primitives.Add(new SpherePrimitive(GraphicsDevice, new Vector3(-0.6f, -0.3f, -0.1f), Vector3.Zero, 10000));
            primitives.Add(new SpherePrimitive(GraphicsDevice, new Vector3(+0.6f, 0.7f, 0.3f), Vector3.Zero, 10000));
        }

        /// <summary>
        /// Allows the game to run logic.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            //Vector3 force01 = ((-1) * Gravitation * primitives[0].Mass * primitives[1].Mass * Vector3.Normalize(primitives[1].Position - primitives[0].Position)) / Vector3.DistanceSquared(primitives[1].Position, primitives[0].Position);
            //primitives[1].Position += force01;

            //Vector3 force10 = ((-1) * Gravitation * primitives[1].Mass * primitives[0].Mass * Vector3.Normalize(primitives[0].Position - primitives[1].Position)) / Vector3.DistanceSquared(primitives[0].Position, primitives[1].Position);
            //primitives[0].Position += force10;

            //Vector3 force02 = ((-1) * Gravitation * primitives[0].Mass * primitives[2].Mass * Vector3.Normalize(primitives[2].Position - primitives[0].Position)) / Vector3.DistanceSquared(primitives[2].Position, primitives[0].Position);
            //primitives[2].Position += force02;

            //Vector3 force20 = ((-1) * Gravitation * primitives[2].Mass * primitives[0].Mass * Vector3.Normalize(primitives[0].Position - primitives[2].Position)) / Vector3.DistanceSquared(primitives[0].Position, primitives[2].Position);
            //primitives[0].Position += force20;

            //Vector3 force12 = ((-1) * Gravitation * primitives[1].Mass * primitives[2].Mass * Vector3.Normalize(primitives[2].Position - primitives[1].Position)) / Vector3.DistanceSquared(primitives[2].Position, primitives[1].Position);
            //primitives[2].Position += force12;

            //Vector3 force21 = ((-1) * Gravitation * primitives[2].Mass * primitives[1].Mass * Vector3.Normalize(primitives[1].Position - primitives[2].Position)) / Vector3.DistanceSquared(primitives[1].Position, primitives[2].Position);
            //primitives[1].Position += force21;

            //if (primitives[0].Position.X > 1.0f || primitives[1].Position.X > 1.0f || primitives[2].Position.X > 1.0f)
            //{
                
            //}

            var dir0 = primitives[0].Position - Vector3.Zero;
            var dir1 = primitives[1].Position - Vector3.Zero;

            dir0.Normalize();
            dir1.Normalize();

            dir0 = Vector3.Multiply(dir0, -0.001f);
            dir1 = Vector3.Multiply(dir1, -0.001f);

            primitives[0].Acceleration = dir0;
            primitives[1].Acceleration = dir1;

            primitives[0].Velocity += primitives[0].Acceleration;
            primitives[1].Velocity += primitives[1].Acceleration;

            // Limit velocity
            if (primitives[0].Velocity.Length() > 0.1f)
            {
                var vel = primitives[0].Velocity;
                vel.Normalize();
                primitives[0].Velocity = vel * 0.1f;
            }

            if (primitives[1].Velocity.Length() > 0.1f)
            {
                var vel = primitives[1].Velocity;
                vel.Normalize();
                primitives[1].Velocity = vel * 0.1f;
            }

            primitives[0].Position += primitives[0].Velocity;
            primitives[1].Position += primitives[1].Velocity;

            if (primitives[0].Position.X > 1)
            {
                primitives[0].Position = new Vector3(1.0f, primitives[0].Position.Y, primitives[0].Position.Z);
            }

            if (primitives[0].Position.Y > 1)
            {
                primitives[0].Position = new Vector3(primitives[0].Position.X, 1.0f, primitives[0].Position.Z);
            }

            if (primitives[0].Position.Z > 1)
            {
                primitives[0].Position = new Vector3(primitives[0].Position.X, primitives[0].Position.Y, 1.0f);
            }

            if (primitives[0].Position.X < -1)
            {
                primitives[0].Position = new Vector3(-1.0f, primitives[0].Position.Y, primitives[0].Position.Z);
            }

            if (primitives[0].Position.Y < -1)
            {
                primitives[0].Position = new Vector3(primitives[0].Position.X, -1.0f, primitives[0].Position.Z);
            }

            if (primitives[0].Position.Z < -1)
            {
                primitives[0].Position = new Vector3(primitives[0].Position.X, primitives[0].Position.Y, -1.0f);
            }

            // ---

            if (primitives[1].Position.X > 1)
            {
                primitives[1].Position = new Vector3(1.0f, primitives[1].Position.Y, primitives[1].Position.Z);
            }

            if (primitives[1].Position.Y > 1)
            {
                primitives[1].Position = new Vector3(primitives[1].Position.X, 1.0f, primitives[1].Position.Z);
            }

            if (primitives[1].Position.Z > 1)
            {
                primitives[1].Position = new Vector3(primitives[1].Position.X, primitives[1].Position.Y, 1.0f);
            }

            if (primitives[1].Position.X < -1)
            {
                primitives[1].Position = new Vector3(-1.0f, primitives[1].Position.Y, primitives[1].Position.Z);
            }

            if (primitives[1].Position.Y < -1)
            {
                primitives[1].Position = new Vector3(primitives[1].Position.X, -1.0f, primitives[1].Position.Z);
            }

            if (primitives[1].Position.Z < -1)
            {
                primitives[1].Position = new Vector3(primitives[1].Position.X, primitives[1].Position.Y, -1.0f);
            }

            // ---

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;

            //var cameraPosition = new Vector3(0, 0, 7.5f);
            //var cameraPosition = new Vector3(1.5f, 1, 0.0f);
            var cameraPosition = new Vector3(0,0,2.5f);

            float aspect = GraphicsDevice.Viewport.AspectRatio;

            Matrix world0 = Matrix.CreateTranslation(primitives[0].Position.X, primitives[0].Position.Y, primitives[0].Position.Z);
            Matrix world1 = Matrix.CreateTranslation(primitives[1].Position.X, primitives[1].Position.Y, primitives[1].Position.Z);
            Matrix view = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            Matrix projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 1, 10);

            // Draw the current primitive.
            GeometricPrimitive sphere0 = primitives[0];
            GeometricPrimitive sphere1 = primitives[1];

            sphere0.Draw(world0, view, projection, Color.Red);
            sphere1.Draw(world1, view, projection, Color.Green);

            // Reset the fill mode renderstate.
            GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;

            base.Draw(gameTime);
        }
    }


    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static class Program
    {
        static void Main()
        {
            using (var game = new Primitives3DGame())
            {
                game.Run();
            }
        }
    }
}
