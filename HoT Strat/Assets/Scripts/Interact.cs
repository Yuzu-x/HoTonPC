using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float interactRadius = 3f;

    bool inRange = false;
    Transform origin;


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);

    }

    void Update()
    {
        GameObject[] original = GameObject.FindGameObjectsWithTag("ActivePlayer");

        GameObject originLocation = null;
        float location = Mathf.Infinity;

        foreach(GameObject org in original)
        {
            float ogd = Vector3.Distance(transform.position, org.transform.position);
            if (ogd < location)
            {
                location = ogd;
                originLocation = org;
            }

            origin = originLocation.transform;
            inRange = true;
        }

        if(inRange)
        {
            float distance = Vector3.Distance(origin.position, transform.position);

            if(distance <= interactRadius)
            {
                if (Input.GetKeyUp(KeyCode.P))
                {
                    AnInteraction();
                    Debug.Log("Decided to interact");
                }
            }
        }
    }

    public virtual void AnInteraction()
    {
        Debug.Log("Interacting with " + transform.name);

    }
}
