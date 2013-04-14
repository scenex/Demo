namespace Primitives3D
{
    using Microsoft.Xna.Framework;

    public interface IPhysicalProperties
    {
        Vector3 Position { get; set; }
        Vector3 Force { get; set; }
        float Mass { get; set; }

        Vector3 Velocity { get; set; }
        Vector3 Acceleration { get; set; }
    }
}
