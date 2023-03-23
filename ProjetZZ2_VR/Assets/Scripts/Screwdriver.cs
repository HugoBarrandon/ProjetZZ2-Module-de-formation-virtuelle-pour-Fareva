using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screwdriver : MonoBehaviour
{

    public Screw currentScrew = null;

    private Vector3 oldRotation;

    private void Start()
    {
        oldRotation = transform.eulerAngles;
    }

    private void Update()
    {
        if(oldRotation != transform.eulerAngles)
        {
            Vector3 diff = oldRotation - transform.eulerAngles;
            if(currentScrew)
            {
                currentScrew.ScrewIn(diff.magnitude);
            }
            oldRotation = transform.eulerAngles;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.gameObject.GetComponent<Screw>() && other.name == "TopEdge")
        {
            currentScrew = other.transform.parent.gameObject.GetComponent<Screw>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "TopEdge")
        {
            currentScrew = null;
        }
    }
    public float AngleOffAroundAxis(Vector3 v, Vector3 forward, Vector3 axis)
    {
        Vector3 right = Vector3.Cross(axis, forward);
        forward = Vector3.Cross(right, axis);
        return Mathf.Atan2(Vector3.Dot(v, right), Vector3.Dot(v, forward));
    }

}
