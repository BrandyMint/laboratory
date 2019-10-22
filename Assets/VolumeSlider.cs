using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;


    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Start()
    {
        SoundReader02.OnAnalyzeSound += SoundReader02_OnAnalyzeSound;
    }

    private void SoundReader02_OnAnalyzeSound(float[] obj)
    {
        //text.text = $"{obj[1]} Гц";

        slider.value = obj[0];
    }

    private void OnDestroy()
    {
        SoundReader02.OnAnalyzeSound -= SoundReader02_OnAnalyzeSound;
    }
}
