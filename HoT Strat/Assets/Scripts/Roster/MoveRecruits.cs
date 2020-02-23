using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveRecruits : MonoBehaviour
{
    GraphicRaycaster menuCast;
    PointerEventData mouseOverRecruit;
    EventSystem rosterAction;
    GameObject selectedRecruit;

    GameObject[] recruits;
    public Transform rosterSlots;
    public Transform garrisonSlots;
    List<GameObject> inRoster = new List<GameObject>();
    List<GameObject> inGarrison = new List<GameObject>();

    public bool overRoster = false;
    public bool overRecruit = false;

    float maxRoster = 5f;
    float maxGarrison = 10f;

    public float recruitingPower;

    void Start()
    {
        menuCast = GetComponent<GraphicRaycaster>();
        rosterAction = GetComponent<EventSystem>();

        recruits = GameObject.FindGameObjectsWithTag("RecPan");

       foreach(GameObject space in rosterSlots)
        {
            inRoster.Add(space);
        }

    }


    void Update()
    {
        PointerEventData mouse = new PointerEventData(EventSystem.current);
        mouse.position = Input.mousePosition;
        List<RaycastResult> findRoster = new List<RaycastResult>();
        EventSystem.current.RaycastAll(mouse, findRoster);
        int count = findRoster.Count;

        Debug.Log("I see these recruits " + recruits);

        foreach(GameObject recruit in rosterSlots)
        {
            if (recruit.tag == "RecPan")
            {
                inRoster.Add(recruit);
            }
        }

        foreach(GameObject recruit in garrisonSlots)
        {
            if (recruit.tag == "RecPan")
            {
                inGarrison.Add(recruit);
            }
        }

        foreach(RaycastResult rAorGA in findRoster)
        {
            if(rAorGA.gameObject.tag == "CurrRost")
            {
                overRoster = true;
            }
            else if(rAorGA.gameObject.tag == "GarrRost")
            {
                overRecruit = true;
            }
            else
            {
                overRecruit = false;
                overRoster = false;
            }

            if(selectedRecruit != null)
            {
                if(Input.GetMouseButtonUp(0) && overRoster && inRoster.Count < maxRoster)
                {
                    selectedRecruit.transform.SetParent(rosterSlots);
                    selectedRecruit.transform.position = rosterSlots.position;
                    selectedRecruit = null;
                }

                else if(Input.GetMouseButtonUp(0) && !overRoster || Input.GetMouseButtonUp(0) && inRoster.Count >= maxRoster)
                {
                    selectedRecruit.transform.SetParent(garrisonSlots);
                    selectedRecruit.transform.position = garrisonSlots.position;
                    selectedRecruit = null;
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            mouseOverRecruit = new PointerEventData(rosterAction);
            mouseOverRecruit.position = Input.mousePosition;

            List<RaycastResult> recruits = new List<RaycastResult>();

            menuCast.Raycast(mouseOverRecruit, recruits);

            foreach (RaycastResult recruit in recruits)
            {
                if (recruit.gameObject.tag == "RecPan")
                {
                    selectedRecruit = recruit.gameObject;
                    Vector2 recPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                    selectedRecruit.transform.position = recPos;
                }
            }
        }
    }
}
