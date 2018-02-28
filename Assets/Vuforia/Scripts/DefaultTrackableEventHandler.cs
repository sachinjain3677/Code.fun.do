/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        public GameObject[] ChildObjects;

        private Renderer[] temprenderercomponents;
        private Collider[] tempcollidercomponents;

        private Vector3[] defaultscale = new Vector3[10];
        private Quaternion[] defaultrotation = new Quaternion[10];
        private Vector3[] defaultposition = new Vector3[10];

        private Vector3[] edefaultscale = new Vector3[7];
        private Quaternion[] edefaultrotation = new Quaternion[7];
        private Vector3[] edefaultposition = new Vector3[7];

        private Vector3[] sdefaultscale = new Vector3[20];
        private Quaternion[] sdefaultrotation = new Quaternion[20];
        private Vector3[] sdefaultposition = new Vector3[20];

        public GameObject[] earthtexts;

        public static int suns = 0;

        public static bool Cassini = false;

        private AudioSource[] allAudioSources;
        private GameObject[] TPlanets;
        private GameObject[] eobjects;
        private GameObject[] Satellites;

        private int start = 0;

        public static bool earth = false;


        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }

            TPlanets = GameObject.FindGameObjectsWithTag("temp");

            for (int i = 0; i < TPlanets.Length; i++)
            {
                defaultscale[i] = TPlanets[i].transform.localScale;
                defaultrotation[i] = TPlanets[i].transform.localRotation;
                defaultposition[i] = TPlanets[i].transform.localPosition;
            }

            eobjects = GameObject.FindGameObjectsWithTag("GameController");

            for (int i = 0; i < eobjects.Length; i++)

            {
                edefaultposition[i] = eobjects[i].transform.localPosition;
                edefaultrotation[i] = eobjects[i].transform.localRotation;
                edefaultscale[i] = eobjects[i].transform.localScale;
            }

            Satellites = GameObject.FindGameObjectsWithTag("satellite");

            for (int i = 0; i < Satellites.Length; i++)

            {
                sdefaultposition[i] = Satellites[i].transform.localPosition;
                sdefaultrotation[i] = Satellites[i].transform.localRotation;
                sdefaultscale[i] = Satellites[i].transform.localScale;
            }

            //earthtexts = GameObject.FindGameObjectsWithTag("earthtext");
            // What's the problelm if instead of making public, use of tags
        }

        void reset(Vector3 dscale, Quaternion drotation, GameObject Planet, Vector3 dposition = default(Vector3))
        {
            Planet.transform.localScale = dscale;
            Planet.transform.localRotation = drotation;
            if (dposition != default(Vector3))
            {
                Planet.transform.localPosition = dposition;
            }

        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS

        public void StopAllAudio()
        {
            allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource audioS in allAudioSources)
            {
                //audioS.Stop();
                audioS.enabled = false; 
            }
        }

        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
                start = 1;
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            /*if (tempcollidercomponents != null || temprenderercomponents != null)
            {
                for (int i = 0; i < temprenderercomponents.Length; i++)
                {
                    temprenderercomponents[i].enabled = false;
                }
                for (int i = 0; i < tempcollidercomponents.Length; i++)
                {
                    tempcollidercomponents[i].enabled = false;
                }
            }*/


            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

            LoadOnClick.explode = false;

            if (mTrackableBehaviour.tag == "0")
            {
                
                suns = 1;
            }
            if(mTrackableBehaviour.tag == "3")
            {
                earth = true;
            }

            

            if (mTrackableBehaviour.GetComponent<AudioSource>() != null)
            {
                mTrackableBehaviour.GetComponent<AudioSource>().enabled = true;
                //mTrackableBehaviour.GetComponent<AudioSource>().Play();
            }

            

            

            /*if (mTrackableBehaviour.TrackableName == "3")
            {
                foreach (GameObject g in earthtexts)
                {
                    g.SetActive(false);
                }
            }*/

            for (int i = 0; i < Satellites.Length; i++)
            {

                reset(sdefaultscale[i], sdefaultrotation[i], Satellites[i], sdefaultposition[i]);

            }
            foreach(GameObject o in ChildObjects)
            {
                o.SetActive(true);
            }
            
            for (int i = 0; i < TPlanets.Length; i++)
            {

                reset(defaultscale[i], defaultrotation[i], TPlanets[i], defaultposition[i]);

            }
            for (int i = 0; i < eobjects.Length; i++)
            {

                reset(edefaultscale[i], edefaultrotation[i], eobjects[i], edefaultposition[i]);

            }
        }



        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering: 
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            /* if(start == 1)
             {
                 // Disable rendering: 
                 foreach (Renderer component in rendererComponents)
                 {
                     component.enabled = true;
                 }

                 // Disable colliders:
                 foreach (Collider component in colliderComponents)
                 {
                     component.enabled = true;
                 }

                 for (int i = 0; i < rendererComponents.Length; i++)
                 {
                     temprenderercomponents[i] = rendererComponents[i];
                 }
                 for (int i = 0; i < colliderComponents.Length; i++)
                 {
                     tempcollidercomponents[i] = colliderComponents[i];
                 }
             }*/


            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

            if (mTrackableBehaviour.tag == "0")
            {
                GameObject[] texts = GameObject.FindGameObjectsWithTag("dtext");
                foreach (GameObject t in texts)
                {
                    t.SetActive(false);
                }
                suns = 0;
            }

            if (mTrackableBehaviour.GetComponent<AudioSource>() != null)
            {
                mTrackableBehaviour.GetComponent<AudioSource>().enabled = false;
            }

            if (mTrackableBehaviour.TrackableName == "3")
            {
                foreach (GameObject g in earthtexts)
                {
                    if(g!=null)
                    {
                        g.SetActive(false);
                    }
                    
                }
            }
            foreach (GameObject o in ChildObjects)
            {
                o.SetActive(false);
            }
            if(mTrackableBehaviour.tag == "3")
            {
                earth = false;
            }
            
        }

        #endregion // PRIVATE_METHODS
    }
}
