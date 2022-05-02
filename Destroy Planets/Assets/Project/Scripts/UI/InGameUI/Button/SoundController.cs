using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public int musicCount = 0;
    public int soundCount = 0;
    public void ChangeBackground()
    {
        musicCount ++;
        if(musicCount % 2 != 0)     Audio.backgroundMusic.Stop();
        if(musicCount % 2 == 0)     Audio.backgroundMusic.Play();
        
    }

    public void ControlSound()
    {
        soundCount ++;
        if(soundCount % 2 != 0)     GrenadeSound.grenadeEffect.Stop();
        if(soundCount % 2 == 0)     GrenadeSound.grenadeEffect.Play();
        
    }
}
