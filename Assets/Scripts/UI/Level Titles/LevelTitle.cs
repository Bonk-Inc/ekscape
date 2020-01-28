using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelTitle : MonoBehaviour
{

    public void Show(Action onFinishedShowing = null)
    {
        StartCoroutine(ShowLevelTitle(onFinishedShowing));
    }
    protected abstract IEnumerator ShowLevelTitle(Action onFinished);
    
}
