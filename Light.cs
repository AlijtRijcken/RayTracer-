using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOGR2019Tmpl8
{
    //Light class has a location (x,y) and a Vector3  which has the color values
    public class Light
    {
        public Vector2 position; 
        public Vector3 color;
        public float brightness; 

        public Light(Vector2 _position, Vector3 _color, float _brightness)
        {

            position = _position; 
            color = _color;
            brightness = _brightness; 

        }

    }
}
