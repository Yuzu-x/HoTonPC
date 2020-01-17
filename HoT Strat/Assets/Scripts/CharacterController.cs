﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool myTurn = false;

    List<Tile> selectableTiles = new List<Tile>();
    GameObject[] tiles;

    Stack<Tile> path = new Stack<Tile>();
    Tile initialTile;

    public bool isMoving = false;
    public bool hasSelectedMove = false;
    public int moveRange = 5;
    public float jumpHeight = 3;
    public float characterMoveSpeed = 2;
    public float jumpVelocity = 4.5f;
    public static float actionPoints = 4f;
    public static float moveActionsThisTurn = 1f;

    Vector3 velocity = new Vector3();
    Vector3 heading = new Vector3();

    float halfHeight = 0;

    bool fallingDown = false;
    bool jumpingUp = false;
    bool moveToEdge = false;
    Vector3 jumpTarget;

    public Tile actualTargetTile;

    public enum TurnState
    {
        MOVING,
        CASTING,
        LONGCASTING,
        RUNNING,
        RUSHING,
        WAITING,
        DEAD
    }

    public TurnState currentState;

    protected void Init()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        halfHeight = GetComponent<Collider>().bounds.extents.y;

        TurnManager.AddUnit(this);

    }

    public void GetInitialTile()
    {
        initialTile = GetTargetTile(gameObject);
        initialTile.current = true;

    }

    public Tile GetTargetTile(GameObject target)
    {
        RaycastHit hit;
        Tile tile = null;
        if(Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1))
        {
            tile = hit.collider.GetComponent<Tile>();

        }

        return tile;
    }

    public void ComputeAdjacencyLists(float jumpHeight, Tile target)
    {
        foreach (GameObject tile in tiles)
        {
            Tile t = tile.GetComponent<Tile>();
            t.FindNeighbours(jumpHeight, target);

        }
    }

    public void FindSelectableTiles()
    {
        ComputeAdjacencyLists(jumpHeight, null);
        GetInitialTile();

        Queue<Tile> process = new Queue<Tile>();

        process.Enqueue(initialTile);
        initialTile.visited = true;

        while (process.Count > 0)
        {
            Tile t = process.Dequeue();
            selectableTiles.Add(t);
            t.selectable = true;

            if (t.distance < moveRange)
            {


                foreach (Tile tile in t.adjacencyList)
                {
                    if (!tile.visited)
                    {
                        tile.parent = t;
                        tile.visited = true;
                        tile.distance = 1 + t.distance;
                        process.Enqueue(tile);

                    }
                }
            }
        }
    }

    public void MoveToTile(Tile tile)
    {
        path.Clear();
        tile.target = true;
        isMoving = true;

        Tile next = tile;
        while(next != null)
        {
            path.Push(next);
            next = next.parent;
        }
    }

    public void Move()
    {
        if (path.Count > 0)
        {
            Tile t = path.Peek();
            Vector3 target = t.transform.position;

            target.y += halfHeight + t.GetComponent<Collider>().bounds.extents.y;

            if (Vector3.Distance(transform.position, target) >= 0.05f)
            {

                bool shouldJump = transform.position.y != target.y;

                if (shouldJump)
                {
                    MoveVertically(target);
                }
                else
                {
                    CalculateHeading(target);
                    SetHorizontalVelocity();
                }
                transform.forward = heading;
                transform.position += velocity * Time.deltaTime;

            }
            else
            {
                transform.position = target;
                path.Pop();
            }
        }
        else
        {
            RemoveSelectableTiles();
            isMoving = false;
            actionPoints = actionPoints - 1f;
            currentState = TurnState.WAITING;
            

        }
    }

    protected void RemoveSelectableTiles()
    {
        if(initialTile != null)
        {
            initialTile.current = false;
            initialTile = null;
        }
        foreach(Tile tile in selectableTiles)
        {
            tile.Reset();
        }

        selectableTiles.Clear();
    }

    void CalculateHeading(Vector3 target)
    {
        heading = target - transform.position;
        heading.Normalize();
    }

    void SetHorizontalVelocity()
    {
        velocity = heading * characterMoveSpeed;

    }

    void MoveVertically(Vector3 target)
    {
        if(fallingDown)
        {
            FallDown(target);
        }
        else if(jumpingUp)
        {
            JumpUp(target);
        }
        else if(moveToEdge)
        {
            ApproachEdge();
        }
        else
        {
            PrepareJump(target);
        }
    }
    void PrepareJump(Vector3 target)
    {
        float targetY = target.y;

        target.y = transform.position.y;

        CalculateHeading(target);

        if(transform.position.y > targetY)
        {
            fallingDown = false;
            jumpingUp = false;
            moveToEdge = true;

            jumpTarget = transform.position + (target - transform.position) / 2f;

        }
        else
        {
            fallingDown = false;
            jumpingUp = true;
            moveToEdge = false;

            velocity = heading * characterMoveSpeed / 3f;

            float difference = targetY - transform.position.y;

            velocity.y = jumpVelocity * (0.5f + difference / 2f);

        }
    }
    void FallDown(Vector3 target)
    {
        velocity += Physics.gravity * Time.deltaTime;

        if(transform.position.y <= target.y)
        {
            fallingDown = false;

            Vector3 p = transform.position;
            p.y = target.y;
            transform.position = p;

            velocity = new Vector3();
        }
    }

    void JumpUp(Vector3 target)
    {
        velocity += Physics.gravity * Time.deltaTime;

        if (transform.position.y > target.y)
        {
            jumpingUp = false;
            fallingDown = true;
        }
    }

    void ApproachEdge()
    {
        if(Vector3.Distance(transform.position, jumpTarget) >= 0.05f)
        {
            SetHorizontalVelocity();
        }
        else
        {
            moveToEdge = false;
            fallingDown = true;

            velocity /= 3.0f;
            velocity.y = 1.5f;

        }
    }

    protected Tile FindLowestF(List<Tile> list)
    {
        Tile lowest = list[0];

        foreach(Tile t in list)
        {
            if(t.f < lowest.f)
            {
                lowest = t;
            }
        }

        list.Remove(lowest);


        return lowest;
    }

    protected Tile FindEndTile(Tile t)
    {
        Stack<Tile> tempPath = new Stack<Tile>();

        Tile next = t.parent;

        while(next != null)
        {
            tempPath.Push(next);
            next = next.parent;

        }

        if(tempPath.Count <= moveRange)
        {
            return t.parent;

        }

        Tile endTile = null;
        for(int i = 0; i <= moveRange; i++)
        {
            endTile = tempPath.Pop();

        }

        return endTile;
    }

    protected void FindPath(Tile target)
    {
        ComputeAdjacencyLists(jumpHeight, target);
        GetInitialTile();

        List<Tile> openList = new List<Tile>();
        List<Tile> closedList = new List<Tile>();

        openList.Add(initialTile);
        initialTile.h = Vector3.Distance(initialTile.transform.position, target.transform.position);
        initialTile.f = initialTile.h;

        while(openList.Count > 0)
        {
            Tile t = FindLowestF(openList);

            closedList.Add(t);

            if(t == target)
            {
                actualTargetTile = FindEndTile(t);
                MoveToTile(actualTargetTile);

                return;

            }

            foreach(Tile tile in t.adjacencyList)
            {
                if (closedList.Contains(tile))
                    {

                     }

                else if (openList.Contains(tile))
                {
                    float tempG = t.g + Vector3.Distance(tile.transform.position, t.transform.position);

                    if(tempG < tile.g)
                    {
                        tile.parent = t;

                        tile.g = tempG;
                        tile.f = tile.g + tile.h;

                    }
                }
                else
                {
                    tile.parent = t;

                    tile.g = t.g + Vector3.Distance(tile.transform.position, t.transform.position);
                    tile.h = Vector3.Distance(tile.transform.position, target.transform.position);
                    tile.f = tile.g + tile.h;

                    openList.Add(tile);
                }
            }
        }
    }

    public void TurnBegin()
    {
        myTurn = true;
    }

    public void TurnEnd()
    {
        myTurn = false;
    }

    public void SelectedMove()
    {
        hasSelectedMove = true;

    }
}
