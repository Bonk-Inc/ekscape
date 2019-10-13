using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Grapple grapple;
 
    private PlayerWalking playerMovement;
    private Rigidbody2D playerRigid;
    private Transform playerPosition;

    private void Awake(){
        playerPosition = player.transform;
        playerMovement = player.GetComponent<PlayerWalking>();
        playerRigid = player.GetComponent<Rigidbody2D>();
    }    
    public void StartGrappling(Transform hookedPosition, Action OnFinish = null){
        StartCoroutine(Grapple(hookedPosition, OnFinish));
    }

    private IEnumerator Grapple(Transform hookedPosition, Action OnFinish = null){
        playerMovement.CanWalk = false;
        float oldGravity = playerRigid.gravityScale;
        playerRigid.velocity = Vector3.zero;
        playerRigid.gravityScale = 0;
        
        yield return new WaitForSeconds(0.3f);
        var distance = Vector2.Distance(playerRigid.position, hookedPosition.position);
        while (Input.GetMouseButton(0) && distance >= 1.1f)
        {
            playerRigid.position = Vector2.MoveTowards(playerRigid.position, hookedPosition.position, 0.4f);
            distance = Vector2.Distance(playerRigid.position, hookedPosition.position);
            grapple.SetLine(hookedPosition.position);
            yield return null;
        }
        playerMovement.CanWalk = true;
        playerRigid.gravityScale = oldGravity;
        OnFinish?.Invoke();
    }

}
