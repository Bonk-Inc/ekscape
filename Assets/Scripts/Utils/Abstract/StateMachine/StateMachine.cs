using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine <StateType, StateName> : MonoBehaviour
    where StateName : Enum
    where StateType : State<StateName>
{

    private Dictionary<StateName, StateType> states = new Dictionary<StateName, StateType>();
    private StateName currentState;

    public StateName CurrentStateName => currentState;
    public StateType CurrentState => states[currentState];

    public virtual void SetState(StateName newState)
    {
        if (!states.ContainsKey(newState))
            return;

        states[currentState]?.LeaveState(newState);
        states[newState].EnterState(currentState);

        currentState = newState;
    }

    public virtual void AddState(StateName name, StateType state)
    {
        if (!states.ContainsKey(name))
        {
            states.Add(name, state);
        }
        else
        {
            states[name] = state;
        }
        
    }

    private void Update()
    {
        states[currentState].UpdateState();
        states[currentState].CheckState(this as StateMachine<State<StateName>, StateName>);
    }

}

public abstract class StateMachine<StateName> : StateMachine<State<StateName>, StateName>
    where StateName : System.Enum
{

}