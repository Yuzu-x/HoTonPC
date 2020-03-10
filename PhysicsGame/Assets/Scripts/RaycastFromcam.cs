using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFromcam : PlayerControls
{
    float selectionDistance;
    Vector3 screenTargetPosition;
    Vector3 rigidBodyPosition;

    Rigidbody toy;
    public float force = 300f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            toy = CheckMouse();
        }

        if(Input.GetMouseButtonDown(0) && toy)
        {
            toy = null;
        }
 
   }

    public void FixedUpdate()
    {
        if(toy)
        {
            Vector3 mousePositionOffset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance)) - screenTargetPosition;
            toy.velocity = (rigidBodyPosition + mousePositionOffset - toy.transform.position) * force * Time.deltaTime;
        }

        CheckMouse();
    }

    Rigidbody CheckMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit selectable;

        if (Physics.Raycast(ray, out selectable))
        {
            if (selectable.collider.gameObject.GetComponent<Rigidbody>())
            {
                selectionDistance = Vector3.Distance(ray.origin, selectable.point);
                screenTargetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));
                rigidBodyPosition = selectable.collider.transform.position;
                return selectable.collider.gameObject.GetComponent<Rigidbody>();

            }
            Debug.Log(selectable);
        }
        return null;
    }
}
