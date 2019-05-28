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
        Vector2 end;
        
        public Line(Vector2 _start, Vector2 _end)
        {
            start = _start;
            end = _end; 

        }

        public bool Intersect(Ray ray)
        {
            Vector2 v1 = ray.origin - this.end;
            Vector2 v2 = this.end - this.start;
            Vector2 v3;

            if (Cross(v2, ray.direction) == 0)
                return false;   //Parallel, so no intersection

            if (Cross(v2, ray.direction) > 0)
                v3 = new Vector2(ray.direction.Y, -ray.direction.X);
            else
                v3 = new Vector2(-ray.direction.Y, ray.direction.X);

            float t1 = Math.Abs(Cross(v2, v1)) / Vector2.Dot(v2, v3);
            float t2 = Vector2.Dot(v1, v3) / Vector2.Dot(v2, v3);
            float distance = ray.t;

            if (t1 >= 0 && t2 >= 0 && t2 <= 1 && t1 < distance)
            {
                distance = 1;
                return true;    //Intesction found
            }
            else
                return false;   //No Intersection


        }

        float Cross(Vector2 V1, Vector2 V2)
        {
            return V2.X * V1.Y - V2.Y * V1.X; 
        }
    }
}
