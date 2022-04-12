using System;
using UnityEngine;

/// <summary>
/// Holds and operates internal state events like Idle, Run, Fly etc.
/// This class is a scriptable object for easy drag and drop global reference
/// </summary>
[CreateAssetMenu(menuName = "Handlers/InternalStateEvents")]
public class InternalStateEvents : ScriptableObject
{
    [SerializeField] InternalState internalState = InternalState.Idle;

    Action onRun;
    Action onFly;
    Action onFail;
    Action onIdle;
    Action onWin;

    void OnEnable()
    {
        internalState = InternalState.Idle;
    }
    public void SetState(InternalState state)
    {
        if (internalState == state)
            return;

        internalState = state;

        switch (internalState)
        {
            case InternalState.Run: onRun?.Invoke(); break;
            case InternalState.Fly: onFly?.Invoke(); break;
            case InternalState.Fail: onFail?.Invoke(); break;
            case InternalState.Idle: onIdle?.Invoke(); break;
            case InternalState.Win: onWin?.Invoke(); break;
        }
    }
    public void SubscribeEvent(InternalState state, Action action)
    {
        switch (state)
        {
            case InternalState.Run: onRun += action; break;
            case InternalState.Fly: onFly += action; break;
            case InternalState.Fail: onFail += action; break;
            case InternalState.Idle: onIdle += action; break;
            case InternalState.Win: onWin += action; break;
        }
    }
    public void UnsubscribeEvent(InternalState state, Action action)
    {
        switch (state)
        {
            case InternalState.Run: onRun -= action; break;
            case InternalState.Fly: onFly -= action; break;
            case InternalState.Fail: onFail -= action; break;
            case InternalState.Idle: onIdle -= action; break;
            case InternalState.Win: onWin -= action; break;
        }
    }
}
