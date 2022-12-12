using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountableRoot : MonoBehaviour
{
    public List<Movable> _pieces = new List<Movable>();
    public List<StateMountable> _initSteps = new List<StateMountable>();

    private StateMachineMountable stateMachine;



    void Start()
    {
        stateMachine = new StateMachineMountable();
        foreach(StateMountable sm in _initSteps)
        {
            sm.initDependances();
            sm.Enter();
            sm.changeEvent.AddListener(stateMachine.ChangeState);
        }
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
