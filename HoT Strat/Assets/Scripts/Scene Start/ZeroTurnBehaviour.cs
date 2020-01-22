using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroTurnBehaviour : MonoBehaviour
{
    public static bool turnZero = true;

    public GameObject zeroTurnUI;


    void Update()
    {
        if (TurnManager.turnCount == 0)
        {
            ZeroTurnActions();

        }
        else
        {
            return;
        }

    }

    void ZeroTurnActions()
    {
        zeroTurnUI.SetActive(true);
        turnZero = true;

    }

    public void PlayButton()
    {
        zeroTurnUI.SetActive(false);
        turnZero = false;
    }
}
