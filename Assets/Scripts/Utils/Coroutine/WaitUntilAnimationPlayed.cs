using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUntilAnimationPlayed : CustomYieldInstruction
{
    public override bool keepWaiting => CheckKeepWaiting();

    private Animator animator;
    private int nameHash;
    private bool waitForStart;
    private int layer;

    private bool started = false; 


    public WaitUntilAnimationPlayed(Animator animator, string animationName, bool waitForStart = true, int layer = 0) 
        : this(animator, Animator.StringToHash(animationName), waitForStart, layer) { }

    public WaitUntilAnimationPlayed(Animator animator, int nameHash, bool waitForStart = true, int layer = 0)
    {
        this.animator = animator;
        this.nameHash = nameHash;
        this.waitForStart = waitForStart;
        this.layer = layer;
    }

    private bool CheckKeepWaiting()
    {
        bool isAnimPlaying = IsAnimationPlaying(nameHash);

        if (!waitForStart)
            return isAnimPlaying;

        if (!isAnimPlaying && started)
            return false;

        if (isAnimPlaying && !started)
            started = true;

        return true;
    }

    private bool IsAnimationPlaying(int namehash)
    {
        return animator.GetCurrentAnimatorStateInfo(layer).shortNameHash == namehash;
    }
    
}
