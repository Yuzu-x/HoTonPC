using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    GameObject target;


    private float currentHealth = 200f;
    private float maxHealth = 250f;

    void Start()
    {
        Init();


    }


    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);

        switch (currentState)
        {
            case (TurnState.MOVING):

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

        if (actionPoints > 0)
        {
            if (!isMoving)
            {
                FindNearestTarget();
                CalculatePath();
                FindSelectableTiles();
                actualTargetTile.target = true;

            }
            else
            {
                Move();
            }
        }
        else
        {
            TurnManager.FinishTurn();
            gameObject.tag = "NPC";
        }
    }
    void CalculatePath()
    {
        Tile targetTile = GetTargetTile(target);
        FindPath(targetTile);

    }

    void FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        GameObject nearest = null;
        float distance = Mathf.Infinity;

        foreach(GameObject obj in targets)
        {
            float d = Vector3.Distance(transform.position, obj.transform.position);

            if(d < distance)
            {
                distance = d;
                nearest = obj;

            }
        }

        target = nearest;
    }
}
