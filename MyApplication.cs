using INFOGR2019Tmpl8;
using System.Collections.Generic;
using OpenTK; 

namespace Template
{
	class MyApplication
	{
		// member variables
		public Surface screen;

        //List that stores all the light sources. 
        public List<Light> LightList;
        Light light1, light2, light3; 


		// initialize
		public void Init()
		{
            //Initialize the list which contains te Lights and the lights them self
            LightList = new List<Light>();
            light1 = new Light(new Vector2(200, 200), new Vector3(255, 255, 0));
            light2 = new Light(new Vector2(300, 300), new Vector3(255, 0, 255));
            light3 = new Light(new Vector2(400, 400), new Vector3(0, 255, 255));

            //add all the lights to the list
            LightList.Add(light1);
            LightList.Add(light2);
            LightList.Add(light3);
		}

		// tick: renders one frame
		public void Tick()
		{
			screen.Clear( 0 );
			screen.Print( "hello world", 2, 2, 0xffffff );
			screen.Line( 2, 20, 160, 20, 0xff0000 );

            //Loopen over all pixels in the screen
            for (int y = 0; y < screen.height; y++)
            {
                for (int x = 0; x < screen.width; x++)
                {
                    var color = new Vector3();                          //Black to begin with
                    var screen_position = new Vector2(x, y);            //position on the screen 

                    //for each pixel loop over the light sources
                    foreach (Light light in LightList)
                    {
                        //shoot a ray from each pixel to each existing light source
                        var ray = new Ray(screen_position, light.position - screen_position);

                        bool occluded = false;
                        ////loop over all primitives that are in the world
                        //foreach (Primitive P in Lijst van Primitives)
                        //{
                        //    if(p.Intersect(ray))
                        //            occluded = true;

                        //}
                        //if(!occluded)
                                //color += light.color * lightAttenuation(ray.t) //distance to light.
                    }

                    //screen.Plot(x, y, ToRGB32(color))
                }

            }

            // lightAttenuation afzwakking van het licht. METHODE

        }
	}
}