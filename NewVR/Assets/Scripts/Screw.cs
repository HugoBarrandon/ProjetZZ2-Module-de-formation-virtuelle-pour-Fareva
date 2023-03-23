using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Screw : MonoBehaviour
{
    public Transform fixedPivotPoint;
    public MeshCollider meshCollider;
    public Rigidbody _rb;
    public Transform model;
    public float screwinfForce = 0.001f;
    private bool isPlanted = false;
    private bool isPlantedMax = false;

    public GameObject mainPiece;
    public List<GameObject> otherPieces = new List<GameObject>();

    private void Start()
    {
        GetComponent<XRGrabInteractable>().selectExited.AddListener(checkGravity);
    }

    public void checkGravity(SelectExitEventArgs args)
    {
        if(isPlanted)
        {
            _rb.useGravity = false;
            _rb.isKinematic = true;
        }
    }
    public void ScrewIn(float value)
    {
        if (isPlanted && !isPlantedMax)
        {
            transform.position -= model.up * value * screwinfForce;
            //model.localEulerAngles += new Vector3(0, value, 0);
        }
    }
    public void onEdgeEnter(string edgeName, Collider collider)
    {

        if (edgeName == "BotEdge" && collider.tag == "Screwable" && GetComponent<XRGrabInteractable>().isSelected)
        {
           _rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            isPlanted = true;
            _rb.isKinematic = true;
            _rb.useGravity = false;
        }
        if (edgeName == "TopEdge" && collider.tag == "Screwable" && isPlanted)
        {
            isPlantedMax = true;
        }
        if (edgeName == "GlobalEdge" && collider.tag == "Screwable" && isPlanted)
        {
            if(mainPiece == null)
            {
                transform.SetParent(collider.gameObject.transform, true);
                mainPiece = collider.gameObject;
            }
            else
            {
                collider.gameObject.transform.parent = mainPiece.transform;
                otherPieces.Add(collider.gameObject);

            }
        }
    }

    public void onEdgeExit(string edgeName, Collider collider)
    {
        if (edgeName == "BotEdge" && collider.tag == "Screwable" && mainPiece == null)
        {
            /*
             _rb.constraints = RigidbodyConstraints.None;
              isPlanted = false;
              _rb.isKinematic = false;
              _rb.useGravity = true;
            */
        }
        if (edgeName == "TopEdge" && collider.tag == "Screwable" && GetComponent<XRGrabInteractable>().isSelected)
        {
            isPlantedMax = false;
        }
        if (edgeName == "GlobalEdge" && collider.tag == "Screwable")
        {
           if(collider.gameObject == mainPiece)
            {
                mainPiece = null;
            }
        }
    }

    public void PivotTo(Vector3 position)
    {
        Vector3 offset = transform.position - position;
        foreach (Transform child in transform)
            child.transform.localPosition += offset;
        transform.position = position;
    }
}
