using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    private const string JumpAxis = "Jump";
    private Rigidbody2D rb;

    private bool isInAir = false;

    [SerializeField]
    private float force;

    public bool IsInAir => isInAir;

    public event Action OnJump;
    public event Action OnLand;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        var isInAir = Mathf.Abs(rb.velocity.y) > 0;

        if (!isInAir && this.isInAir)
        {
            OnLand?.Invoke();
        }
        this.isInAir = isInAir;
        if (!Input.GetKeyDown(KeyCode.Space) || isInAir)
            return;

        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        OnJump?.Invoke();
    }
}
