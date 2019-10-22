using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class PitchDevice : MonoBehaviour
{
    public TextMeshProUGUI text;
    public RectTransform panel;

    private void Awake()
    {
        SoundReader02.OnAnalyzeSound += SoundReader02_OnAnalyzeSound;
        EventsManager.OnPitchDeviceSetActive += EventsManager_OnPitchDeviceSetActive;
    }

    private void Start()
    {


        panel.DOAnchorPosY(900, 0);
    }

    private void EventsManager_OnPitchDeviceSetActive(bool obj)
    {
        SetActive(obj);
    }

    private void SoundReader02_OnAnalyzeSound(float[] obj)
    {
        text.text = $"{obj[1].ToString("F0")} Гц";
    }

    private void OnDestroy()
    {
        SoundReader02.OnAnalyzeSound -= SoundReader02_OnAnalyzeSound;
        EventsManager.OnPitchDeviceSetActive -= EventsManager_OnPitchDeviceSetActive;
    }

    public void SetActive(bool value)
    {
        if (value)
        {
            panel.DOAnchorPosY(2.5f, 1);
        }
        else
        {
            panel.DOAnchorPosY(900, 1);
        }


    }
}