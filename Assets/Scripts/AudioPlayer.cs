using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooter")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 0.5f;

    [Header("Explosion Damage")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0f, 1f)] float explosionVolume = 0.5f;

    static AudioPlayer instance;

    private AudioClip currentAudioClip;

    private AudioSource audioSource;

    private bool isMusicPlaying;

    private void Awake ()
    {
        CreateSingleton();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start ()
    {
        isMusicPlaying = true;
    }

    private void CreateSingleton ()
    {
        if (instance !=null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayAudioClip (AudioClip clip, float volume)
    {
        if (clip != null)
        {
            currentAudioClip = clip;
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
        }
    }

    public void PlayShootingClip ()
    {
        PlayAudioClip(shootingClip, shootingVolume);
    }

    public void PlayExplosionClip ()
    {
        PlayAudioClip(explosionClip, explosionVolume);
    }

    public bool IsMusicPlaying () 
    {
        return isMusicPlaying;
    }

    public void Stop ()
    {
        // stop audio
        audioSource.Stop();
        isMusicPlaying = false;
    }

    public void FadeOut ()
    {
        // fade that bitch out some how
    }
    
}
