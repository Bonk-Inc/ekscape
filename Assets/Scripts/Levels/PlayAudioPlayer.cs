using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioPlayer : MonoBehaviour
{

    private static PlayAudioPlayer instance;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
        instance = this;
    }


}
