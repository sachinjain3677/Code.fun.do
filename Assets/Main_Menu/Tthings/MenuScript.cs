using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class MenuScript : MonoBehaviour {
	//public Canvas QuitMenu;
	//public Button StartText;
	//public Button ExitText;
	public Button Explodetext,Mergetext;
	public GameObject CassiniExplode,  ApolloExplode, CuriosityExplode, ISSExplode, GalileoExplode, HSTExplode, MessengerExplode, PSLVExplode, ChandrayaanExplode, MangalyaanExplode, EarthExplode;
	public GameObject Cassini, Apollo, Curiosity, ISS, Galileo, HST, Messenger, PSLV, Chandrayaan, Mangalyaan, Earth;
	//public Camera ARCamera;
	//public Canvas StartMenu;
	//public Canvas Obj,Cross;
	//public Canvas Canvas;
	public GameObject Butobj;
	private bool hasexploded;
		// Use this for initialization
	void Start () {
		//QuitMenu = QuitMenu.GetComponent<Canvas> ();
		//StartText = StartText.GetComponent<Button> ();
		//ExitText = ExitText.GetComponent<Button> ();
		Explodetext = Explodetext.GetComponent<Button> ();
		//Mergetext = Mergetext.GetComponent<Button> ();
		//Obj = Obj.GetComponent<Canvas> ();
		//Cross = Cross.GetComponent<Canvas> ();
		//Canvas = Canvas.GetComponent<Canvas> ();
		//QuitMenu.enabled = false;
		//ARCamera.enabled = false;
		//Obj.enabled = false;
		//Cross.enabled = false;
		//Canvas.enabled = false;
		Butobj.SetActive(false);
		CassiniExplode.SetActive (false);
		ApolloExplode.SetActive (false);
		CuriosityExplode.SetActive (false);
		ISSExplode.SetActive (false);
		GalileoExplode.SetActive (false);
		HSTExplode.SetActive (false);
		MessengerExplode.SetActive (false);
		PSLVExplode.SetActive (false);
		ChandrayaanExplode.SetActive (false);
		MangalyaanExplode.SetActive (false);
        EarthExplode.SetActive(false);
	}
	
	public void EXITPress()
	{
		//QuitMenu.enabled = true;
		//StartText.enabled = false;
		//ExitText.enabled = false;
		//Obj.enabled = false;
	}

	public void NoPress()
	{
		//QuitMenu.enabled = false;
		//StartText.enabled = true;
		//ExitText.enabled = true;
	}

	/*public void StartPlay()
	{
		ARCamera.enabled = true;
		StartMenu.enabled = false;
		Cross.enabled = true;
	}*/
	public void Explode()
	{
		//hasexploded = true;
	}

	public void Merge()
	{
		//hasexploded = false;
		if (DefaultTrackableEventHandler1.Cassini) {
			CassiniExplode.SetActive (false);
			Cassini.SetActive (true);

		} else if (DefaultTrackableEventHandler1.Apollo) {
			ApolloExplode.SetActive (false);
			Apollo.SetActive (true);

		} 
		else if (DefaultTrackableEventHandler1.Curiosity) 
		{
			CuriosityExplode.SetActive (false);
			Curiosity.SetActive (true);
		}
		else if (DefaultTrackableEventHandler1.ISS) 
		{
			ISSExplode.SetActive (false);
			ISS.SetActive (true);
		}
		else if (DefaultTrackableEventHandler1.Galileo) 
		{
			GalileoExplode.SetActive (false);
			Galileo.SetActive (true);
		}
		else if (DefaultTrackableEventHandler1.HST) 
		{
			HSTExplode.SetActive (false);
			HST.SetActive (true);
		}
		else if (DefaultTrackableEventHandler1.Messenger) 
		{
			MessengerExplode.SetActive (false);
			Messenger.SetActive (true);
		}
		else if (DefaultTrackableEventHandler1.PSLV) 
		{
			PSLVExplode.SetActive (false);
			PSLV.SetActive (true);
		}
		else if (DefaultTrackableEventHandler1.Chandrayaan) 
		{
			ChandrayaanExplode.SetActive (false);
			Chandrayaan.SetActive (true);
		}
		else if (DefaultTrackableEventHandler1.Mangalyaan) 
		{
			MangalyaanExplode.SetActive (false);
			Mangalyaan.SetActive (true);
		}  
        else if(DefaultTrackableEventHandler.earth)
        {
            EarthExplode.SetActive(false);
            Earth.SetActive(true);
        }
	}

	public void Tired()
	{
		//StartMenu.enabled = true;
		//ARCamera.enabled = false;
	}

	public void ExitGame()
	{
		Application.Quit ();
	}
	public void Update()
	{
        hasexploded = LoadOnClick.explode;

        if(hasexploded == false)
        {
            Merge();
        }

		if (DefaultTrackableEventHandler1.Cassini) {
			//Obj.enabled = true;
			//Canvas.enabled = true;
			Butobj.SetActive(true);
			if (hasexploded) {
			    CassiniExplode.SetActive (true);
				Cassini.SetActive (false);
			}
		} else if (DefaultTrackableEventHandler1.Apollo) {
			//Obj.enabled = true;
			//Canvas.enabled = true;
			Butobj.SetActive(true);
			if (hasexploded) {
				ApolloExplode.SetActive (true);
				Apollo.SetActive (false);
			}

		} else if (DefaultTrackableEventHandler1.Curiosity) {
			//Obj.enabled = true;
			//Canvas.enabled = true;
			Butobj.SetActive(true);
			if (hasexploded) {
				CuriosityExplode.SetActive (true);
				Curiosity.SetActive (false);
			}
		} else if (DefaultTrackableEventHandler1.ISS) {
			//Obj.enabled = true;
			//Canvas.enabled = true;
			if (hasexploded) {
				ISSExplode.SetActive (true);
				ISS.SetActive (false);
			}
		} else if (DefaultTrackableEventHandler1.Galileo) {
			//Obj.enabled = true;
			//Canvas.enabled = true;
			Butobj.SetActive(true);
			if (hasexploded) {
				GalileoExplode.SetActive (true);
				Galileo.SetActive (false);
			}
		} else if (DefaultTrackableEventHandler1.HST) {
			//Obj.enabled = true;
			//Canvas.enabled = true;
			Butobj.SetActive(true);
			if (hasexploded) {
				HSTExplode.SetActive (true);
				HST.SetActive (false);
			}
		} else if (DefaultTrackableEventHandler1.Messenger) {
			//Obj.enabled = true;
			//Canvas.enabled = true;
			Butobj.SetActive(true);
			if (hasexploded) {
				MessengerExplode.SetActive (true);
				Messenger.SetActive (false);
			}
		} else if (DefaultTrackableEventHandler1.PSLV) {
			//Obj.enabled = true;
			//Canvas.enabled = true;
			Butobj.SetActive(true);
			if (hasexploded) {
				PSLVExplode.SetActive (true);
				PSLV.SetActive (false);
			}
		} else if (DefaultTrackableEventHandler1.Chandrayaan) {
			//Obj.enabled = true;
			//Canvas.enabled = true;
			Butobj.SetActive(true);
			if (hasexploded) {
				ChandrayaanExplode.SetActive (true);
				Chandrayaan.SetActive (false);
			}
		} else if (DefaultTrackableEventHandler1.Mangalyaan) {
			//Obj.enabled = true;
			//Canvas.enabled = true;
			Butobj.SetActive(true);
			if (hasexploded) {
				MangalyaanExplode.SetActive (true);
				Mangalyaan.SetActive (false);
			}
		}

        else if(DefaultTrackableEventHandler.earth == true)
        {
            Butobj.SetActive(true);
            if(hasexploded)
            {
                EarthExplode.SetActive(true);
                Earth.SetActive(false);
            }
        }

        else 
		   {
			//Obj.enabled = false;
			//Canvas.enabled = false;
			Butobj.SetActive(false);
			CassiniExplode.SetActive (false);
			ApolloExplode.SetActive (false);
			CuriosityExplode.SetActive (false);
			ISSExplode.SetActive (false);
			GalileoExplode.SetActive (false);
			HSTExplode.SetActive (false);
			MessengerExplode.SetActive (false);
			PSLVExplode.SetActive (false);
			ChandrayaanExplode.SetActive (false);
			MangalyaanExplode.SetActive (false);
            EarthExplode.SetActive(false);
		}
     }
}
