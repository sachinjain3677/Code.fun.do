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
	public class DefaultTrackableEventHandler1 : MonoBehaviour,
	ITrackableEventHandler
	{
		#region PRIVATE_MEMBER_VARIABLES

		private TrackableBehaviour mTrackableBehaviour;


		#endregion // PRIVATE_MEMBER_VARIABLES

		public static bool Cassini,Apollo,Curiosity,ISS,Galileo,HST,Messenger,PSLV,Chandrayaan,Mangalyaan;


		#region UNTIY_MONOBEHAVIOUR_METHODS

		void Start()
		{
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
		}

		#endregion // UNTIY_MONOBEHAVIOUR_METHODS



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

			if (mTrackableBehaviour.TrackableName == "Cassini") 
			{
				Cassini = true;
			}
			else if (mTrackableBehaviour.TrackableName == "Apollo") 
			{
				Apollo = true;
			}
			else if (mTrackableBehaviour.TrackableName == "Curiosity") 
			{
				Curiosity = true;
			}
			else if (mTrackableBehaviour.TrackableName == "ISS") 
			{
				ISS = true;
			}
			else if (mTrackableBehaviour.TrackableName == "Galileo") 
			{
				Galileo = true;
			}
			else if (mTrackableBehaviour.TrackableName == "HST") 
			{
				HST = true;
			}
			else if (mTrackableBehaviour.TrackableName == "Messenger") 
			{
				Messenger = true;
			}
			else if (mTrackableBehaviour.TrackableName == "PSLV") 
			{
				PSLV = true;
			}
			else if (mTrackableBehaviour.TrackableName == "Chandrayaan") 
			{
				Chandrayaan = true;
			}
			else if (mTrackableBehaviour.TrackableName == "Mangalyaan") 
			{
				Mangalyaan = true;
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

			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

			if (mTrackableBehaviour.TrackableName == "Cassini") 
			{
				Cassini = false;
			}
			else if (mTrackableBehaviour.TrackableName == "Apollo") 
			{
				Apollo = false;
			}
			else if (mTrackableBehaviour.TrackableName == "Curiosity") 
			{
				Curiosity = false;
			}
			else if (mTrackableBehaviour.TrackableName == "ISS") 
			{
				ISS = false;
			}
			else if (mTrackableBehaviour.TrackableName == "Galileo") 
			{
				Galileo = false;
			}
			else if (mTrackableBehaviour.TrackableName == "HST") 
			{
				HST = false;
			}
			else if (mTrackableBehaviour.TrackableName == "Messenger") 
			{
				Messenger = false;
			}
			else if (mTrackableBehaviour.TrackableName == "PSLV") 
			{
				PSLV = false;
			}
			else if (mTrackableBehaviour.TrackableName == "Chandrayaan") 
			{
				Chandrayaan = false;
			}
			else if (mTrackableBehaviour.TrackableName == "Mangalyaan") 
			{
				Mangalyaan = false;
			}

		}

		#endregion // PRIVATE_METHODS
	}
}
