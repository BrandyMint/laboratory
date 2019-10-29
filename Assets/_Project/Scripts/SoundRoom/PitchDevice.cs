using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using Bluehorse.Game.Messages;

public class PitchDevice : MonoBehaviour
{
    public TextMeshProUGUI text;
    public RectTransform panel;

    private void Awake()
    {
        MessageBus.OnAnalyzeSound.Receive += SoundReader02_OnAnalyzeSound;
        //SoundReader02.OnAnalyzeSound += SoundReader02_OnAnalyzeSound;
        //EventsManager.OnPitchDeviceSetActive += EventsManager_OnPitchDeviceSetActive;
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
        MessageBus.OnAnalyzeSound.Receive += SoundReader02_OnAnalyzeSound;
        //SoundReader02.OnAnalyzeSound -= SoundReader02_OnAnalyzeSound;
        //EventsManager.OnPitchDeviceSetActive -= EventsManager_OnPitchDeviceSetActive;
    }

    public void SetActive(bool value, TweenCallback callback = null)
    {
        if (value)
        {
            panel.DOAnchorPosY(2.5f, 1).OnComplete(callback); ;
        }
        else
        {
            panel.DOAnchorPosY(900, 1).OnComplete(callback); ;
        }


    }
}