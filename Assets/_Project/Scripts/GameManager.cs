using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public static event Action OnStepFinished;

    public SoundController soundController;
    public Animator girlAnimator;
    public DeviceManager deviceManager;

    private void Awake()
    {
        LessonManager.OnStepRun += LessonManager_OnStepRun;
    }

    private void LessonManager_OnStepRun(LessonStep obj)
    {
        switch (obj.id)
        {
            case LessonStepID.step01:
                {
                    girlAnimator.SetBool("Speech", true);
                    soundController.PlaySound1(obj.id, StepFinishedCallback);
                }
                break;
            case LessonStepID.step02:
                {
                    deviceManager.volumeDevice.SetActive(true, () =>
                    {
                        girlAnimator.SetBool("Speech", true);
                        soundController.PlaySound1(obj.id,()=> { girlAnimator.SetBool("Speech", false); });

                        Observable.Timer(System.TimeSpan.FromSeconds(4))
                        .Subscribe(_ => OnStepFinished?.Invoke());
                    });

                }
                break;
            case LessonStepID.step03:
                {
                    girlAnimator.SetBool("Speech", true);
                    soundController.PlaySound1(obj.id, () => { girlAnimator.SetBool("Speech", false); });

                    Observable.Timer(System.TimeSpan.FromSeconds(4))
                    .Subscribe(_ => OnStepFinished?.Invoke());
                }
                break;
            case LessonStepID.step04:
                {
                    girlAnimator.SetBool("Speech", true);
                    soundController.PlaySound1(obj.id, () => { girlAnimator.SetBool("Speech", false); });

                    Observable.Timer(System.TimeSpan.FromSeconds(4))
                    .Subscribe(_ => OnStepFinished?.Invoke());
                }
                break;
            case LessonStepID.step05:
                {
                    girlAnimator.SetBool("Speech", true);
                    soundController.PlaySound1(obj.id, () => { girlAnimator.SetBool("Speech", false); });

                    Observable.Timer(System.TimeSpan.FromSeconds(4))
                    .Subscribe(_ => OnStepFinished?.Invoke());
                }
                break;
            case LessonStepID.step06:
                {
                    girlAnimator.SetBool("Speech", true);
                    soundController.PlaySound1(obj.id, () => { girlAnimator.SetBool("Speech", false); });

                    Observable.Timer(System.TimeSpan.FromSeconds(4))
                    .Subscribe(_ => OnStepFinished?.Invoke());
                }
                break;
            case LessonStepID.step07:
                break;
            case LessonStepID.step08:
                break;
            case LessonStepID.step09:
                break;
            case LessonStepID.step10:
                break;
            case LessonStepID.step11:
                break;
            case LessonStepID.step12:
                break;
            default:
                break;
        }

    }

    void StepFinishedCallback()
    {
        girlAnimator.SetBool("Speech", false);

        OnStepFinished?.Invoke();
    }
}
