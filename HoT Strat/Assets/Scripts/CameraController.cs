using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 velocity = Vector3.zero;
    public Transform playerTransform;
    GameObject[] activePlayer = null;
    public Transform cameraControl;
    public bool foundCamTarget = false;

    public float camMoveVelocity = 10f;
    public float camHeading = 0f;
    Vector2 camInput;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float cameraSmooth = 1f;
    public float involTurning = 10f;
    public float rotationSpeed = 5f;

    void Start()
    {

    }

    void Update()
    {


        activePlayer = GameObject.FindGameObjectsWithTag("ActivePlayer");

        FindActivePlayer("ActivePlayer");

        if (foundCamTarget)
        {
            cameraControl.SetParent(playerTransform, false);
        }

        cameraControl.rotation = Quaternion.Euler(0, camHeading, 0);


        if (Input.GetKey(KeyCode.Q))
        {
            camHeading = camHeading - rotationSpeed;
        }

        if (Input.GetKey(KeyCode.E))
        {
            camHeading = camHeading + rotationSpeed;
        }

    }

    void FindNewActivePlayer(Transform _playerTransform)
    {
        playerTransform = _playerTransform;
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
            ControlCamera();
            Debug.Log("Unable to find " + _tag);
        }
    }

    void ControlCamera()
    {
        Vector3 camContForward = cameraControl.forward;
        Vector3 camContRight = cameraControl.right;
        camContForward.y = 0;
        camContRight.y = 0;
        camContForward = camContForward.normalized;
        camContRight = camContRight.normalized;

        camInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        camInput = Vector2.ClampMagnitude(camInput, 1);

        transform.position += (camContForward * camInput.y + camContRight * camInput.x) * Time.deltaTime * camMoveVelocity;


    }
}
