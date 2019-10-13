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

    public bool CanWalk { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var input = Input.GetAxis(MovementAxis);

        rb.position += Vector2.right * input * speed * Time.fixedDeltaTime;
        
    }


}
