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

    private void LessonManager_OnStepRun(LessonStep step)
    {
        switch (step.id)
        {
            case LessonStepID.step01:
                {
                    girlAnimator.SetBool("Speech", true);
                    soundController.PlaySound1(step.id, StepFinishedCallback);
                }
                break;
            case LessonStepID.step02:
                {
                    deviceManager.volumeDevice.SetActive(true, () =>
                    {
                        FinishStep(step);
                    });

                }
                break;
            case LessonStepID.step03:
                {
                    FinishStep(step);
                }
                break;
            case LessonStepID.step04:
                {
                    FinishStep(step);
                }
                break;
            case LessonStepID.step05:
                {
                    FinishStep(step);
                }
                break;
            case LessonStepID.step06:
                {
                    FinishStep(step);
                }
                break;
            case LessonStepID.step07:
                {
                    FinishStep(step);

                }
                break;
            case LessonStepID.step08:
                {
                    deviceManager.volumeDevice.SetActive(false, () =>
                    {
                        deviceManager.pitchDevice.SetActive(true, () =>
                        {
                            FinishStep(step);
                        });
                    });
                }
                break;
            case LessonStepID.step09:
                FinishStep(step);
                break;
            case LessonStepID.step10:
                FinishStep(step);
                break;
            case LessonStepID.step11:
                FinishStep(step);
                break;
            case LessonStepID.step12:
                FinishStep(step);
                break;
            case LessonStepID.step13:
                FinishStep(step);
                break;
            case LessonStepID.step14:
                {
                    girlAnimator.SetBool("Speech", true);
                    soundController.PlaySound1(step.id, () => { girlAnimator.SetBool("Speech", false); });

                    //Observable.Timer(System.TimeSpan.FromSeconds(step.actionTime))
                    //.Subscribe(_ => OnStepFinished?.Invoke());
                }
                break;
            default:
                break;
        }

    }

    void FinishStep(LessonStep step)
    {
        girlAnimator.SetBool("Speech", true);
        soundController.PlaySound1(step.id, () => { girlAnimator.SetBool("Speech", false); });

        Observable.Timer(System.TimeSpan.FromSeconds(step.actionTime))
        .Subscribe(_ => OnStepFinished?.Invoke());
    }

    void StepFinishedCallback()
    {
        girlAnimator.SetBool("Speech", false);

        OnStepFinished?.Invoke();
    }
}
