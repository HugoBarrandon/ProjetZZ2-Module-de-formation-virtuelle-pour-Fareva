using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepMount : State
{

    public StateEvent changeEvent = new StateEvent();
    public Mountable _aDeplacer;
    public Mountable _destination;

    protected StateMachine<StepMount> stateMachine;

    public List<State> _nextSteps = new List<State>();

    public void initDependances()
    {
        foreach(StepMount sm in _nextSteps)
        {
            sm._nbDependances++;
            sm.initDependances();
        }

        _aDeplacer.change.AddListener(Change);
    }

    public void Change()
    {
        _aDeplacer._isMovable = false;
        changeEvent.Invoke(this);
    }

    public override void Enter()
    {
        Debug.Log(name);
        _aDeplacer._isMovable = true;
        _aDeplacer._nextElement = _destination;
    }

    public override void Exit()
    {
        _aDeplacer._isMovable = false;
        foreach (StepMount sm in _nextSteps)
        {
            sm._nbDependances--;
        }
        _aDeplacer.transform.localPosition = _aDeplacer._basePosition;
        _aDeplacer.transform.localRotation = _aDeplacer._baseRotation;
    }

    public override void StateUpdate()
    {
       
    }

    public override List<State> GetNextStates()
    {
        return _nextSteps;
    }
}
