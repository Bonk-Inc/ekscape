using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTitleController : MonoBehaviour
{



    [SerializeField]
    private LevelTitle title;

    [SerializeField]
    private bool disableGameobjectAfterShow;

    private void Start()
    {
        title.Show(GetFinishAction());

        //TODO add to saved (now done using playerprefs
        
    }

    private Action GetFinishAction()
    {
        if (disableGameobjectAfterShow)
            return () => gameObject.SetActive(false);

        return null;
    }


}
