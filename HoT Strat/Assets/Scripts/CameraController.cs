using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 velocity = Vector3.zero;
    public Transform playerTransform;
    public Transform cameraTracker;
    int foundActive = 0;
    GameObject[] activePlayer = null;
    public Transform cameraControl;
    public bool foundCamTarget = false;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float cameraSmooth = 1f;

    public float involTurning = 10f;

    public bool lookAtPlayer = false;

    public bool RotateAroundPlayer = false;

    public float RotationSpeed = 5f;

    void Start()
    {
        mainCam = GetComponent<Camera>();

       // cameraOffset = transform.position - cameraTracker.position;


    }

  void Update()
    {


        activePlayer = GameObject.FindGameObjectsWithTag("ActivePlayer");

       FindActivePlayer("ActivePlayer");

        if (foundCamTarget)
        {
            cameraControl.SetParent(playerTransform, false);
            Debug.Log("To confirm, the active player is " + playerTransform);
        }

        cameraTracker.eulerAngles = new Vector3(cameraTracker.eulerAngles.x, involTurning, cameraTracker.eulerAngles.z);

       // Vector3 newPosition = cameraTracker.position + cameraOffset;

      //  transform.position = Vector3.Slerp(transform.position, newPosition, cameraSmooth);



        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                RotateAroundPlayer = true;
            }
        }
        else
            RotateAroundPlayer = false;

        if (RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            cameraOffset = camTurnAngle * cameraOffset;

        }

    }

    void FindNewActivePlayer(Transform _playerTransform)
    {
        playerTransform = _playerTransform;
        Debug.Log("The active player is " + _playerTransform);
        foundCamTarget = true;
    }


    void FindActivePlayer(string _tag)
    {

        GameObject act = GameObject.FindWithTag(_tag);

        if(act)
        {
            FindNewActivePlayer(act.transform);

        }
        else
        {
            Debug.Log("Unable to find " + _tag);
        }
    }
}
