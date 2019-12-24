using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedLevelTitle : LevelTitle
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string animationStateName = "Show", triggerName = "show";

    protected override IEnumerator ShowLevelTitle(Action onFinished)
    {
        animator.SetTrigger(triggerName);
        yield return new WaitUntilAnimationPlayed(animator, animationStateName);
        onFinished?.Invoke();
    }
}
