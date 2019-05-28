using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOGR2019Tmpl8
{
    public class Ray
    {
        public Vector2 origin; //ray origin
        public Vector2 direction;  //ray direction
        public float t; //distance

        public Ray(Vector2 o, Vector2 d)
        {
            origin = o;
            direction = d.Normalized();
            t = d.Length; 
        }

        public Vector2 Intersection(Ray ray)
        {
            //if (Vector2.Dot(direction, ray.direction) == 0)
                //throw new Exception("Rays are parallel, no intersection");

            float u = (this.origin.Y * ray.direction.X + ray.direction.Y * ray.origin.X - ray.origin.Y * ray.direction.X - ray.direction.Y * this.origin.X) 
                / (this.direction.X * ray.direction.Y - this.direction.Y * ray.direction.X);

            return new Vector2(origin.X + u * direction.X, origin.Y + u * direction.Y);
        }
    }

    
}
