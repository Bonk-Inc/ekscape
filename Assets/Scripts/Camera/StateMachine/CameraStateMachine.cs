using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateMachine : StateMachine<CameraStateName>
{

    [SerializeField]
    private CameraStateName startState;

    [SerializeField]
    private CameraState[] defaultStates;

    private void Start()
    {
        for (int i = 0; i < defaultStates.Length; i++)
        {
            AddState(defaultStates[i].Name, defaultStates[i]);
        }
        SetState(startState);
    }
}
