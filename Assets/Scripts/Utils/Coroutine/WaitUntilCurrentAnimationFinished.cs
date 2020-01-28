using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUntilCurrentAnimationFinished : WaitUntilAnimationPlayed
{
    public WaitUntilCurrentAnimationFinished(Animator animator, int layer = 0) 
        : base (animator, animator.GetCurrentAnimatorStateInfo(0).shortNameHash, false, layer){}

}
