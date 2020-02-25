using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceScript : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
