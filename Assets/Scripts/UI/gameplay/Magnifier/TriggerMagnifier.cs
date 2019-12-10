using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMagnifier : MonoBehaviour
{
    [SerializeField]
    private Magnifiable magnifiable;

    [SerializeField]
    private string acceptedTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(acceptedTag))
            return;

        Magnifier.Instance.MagnifyFadeIn(magnifiable);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(acceptedTag))
            return;

        Magnifier.Instance.MagnifyFadeOut();
    }



}
