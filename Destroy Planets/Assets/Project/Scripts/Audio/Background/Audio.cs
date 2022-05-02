//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public static AudioSource backgroundMusic; //nothing does in this scrit but provide to change the values of music frorm another script. a reference basically.
    public static Audio audioObject = null;
  
    void Awake()
    {
        //backgroundMusic = this;
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
