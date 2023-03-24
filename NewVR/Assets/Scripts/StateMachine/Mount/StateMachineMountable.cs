using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class StateMachineMountable
{
    public GameObject _base;
    public UnityEvent changeState = new UnityEvent();
    public UnityEvent updateUI = new UnityEvent();
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
                newState.updateName.AddListener(this.UpdateDisplay);
            }
        }
        if(currentStates.Count == 0)
        {
            _base.GetComponent<XRGrabInteractable>().enabled = true;
            _base.GetComponent<Rigidbody>().isKinematic = false;
        }
        UpdateDisplay();
        changeState.Invoke();
    }

    public void UpdateDisplay()
    {
        updateUI.Invoke();
    }

    public void Update()
    {
        foreach (StateMountable currentState in currentStates)
        {
            currentState.StateUpdate();
        }
    }
    override public string ToString()
    {
        string ret = "À réaliser :\n";
        foreach(StateMountable sm in currentStates)
        {
            ret += sm.ToString() + "\n";
        }
        return ret;
    }
}
