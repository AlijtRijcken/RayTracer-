using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOGR2019Tmpl8
{
    class Line : IPrimitive
    {
        Vector2 start;
        Vector2 direction;
        Vector2 end;
        Vector3 color; 
        
        public Line(Vector2 _start, Vector2 _end, Vector3 _color)
        {
            start = _start;
            end = _end;
            color = _color;
            direction = Vector2.Normalize(end - start);

        }

        public bool Intersect(Ray ray)
        { 
            if (Vector2.Dot(direction, ray.direction) == 1)
                return false;   //Parallel, so no intersection

            Vector2 intersection = ray.Intersection(ray);

            float m = (end.X - start.X) / (end.Y - start.Y);
            float c = intersection.Y - intersection.X * m; 

            if(pointIsOnLine(m,c, intersection.X, intersection.Y))
                return true;
            else
             return false;

        }

        //Given the values of m and c for the equation of a line y = (m * x) + c, the task is to find whether the point (x, y) lies on the given line
        bool pointIsOnLine(float m, float c, float x, float y)
        {
            // If (x, y) satisfies the equation of the line 
            if (y == ((m * x) + c))
                return true;

            return false;
        }
    }
}
