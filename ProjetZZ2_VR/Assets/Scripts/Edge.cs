using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public Screw target;
    private void OnTriggerEnter(Collider other)
    {
        target.onEdgeEnter(name,other);
    }
    private void OnTriggerExit(Collider other)
    {
        target.onEdgeExit(name, other);
    }
}
