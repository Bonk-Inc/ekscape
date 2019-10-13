using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinscreenOpener : MonoBehaviour
{

    [SerializeField]
    private GameObject winScreen;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || !Input.GetKeyDown(KeyCode.W))
            return;


        winScreen.SetActive(true);
    }
}
