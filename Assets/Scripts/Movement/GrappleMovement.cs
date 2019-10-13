using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerWalking playerMovement;
    [SerializeField]
    private Transform playerPosition;
    
    public void StartGrappling(Transform hookedPosition, Action OnFinish = null){
        StartCoroutine(Grapple(hookedPosition, OnFinish));
    }

    private IEnumerator Grapple(Transform hookedPosition, Action OnFinish = null){
        playerMovement.CanWalk = false;
        yield return new WaitForSeconds(0.3f);
        while (Input.GetMouseButtonDown(0))
        {
            Vector2.MoveTowards(playerPosition.position, hookedPosition.position, 3);
            yield return null;
        }
        OnFinish?.Invoke();
        playerMovement.CanWalk = true;
    }

}
