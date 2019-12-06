using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : CameraState
{
    [SerializeField]
    private CameraZoomer zoomer;

    [SerializeField]
    private CameraFollow follow;

    [SerializeField]
    private ObjectPositionLerper positionHandler;

    [SerializeField]
    private float defaultZoom = 5;

    public override CameraStateName Name => CameraStateName.Follow;

    public override void EnterState(CameraStateName oldState)
    {
        positionHandler.MoveToTarget();
        zoomer.ZoomTo(defaultZoom, () => {
            positionHandler.StopMoving();
            follow.enabled = true;
        });
    }

    public override void CheckState(StateMachine<State<CameraStateName>, CameraStateName> stateMachine)
    {
        base.CheckState(stateMachine);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            stateMachine.SetState(CameraStateName.ZoomedOut);
        }
    }

    public override void LeaveState(CameraStateName newState)
    {
        follow.enabled = false;
        zoomer.StopZoom();
        positionHandler.StopMoving();
    }

}
