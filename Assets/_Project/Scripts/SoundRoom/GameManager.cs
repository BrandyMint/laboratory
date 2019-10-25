using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public static event Action OnStepFinished;
    public static event Action<bool> OnSpeechActive;
    public static event Action OnLessonStart;

    public static GameObject instance;

    public SoundController soundController;
    public GameObject girlTemplate;

    public DeviceManager deviceManager;
    private CompositeDisposable _disposables;

    private void Awake()
    {
        LessonManager.OnStepRun += LessonManager_OnStepRun;
    }

    private void OnEnable()
    {
        _disposables = new CompositeDisposable();
    }

    private void Start()
    {
        CreateGirl();
        OnLessonStart?.Invoke();
    }

    public void StartLesson()
    {
        OnLessonStart?.Invoke();
    }

    private void OnDisable()
    {
        if (_disposables != null)
        {
            _disposables.Dispose();
        }
    }

    private void LessonManager_OnStepRun(LessonStep step)
    {
        switch (step.id)
        {
            case LessonStepID.step01:
                {
                    RunStep(step);
                }
                break;
            case LessonStepID.step02:
                {
                    deviceManager.volumeDevice.SetActive(true, () =>
                    {
                        Observable.Timer(System.TimeSpan.FromSeconds(1))
                                  .Subscribe(_ => RunStep(step))
                                  .AddTo(_disposables);
                    });

                }
                break;
            case LessonStepID.step03:
                {
                    RunStep(step);
                }
                break;
            case LessonStepID.step04:
                {
                    RunStep(step);
                }
                break;
            case LessonStepID.step05:
                {
                    RunStep(step);
                }
                break;
            case LessonStepID.step06:
                {
                    RunStep(step);
                }
                break;
            case LessonStepID.step07:
                {
                    RunStep(step);
                }
                break;
            case LessonStepID.step08:
                {
                    deviceManager.volumeDevice.SetActive(false, () =>
                    {
                        deviceManager.pitchDevice.SetActive(true, () =>
                        {
                            Observable.Timer(System.TimeSpan.FromSeconds(1))
                                  .Subscribe(_ => RunStep(step))
                                  .AddTo(_disposables);
                        });
                    });
                }
                break;
            case LessonStepID.step09:
                RunStep(step);
                break;
            case LessonStepID.step10:
                RunStep(step);
                break;
            case LessonStepID.step11:
                RunStep(step);
                break;
            case LessonStepID.step12:
                RunStep(step);
                break;
            case LessonStepID.step13:
                RunStep(step);
                break;
            case LessonStepID.step14:
                {
                    OnSpeechActive?.Invoke(true);
                    soundController.PlaySound1(step.id, () => { OnSpeechActive?.Invoke(false); });
                }
                break;
            default:
                break;
        }
    }

    void CreateGirl()
    {
        Instantiate(girlTemplate);

    }

    void RunStep(LessonStep step)
    {
        OnSpeechActive?.Invoke(true);

        SoundController.Instance.PlaySound1(step.id, () =>
        {
            OnSpeechActive?.Invoke(false);

            Observable.Timer(System.TimeSpan.FromSeconds(step.actionTime))
                      .Subscribe(_ => OnStepFinished?.Invoke())
                      .AddTo(_disposables);
        });
    }
}