using GeometricObjects.Basic;
using GeometricObjects.Figures;

namespace GeometricObjects
{
    public interface ITraceable
    {
        BoundBox GetBounds();

        bool Intersects(Ray ray, out double t);

        Vector NormalAt(Vertex p);
    }
}
