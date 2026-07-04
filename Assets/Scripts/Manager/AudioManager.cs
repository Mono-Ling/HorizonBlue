using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingleMono<AudioManager>
{
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
}
