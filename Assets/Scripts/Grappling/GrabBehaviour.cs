using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehaviour : MonoBehaviour {
    [SerializeField]
    private Grapple grapple;
    [SerializeField]
    private GrappleMovement grappleMovement;

    private void OnTriggerEnter2D(Collider2D col) {
        switch (col.tag) {
            case "Enemy":
                Attack(col);
                break;
            case "Pushable":
                col.GetComponent<IPushable>().Push();
                break;
            case "WallRoof":
                grapple.StopRoutine();
                grappleMovement.StartGrappling(gameObject.transform, grapple.ClearPositionCount);
                break;
            default:
                break;
        }
    }

    private void Attack(Collider2D enemyCollider) {
        Destroy(enemyCollider.gameObject);
    }
}