using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float cameraSmooth = 0.5f;

    public bool lookAtPlayer = false;

    public bool RotateAroundPlayer = false;

    public float RotationSpeed = 5f;

    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = playerTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPosition, cameraSmooth);

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                RotateAroundPlayer = true;
            }
        }
        else
            RotateAroundPlayer = false;
        
        if(RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            cameraOffset = camTurnAngle * cameraOffset;

        }

        if (lookAtPlayer || RotateAroundPlayer)
        {
            transform.LookAt(playerTransform);

        }
    }
}
