using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{

    private const string mvementAnimationKey = "IsWalking";
    private const string jumpAnimationKey = "IsJumping";
    private const string jumpTriggerAnimationKey = "Jump";
    private const string inAirAnimationKey = "InAir";

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private PlayerWalking playerMovement;

    [SerializeField]
    private PlayerJump playerJump;

    private void Awake()
    {
        playerMovement.OnMove += HandleMovementAnimation;
        playerJump.OnJump += HandleJumpAnimation;
    }

    private void Update()
    {
        animator.SetBool(inAirAnimationKey, playerJump.IsInAir);
    }

    private void HandleMovementAnimation(float input)
    {
        if (Mathf.Approximately(input, 0))
        {
            animator.SetBool(mvementAnimationKey, false);
        }
        else
        {
            animator.SetBool(mvementAnimationKey, true);
            var yRotation = input > 0 ? 0 : 180;
            var playerRot = transform.rotation.eulerAngles;
            playerRot.y = yRotation;
            transform.rotation = Quaternion.Euler(playerRot);
        }
    }


    private void HandleJumpAnimation()
    {
        animator.SetTrigger(jumpTriggerAnimationKey);
    }

}
