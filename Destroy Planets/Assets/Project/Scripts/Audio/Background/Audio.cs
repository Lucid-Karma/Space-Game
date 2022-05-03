//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public static Audio Instance { get; private set; }
    public static Audio audioObject = null;

    private AudioSource background;

    void Awake()
    {
        background = gameObject.GetComponent<AudioSource>();

        if( audioObject == null )
        {
            audioObject = this;
            DontDestroyOnLoad( this );
        }
        else if( this != audioObject )
        {
            Destroy( gameObject );
        }
    }

    void OnEnable()
    {
        EventManager.OnMusicOn.AddListener(PlayMusic);
        EventManager.OnMusicOff.AddListener(StopMusic);
    }
    void OnDisable()
    {
        EventManager.OnMusicOn.RemoveListener(PlayMusic);
        EventManager.OnMusicOff.RemoveListener(StopMusic);
    }

    public void PlayMusic()
    {
        background.Play();
    }
    public void StopMusic()
    {
        background.Stop();
    }
}
