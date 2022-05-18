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
}
