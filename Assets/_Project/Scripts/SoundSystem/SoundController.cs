using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoSingleton<SoundController>
{
    public SoundLibrary SoundLibrary => soundLibrary;

    [SerializeField] SoundLibrary soundLibrary;
    [SerializeField] AudioSource audioSource;

    public void PlaySound(LessonStepID soundName)
    {
        Sound sound = soundLibrary.Data.Find(item => item.lessonStepID == soundName);
        audioSource.volume = sound.volume;
        //audioSource.PlayOneShot(sound.audioClip);

        foreach (var item in sound.audioClips)
        {
            audioSource.PlayOneShot(item); 
        }
    }
}