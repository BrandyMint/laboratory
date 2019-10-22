﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PitchDevice : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        SoundReader02.OnAnalyzeSound += SoundReader02_OnAnalyzeSound;
    }

    private void SoundReader02_OnAnalyzeSound(float[] obj)
    {
        text.text = $"{obj[1].ToString("F0")} Гц";
    }

    private void OnDestroy()
    {
        SoundReader02.OnAnalyzeSound -= SoundReader02_OnAnalyzeSound;
    }
}