using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip backgroundM;
    public AudioClip backgroundM2;
    public AudioClip playerHit;
    public AudioClip playerFire;
    public AudioClip enemyHit;

    public static AudioManager Instance;

    public AudioClip[] songs;
    private int currentSongIndex = 0;

    private void Start()
    {
        PlayNextSong();
    }
    private void Awake()
    {
        if(Instance == null)
        {
            // If instance doesn't exist, set it to this instance
            Instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this object when loading new scenes
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    void PlayNextSong()
    {
        musicSource.clip = songs[currentSongIndex];
        musicSource.Play();
        currentSongIndex = (currentSongIndex + 1) % songs.Length; // Loop back to the beginning if we reach the end
    }

    private void Update()
    {
        if (!musicSource.isPlaying)
        {
            PlayNextSong();
        }
    }
}
