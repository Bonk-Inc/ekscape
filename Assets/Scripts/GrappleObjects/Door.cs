using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{   
    [SerializeField]
    private Sprite[] doorState;
    
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D doorCollider;
    
    private void Start(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        doorCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    public override void Execute(bool value = true)
    {
        spriteRenderer.sprite = value ? doorState[0] : doorState[1];
        doorCollider.enabled = !value;
    }
}
