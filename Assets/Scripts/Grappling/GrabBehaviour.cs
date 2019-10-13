using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehaviour : MonoBehaviour
{
    [SerializeField]
    private Grapple grapple;
    
    private void OnTriggerEnter2D(Collider2D col){
        switch (col.tag)
        {
            case "Enemy":
                Attack(col);
                break;
            case "Pushable":

                break;
            case "Pullable":
                col.GetComponent<IPullable>().Pull();
                break;
            case "WallRoof":

                break;
            default:
                break;
        }
    }

    private void Attack(Collider2D enemyCollider){
        Destroy(enemyCollider.gameObject);
    }
}
