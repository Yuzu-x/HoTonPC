using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CharacterController
{
    private float currentHealth = 200f;
    private float maxHealth = 250f;
    public Image PlayerHealth;

    
    void Start()
    {
        Init();

        currentState = TurnState.WAITING;

    }


    void Update()
    {
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
    }

    void MoveSelected()
        {

            if (actionPoints > 0)
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
            else
            {
                TurnManager.FinishTurn();

            }
        }

    void CheckMouse()
    {
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

    void PlayerCharacterHealth()
    {

    }

    public void MoveButton()
    {
        currentState = TurnState.MOVING;
    }
}
