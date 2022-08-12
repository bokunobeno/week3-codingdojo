using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        Vector3 cameraForward = transform.position + _camera.rotation * Vector3.forward;
        Vector3 cameraUp = _camera.rotation * Vector3.up;
        transform.LookAt(cameraForward, cameraUp);
    }
}
