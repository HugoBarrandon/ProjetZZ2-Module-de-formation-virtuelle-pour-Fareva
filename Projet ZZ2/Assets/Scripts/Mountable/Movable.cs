using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public Vector3 _basePosition = new Vector3(0, 0, 0);
    public Quaternion _baseRotation = Quaternion.identity;
    public bool _isMovable = false;
}
