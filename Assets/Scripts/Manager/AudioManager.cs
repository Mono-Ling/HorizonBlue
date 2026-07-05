using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingleMono<AudioManager>
{
    public override void Init()
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
        audioSource.volume = 1;
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
    public void SwitchMusic(AudioClip audio)
    {
        if(!_musicSource)
        {
            Debug.LogError("【空引用】 _musicSource is null");
            return;
        }
        _musicSource.Stop();
        _musicSource.clip = audio;
        _musicSource.loop = true;
        _musicSource.volume = 1;
        _musicSource.Play();
    }
    public void SwitchMusic(string path)
    {
        var audioClip = Resources.Load<AudioClip>($"Music/{path}");
        if(!audioClip)
        {
            Debug.LogError("【空引用】音频加载失败");
            return;
        }
        SwitchMusic(audioClip);
    }
    public AudioSource Play(string path,bool isLoop)
    {
        var audioClip = Resources.Load<AudioClip>($"Music/{path}");
        if(!audioClip)
        {
            Debug.LogError("【空引用】音频加载失败");
            return null;
        }
        return Play(audioClip,isLoop);
    }
    public void StopMusic()
    {
        _musicSource.Stop();
    }
}
