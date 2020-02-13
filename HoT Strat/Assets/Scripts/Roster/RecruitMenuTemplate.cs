using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitMenuTemplate : MonoBehaviour
{
    public RecruitClass recruitClass;

    public Text recruitClassName;
    public Image recruitClassSymbol;
    public Text recruitName;

    void Start()
    {
        recruitClassName.text = recruitClass.myClass;
        recruitClassSymbol.sprite = recruitClass.myClassSymbol;
        recruitName.text = recruitClass.myName;


    }


}
