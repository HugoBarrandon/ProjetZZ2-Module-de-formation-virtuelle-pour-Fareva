using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMountable : State
{

    public StateEventMountable changeEvent = new StateEventMountable();
    public List<Mountable> _aDeplacer = new List<Mountable>();
    public List<Collider> _destination = new List<Collider>();
    public string _description = "";

    public int _nbDependances = 0;

    private int nbPieces = 0;

    public List<StateMountable> _nextSteps = new List<StateMountable>();

    public void initDependances()
    {
        foreach(StateMountable sm in _nextSteps)
        {
            sm._nbDependances++;
            sm.initDependances();
        }

        foreach (Mountable obj in _aDeplacer)
        {
            obj.change.AddListener(Change);
        }
        nbPieces = _aDeplacer.Count;
    }

    public void Change()
    {
        nbPieces--;
        if(nbPieces == 0)
        {
            changeEvent.Invoke(this);
        }
    }

    public override void Enter()
    {
        foreach(Mountable obj in _aDeplacer)
        {
            obj.SetUp(_destination);
        }
    }

    public override void Exit()
    {
        //_aDeplacer._isMovable = false;
        foreach (StateMountable sm in _nextSteps)
        {
            sm._nbDependances--;
        }
        //_aDeplacer.transform.localPosition = _aDeplacer._basePosition;
        //_aDeplacer.transform.localRotation = _aDeplacer._baseRotation;
    }

    public override void StateUpdate()
    {
       
    }

    public List<StateMountable> GetNextStates()
    {
        return _nextSteps;
    }
}
