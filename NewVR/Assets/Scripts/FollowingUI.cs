using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingUI : MonoBehaviour
{

    public float heightModifier = 1f;
    public Camera followingCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float cam_y = followingCamera.transform.position.y;
        transform.position = followingCamera.transform.position + new Vector3(0, heightModifier-cam_y, 0);
        transform.rotation = new Quaternion(0, followingCamera.transform.rotation.y, 0, followingCamera.transform.rotation.w);
    }
}
