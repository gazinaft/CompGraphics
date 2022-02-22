using GeometricObjects.Basic;

namespace GeometricObjects
{
    public interface ITraceable
    {
        bool Intersects(Ray ray, out double t);
    }
}
