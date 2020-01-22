using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    Rigidbody diceRB;
    bool hasLanded;
    bool hasThrown;

    Vector3 initPosition;

    public int diceResult;
    public int compareToThis;
    bool hPGemSelected = false;
    bool juranSelected = false;
    bool strengthSelected = false;
    public bool redResult = false;
    public bool blueResult = false;
    public bool hPGemResult = false;
    public bool juranResult = false;
    public bool strengthResult = false;

    public DiceResult[] rolledResults;

    public ItemBlueprint juranBerry;
    public ItemBlueprint healingGem;
    public ItemBlueprint legitStrength;

    private void Start()
    {
        diceRB = GetComponent<Rigidbody>();
        initPosition = transform.position;
        diceRB.useGravity = false;

    }

    private void Update()
    {
      if(diceRB.IsSleeping() && !hasLanded && hasThrown)
        {
            hasLanded = true;
            diceRB.useGravity = false;
            DiceResultCheck();

        }
      else if(diceRB.IsSleeping() && hasLanded && diceResult == 0)
        {
            Reroll();

        }
    }

    public void HealthGemWagerButton()
    {
        if(!hasThrown && !hasLanded)
        {
            hPGemSelected = true;
            hasThrown = true;
            diceRB.useGravity = true;
            diceRB.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));

        }
    }
    public void JuranBerryWagerButton()
    {
        if (!hasThrown && !hasLanded)
        {
            juranSelected = true;
            hasThrown = true;
            diceRB.useGravity = true;
            diceRB.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));

        }
    }
    public void StrengthUpWagerButton()
    {
        if (!hasThrown && !hasLanded)
        {
            strengthSelected = true;
            hasThrown = true;
            diceRB.useGravity = true;
            diceRB.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));

        }
    }

    void ResetDice()
    {
        transform.position = initPosition;
        hasThrown = false;
        hasLanded = false;
        diceRB.useGravity = false;
    }

    void Reroll()
    {
        ResetDice();
        hasThrown = true;
        diceRB.useGravity = true;
        diceRB.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));

    }

    void DiceResultCheck()
    {
        diceResult = 0;
        foreach(DiceResult side in rolledResults)
        {
            if(side.grounded())
            {
                diceResult = side.sideResult;
                Debug.Log(diceResult + " is the result");
                compareToThis = diceResult;
                ResultTranslation();
            }
        }

    }

    void ResultTranslation()
    {
        if(compareToThis == 1)
        {
            redResult = true;
            juranResult = true;

        }
        else if(compareToThis == 2)
        {
            blueResult = true;
            hPGemResult = true;

        }
        else if(compareToThis == 3)
        {
            redResult = true;
            strengthResult = true;

        }
        else if(compareToThis == 4)
        {
            blueResult = true;
            strengthResult = true;

        }
        else if(compareToThis == 5)
        {
            redResult = true;
            hPGemResult = true;

        }
        else if(compareToThis == 6)
        {
            blueResult = true;
            juranResult = true;

        }

        CompareResult();
    }

    void CompareResult()
    {
        if(redResult)
        {
            TurnManager.playerTurn = false;
            TurnManager.enemyTurn = true;
        }
        else if(blueResult)
        {
            TurnManager.playerTurn = true;
            TurnManager.enemyTurn = false;
        }

        if(hPGemSelected && hPGemResult)
        {
            ItemPickup.DiceAdd(healingGem);

        }

        if(juranSelected && juranResult)
        {
            ItemPickup.DiceAdd(juranBerry);

        }

        if(strengthSelected && strengthResult)
        {
            ItemPickup.DiceAdd(legitStrength);

        }
    }
}
