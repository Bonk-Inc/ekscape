using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{

    private const string mvementAnimationKey = "IsWalking";

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private PlayerWalking playerMovement;

    private void Awake()
    {
         playerMovement.OnMove += HandleMovementAnimation;
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


}
