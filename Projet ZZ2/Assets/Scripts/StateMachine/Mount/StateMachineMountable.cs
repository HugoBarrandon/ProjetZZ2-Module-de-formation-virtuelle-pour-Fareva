using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineMountable
{
    private List<StateMountable> currentStates = new List<StateMountable>();

    public void ChangeState(StateMountable oldState)
    {
        oldState.Exit();
        foreach (StateMountable newState in oldState.GetNextStates())
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
        foreach (StateMountable currentState in currentStates)
        {
            currentState.StateUpdate();
        }
    }
}
