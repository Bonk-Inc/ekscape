using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    private const string JumpAxis = "Jump";
    private const float velocityZero = 0.0003f;
    private Rigidbody2D rb;

    private bool isInAir = false;

    [SerializeField, Header("Debug Options")]
    private bool noCoyote = false;


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


    [SerializeField, Header("Coyote Vars")]
    private float waitForJumpTime = 1;    

    private Coroutine WaitForLandRoutine;

    public bool IsInAir => isInAir;

    public event Action OnJump;
    public event Action OnLand;

    private Coroutine coyoteRoutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckInAir();
        HandleJump();
        HandleGravity();
    }

    private void HandleJump(bool coyote = false){
        
        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        if (IsInAir && !coyote)
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

        if(coyoteRoutine != null)
            StopCoroutine(coyoteRoutine);
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
        else if(isInAir && !this.isInAir && rb.velocity.y <= velocityZero && !noCoyote)
        {
            coyoteRoutine = StartCoroutine(CoyoteHandler());
        }

        this.isInAir = isInAir;
    }

    private IEnumerator CoyoteHandler(){
        float timeLeft = waitForJumpTime;
        while(timeLeft >= 0){
            timeLeft -= Time.deltaTime;
            HandleJump(true);

            yield return null;
        }
    }

    private bool CheckGrounded(){
        Vector2 checkArea = new Vector2(boxCol.bounds.center.x , boxCol.bounds.center.y - boxCol.bounds.extents.y);
        Vector2 checkSize = new Vector2(boxCol.bounds.extents.x, sizeCheck);

        Collider2D checkBox = Physics2D.OverlapBox(checkArea, checkSize, boxCol.transform.rotation.y, layer);
        return checkBox != null;
    }

    private void HandleGravity(){
        if(CheckGrounded())
            return;        
        
        if(rb.velocity.y > velocityZero && !Input.GetButton(JumpAxis))
            rb.velocity += Vector2.up * Physics2D.gravity * lowJumpVelocity * Time.deltaTime;
    }
}
