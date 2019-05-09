using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOGR2019Tmpl8
{
    //Light class has a location (x,y) and a Vector3  which has the color values
    //POSSIBILITY: ADD BRIGHTNESS.
    public class Light
    {
        public Vector2 position; 
        public Vector3 color; 

        public Light(Vector2 _position, Vector3 _color)
        {

            position = _position; 
            color = _color; 

        }

    }
}
