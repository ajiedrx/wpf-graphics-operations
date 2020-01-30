using System.Windows.Shapes;

namespace TestWPF1
{
    public interface IMyPolygon
    {
        void setPolygon(object _polygon);

        Polygon getPolygon();

        MyPolygon createPolygon();

        MyStylusPointCollection getPolygonPoints();
        void setPolygonPoints(IMyStroke _stroke);
    }
}
