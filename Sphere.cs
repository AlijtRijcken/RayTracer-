using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOGR2019Tmpl8
{
    class Sphere : IPrimitive
    {
        //position, radius, color
        public Vector2 postion;
        public float radius;
        public Vector3 color; 
        public Sphere(Vector2 _position, float _radius, Vector3 _color)
        {
            postion = _position;
            radius = _radius;
            color = _color; 
        }

        public bool Intersect(Ray ray)
        {
            Vector2 c = this.postion - ray.origin;
            if (c.LengthSquared <= this.radius * this.radius)
                return true; //Intersection with a primitive
            float t = Vector2.Dot(c, ray.direction);
            Vector2 q = c - t * ray.direction;
            float p2 = Vector2.Dot(q, q);
            if (p2 > this.radius * this.radius)
                return false; //No intersection
            t -= (float)Math.Sqrt(this.radius * this.radius - p2);
            if (t < ray.t && t > 0)
                return true; //Intersection with a primitive

            return false; 

        }


    }
}
