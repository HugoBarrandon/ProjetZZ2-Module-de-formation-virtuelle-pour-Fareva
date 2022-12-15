using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateMachineMountable
{
    public UnityEvent changeState = new UnityEvent();
    public List<StateMountable> currentStates = new List<StateMountable>();

    public void ChangeState(StateMountable oldState)
    {
        oldState.Exit();
        currentStates.Remove(oldState);
        foreach (StateMountable newState in oldState.GetNextStates())
        {
            if (newState._nbDependances == 0)
            {
                currentStates.Add(newState);
                newState.Enter();
                newState.changeEvent.AddListener(this.ChangeState);
            }
        }
        changeState.Invoke();
    }

    public void Update()
    {
        foreach (StateMountable currentState in currentStates)
        {
            currentState.StateUpdate();
        }
    }
}
