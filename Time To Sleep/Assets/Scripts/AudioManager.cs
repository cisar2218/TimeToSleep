using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using static Unity.VisualScripting.Member;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    private bool canPlayAudio = true;

    public void PlayAudioClipNextFrame(int clipNumber, float volume = 1f)
    {
        if (canPlayAudio)
        {
            canPlayAudio = false;
            StartCoroutine(PlayAudioClip(clipNumber, volume));
        }
    }

    IEnumerator PlayAudioClip(int clipNumber, float clipVolume)
    {
        GameObject soundObject = new GameObject("PlayingAudio");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = audioClips[clipNumber];
        audioSource.volume = clipVolume;
        audioSource.Play();
        Destroy(soundObject, audioClips[clipNumber].length);
        canPlayAudio = true;
        yield return null;
    }
    [ContextMenu("Play Test Sound")]
    public void PlayTestSound()
    {
        PlayAudioClipNextFrame(3, 1f);
    }
}