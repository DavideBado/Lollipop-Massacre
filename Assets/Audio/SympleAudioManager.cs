using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SympleAudioManager : MonoBehaviour {

    public static SympleAudioManager instance;

    [Header("Audio Sources")]
    public List<AudioSource> FXSources;
    public AudioSource MusicSources;
    

    [Header("Audio Clips Music")]
    public AudioClip MusicMenuClip;
    public AudioClip MusicWinningClip;

    [Header("Audio Clips FX")]
    public List<AudioClip> Clips = new List<AudioClip>();

    private void OnEnable()
    {
        transform.position = Camera.main.transform.position;
        SympleAudioManager.PlayFXClip += PlayFX;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    #region API

    public void PlayMenuMusic() {
        MusicSources.clip = MusicMenuClip;
        MusicSources.Play();
    }

    public void PlayWinningMusic() {
        foreach (AudioSource audioSource in FXSources)
        {
            audioSource.clip = null;
        }
        MusicSources.clip = MusicWinningClip;
        MusicSources.Play();
    }

    public void PlayFX(int currentClip) {
        foreach (AudioSource audioSource in FXSources)
        {
            if(audioSource == null || audioSource.isPlaying == false)
            {
                audioSource.clip = Clips[currentClip];
                audioSource.Play();
            }
        }

    }

    #endregion

    #region delegates
    public delegate void PlayClipDelegate(int clipIndex);
    public static PlayClipDelegate PlayFXClip;
    public static PlayClipDelegate PlayMusicClip;

    #endregion

    private void OnDisable()
    {
        SympleAudioManager.PlayFXClip -= PlayFX;
    }

}
