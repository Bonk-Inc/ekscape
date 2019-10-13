using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueCheck : MonoBehaviour
{

    [SerializeField]
    private StartLastLevel level;

    private void Awake()
    {
        if (!level.HasLastLevel())
        {
            gameObject.SetActive(false);
        }   
    }
}
