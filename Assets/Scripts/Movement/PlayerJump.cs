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
    private BoxCollider2D boxCol;

    [SerializeField]
    private LayerMask layer;

    [SerializeField]
    private float force;

    [SerializeField]
    private float landingWaitTime = 0.05f;


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
        var isInAir = !CheckGrounded();

        if (!isInAir && this.isInAir)
        {
            OnLand?.Invoke();
        }
        this.isInAir = isInAir;
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

        Jump();
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        OnJump?.Invoke();
    }

    private IEnumerator JumpOnLand()
    {
        float time = landingWaitTime;
        while(time > 0)
        {
            if (!isInAir) {
                Jump();
                yield break;
            }

            time -= Time.deltaTime;
            yield return null;
        }
    }

    private bool CheckGrounded(){
        Vector2 checkArea = new Vector2(transform.position.x, transform.position.y - (boxCol.bounds.extents.y + 0.3f));
        Collider2D checkBox = Physics2D.OverlapBox(checkArea, Vector2.one, boxCol.transform.rotation.y, layer);
        return checkBox != null;
    }
}
