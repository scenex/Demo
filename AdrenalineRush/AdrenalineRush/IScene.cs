
namespace AdrenalineRush
{
    /// <summary>
    /// Interface for scene transitions.
    /// </summary>
    public interface IScene
    {
        /// <summary>
        /// Gets the complete scene duration in milliseconds.
        /// </summary>
        int CompleteSceneDuration { get; }

        /// <summary>
        /// Gets the order of the scene beginning from the lowest
        /// </summary>
        int SceneOrder { get; }

        /// <summary>
        /// Gets the duration of the scene transition in the beginning.
        /// </summary>
        int SceneBeginTransitionDuration { get; }

        /// <summary>
        /// Gets the duration of the scene transition in the end.
        /// </summary>
        int SceneEndTransitionDuration { get; }
    }
}
