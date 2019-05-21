using INFOGR2019Tmpl8;
using System.Collections.Generic;
using OpenTK;
using System;

namespace Template
{
	class MyApplication
	{
		//Member variables
		public Surface screen;

        //List that stores all the light sources. 
        public List<Light> LightList;
        Light light1, light2, light3, light4;

        //List that contains all the primitives
        public List<IPrimitive> PrimitiveList;
        Sphere sphere1; 


		// initialize
		public void Init()
		{
            //Initialize the list which contains the Lights and the lights them self
            LightList = new List<Light>();
            light1 = new Light(new Vector2(200, 200), new Vector3(255, 255, 0), 1);
            light2 = new Light(new Vector2(300, 300), new Vector3(255, 0, 255), 5);
            light3 = new Light(new Vector2(250, 250), new Vector3(0, 255, 255), 7);
            light4 = new Light(new Vector2(0, 0), new Vector3(200, 200, 200), 10); 

            //Create Primitives
            PrimitiveList = new List<IPrimitive>(); 
            sphere1 = new Sphere(new Vector2(100, 100), 20, new Vector3(160,160,160));

            //Add all the lights to the list
            LightList.Add(light1);
            LightList.Add(light2);
            LightList.Add(light3);
            LightList.Add(light4);

            //Add
            PrimitiveList.Add(sphere1); 
		}

		// tick: renders one frame
		public void Tick()
		{
			screen.Clear( 0 );

            //Loop over all pixels in the screen
            for (int y = 0; y < screen.height; y++)
            {
                for (int x = 0; x < screen.width; x++)
                {
                    var color = new Vector3();                          //Black to begin with
                    Vector2 screen_position = new Vector2(x, y);        //position on the screen 

                    //for each pixel loop over the light sources
                    foreach (Light light in LightList)
                    {
                        //shoot a ray from each pixel to each existing light source
                        var ray = new Ray(screen_position, light.position - screen_position);

                        bool occluded = false;
                        //loop over all primitives that are in the world
                        foreach (IPrimitive p in PrimitiveList)
                        {
                                if (p.Intersect(ray))
                                     occluded = true;

                        }
                        if (!occluded)
                            color += light.color * lightAttenuation(ray.t) * light.brightness; //distance to light.
                    }
                    screen.Plot(x,y, ToRGB32(color)); 
                }

            }

            //lightAttenuation: Light energy dissipates at a rate of 1/(distance^2)
            float lightAttenuation(float r)
            {
                return 1 / (r * r); 
            }

            //Converstion from Vector3 color to Integer colors.                                    
            int ToRGB32(Vector3 Color)
            {
                int color;
                int red = (int)(Math.Min(1.0f, Color.X) * 255.0f);
                int blue = (int)(Math.Min(1.0f, Color.Z) * 255.0f);
                int green = (int)(Math.Min(1.0f, Color.Y) * 255.0f);

                color = (blue << 0) | (green << 8) | (red << 16);
                return color;
            }

        }
	}
}