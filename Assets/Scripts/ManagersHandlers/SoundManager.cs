using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<Audio> audioList;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if (!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    public void PlayAudio(string name)
    {
        Audio audioToPlay = audioList.Find(audio => audio.name == name);
        audioSource.clip = audioToPlay.audioClip;
        if (audioSource.isPlaying)
        {
            StopAudio();
        }
        audioSource.Play();
    }


    public void StopAudio()
    {
        audioSource.Stop();
    }
}
