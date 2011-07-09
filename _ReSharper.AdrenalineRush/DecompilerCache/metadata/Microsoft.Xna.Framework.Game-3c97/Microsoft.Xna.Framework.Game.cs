// Type: Microsoft.Xna.Framework.Game
// Assembly: Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553
// Assembly location: C:\Program Files\Microsoft XNA\XNA Game Studio\v4.0\References\Windows\x86\Microsoft.Xna.Framework.Game.dll

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Microsoft.Xna.Framework
{
    public class Game : IDisposable
    {
        #region Constructors and Destructors

        ~Game();

        #endregion

        #region Events

        public event EventHandler<EventArgs> Activated;

        public event EventHandler<EventArgs> Deactivated;

        public event EventHandler<EventArgs> Disposed;

        public event EventHandler<EventArgs> Exiting;

        #endregion

        #region Properties

        public GameComponentCollection Components { get; }

        public ContentManager Content { get; set; }

        public GraphicsDevice GraphicsDevice { get; }

        public TimeSpan InactiveSleepTime { get; set; }

        public bool IsActive { get; }

        public bool IsFixedTimeStep { get; set; }

        public bool IsMouseVisible { get; set; }

        public LaunchParameters LaunchParameters { get; }

        public GameServiceContainer Services { get; }

        public TimeSpan TargetElapsedTime { get; set; }

        public GameWindow Window { get; }

        #endregion

        #region Public Methods

        public void Exit();

        public void ResetElapsedTime();

        public void Run();

        public void RunOneFrame();

        public void SuppressDraw();

        public void Tick();

        #endregion

        #region Implemented Interfaces

        #region IDisposable

        public void Dispose();

        #endregion

        #endregion

        #region Methods

        protected virtual bool BeginDraw();

        protected virtual void BeginRun();

        protected virtual void Dispose(bool disposing);

        protected virtual void Draw(GameTime gameTime);

        protected virtual void EndDraw();

        protected virtual void EndRun();

        protected virtual void Initialize();

        protected virtual void LoadContent();

        protected virtual void OnActivated(object sender, EventArgs args);

        protected virtual void OnDeactivated(object sender, EventArgs args);

        protected virtual void OnExiting(object sender, EventArgs args);

        protected virtual bool ShowMissingRequirementMessage(Exception exception);

        protected virtual void UnloadContent();

        protected virtual void Update(GameTime gameTime);

        #endregion
    }
}
