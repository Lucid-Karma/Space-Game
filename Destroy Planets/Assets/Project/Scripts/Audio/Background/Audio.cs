//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    private static Audio audioObject = null;
  
    void Awake()
    {
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

    /*
    public AudioSource backGround;

    void Awake()
    {
        backGround = gameObject.AddComponent<AudioSource>();
    }

    void OnEnable()
    {
        EventManager.OnGameStart.AddListener(PlaySound);
        EventManager.OnGameEnd.AddListener(StopSound);

    }
    void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(PlaySound);
        EventManager.OnGameEnd.RemoveListener(StopSound);
    }

    public void PlaySound()
    {
        backGround.Play();
    }

    public void StopSound()
    {
        backGround.Stop();
    }
    */
}
