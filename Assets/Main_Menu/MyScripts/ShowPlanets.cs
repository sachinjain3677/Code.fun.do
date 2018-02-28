using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

// ToDo Think or Search How to make the object's position independent of the image target if it is child of imagetarget

public class ShowPlanets : MonoBehaviour
{
    public Button b1, b2;
    public Button c1, c2, c3, c4;
    public Light sunlight;
    public Slider slider;

    public GameObject[][] planets = new GameObject[9][];
    public GameObject[][] smallplanets = new GameObject[9][];
    private int[] planet = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public float[] distances = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public Light Sunlight;

    public Text Header;
    public Text Content;

    private GameObject Sun;
	private AudioSource[] allAudioSource;
	private string active = "null";
	//private int[] active;
	//private AudioSource activeaudio = new AudioSource();
	//private int checkactive = 0; 

    public static bool go = true; //Initially true so that works for single planet

    private GameObject[] TargetPlanets;
    

    // Use this for initialization
    void Start()
    {
		

        for (int i = 0; i < 9; i++)
        {
            planets[i] = GameObject.FindGameObjectsWithTag((i + 1).ToString());
            smallplanets[i] = GameObject.FindGameObjectsWithTag((i + 11).ToString());
            //planets[i][1].SetActive(false);
            planet[i] = 0;
        }


    }

   

