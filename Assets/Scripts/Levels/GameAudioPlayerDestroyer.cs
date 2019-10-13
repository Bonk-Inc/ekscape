using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioPlayerDestroyer : MonoBehaviour
{
    
    void Start()
    {
        if (PlayAudioPlayer.Insctance != null)
        {
            Destroy(PlayAudioPlayer.Insctance.gameObject);
        }
    }

}
