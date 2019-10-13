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
        Debug.Log(input);
        rb.position += Vector2.right * input * speed * Time.fixedDeltaTime;

        
        OnMove?.Invoke(Input.GetAxis(MovementAxis));

    }


}
