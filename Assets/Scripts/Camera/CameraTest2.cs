using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest2 : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    Vector3 currentVelocity = Vector3.zero;
    [SerializeField] float smoothTime = 0.2f;
    [SerializeField] Vector3 offset = new Vector3(0, 3.3f, -10);

    // Update is called once per frame
    void Update()
    {
        transform.position =
            Vector3.SmoothDamp(
            transform.position,
            targetTransform.position + offset,
            ref currentVelocity,
            smoothTime
            );
    }
}
