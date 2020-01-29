using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : PlayerController
{
    public int teamMax = 5;

    public PlayerController activeMember;

    public List<PlayerController> myTeam = new List<PlayerController>();

    public void Start()
    {


    }

    public void Update()
    {
        foreach(PlayerController play in myTeam)
        {
            GameObject thisPlayer = play.GetComponent<GameObject>();
            CheckForActive(thisPlayer);
        }
        
    }

    public void CheckForActive(GameObject thisPlayer)
    {
        if(thisPlayer.tag == "ActivePlayer")
        {
           activeMember = thisPlayer.GetComponent<PlayerController>();
        }


    }


}
