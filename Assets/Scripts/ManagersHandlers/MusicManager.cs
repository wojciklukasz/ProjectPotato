using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<Audio> musicList;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if(!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = true;
        audioSource.ignoreListenerPause = true;
    }

    public void PlayMusic(string name)
    {
        Audio musicToPlay = musicList.Find(audio => audio.name == name);
        audioSource.clip = musicToPlay.audioClip;
        if(audioSource.isPlaying)
        {
            StopMusic();
        }
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
    
}