    // Update is called once per frame
    void Update()
    {

        allAudioSource = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        //active.Length = allAudioSource.Length;
        //foreach (int a in active) {
        //	a = 0;
        //}


        TargetPlanets = GameObject.FindGameObjectsWithTag("temp");

        Sun = GameObject.Find("Sun");
        // motion is not working along with setactive
        //c1.gameObject.SetActive(false);
        //c2.gameObject.SetActive(false);
        //c3.gameObject.SetActive(false);
        //c4.gameObject.SetActive(false);

        slider.gameObject.SetActive(false);

        c1.gameObject.transform.localScale = new Vector3(0, 0, 0);
        c2.gameObject.transform.localScale = new Vector3(0, 0, 0);
        c3.gameObject.transform.localScale = new Vector3(0, 0, 0);
        c4.gameObject.transform.localScale = new Vector3(0, 0, 0);

        //c1.gameObject.GetComponent<Renderer>().enabled = false;

        if (LoadOnClick.play == false) {
			
			foreach( AudioSource audioS in allAudioSource) {

				if (audioS.enabled == true) {
					//activeaudio = audioS;

					//active.SetValue(1, );
					audioS.Pause();
                    //activeaudio.Pause();
                    //checkactive = 1;
                    //active = audioS.gameObject.tag;
                    active = audioS.gameObject.name;
                    Debug.Log(audioS.gameObject.name + "Paused");
                    
				}
			}
		}

		if (LoadOnClick.play == true) {

			//if (checkactive == 1) {
				
			//	activeaudio.UnPause ();
			//}

			foreach( AudioSource audioS in allAudioSource) {

				if (audioS.gameObject.name.Contains(active)) {
					//activeaudio = audioS;

					audioS.UnPause();
                    //audioS.tag = "0";
                    //activeaudio.Pause();
                    //checkactive = 1;
                    Debug.Log(audioS.gameObject.name + "Unpaused");
				}
			}


		}


        bool multicard = LoadOnClick.multicards;

        GameObject Des = GameObject.Find("Des");

        //Text des = Des.GetComponent<Text>();

        float[] distances = { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; 

        int ss = DefaultTrackableEventHandler.suns;


        // Whenever there is sun, all the stationary planet models are off

       

        if (ss == 1)
        {
            for (int i = 0; i < TargetPlanets.Length; i++)
            {
                
                TargetPlanets[i].SetActive(false);
               //TargetPlanets[i].GetComponent<MeshRenderer>().enabled = false;
                //Debug.Log(TargetPlanets[i]);
            }

           /* Renderer[] temp = smallplanets[][0].GetComponentsInChildren<MeshRenderer>(true);
            foreach (Renderer r in temp)
            {
                r.enabled = true;
            }*/

            //b1.gameObject.SetActive(true);               // 3D button active when sun is there
            //b2.gameObject.SetActive(true);                 // P button active when sun is there

            sunlight.gameObject.SetActive(true);
        }
        else
        {
            for (int i = 0; i < TargetPlanets.Length; i++)
            {

                 TargetPlanets[i].SetActive(true);
                //TargetPlanets[i].GetComponent<MeshRenderer>().enabled = true;
                //Debug.Log(TargetPlanets[i]);
            }
            b1.gameObject.SetActive(false);
            b2.gameObject.SetActive(false);
           /* Renderer[] temp = smallplanets[i][0].GetComponentsInChildren<MeshRenderer>(true);
            foreach (Renderer r in temp)
            {
                r.enabled = false;
            }*/

            sunlight.gameObject.SetActive(false);
        }





        

        for (int i = 0; i < 9; i++)
        {
            if (planet[i] == 0)
            {
                //planets[i][1].GetComponent<MeshRenderer>().enabled = true;
                
            }
        }

        string trackeditems = "tracked items are ";

        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        /*foreach (TrackableBehaviour tb in activeTrackables)
        {
            if (tb.tag == "0")
            {
                suns = 1;
                Sun.GetComponent<MeshRenderer>().enabled = true;
                break;
            }
            else
            {
                suns = 0;
                Sun.GetComponent<MeshRenderer>().enabled = false;
            }
        }*/ // why is this not working

        string a = "distances are ";

        Stack<float> stack = new Stack<float>();

        foreach (TrackableBehaviour tb in activeTrackables)
        {

            trackeditems = trackeditems + tb.TrackableName;

            //des = tb.GetComponentInChildren<Text>();

			/*if (LoadOnClick.play == true) {
				tb.GetComponent<AudioSource> ().Pause = true;
			} else {
				tb.GetComponent<AudioSource> ().UnPause = true;
			}*/

            if(tb.TrackableName == "q")
            {
                //slider.gameObject.SetActive(true);
            }
				




            Header.text = Information(tb.TrackableName)[0];
            Content.text = Information(tb.TrackableName)[1];

            for(int i =0; i<11; i++)
            {
               // Debug.Log(i);
               // if(i!=3)
               // {

                if((i).ToString().Equals(tb.tag))
                {
                    slider.gameObject.SetActive(true);        // slider is active only for 8 planets,sun and moon
                }

                //}
            }
 
            for(int i = 0; i<9; i++)
                {
                    if ( (i+1).ToString().Equals(tb.tag))
				{
							
					if (ss == 1) {
						
						smallplanets[i][0].GetComponent<MeshRenderer>().enabled = true;
                        
                       
                        planet[i] = 1;
                    }
                             

                             distances[i] = distance(tb.transform.position.x, tb.transform.position.y, tb.transform.position.z);

                             stack.Push(distances[i]);
                            
                             a = a + i.ToString() + " " + distances[i].ToString() + " ";

                   
                            // In absence of sun, if image target is tracked then bigger model planet is shown

                            /*if (ss == 0)
                            {
                                if (i < TargetPlanets.Length)
                                    {
                                        TargetPlanets[i].SetActive(true);
                                        TargetPlanets[i].GetComponent<MeshRenderer>().enabled = true;
                                    }
                            }*/
                        }
                

               if (tb.tag == "0")
                {
                    ss = 1;
                    Sun.GetComponent<MeshRenderer>().enabled = true;
                    //Sun.GetComponentInChildren<Light>().gameObject.SetActive(true);
                    Sunlight.gameObject.SetActive(true);
                }// happening from the script of tracking
                
               if(tb.TrackableName == "c")
                {
                    /*c1.gameObject.SetActive(true);
                    c2.gameObject.SetActive(true);
                    c3.gameObject.SetActive(true);
                    c4.gameObject.SetActive(true);*/

                    c1.gameObject.transform.localScale = new Vector3(0.55f, 1, 0.85f);
                    c2.gameObject.transform.localScale = new Vector3(0.55f, 1, 0.85f);
                    c3.gameObject.transform.localScale = new Vector3(0.55f, 1, 0.85f);
                    c4.gameObject.transform.localScale = new Vector3(0.55f, 1, 0.85f);
                }

            }

            
        }
        //Debug.Log(a);


        if (multicard == false && ss == 1)
        {
            for (int i = 0; i < 9; i++)
            {
                if (planet[i] == 0)
                {
                    smallplanets[i][0].GetComponent<MeshRenderer>().enabled = true;
                    smallplanets[i][0].GetComponent<TrailRenderer>().enabled = true;
                    smallplanets[i][0].GetComponent<activation>().setstate(true);
                    //planets[i][1].SetActive(true);
                }
            }
        }

        if (multicard == true | ss == 0)
        {
            for (int i = 0; i < 9; i++)
            {
                if (planet[i] == 0)
                {
                    smallplanets[i][0].GetComponent<MeshRenderer>().enabled = false;
                    smallplanets[i][0].GetComponent<TrailRenderer>().enabled = false;
                    smallplanets[i][0].GetComponent<activation>().setstate(false);
                    //planets[i][1].SetActive(false);
                    
                }
            }
        }

        if(LoadOnClick.plane == true)
        {
            for (int i = 0; i < 9; i++)
            {
                if (planet[i] == 0)
                {
                    
                    smallplanets[i][0].GetComponent<TrailRenderer>().enabled = true;
                 
                }
            }
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                if (planet[i] == 0)
                {
                    
                    smallplanets[i][0].GetComponent<TrailRenderer>().enabled = false;
                   
                }
            }
        } 

        // If setactive is false it can't detect it to make it active

        //Debug.Log(trackeditems);

        if (ss == 0)
        {
            Sun.GetComponent<MeshRenderer>().enabled = false;
            // Sun.GetComponentInChildren<Light>().gameObject.SetActive(false);
            Sunlight.gameObject.SetActive(false);
        }
        for (int i =0; i<9; i++)
        {
            if(planet[i] == 0 | ss == 0)
            {
                //planets[i][1].GetComponent<MeshRenderer>().enabled = false;
            }
        }

        // suns = 0;

        // What is the problem if we do the below process in elliptical motion script by just inherting distances from here

        //bool go = false;

        // string qwe = " ";

        float[] sas = stack.ToArray();

        for (int i = 1; i < sas.Length; i++)
        {
           /* if ((distances[i] >= distances[i - 1]) | distances[i] == 0)
            {
                go = true;
            }*/

            if(sas[i] > sas[i-1])
            {
                go = true;
            }
            else
            {
                go = false;
                break;
            }

            //qwe = qwe + ds[i].ToString();

        }

        //Debug.Log(qwe);

    }

