namespace GeometricObjects.Basic
{
    public class HitResult
    {
        public double t;
        public double? u;
        public double? v;

        public HitResult(double t)
        {
            this.t = t;
        }
        
        public HitResult(double t, double u, double v)
        {
            this.t = t;
            this.u = u;
            this.v = v;
        }
    }
}