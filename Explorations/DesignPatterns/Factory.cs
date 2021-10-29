using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/////////////////////////////////PROBLEM FACTORY SOLVES//////////////////////////////
public interface IPoint
{
    void toString();
}
public interface IDraw
{
    void draw();
}
public class Point 
{
    protected double x;
    protected double y;
}
public class CartesianPoint : Point, IPoint, IDraw
{
    public CartesianPoint(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public void draw()
    {
    }

    public void toString()
    {
    }
}
public class PolarPoint : Point, IPoint, IDraw
{
    public PolarPoint(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void draw()
    {
    }
    public void toString()
    {
    }
}
public enum CoordinanteSystem
{
    Cartesian,
    Polar
}

public class Plotter
{
    public void drawGraph(CoordinanteSystem coordinanteSystem, IPointFactory pointFactory)
    {
        var pf = new PointFactoryV2();
        var point = pf.getPoint(coordinanteSystem);
    }

    public List<Point> getGraphPoints()
    {
        // loop get all the points
        return new List<Point>();
    }
}
////////////////////////////////PROBLEM FACTORY SOLVES END///////////////////////////

public class PointFactory
{
    public static IPoint newCartesianPoint(double x, double y)
    {
        return new CartesianPoint(x, y);
    }
    public static IPoint newPolarPoint(float x, float y)
    {
        return new PolarPoint(x, y);
    }

    public static IPoint GetPoint(CoordinanteSystem coordinanteSystem)
    {
        IPoint point;
        switch (coordinanteSystem)
        {
            case CoordinanteSystem.Polar:
                point = newPolarPoint(1, 1);
                break;
            case CoordinanteSystem.Cartesian:
                point = newCartesianPoint(1, 1);
                break;
            default:
                throw new ArgumentNullException();
        }
        return point;
    }
    
}
public interface IPointFactory
{
    IPoint getPoint(CoordinanteSystem coordinanteSystem);
}
public class PointFactoryV2 : IPointFactory
{
    
    public IPoint getPoint(CoordinanteSystem coordinanteSystem)
    {
        IPoint point;
        switch (coordinanteSystem)
        {
            case CoordinanteSystem.Polar:
                point = new PolarPoint(1, 1);
                break;
            case CoordinanteSystem.Cartesian:
                point = new CartesianPoint(1, 1);
                break;
            default:
                throw new ArgumentNullException();
        }
        return point;
    }
}

