using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerHitHandler : MonoBehaviour
{

    private Health health;
    private Rigidbody2D rb;

    [SerializeField]
    private float force = 2;

    [SerializeField]
    private PlayerWalking movement;

    private void Awake()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Hit(Collision2D collision, GameObject other)
    {
        health.AddHealth(-1);
        var x = transform.position.x - other.transform.position.x;
        x /= Mathf.Abs(x);
        var y = 2;
        var dir = new Vector2(x, y);
        rb.AddForce(dir.normalized * force, ForceMode2D.Impulse);
        StartCoroutine(DisableMovementInAir());
    }

    private IEnumerator DisableMovementInAir()
    {
        movement.enabled = false;
        while (Mathf.Abs(rb.velocity.y) > 0.01f)
        {
            yield return null;
        }
        movement.enabled = true;
    }


}
