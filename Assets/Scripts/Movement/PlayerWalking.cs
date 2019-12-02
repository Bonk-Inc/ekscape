using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerWalking : MonoBehaviour
{

    private const string MovementAxis = "Horizontal";
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxSpeed;

    public bool CanWalk { get; set; } = true;

    public Action<float> OnMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!CanWalk)
            return;

        var input = Input.GetAxis(MovementAxis);
        rb.AddForce(GetForce());
        OnMove?.Invoke(Input.GetAxis(MovementAxis));
    }
    
    private Vector2 GetForce(){
        var input = Input.GetAxisRaw(MovementAxis);
        print(Vector2.right * input * (100 * speed) * Time.fixedDeltaTime);
        return Mathf.Abs(rb.velocity.x) <= maxSpeed ? Vector2.right * input * (100 * speed) * Time.fixedDeltaTime : Vector2.zero;
    }

}
