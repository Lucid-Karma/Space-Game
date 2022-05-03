using UnityEngine;
using UnityEngine.Audio;

public class GrenadeSound : MonoBehaviour
{
    public static GrenadeSound Instance { get; private set; }
    public static AudioSource grenadeEffect;

    void Awake()
    {
        grenadeEffect = gameObject.AddComponent<AudioSource>();
    }
    void OnEnable()
    {
        EventManager.OnPreDestroy.AddListener(PlayFX);
    }
    void OnDisable()
    {
        EventManager.OnPreDestroy.RemoveListener(PlayFX);
    }
    public void PlayFX()
    {
        grenadeEffect.Play();
    }

    public int soundCount = 0;
    public void ControlFX()
    {
        soundCount ++;
        if(soundCount % 2 != 0)
        {
            FindObjectOfType<AudioManager>().Stop("ShootingFX");
            Debug.Log("stop");
        }        
        else if(soundCount % 2 == 0)     AudioManager.isSoundOn = true;

        if(soundCount >= 2)     soundCount = 0;
    }
}
