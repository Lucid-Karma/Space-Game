using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public static SwitchCamera Instance { get; private set; }
    private int anchor = 0; // assigned a value to determine which camera is on.
    public Camera[] cameras; // Access to cameras
    public AudioListener[] camAudio;// Access to AudioListeners coz it can be bug when you enabled false Cameras but not AudioListeners.

    private void Awake() 
    {
        for (int i = 0; i < camAudio.Length; i++)
        {
            camAudio[i] = cameras[i].GetComponent<AudioListener>(); // Access every AudioListener of cameras.
        }

        camAudio[1].enabled = false;    
        cameras[1].enabled =  false; // Disable second Camera so game'll start with Main Camera.

    }

    public void changeView()
    {
            cameras[anchor].enabled = false; // Disable main camera when pressed space. Will represent the second camera next time
            camAudio[anchor].enabled = false;
            anchor++;
            if (anchor >= cameras.Length) // It creates a loop because we control anchor.
            {
                anchor = 0 ;
            }

            cameras[anchor].enabled = true; // enabled second cam coz anchor increased. will represent the main camera next time
            camAudio[anchor].enabled = true;

            if(cameras[1].enabled)  EventManager.OnCamera01On.Invoke();
            else    EventManager.OnCamera00On.Invoke();
    }
}
