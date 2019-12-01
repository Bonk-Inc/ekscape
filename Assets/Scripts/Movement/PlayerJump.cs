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

    [SerializeField, Header("Ground Check")]
    private BoxCollider2D boxCol;

    [SerializeField]
    private LayerMask layer;

    [SerializeField]
    private float sizeCheck = 0.3f;



    [SerializeField, Header("Jump Stats")]
    private float force;

    [SerializeField]
    private float landingWaitTime = 0.05f;

    [SerializeField, Header("Velocity Scales")]
    private float lowJumpVelocity;
    
    [SerializeField]
    private float fallVelocity;
    

    private Coroutine WaitForLandRoutine;

    public bool IsInAir => isInAir;

    public event Action OnJump;
    public event Action OnLand;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckInAir();
        HandleJump();
        //print(rb.velocity.y);
        //HandleGravity();
    }

    private void HandleJump(){
        
        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        if (IsInAir)
        {
            if (WaitForLandRoutine != null)
            {
                StopCoroutine(WaitForLandRoutine);
            }

            WaitForLandRoutine = StartCoroutine(JumpOnLand());
            return;
        }

        ExecuteJump();
    }

    private void ExecuteJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, force);
        OnJump?.Invoke();
    }

    private IEnumerator JumpOnLand()
    {
        float time = landingWaitTime;
        while(time > 0)
        {
            if (!isInAir) {
                ExecuteJump();
                yield break;
            }

            time -= Time.deltaTime;
            yield return null;
        }
    }

    private void CheckInAir(){
        var isInAir = !CheckGrounded();

        if (!isInAir && this.isInAir)
        {
            OnLand?.Invoke();
        }
        this.isInAir = isInAir;
    }
    
    private bool CheckGrounded(){
        Vector2 checkArea = new Vector2(boxCol.bounds.center.x , boxCol.bounds.center.y - boxCol.bounds.extents.y);
        Vector2 checkSize = new Vector2(boxCol.bounds.extents.x, sizeCheck);

        Collider2D checkBox = Physics2D.OverlapBox(checkArea, checkSize, boxCol.transform.rotation.y, layer);
        return checkBox != null;
    }

    private void HandleGravity(){
        
        if(rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity * fallVelocity * Time.deltaTime;
        else if(rb.velocity.y > 0 && !Input.GetButton(JumpAxis))
            rb.velocity += Vector2.up * Physics2D.gravity * lowJumpVelocity * Time.deltaTime;
    }
}
