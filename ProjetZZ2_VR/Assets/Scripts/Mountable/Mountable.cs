using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Mountable : Movable
{
    public UnityEvent change;
    public Mountable _nextElement;

    private List<Collider> possibleDestinations;
    private Vector3 angleDestination;

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

            transform.parent = GetComponent<Collider>().transform;
            if(_useBasePosition)
            {
                transform.position = _basePosition;
            }
            if (_useBaseRotation)
            {
                transform.rotation = Quaternion.Euler(_baseRotation);
            }
            change.Invoke();
        }
    }
}
