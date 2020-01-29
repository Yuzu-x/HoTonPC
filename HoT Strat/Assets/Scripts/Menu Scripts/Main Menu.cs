using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playButton;
    public GameObject mainOptions;

    public void PlayButton()
    {
        mainOptions.SetActive(true);
        playButton.SetActive(false);
    }
}
