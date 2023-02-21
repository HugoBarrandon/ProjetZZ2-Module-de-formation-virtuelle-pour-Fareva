using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPoint : MonoBehaviour
{
    public Montant montant;

    private void OnTriggerEnter(Collider other)
    {
        montant.OnEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        montant.OnExit(other);
    }
}
