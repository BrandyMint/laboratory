using System;
using UniRx;
using UnityEngine;

public class LessonManager : MonoBehaviour
{
    public static event Action<LessonStep> OnStepRun;

    public LessonStepList stepList;

    private LessonStep _currentStep;

    private void Awake()
    {
        GameManager.OnStepFinished += GameManager_OnStepFinished;
    }

    private void GameManager_OnStepFinished()
    {

        var nextStepIndex = stepList.Data.IndexOf(_currentStep) + 1;
        _currentStep = stepList.Data[nextStepIndex];

        Observable.Timer(System.TimeSpan.FromSeconds(2))
            .Subscribe(_ => { Debug.Log("After delay"); RunStep(_currentStep); });
    }

    private void Start()
    {
        _currentStep = stepList.Data[0];
        RunStep(_currentStep);
    }

    private void RunStep(LessonStep value)
    {
        OnStepRun?.Invoke(value);
    }
}
