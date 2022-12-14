using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mountable : Movable
{
    public UnityEvent change;
    public Mountable _nextElement;
    void OnCollisionEnter(Collision collision)
    {
        
        Collider collider = collision.collider;
        if (_nextElement)
        {
            if (collider.name == _nextElement.name)
            {
                Destroy(GetComponent<Rigidbody>());

                transform.parent = collider.transform;
                Debug.Log(transform.parent);
                change.Invoke();
            }
        }
    }
}
