using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class VolumeDevice : MonoBehaviour
{
    public RectTransform panel;
    private Slider _slider;

    private void Awake()
    {
        SoundReader02.OnAnalyzeSound += SoundReader02_OnAnalyzeSound;
        EventsManager.OnVolumeDeviceSetActive += EventsManager_OnVolumeDeviceSetActive;

        _slider = GetComponentInChildren<Slider>();
    }

    private void EventsManager_OnVolumeDeviceSetActive(bool obj)
    {
        SetActive(obj);
    }

    private void OnDestroy()
    {
        SoundReader02.OnAnalyzeSound -= SoundReader02_OnAnalyzeSound;
        EventsManager.OnVolumeDeviceSetActive -= EventsManager_OnVolumeDeviceSetActive;
    }

    private void SoundReader02_OnAnalyzeSound(float[] obj)
    {
        _slider.value = Mathf.Lerp(_slider.value, obj[0], 2 * Time.deltaTime);
    }

    public void SetActive(bool value)
    {
        if (value)
        {
            panel.DOAnchorPosX(-233, 1);
        }
        else
        {
            panel.DOAnchorPosX(-1685, 1);
        }


    }
}
