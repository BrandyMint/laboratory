using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public SoundLibrary SoundLibrary => soundLibrary;

    [SerializeField] SoundLibrary soundLibrary;
    [SerializeField] AudioSource audioSource;

    public void PlaySound(LessonStepID soundName, Action callback = null)
    {
        Sound sound = soundLibrary.Data.Find(item => item.lessonStepID == soundName);
        audioSource.volume = sound.volume;
        //audioSource.PlayOneShot(sound.audioClip);

        foreach (var item in sound.audioClips)
        {
            audioSource.PlayOneShot(item);
        }
    }

    public void PlaySound1(LessonStepID soundName, Action callback = null)
    {
        StartCoroutine(PlaySoundRoutine(soundName, callback));
    }

    public IEnumerator PlaySoundRoutine(LessonStepID soundName, Action callback = null)
    {
        Sound sound = soundLibrary.Data.Find(item => item.lessonStepID == soundName);
        audioSource.volume = sound.volume;
        //audioSource.PlayOneShot(sound.audioClip);

        foreach (var item in sound.audioClips)
        {
            audioSource.PlayOneShot(item);

            yield return new WaitWhile(() => audioSource.isPlaying);
        }

        callback();
    }
}