using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public int musicCount = 0;
    public void ControlMusic()
    {
        musicCount ++;

        if(musicCount % 2 != 0)     EventManager.OnMusicOff.Invoke();
        if(musicCount % 2 == 0)     EventManager.OnMusicOn.Invoke();

        if(musicCount >= 2)     musicCount = 0;
    }

    
    /*
    public int musicCount = 0;
    public int soundCount = 0;

    //public GrenadeSound grenadeSound;
    //public AudioSource grenade;

    void Awake()
    {
        //grenadeSound = gameObject.GetComponent<GrenadeSound>();
        //grenade = GrenadeSound.grenadeEffect;
        //GrenadeSound.grenadeEffect = grenade;
        //AudioSource grenade = GrenadeSound.grenadeEffect;
    }

    public void ChangeBackground()
    {
        musicCount ++;
        if(musicCount % 2 != 0)     Audio.backgroundMusic.Stop();
        if(musicCount % 2 == 0)     Audio.backgroundMusic.Play();
        if(musicCount >= 2)     musicCount = 0;
        
    }

    public void ControlSound()
    {
        //grenade = GrenadeSound.grenadeEffect;

        soundCount ++;
        if(soundCount % 2 != 0)     GrenadeSound.Instance.grenadeEffect.Stop();
        if(soundCount % 2 == 0)     GrenadeSound.Instance.grenadeEffect.Play();
        if(soundCount >= 2)     soundCount = 0;
        
    }*/
}
