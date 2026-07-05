using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingleMono<AudioManager>
{
    public AudioManager()
    {
        GameObject obj = new GameObject("MusicSource");
        obj.transform.SetParent(transform);
        _musicSource = obj.AddComponent<AudioSource>();
    }
    private AudioSource _musicSource;
    public AudioSource Play(AudioClip audioClip,bool isLoop)
    {
        GameObject obj = new GameObject(audioClip.name);
        obj.transform.SetParent(transform);
        AudioSource audioSource = obj.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = isLoop;
        audioSource.Play();
        if(!isLoop)
            StartCoroutine(DestroyAudioSource(audioSource));
        return audioSource;
    }
    private IEnumerator DestroyAudioSource(AudioSource audioSource)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        if (audioSource)
            Destroy(audioSource.gameObject);
    }
    private void SwitchMusic(AudioClip audio)
    {
        if(!_musicSource)
        {
            Debug.LogError("【空引用】 _musicSource is null");
            return;
        }
        _musicSource.clip = audio;
        _musicSource.Play();
    }
}
