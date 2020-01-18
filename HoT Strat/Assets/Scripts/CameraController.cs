using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 velocity = Vector3.zero;
    public Transform playerTransform;
    int foundActive = 0;
    GameObject[] activePlayer = null;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float cameraSmooth = 0.5f;

    public bool lookAtPlayer = false;

    public bool RotateAroundPlayer = false;

    public float RotationSpeed = 5f;

    void Start()
    {
        mainCam = GetComponent<Camera>();

        cameraOffset = transform.position - playerTransform.position;

    }

  //  private void Update()
   // {


      //  activePlayer = GameObject.FindGameObjectsWithTag("ActivePlayer");

     //   FindActivePlayer("ActivePlayer");

      //  if (playerTransform)
     //   {
      //      Vector3 point = mainCam.WorldToViewportPoint(playerTransform.position);
       //     Vector3 delta = playerTransform.position - mainCam.ViewportToWorldPoint(new Vector3(0.2f, .43f, point.z));
      //      Vector3 destination = transform.position + delta;
       //     transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 0) + cameraOffset;

      //  }

   // }

    void FindNewActivePlayer(Transform _playerTransform)
    {
        playerTransform = _playerTransform;
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
