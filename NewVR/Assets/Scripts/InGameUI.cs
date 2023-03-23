using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{

    public Camera camera;
    public void UpdateState(List<StateMountable> states)
    {
        string s = "Prochaines étapes :";
        foreach(StateMountable state in states)
        {
            s += System.Environment.NewLine + "- " + state._description;
        }
        Text t = GetComponentInChildren<Text>();
        t.text = s;
    }
    public void Start()
    {
        GetComponentInChildren<Text>().transform.localEulerAngles = new Vector3(0, 180, 0);
    }
    public void Update()
    {
        transform.LookAt(camera.transform.position);
    }
}
