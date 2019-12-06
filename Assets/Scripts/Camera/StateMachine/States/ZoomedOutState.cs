using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomedOutState : CameraState
{

    [SerializeField]
    private CameraZoomHandler zoomHandler;

    public override CameraStateName Name => CameraStateName.ZoomedOut;

    public override void EnterState(CameraStateName oldState)
    {
        base.EnterState(oldState);
        zoomHandler.StartZoom();
    }

    public override void CheckState(StateMachine<State<CameraStateName>, CameraStateName> stateMachine)
    {
        base.CheckState(stateMachine);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            stateMachine.SetState(CameraStateName.Follow);
        }
    }

    public override void LeaveState(CameraStateName newState)
    {
        base.LeaveState(newState);
        zoomHandler.StopZoom();
    }
}
