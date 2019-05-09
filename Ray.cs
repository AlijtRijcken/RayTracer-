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

    }
}
