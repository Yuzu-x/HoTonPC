using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceResult : MonoBehaviour
{
    bool onGround;

    public int sideResult;

    private void OnTriggerStay(Collider faceDown)
    {
        if(faceDown.tag == "DiceTray")
        {
            onGround = true;

        }
    }

    private void OnTriggerExit(Collider faceDown)
    {
        if (faceDown.tag == "DiceTray")
        {
            onGround = false;

        }
    }
    public bool grounded()
    {
        return onGround;
    }
}
