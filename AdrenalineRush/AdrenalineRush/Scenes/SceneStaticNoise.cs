using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace AdrenalineRush.DemoEffects
{
    public class SceneStaticNoise
    {
        GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect effect;
        List<Texture2D> tvNoiseFrames;
        int width;
        int height;
        int alpha = 0;
        float size;

        int currentFrameIndex = 0;

        public SceneStaticNoise(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Texture2D texture, Effect effect, int width, int height)
        {
            this.graphicsDevice = graphicsDevice;
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.effect = effect;

            //this.renderTarget = new RenderTarget2D(this.graphicsDevice, width, height);
            this.width = width;
            this.height = height;

            tvNoiseFrames = new List<Texture2D>();
        }

        //public void PrecalcTVStaticNoise()
        //{
        //    for (int x = 0; x < 4; x++) // 8*2 Frames
        //    {
        //        this.renderTarget = new RenderTarget2D(this.graphicsDevice, width, height);
        //        this.graphicsDevice.SetRenderTarget(renderTarget);

        //        spriteBatch.Begin();
        //        for (int i = 0; i < height; i++)
        //        {
        //            for (int j = 0; j < width; j++)
        //            {
        //                spriteBatch.Draw(texture, new Vector2(j, i), ColorHelper.GetRandomColor());
        //            }
        //        }
        //        spriteBatch.End();

        //        this.graphicsDevice.SetRenderTarget(null);
        //        tvNoiseFrames.Add(renderTarget);
        //        tvNoiseFrames.Add(renderTarget);
        //    }

            
        //}


        public Texture2D GetNextTVNoiseFrame()
        {
            if (currentFrameIndex >= tvNoiseFrames.Count)
            {
                currentFrameIndex = 0;
            }

            Texture2D tempTexture = tvNoiseFrames[currentFrameIndex];
            currentFrameIndex++;
            return tempTexture;
        }

        public void RunDemoEffect(GameTime gameTime, int startTime, int endTime)
        {
            //if (((int)gameTime.TotalGameTime.TotalMilliseconds > startTime) && ((int)gameTime.TotalGameTime.TotalMilliseconds < endTime))
            //{
            //    spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, Resolution.getTransformationMatrix());
            //    spriteBatch.Draw(GetNextTVNoiseFrame(), Vector2.Zero, Color.FromNonPremultiplied(255,255,255,alpha));
            //    spriteBatch.End();
            //}

            //alpha++;

            //if (alpha == 255)
            //{
            //    alpha = 0;
            //}   

            //size = (float)gameTime.TotalGameTime.TotalMilliseconds;

            if (((int)gameTime.TotalGameTime.TotalMilliseconds > startTime) && ((int)gameTime.TotalGameTime.TotalMilliseconds < endTime))
            {
                
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, effect, Resolution.getTransformationMatrix());
                //effect.Parameters["size"].SetValue(size);
                //effect.CurrentTechnique.Passes[0].Apply();
                spriteBatch.Draw(texture, Vector2.Zero, Color.White);

                spriteBatch.End();
            }

        }


    }
}
