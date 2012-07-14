
namespace AdrenalineRush
{
    using System;
    using AdrenalineRush.Scenes;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Manages the scenes with its transitions.
    /// </summary>
    public class SceneManager : DrawableGameComponent
    {
        private readonly TimeSpan timeLineOffset;

        private SceneIntroduction sceneIntroduction;
        private SceneTunnel sceneTunnel;
        private SceneCube sceneCube;

        public SceneManager(Game game, TimeSpan timeLineOffset) : base(game)
        {
            this.timeLineOffset = timeLineOffset;
        }

        public override void Initialize()
        {
            // Initialize and add scenes to GameComponentCollection
            this.sceneIntroduction = new SceneIntroduction(Game) { Enabled = false, Visible = false };
            this.Game.Components.Add(this.sceneIntroduction);

            this.sceneTunnel = new SceneTunnel(Game) { Enabled = false, Visible = false };
            this.Game.Components.Add(this.sceneTunnel);

            this.sceneCube = new SceneCube(Game) { Enabled = false, Visible = false };
            this.Game.Components.Add(this.sceneCube);

            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            var time = gameTime.TotalGameTime.TotalMilliseconds + this.timeLineOffset.TotalMilliseconds;

            if (time > 0 && time <= 3000)
            {
                this.sceneIntroduction.Enabled = true;
                this.sceneIntroduction.Visible = true;
            }

            if (time > 3000 && time <= 10000)
            {
                this.sceneIntroduction.Enabled = false;
                this.sceneIntroduction.Visible = false;

                this.sceneTunnel.Enabled = true;
                this.sceneTunnel.Visible = true;
            }

            if (time > 10000 && time <= 30000)
            {
                this.sceneTunnel.Enabled = false;
                this.sceneTunnel.Visible = false;

                this.sceneCube.Enabled = true;
                this.sceneCube.Visible = true;
            }

            base.Draw(gameTime);
        }
    }
}
