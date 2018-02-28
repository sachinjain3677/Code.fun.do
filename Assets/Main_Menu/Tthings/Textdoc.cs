using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class Textdoc : MonoBehaviour {

	//public GameObject Cassinitext,Apollotext,Curiositytext,ISStext,Galileotext,HSTtext,Messengertext,PSLVtext,Chandrayaantext,Mangalyaantext;
	public GameObject CassiniAudio,ApolloAudio,CuriosityAudio,ISSAudio,GalileoAudio,HSTAudio,MessengerAudio,PSLVAudio,ChandrayaanAudio,MangalyaanAudio;
    public Text cassini, apollo, curiosity, iss, galileo, hst, messenger, pslv, chandrayaan, mangalyaan;
    public Text cassinih, apolloh, curiosityh, issh, galileoh, hsth, messengerh, pslvh, chandrayaanh, mangalyaanh;
    public Text info;
    public Text heading;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (DefaultTrackableEventHandler1.Cassini) { 
			//Cassinitext.gameObject.SetActive (true);
			CassiniAudio.gameObject.SetActive (true);
            info.text = cassini.text;
            heading.text = cassinih.text;
		} 
		else 
		{
			//Cassinitext.gameObject.SetActive (false);
			CassiniAudio.gameObject.SetActive (false);
		}
		if (DefaultTrackableEventHandler1.Apollo) {
            //Apollotext.gameObject.SetActive (true);
            ApolloAudio.gameObject.SetActive (true);
            info.text = apollo.text;
            heading.text = apolloh.text;
		} 
		else 
		{
			//Apollotext.gameObject.SetActive (false);
			ApolloAudio.gameObject.SetActive (false);
		}
		if (DefaultTrackableEventHandler1.Curiosity) { 
			//Curiositytext.gameObject.SetActive (true);
			CuriosityAudio.gameObject.SetActive (true);
            info.text = curiosity.text;
            heading.text =  curiosityh.text;
        } 
		else 
		{
			//Curiositytext.gameObject.SetActive (false);
			CuriosityAudio.gameObject.SetActive (false);
		}
		if (DefaultTrackableEventHandler1.ISS) { 
			//ISStext.gameObject.SetActive (true);
			ISSAudio.gameObject.SetActive (true);
            info.text = iss.text;
            heading.text = issh.text;
        } 
		else 
		{
			//ISStext.gameObject.SetActive (false);
			ISSAudio.gameObject.SetActive (false);
		}
		if (DefaultTrackableEventHandler1.Galileo) 
		{ 
			//Galileotext.gameObject.SetActive (true);
			GalileoAudio.gameObject.SetActive (true);
            info.text = galileo.text;
            heading.text = galileoh.text;
        } 
		else 
		{
			//Galileotext.gameObject.SetActive (false);
			GalileoAudio.gameObject.SetActive (false);
		}
		if (DefaultTrackableEventHandler1.HST) 
		{ 
			//HSTtext.gameObject.SetActive (true);
			HSTAudio.gameObject.SetActive (true);
            info.text = hst.text;
            heading.text = hsth.text;
        } 
		else 
		{
			//HSTtext.gameObject.SetActive (false);
			HSTAudio.gameObject.SetActive (false);
		}
		if (DefaultTrackableEventHandler1.Messenger) 
		{ 
			//Messengertext.gameObject.SetActive (true);
			MessengerAudio.gameObject.SetActive (true);
            info.text = messenger.text;
            heading.text = messengerh.text;
        } 
		else 
		{
			//Messengertext.gameObject.SetActive (false);
			MessengerAudio.gameObject.SetActive (false);
		}
		if (DefaultTrackableEventHandler1.PSLV) 
		{ 
			//PSLVtext.gameObject.SetActive (true);
			PSLVAudio.gameObject.SetActive (true);
            info.text = pslv.text;
            heading.text = pslvh.text;
        } 
		else 
		{
			//PSLVtext.gameObject.SetActive (false);
			PSLVAudio.gameObject.SetActive (false);
		}
		if (DefaultTrackableEventHandler1.Chandrayaan) 
		{ 
			//Chandrayaantext.gameObject.SetActive (true);
			ChandrayaanAudio.gameObject.SetActive (true);
            info.text = chandrayaan.text;
            heading.text = chandrayaanh.text;
        } 
		else 
		{
			//Chandrayaantext.gameObject.SetActive (false);
			ChandrayaanAudio.gameObject.SetActive (false);
		}
		if (DefaultTrackableEventHandler1.Mangalyaan) { 
			//Mangalyaantext.gameObject.SetActive (true);
			MangalyaanAudio.gameObject.SetActive (true);
            info.text = mangalyaan.text;
            heading.text = mangalyaanh.text;
        } 
		else 
		{
			//Mangalyaantext.gameObject.SetActive (false);
			MangalyaanAudio.gameObject.SetActive (false);
		}
	}
}
