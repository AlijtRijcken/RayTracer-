using INFOGR2019Tmpl8;
using System.Collections.Generic;
using OpenTK;
using System;
using System.Threading.Tasks;

namespace Template
{
	class MyApplication
	{
        //Member variables
        public Surface screen; 
        public float range = 1.0f;               //range and divison can be changed in the template.OnUpdateFrame() for zooming
        public float division = 2.0f; 

        //List that stores all the light sources. 
        public List<Light> LightList;
        Light light1, light2, light3, light4, light5;

        //List that contains all the primitives
        public List<IPrimitive> PrimitiveList;
        Sphere sphere1, sphere2, sphere3; 


		// initialize
		public void Init()
		{
            //Initialize the list which contains the Lights and the lights them self
            LightList = new List<Light>();
            light1 = new Light(new Vector2(-0.55f, -0.5f), new Vector3(255, 255, 0), 0.00005f);
            light2 = new Light(new Vector2(-0.4f, -0.3f), new Vector3(255, 0, 255), 0.0001f);
            light3 = new Light(new Vector2(0.3f, -0.5f), new Vector3(0, 255, 255), 0.00007f);
            light4 = new Light(new Vector2(-0.8f, 0.8f), new Vector3(200, 200, 200), 0.0001f);
            light5 = new Light(new Vector2(0.7f, 0.75f), new Vector3(60, 150, 200), 0.00001f);

            //Create Primitives
            PrimitiveList = new List<IPrimitive>();
            sphere1 = new Sphere(new Vector2(-0.5f, 0.7f), 0.1f, new Vector3(0, 0, 0));
            sphere2 = new Sphere(new Vector2(-0.2f, -0.2f), 0.1f, new Vector3(0, 0, 0));
            sphere3 = new Sphere(new Vector2(0.8f, 0.6f), 0.5f, new Vector3(0, 0, 0));

            //Add all the lights to the list
            LightList.Add(light1);
            LightList.Add(light2);
            LightList.Add(light3);
            LightList.Add(light4);
            LightList.Add(light5);

            //Add all primitives to the list
            PrimitiveList.Add(sphere1);
            PrimitiveList.Add(sphere2);
            PrimitiveList.Add(sphere3);
        }

		// tick: renders one frame
		public void Tick()
		{
			screen.Clear( 0 );
            //Parallel.For is used for Multi- threading
            //Loop over all pixels in the screen
            Parallel.For(0, screen.height, (y) =>
           {
               Parallel.For(0, screen.width, (x) =>
               {
                   var color = new Vector3();                                       //Black to begin with
                   Vector2 ray_position = new Vector2(TransX(x), TransY(y));        //position on the screen 

                   //for each pixel loop over the light sources
                   foreach (Light light in LightList)
                   {
                       //shoot a ray from each pixel to each existing light source
                       var ray = new Ray(ray_position, light.position - ray_position);

                       bool occluded = false;
                       //loop over all primitives that are in the world
                       foreach (IPrimitive p in PrimitiveList)
                       {
                           if (p.Intersect(ray))
                               occluded = true;

                       }
                       if (!occluded)
                           color += light.color * lightAttenuation(ray.t) * light.brightness;
                   }
                   screen.Plot(x, y, ToRGB32(color));
               });

           });

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

        float TransY(int y)
        {
            //screen.width/screen.height => aspect ratio
            //range = 1f, division = 2f
            return ((y / (screen.height / division)) - range) * -1f / ((float)screen.width / screen.height);
        }

        float TransX(int x)
        {
            //range = 1f, division = 2f 
            return x / (screen.width / division) - range; 
        }
    }
}