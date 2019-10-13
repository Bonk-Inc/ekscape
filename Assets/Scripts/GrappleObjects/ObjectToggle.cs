using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToggle : Interactable
{   

    [SerializeField]
    private bool normal = true;

    public override void Execute(bool value = true)
    {
        if(normal)
            gameObject.SetActive(value);
        else
            gameObject.SetActive(!value);
    }
}
