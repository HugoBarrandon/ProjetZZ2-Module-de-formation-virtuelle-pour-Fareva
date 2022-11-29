using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCombinaison : Movable
{
    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if(collider.name == "Part0")
        {
            Destroy(GetComponent<Rigidbody>());
            tag = "Untagged";

            transform.parent = collider.transform;

            isMovable = false;
        }
    }
}
