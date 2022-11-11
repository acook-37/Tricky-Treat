using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // the camera follows who? 
    public GameObject target;
    private float distanceToTarget;

    // Start is called before the first frame update
    void Start()
    {
        distanceToTarget = transform.position.x - target.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float targetObjectX = target.transform.position.x;
        Vector3 newCameraPosition = transform.position;
        newCameraPosition.x = targetObjectX + distanceToTarget;
        transform.position = newCameraPosition;
    }
}
