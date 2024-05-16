using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    public Button retryButton;
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        //Hook events
        retryButton.onClick.AddListener(StartGame);
        backButton.onClick.AddListener(Back);

    }


    public void StartGame()
    {
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    public void Back()
    {
        SceneTransitionManager.singleton.GoToSceneAsync(0);
    }
}