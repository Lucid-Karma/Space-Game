using UnityEngine;
using UnityEngine.Audio;

public class GrenadeSound : MonoBehaviour
{
    public AudioSource grenadeEffect;

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
        Debug.Log("able to hear");
    }
}
