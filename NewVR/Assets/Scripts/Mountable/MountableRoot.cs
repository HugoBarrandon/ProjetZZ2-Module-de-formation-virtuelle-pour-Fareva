using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MountableRoot : MonoBehaviour
{
    public List<StateMountable> _initSteps = new List<StateMountable>();

    public TextMeshProUGUI textMesh;

    private StateMachineMountable stateMachine;

    public GameObject _base;


    void Start()
    {
        stateMachine = new StateMachineMountable();
        stateMachine._base = _base;
        foreach(StateMountable sm in _initSteps)
        {
            sm.initDependances();
            sm.Enter();
            sm.changeEvent.AddListener(stateMachine.ChangeState);
            sm.updateName.AddListener(stateMachine.UpdateDisplay);
            stateMachine.currentStates.Add(sm);
        }
        stateMachine.updateUI.AddListener(ChangeUI);
        ChangeUI();
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void ChangeUI()
    {
        if(textMesh)
            textMesh.text = stateMachine.ToString();
    }
}