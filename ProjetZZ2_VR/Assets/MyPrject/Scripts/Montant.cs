using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Montant : MonoBehaviour
{
    public Transform module;
    public Collider _collider;

    public void OnEnter(Collider other)
    {
        if(other.name == "montantPoint")
        {
            Destroy(GetComponent<XRGrabInteractable>());
            Destroy(GetComponent<Rigidbody>());

            transform.SetParent(other.transform);
        }
    }


    public void OnExit(Collider other)
    {
        /*
        if (other.name == "montantPoint")
        {
            transform.SetParent(module);
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.gameObject.layer = 16;
        }
        */
    }
}
