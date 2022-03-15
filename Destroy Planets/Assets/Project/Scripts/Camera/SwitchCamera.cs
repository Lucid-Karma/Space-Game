using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    private int anchor = 0;
    public Camera[] cameras;
    public AudioListener[] cams;

    private void Awake() 
    {
        for (int i = 0; i < cams.Length; i++)
        {
            cams[i] = cameras[i].GetComponent<AudioListener>();
        }

        cams[1].enabled = false;
        cameras[1].enabled =  false; 
    }

    void Update()
    {
        changeView();
    }

    private void changeView()
    {
        if(Input.GetKeyDown("space"))
        {
            cameras[anchor].enabled = false;
            cams[anchor].enabled = false;
            anchor++;
            if (anchor >= cameras.Length)
            {
                anchor = 0 ;
            }

            cameras[anchor].enabled = true;
            cams[anchor].enabled = true;
        }
    }
}
