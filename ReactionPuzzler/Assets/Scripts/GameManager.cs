using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public float actionTimer;
    public float reactionGrade;
    public float enemyLevel = 1f;
    public float numbOptions;
    public float answerShuffle = 0f;

    public bool hasDilemma = false;

    public Button option1;
    public Text option1Text;
    public Button option2;
    public Text option2Text;
    public Button option3;
    public Text option3Text;
    public Text dilemma;

    public string dilemmaContent;
    public string answer1;
    public string answer2;
    public string answer3;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] oldTouches;
    PointerEventData touchButton;
    EventSystem buttonAction;
    GraphicRaycaster touchRay;

    void Update()
    {
        if (!hasDilemma)
        {
            StartDilemma();
        }

        dilemma.text = dilemmaContent;
        
        if(hasDilemma && answerShuffle == 0)
        {
            answerShuffle = Random.Range(1, 4);
            
            switch(answerShuffle)
            {
                case 1:
                    option1Text.text = answer1;
                    option2Text.text = answer2;
                    option3Text.text = answer3;

                    option1.gameObject.tag = "Correct";
                    option2.gameObject.tag = "Incorrect";
                    option3.gameObject.tag = "Incorrect";
                    break;
                case 2:
                    if(numbOptions < 2)
                    {
                        option1Text.text = answer2;
                        option2Text.text = answer1;
                        option3Text.text = answer3;
                        option1.gameObject.tag = "Inorrect";
                        option2.gameObject.tag = "Correct";
                        option3.gameObject.tag = "Incorrect";
                    }
                    else
                    {
                        option1Text.text = answer2;
                        option2Text.text = answer1;
                        option1.gameObject.tag = "Incorrect";
                        option2.gameObject.tag = "Correct";
                        option3.gameObject.tag = "Incorrect";
                    }
                    break;
                case 3:
                    if (numbOptions < 2)
                    {
                        option1Text.text = answer3;
                        option2Text.text = answer2;
                        option3Text.text = answer1;
                        option1.gameObject.tag = "Incorrect";
                        option2.gameObject.tag = "Incorrect";
                        option3.gameObject.tag = "Correct";
                    }
                    else
                    {
                        option1Text.text = answer1;
                        option2Text.text = answer2;
                        option1.gameObject.tag = "Correct";
                        option2.gameObject.tag = "Incorrect";
                        option3.gameObject.tag = "Incorrect";
                    }
                    break;
            }
        }

        Touch touchTarget = Input.GetTouch(0);
        touchTarget.phase = TouchPhase.Began;

        if(Input.touchCount > 0)
        {
            oldTouches = new GameObject[touchList.Count];
            touchList.CopyTo(oldTouches);
            touchList.Clear();

            touchButton = new PointerEventData(buttonAction);
            touchButton.position = touchTarget.position;

            List<RaycastResult> buttonPress = new List<RaycastResult>();

            touchRay.Raycast(touchButton, buttonPress);

            foreach(RaycastResult button in buttonPress)
            {
                if(button.gameObject.tag == "Correct")
                {


                }
            }
        }

        /*if(reactionGrade > 0.99f)
        {
            hasDilemma = false;
            enemyLevel = Random.Range(1, 6);
            actionTimer = 0f;
            reactionGrade = 0f;
            answerShuffle = 0f;
        }*/
    }

    void StartDilemma()
    {
        hasDilemma = true;
        actionTimer = 0f;
        GenerateDilemma();
    }

    void GenerateDilemma()
    {
      switch(enemyLevel)
        {
            case 1:
                dilemmaContent = "He's gonna bite you!";
                numbOptions = 2f;
                option3.enabled = false;
                answer1 = "No way!";
                answer2 = "No weigh!";
                actionTimer = 1 * Time.deltaTime;
                break;

            case 2:
                dilemmaContent = "He's gonna spit at you!";
                numbOptions = 2f;
                option3.enabled = false;
                answer1 = "Dodge it!";
                answer2 = "Dog it!";
                actionTimer = 1 * Time.deltaTime;
                break;

            case 3:
                dilemmaContent = "He's charging at you!";
                numbOptions = 3f;
                option3.enabled = true;
                answer1 = "Jump to the side!";
                answer2 = "Jump to this pie!";
                answer3 = "Jupiter the side!";
                actionTimer = 1 * Time.deltaTime;
                break;

            case 4:
                dilemmaContent = "He wants your phone number!";
                numbOptions = 3f;
                option3.enabled = true;
                answer1 = "Sorry, no thanks!";
                answer2 = "Soggy, no thanks!";
                answer3 = "Sorry, no Tom Hanks!";
                actionTimer = 1 * Time.deltaTime;
                break;

            case 5:
                dilemmaContent = "He needs medical attention!";
                numbOptions = 3f;
                option3.enabled = true;
                answer1 = "I'll call the hospital!";
                answer2 = "I'll call a basketball!";
                answer3 = "I'll call my Mother, honest!";
                actionTimer = 1 * Time.deltaTime;
                break;

        }

        if (actionTimer <= 2f)
        {
            reactionGrade = 4f;
        }
        else if (actionTimer > 2f && actionTimer <= 3f)
        {
            reactionGrade = 3f;
        }
        else if (actionTimer > 3f && actionTimer <= 4f)
        {
            reactionGrade = 2f;
        }
        else if (actionTimer > 4f)
        {
            reactionGrade = 1f;
        }

    }

    void FirstButton()
    {

    }

    void SecondButton()
    {

    }

    void ThirdButton()
    {

    }
     
}
