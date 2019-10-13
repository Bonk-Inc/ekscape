using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IPushable
{
    [SerializeField]
    private Interactable[] interactables;

    [SerializeField]
    private Sprite[] leverState;

    private SpriteRenderer spriteRenderer;

    private bool currentValue = false;

    private void Start(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Push()
    {
        currentValue = !currentValue;
        foreach (Interactable interactable in interactables)
        {
            interactable?.Execute(currentValue); 
        }

        spriteRenderer.sprite = currentValue ? leverState[1] : leverState[0];
    }
}
