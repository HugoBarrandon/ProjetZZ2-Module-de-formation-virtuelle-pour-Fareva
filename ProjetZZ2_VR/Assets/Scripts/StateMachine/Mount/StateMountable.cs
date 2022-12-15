using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMountable : State
{

    public StateEventMountable changeEvent = new StateEventMountable();
    public Mountable _aDeplacer;
    public Mountable _destination;

    public int _nbDependances = 0;


    public List<StateMountable> _nextSteps = new List<StateMountable>();

    public void initDependances()
    {
        foreach(StateMountable sm in _nextSteps)
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
        _aDeplacer._isMovable = true;
        _aDeplacer._nextElement = _destination;
    }

    public override void Exit()
    {
        _aDeplacer._isMovable = false;
        foreach (StateMountable sm in _nextSteps)
        {
            sm._nbDependances--;
        }
        _aDeplacer.transform.localPosition = _aDeplacer._basePosition;
        _aDeplacer.transform.localRotation = _aDeplacer._baseRotation;
    }

    public override void StateUpdate()
    {
       
    }

    public List<StateMountable> GetNextStates()
    {
        return _nextSteps;
    }
}
