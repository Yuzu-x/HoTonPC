using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CharacterController
{

    
    void Start()
    {
        Init();

        currentState = TurnState.WAITING;
        currentHealth = maxHealth;

    }

    //State Machine
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10f);

        }

        Debug.DrawRay(transform.position, transform.forward);

        switch (currentState)
        {
            case (TurnState.MOVING):
                MoveSelected();
                break;

            case (TurnState.CASTING):

                break;

            case (TurnState.LONGCASTING):

                break;

            case (TurnState.RUNNING):

                break;

            case (TurnState.RUSHING):

                break;

            case (TurnState.WAITING):

                break;

            case (TurnState.DEAD):

                break;
        }

        if (!myTurn)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray charay = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit charHit;

                if (Physics.Raycast(charay, out charHit))
                {
                    if (charHit.collider.tag == "Player")
                    {
                        SwapActivePlayer("ActivePlayer");
                        gameObject.tag = "ActivePlayer";
                        isActive = true;


                    }
                }

            }
        }

        if(actionPoints <= 0)
        {
            if(currentState != TurnState.LONGCASTING)
            {
                currentState = TurnState.WAITING;
            }
        }

    }

    //Movement Handling
    void MoveSelected()
    {
        if (isActive)
        {
            if (!isMoving)
            {

                FindSelectableTiles();
                CheckMouse();

            }
            else
            {
                Move();
            }
        }
    }



    void CheckMouse()
    {

        Ray pathVisRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit visHit;

        if(Physics.Raycast(pathVisRay, out visHit))
        {
            if(visHit.collider.tag == "Tile")
            {
                Tile t = visHit.collider.GetComponent<Tile>();

                if(t.selectable)
                {
                    t.GetComponent<Renderer>().material.color = Color.red;

                }
            }
        }

        if(Input.GetMouseButtonUp(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if(t.selectable)
                    {
                        MoveToTile(t);
                    }
                }
            }
        }
    }

    //Character Resources
    void PlayerCharacterHealth()
    {

    }

    //Player UI Events
    public void MoveButton()
    {
        if (isActive)
        {
            if (moveActionsThisTurn > 0)
            {
                currentState = TurnState.MOVING;
                moveActionsThisTurn = moveActionsThisTurn - 1;
            }
            else
            {
                currentState = TurnState.WAITING;
            }
        }
    }

    public void EndTurnButton()
    {
        TurnManager.FinishTurn();
        gameObject.tag = "Player";
        isActive = false;
    }

    //Team Management
    void SwapActivePlayer(string _tag)
    {
        GameObject needSwap = GameObject.FindWithTag(_tag);

        if(needSwap)
        {
            gameObject.tag = "Player";
            isActive = false;

        }
    }
}
