using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountableRoot : MonoBehaviour
{
    public List<Movable> _pieces = new List<Movable>();
    public List<StepMount> _initSteps = new List<StepMount>();

    private StateMachine<StepMount> stateMachine;



    void Start()
    {
        stateMachine = new StateMachine<StepMount>();
        foreach(StepMount sm in _initSteps)
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
