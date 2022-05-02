using UnityEngine;
using UnityEngine.Audio;

public class GrenadeSound : MonoBehaviour
{
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
}
