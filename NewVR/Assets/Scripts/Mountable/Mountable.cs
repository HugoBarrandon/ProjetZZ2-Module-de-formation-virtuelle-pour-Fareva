using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Mountable : Movable
{
    public UnityEvent change;
    public Mountable _nextElement;

    private List<Collider> possibleDestinations = new List<Collider>();

    public void SetUp(List<Collider> destinations)
    {
        possibleDestinations = destinations;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(possibleDestinations.Contains(other))
        {
            Destroy(GetComponent<XRGrabInteractable>());
            Destroy(GetComponent<Rigidbody>());

            transform.parent = other.transform.parent.transform;

            if(_useBasePosition)
            {
                transform.localPosition = _basePosition;
            }
            if (_useBaseRotation)
            {
                transform.localRotation = Quaternion.Euler(_baseRotation);
            }
            change.Invoke();
        }
    }
}
