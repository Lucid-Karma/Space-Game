using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public static SwitchCamera Instance { get; private set; }
    private int anchor = 0; // assigned a value to determine which camera is on.
    public Camera[] cameras; // Access to cameras
    public AudioListener[] camAudio;// Access to AudioListeners coz it can be bug when you enabled false Cameras but not AudioListeners.

    //public GameObject crosshair;

    public static bool isCamera1Active;

    private void Awake() 
    {
        for (int i = 0; i < camAudio.Length; i++)
        {
            camAudio[i] = cameras[i].GetComponent<AudioListener>(); // Access every AudioListener of cameras.
        }

        camAudio[1].enabled = false;    
        cameras[1].enabled =  false; // Disable second Camera so game'll start with Main Camera.

        //crosshair.GetComponent<GameObject>();
        //crosshair.SetActive(false);
    }

    void Update()
    {
        changeView();
    }

    private void changeView()
    {
        if(Input.GetKeyDown("space"))
        {
            cameras[anchor].enabled = false; // Disable main camera when pressed space. Will represent the second camera next time
            camAudio[anchor].enabled = false;
            //crosshair.SetActive(true);
            anchor++;
            isCamera1Active = false;
            if (anchor >= cameras.Length) // It creates a loop because we control anchor.
            {
                anchor = 0 ;
            }

            cameras[anchor].enabled = true; // enabled second cam coz anchor increased. will represent the main camera next time
            camAudio[anchor].enabled = true;
            isCamera1Active = true;
            //crosshair.SetActive(false);
        }
    }
}
