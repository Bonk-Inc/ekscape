using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State <StateName> : MonoBehaviour
    where StateName : System.Enum
{

    public abstract StateName Name { get; }

    public virtual void EnterState(StateName oldState) { }
    public virtual void UpdateState() { }
    public virtual void CheckState(StateMachine<State<StateName>, StateName> stateMachine) { }
    public virtual void LeaveState(StateName newState) { }
}
