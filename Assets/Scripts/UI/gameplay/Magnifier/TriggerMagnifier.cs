using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMagnifier : MonoBehaviour
{
    [SerializeField]
    private Magnifiable magnifiable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Magnifier.Instance.MagnifyFade(magnifiable);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Magnifier.Instance.StopMagnifyAlpha();
    }



}
