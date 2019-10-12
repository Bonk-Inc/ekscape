using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private const string playerTag = "Player";

    [SerializeField]
    private float force = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(playerTag))
            return;

        var other = collision.gameObject;
        other.GetComponent<PlayerHitHandler>().Hit(collision, gameObject);
    }

}
