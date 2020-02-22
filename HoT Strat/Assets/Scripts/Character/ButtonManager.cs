using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject activePlayer;
    public PlayerController activeController;

    public Button moveButton;
    public Button runButton;
    public Image activeHealth;
    public Image activeAP;
    public Image activeInv;
    public Image activeFatigue;


    void Update()
    {
        activePlayer = GameObject.FindGameObjectWithTag("ActivePlayer");

        activeController = activePlayer.GetComponent<PlayerController>();
    }

    public void MoveButtonMana()
    {
        activePlayer.GetComponent<PlayerController>().MoveButton();
    }
}
