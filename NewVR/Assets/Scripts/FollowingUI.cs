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
        Vector3 dist = followingCamera.transform.forward;
        dist.y = 0;
        dist = dist.normalized * 0.2f;
        transform.rotation = new Quaternion(0, followingCamera.transform.rotation.y, 0, followingCamera.transform.rotation.w);
        transform.position = followingCamera.transform.position + new Vector3(0, heightModifier - cam_y, 0) + dist;
    }
}
