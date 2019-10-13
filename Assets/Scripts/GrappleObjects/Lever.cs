using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IPullable
{
    [SerializeField]
    private Interactable interactable;

    [SerializeField]
    private Sprite[] leverState;

    private SpriteRenderer spriteRenderer;

    private bool currentValue = false;

    private void Start(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Pull()
    {
        currentValue = !currentValue;
        interactable?.Execute(currentValue); 

        spriteRenderer.sprite = currentValue ? leverState[1] : leverState[0];
    }
}
