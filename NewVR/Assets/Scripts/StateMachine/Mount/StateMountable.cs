using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateMountable : State
{

    public StateEventMountable changeEvent = new StateEventMountable();
    public List<Mountable> _aDeplacer = new List<Mountable>();
    public List<Collider> _destination = new List<Collider>();
    public string _description = "";
    public UnityEvent updateName = new UnityEvent();
    public int _nbDependances = 0;
    private int nbPieces = 0;
    private int totalPieces = 0;
    private bool inited = false;

    public List<StateMountable> _nextSteps = new List<StateMountable>();

    public void initDependances()
    {
        if(!inited)
        {
            foreach (StateMountable sm in _nextSteps)
            {
                sm._nbDependances++;
                sm.initDependances();
            }

            foreach (Mountable obj in _aDeplacer)
            {
                obj.change.AddListener(Change);
            }
            nbPieces = _aDeplacer.Count;
            totalPieces = _aDeplacer.Count;
            inited = true;
        }
    }

    public void Change()
    {
        nbPieces--;
        updateName.Invoke();
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
        foreach (StateMountable sm in _nextSteps)
        {
            sm._nbDependances--;
        }
    }

    public override void StateUpdate()
    {
       
    }

    public List<StateMountable> GetNextStates()
    {
        return _nextSteps;
    }

    override public string ToString()
    {
        string ret = _description + " : " + (totalPieces - nbPieces) + "/" + totalPieces;
        return ret;
    }
}
