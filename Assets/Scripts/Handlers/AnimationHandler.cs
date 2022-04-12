using UnityEngine;

/// <summary>
/// Handles race entry animations
/// </summary>
public class AnimationHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] InternalStateEvents iStateEvents;

    /// <summary>
    /// Caching animation hashes for better performance
    /// </summary>
    readonly int runHash = Animator.StringToHash(Helper.ANIM_RUNNING);
    readonly int flyHash = Animator.StringToHash(Helper.ANIM_FLY);
    readonly int idleHash = Animator.StringToHash(Helper.ANIM_IDLE);
    readonly int failHash = Animator.StringToHash(Helper.ANIM_FAIL);
    readonly int winHash = Animator.StringToHash(Helper.ANIM_WIN);

    /// <summary>
    /// Subscribe and Unsubscribe events
    /// </summary>
    void OnEnable()
    {
        if (iStateEvents == null) return;
        iStateEvents.SubscribeEvent(InternalState.Run, triggerRun);
        iStateEvents.SubscribeEvent(InternalState.Fly, triggerFly);
        iStateEvents.SubscribeEvent(InternalState.Fail, triggerFail);
        iStateEvents.SubscribeEvent(InternalState.Idle, triggerIdle);
        iStateEvents.SubscribeEvent(InternalState.Win, triggerWin);
    }

    void OnDisable()
    {
        if (iStateEvents == null) return;
        iStateEvents.UnsubscribeEvent(InternalState.Run, triggerRun);
        iStateEvents.UnsubscribeEvent(InternalState.Fly, triggerFly);
        iStateEvents.UnsubscribeEvent(InternalState.Fail, triggerFail);
        iStateEvents.UnsubscribeEvent(InternalState.Idle, triggerIdle);
        iStateEvents.UnsubscribeEvent(InternalState.Win, triggerWin);
    }

    /// <summary>
    /// Animation triggers
    /// </summary>
    void triggerRun()
    {
        if (animator == null) return;

        animator.SetTrigger(runHash);
    }
    void triggerFly()
    {
        if (animator == null) return;

        animator.SetTrigger(flyHash);
    }
    void triggerFail()
    {
        if (animator == null) return;

        animator.SetTrigger(failHash);
    }
    void triggerIdle()
    {
        if (animator == null) return;

        animator.SetTrigger(idleHash);
    }
    void triggerWin()
    {
        if (animator == null) return;

        animator.SetTrigger(winHash);
    }
}