    public float distance (float x, float y, float z)
    {
        float d = 0;

        d = Mathf.Sqrt(x * x + y * y + z * z);

        return d;
    }

    public string[] Information(string a)
    {
        string[] info = { "None", "Please bring a card to see its information" }; 

        if(a == "0")
        {
            info[0] = "Sun";
            info[1] = "Sun is a star, that forms the centre of our solar system.\nThe Sun revolves around the milky way galaxy at about 220 km per second.\nThe sun rotates around its axis in anti-clockwise direction.\nThe sun’s surface temperature is nearly 5500 degree celsius. The temperature increases to 1,36,00,000 degree celsius at the centre of the sun.\nIt takes approximately eight minutes for light to reach Earth from the Sun with a speed of 3,00,000 km per second.\nEnergy received from Sun, plays an important role in food for plants and thus, life on earth.";
            return info;
        }

        else if(a == "1")
        {
            info[0] = "Mercury";
            info[1] = "Mercury is the smallest and closest planet near the sun, and revolves around the sun.\nDue to its closeness to sun, Mercury has no atmosphere and no known satellite.\nA day in mercury is equal to 176 days on Earth.\nAn year on Mercury is equal to 88 days on Earth.\nTemperatures on Mercury can be as low as -173 degree celsius and as high as 450 degree celsius.\nNASA’s MESSENGER probe has been orbiting mercury since 2011.\nGravity of Mercury is about 38% that of Earth’s gravity. Thus, 100kgs on Earth is equal to 38 kgs on Mercury.";
            return info;
        }
        else if (a == "2")
        {
            info[0] = "Venus";
            info[1] = "Venus is the second closest planet, after Mercury in the solar system. It is the sixth largest planet in the solar system.\nVenus and Earth are often referred as sister planets, due to their similar size, mass and density.\nVenus is the hottest planet in our solar system, while it is the second brightest object in the night sky after moon.\nA day on Venus is equal to 243 days on Earth.\nFor Venus, it takes about 224 days to complete one rotation around Sun.\nThe gravity on venus, is about 90% of gravity on Earth. Thus, 100kgs on earth is equal to 90 kgs on Venus.\nVenus and Uranus are the only two planets that revolve around the sun from East to West.";
            return info;
        }
        else if (a == "3")
        {
            info[0] = "Earth";
            info[1] = "Earth is the third closest planet in the solar system after Venus. It is the fifth largest planet.\nEarth is the only planet in the solar system, that supports life. This is due to presence of water and favorable atmosphere on earth.\nEarth takes about 24 hours to complete a day, while it takes about 365 and one fourth days to complete one revolution around Sun.\nEarth is not a complete sphere, and bulges around equator. Thus, it takes the shape of  a Spheroid.\nNearly 70% of Earth’s surface is covered by water, that gives it its blue color.\nHighest point on Earth is Mount Everest in Nepal, while lowest point is Challenger Deep in Pacific Ocean.";
            return info;
        }
        else if (a == "4")
        {
            info[0] = "Mars";
            info[1] = "Mars is the fourth nearest planet in the solar system after Earth.\nMars looks red, because of the presence of Iron Oxide on its surface.\nMars takes about 24 hours, 39 minutes to complete one day.\n.One year on Mars, equals 1.88 years on Earth.\nGravity on Mars, is about 37.5% of gravity on Earth. Thus, 100 kgs on Earth is same as 37.5 kgs on Mars.\nVarious Movies have been made on mars, latest being ‘The Martian’.\nMars Orbiter Mission or Mangalyaan is a space probe orbiting Mars, that was launched by ISRO in 2013.";
            return info;
        }
        else if (a == "5")
        {
            info[0] = "Jupiter";
            info[1] = "Jupiter is the fifth planet from the sun, in the solar system.\nIt’s the largest planet in the solar system.\nA day on Jupiter, is nearly equal to 10 hour day on Earth.\nWhile one year on Jupiter, is equal to 11 years and 10 months of Earth.\nUnlike Earth, Jupiter is made of gases, thus being known as ‘Gas Giant’.\nGravity on Jupiter is about 2.5 times that on Earth. Thus, 100 kgs on Earth weighs about 252 kgs on Jupiter.";
            return info;
        }
        else if (a == "6")
        {
            info[0] = "Saturn";
            info[1] = "Saturn is the sixth planet from the sun.\nSaturn is a gaseous planet, comprising mainly of Hydrogen.\nA  day on Saturn, is same as 10.6 hours day on Earth.\nAn year on Saturn, is equal to 29.7 years on Earth.\nCassini is the space mission to explore Saturn.";
            return info;
        }
        else if (a == "7")
        {
            info[0] = "Uranus";
            info[1] = "Uranus is the seventh planet in the solar system.\nUranus is known as ‘Ice Giant’ due to its composition comprising of hydrogen, helium, ammonia and methane.\nIt’s the coldest planet in the solar system, with a minimum temperature of -224 degree Celsius. \nA day on uranus is equal to the 17 hour, 14 minute day on Earth.\n An year in Uranus is equal to 86 years on planet Earth.";
            return info;
        }
        else if (a == "8")
        {
            info[0] = "Neptune";
            info[1] = "Neptune is the eight and farthest planet from the Sun.\nA 24 hour day on Earth is same as 18 hours day on Neptune.\nAn year on Neptune is equal to 164.8 years on Earth.\nAverage temperature on Neptune is -214 degree Celsius.\nNeptune has 13 moons.";
            return info;
        }
        else if (a == "9")
        {
            info[0] = "Pluto";
            info[1] = "Pluto is a dwarf planet, meaning it is neither a planet, nor a natural satellite.\n It’s the ninth-largest object orbiting the sun.\nPluto is primarily made of Ice and rock.\nNew Horizons spacecraft is the first spacecraft to fly by Pluto.\nOne day on Pluto is same as 6.39 days on Earth.\nAn year on Pluto is same as about 248 years on Earth.";
            return info;
        }
        else if (a == "10")
        {
            info[0] = "Moon";
            info[1] = "Moon is a large astronomical body, that orbits Earth, and is the only natural satellite of Earth.\nThe moon takes about 27 days to orbit the earth.\nThe moon does not have a light of its own. It reflects the light of sun.\nThe effect of gravity on moon is about one sixth as strong as it is on the surface of Earth. Thus, 100 kgs on earth will weigh about 16 kgs on moon.\nNeil Armstrong was the first man to land on the surface of Moon, while Rakesh Sharma was first Indian to land on Moon.\nMoon plays an important role in rise and fall of tides in our Oceans.";
            return info;
        }
        else if (a == "r")
        {
            info[0] = "Solar Eclipse";
            info[1] = "As seen from the Earth, a solar eclipse is a type of eclipse that occurs when the Moon passes between the Sun and Earth, and the Moon fully or partially blocks the Sun. This can happen only at new moon when the Sun and the Moon are in conjunction as seen from Earth in an alignment referred to as syzygy. In a total eclipse, the disk of the Sun is fully obscured by the Moon. In partial and annular eclipses, only part of the Sun is obscured.\n If the Moon were in a perfectly circular orbit, a little closer to the Earth, and in the same orbital plane, there would be total solar eclipses every month. However, the Moon's orbit is inclined (tilted) at more than 5 degrees to the Earth's orbit around the Sun, so its shadow at new moon usually misses Earth.\n Since looking directly at the Sun can lead to permanent eye damage or blindness, special eye protection or indirect viewing techniques are used when viewing a solar eclipse.";
            return info;
        }
        else if (a == "t")
        {
            info[0] = "Different Positions";
            info[1] = "Different cameras show different views from different positions.";
            return info;
        }
        else if (a == "e")
        {
            info[0] = "Lunar Eclipse";
            info[1] = "A lunar eclipse occurs when the Moon passes directly behind the Earth into its umbra (shadow). This can occur only when the sun, Earth, and moon are aligned exactly, or very closely so, with the Earth in the middle. Hence, a lunar eclipse can occur only the night of a full moon. The type and length of an eclipse depend upon the Moon's location relative to its orbital nodes.\n A total lunar eclipse has the direct sunlight completely blocked by the earth's shadow. The only light seen is refracted through the earth's shadow. This light looks red for the same reason that the sunset looks red, due to rayleigh scattering of the more blue light. Because of its reddish color, a total lunar eclipse is sometimes called a blood moon.\n Unlike a solar eclipse, which can be viewed only from a certain relatively small area of the world, a lunar eclipse may be viewed from anywhere on the night side of the Earth. A lunar eclipse lasts for a few hours, whereas a total solar eclipse lasts for only a few minutes at any given place, due to the smaller size of the Moon's shadow. Also unlike solar eclipses, lunar eclipses are safe to view without any eye protection or special precautions, as they are dimmer than the full moon.";
            return info;
        }
        else if (a == "w")
        {
            info[0] = "Lunar Phases";
            info[1] = "The phases of the Moon are the different ways the Moon looks from Earth over about a month.As the Moon orbits around the Earth, the half of the Moon that faces the Sun will be lit up.The different shapes of the lit portion of the Moon that can be seen from Earth are known as phases of the Moon.Each phase repeats itself every 29.5 days.\n The same half of the Moon always faces the Earth, so the phases will always occur over the same half of the Moon's surface.\n There are 8 phases that the moon goes through.\nPhase 1 - New Moon\n Phase 2 - Waxing Crescent\n Phase 3 - First Quarter \n Phase 4 - Waxing Gibbous \n Phase 5 - Full Moon \nPhase 6 - Waning Gibbous \n Phase 7 - Last Quarter \n Phase 8 - Waning Crescent";
            return info;
        }
        else if (a == "q")
        {
            info[0] = "Revolution of Earth and Moon";
            info[1] = "The change in the time the sun is at its highest point in the sky (true noon) varies throughout the year. This happens for two reasons: the Earth’s orbit is an ellipse, rather than a circle, and the Earth is tilted with respect to the Sun. \n Due to friction caused by the tides and stray space particles, the Earth’s rotation is very gradually slowing down.\n Every year, the Moon moves about 4 centimeters (1.6 inches) out from its orbit around the Earth. This is due to the tides the Moon brings to the Earth. \n The Moon has a nearly circular orbit (e=0.05) which is tilted about 5° to the plane of the Earth's orbit. Its average distance from the Earth is 384,400 km. The combination of the Moon's size and its distance from the Earth causes the Moon to appear the same size in the sky as the Sun, which is one reason we can have total solar eclipses.\n It takes the Moon 27.322 days to go around the Earth once. Because of this motion, the Moon appears to move about 13° against the stars each day, or about one-half degree per hour. If you watch the Moon over the course of several hours one night, you will notice that its position among the stars will change by a few degrees. The changing position of the Moon with respect to the Sun leads to lunar phases.";
            return info;
        }
        else if (a == "b")
        {
            info[0] = "Satellite Launching";
            info[1] = "Satellite is launched from earth to revolve around any celestial body. Usually the bodies are other planets and moons. Satellite is fist set to revolve around the earth and after some revoulutions, it is thrown it starts orbitting the moon or the other targeted planet.";
            return info;
        }
        /* else if(a == "Cassinni")
         {
             info[0] = "Cassinni";
             info[1] = "";
         }
         else if (a == "HST")
         {
             info[0] = "HST";
             info[1] = "";
         }
         else if (a == "ISS")
         {
             info[0] = "ISS";
             info[1] = "";
         }
         else if (a == "Apollo")
         {
             info[0] = "Apollo";
             info[1] = "";
         }
         else if (a == "Messenger")
         {
             info[0] = "Messenger";
             info[1] = "";
         }
         else if (a == "Mangalyaan")
         {
             info[0] = "Mangalyaan";
             info[1] = "";
         }
         else if (a == "Curiosity")
         {
             info[0] = "Curiosity";
             info[1] = "";
         }
         else if (a == "PSLV")
         {
             info[0] = "PSLV";
             info[1] = "";
         }
         else if (a == "Galileo")
         {
             info[0] = "Galileo";
             info[1] = "";
         }
         else if (a == "Chandrayaan")
         {
             info[0] = "Chandrayaan";
             info[1] = "";
         }*/
        else
        {
            return info;
        }
    }

    public void setstate(GameObject g, bool var)
    {
        g.SetActive(var);
    }
}

