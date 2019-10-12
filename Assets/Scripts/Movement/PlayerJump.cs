using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    private const string JumpAxis = "Jump";
    private Rigidbody2D rb;

    [SerializeField]
    private float force;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || Mathf.Abs(rb.velocity.y) > 0.01f)
            return;

        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
}
