using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static event Action<bool> OnPitchDeviceSetActive;
    public static event Action<bool> OnVolumeDeviceSetActive;

    bool b1 = true, b2 = true;

    private void Start()
    {
        //PitchDeviceSetActive();
        //VolumeDeviceSetActive();
    }

    public void PitchDeviceSetActive()
    {
        OnPitchDeviceSetActive?.Invoke(b1);
        b1 = !b1;
    }

    public void VolumeDeviceSetActive()
    {
        OnVolumeDeviceSetActive?.Invoke(b2);
        b2 = !b2;
    }
}
