using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    public InputActionReference leftJoystick;
    public float SPEED = 0.001f;
    private void Start()
    {
        leftJoystick.action.performed += Move;
    }

    private void Move(CallbackContext obj)
    {
        if(Camera.current)
        {
            Vector2 input = obj.ReadValue<Vector2>();
            Vector3 forward = Camera.current.transform.forward;
            forward.y = 0;
            Vector3 right = Camera.current.transform.right;
            right.y = 0;
            Vector3 deplacement = forward * input.y + right * input.x;
            transform.position += deplacement * SPEED;
        }
    }
}
