using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : State
{
    private List<T> currentStates = new List<T>();
    
    public StateMachine()
    {

    }

    public void ChangeState(State oldState)
    {
        oldState.Exit();
        foreach (T newState in oldState.GetNextStates())
        {
            if (newState._nbDependances == 0)
            {
                currentStates.Add(newState);
                newState.Enter();
            }
        }
    }

    public void Update()
    {
        foreach(T currentState in currentStates)
        {
            currentState.StateUpdate();
        }
    }


}
