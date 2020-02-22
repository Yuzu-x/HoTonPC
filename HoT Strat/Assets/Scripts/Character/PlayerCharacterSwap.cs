using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSwap : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;

    List<GameObject> playerTeam = new List<GameObject>();

    void Start()
    {
        foreach(GameObject teamMember in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerTeam.Add(teamMember);
        }

    }

    void Update()
    {
        foreach (GameObject member in playerTeam)
        {
            if(Input.GetMouseButtonUp(0) && TurnManager.playerTurn)
            {
                Ray switchChar = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit newCharHit;
                if(Physics.Raycast(switchChar, out newCharHit))
                {
                    if(newCharHit.collider.gameObject == member)
                    {
                        if(GameObject.FindGameObjectsWithTag("ActivePlayer").Length > 0)
                        {
                           foreach(GameObject acpl in GameObject.FindGameObjectsWithTag("ActivePlayer"))
                            {
                                acpl.tag = "Player";
                            }
                            
                        }

                        member.tag = "ActivePlayer";

                    }
                }
            }
            /*
            Debug.Log("Checking " + player1 + " for " + member);
            if (player1 = null)
            {
                player1 = member;
            }
            else if (player2 == null && player1 != null)
            {
                player2 = member;
            }
            else if (player3 == null && player1 != null && player2 != null)
            {
                player3 = member;
            }
            else if (player4 == null && player1 != null && player2 != null && player3 != null)
            {
                player4 = member;
            }
            else if (player5 == null && player1 != null && player2 != null && player3 != null && player4 != null)
            {
                player5 = member;
            }
            */
        }
    }
}
