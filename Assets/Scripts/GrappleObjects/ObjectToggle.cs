using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToggle : Interactable
{   

    public override void Execute(bool value = true)
    {
        gameObject.SetActive(value);
    }
}
