public class Vector {
    double X;
    double Y;
    public Vector(double x, double y) {
        this.X = x;
        this.Y = y;
    }
    public Vector(Vector v, double s) : this(v.X * s, v.Y * s) { }
}

var v = new Vector(100, 100);