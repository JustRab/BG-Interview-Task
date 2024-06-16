using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject TutorialScreen;

    public void loadScene(string sceneName)
    {
        StartCoroutine(GetComponent<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, sceneName));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowTutorial()
    {
        titleScreen.SetActive(false);
        TutorialScreen.SetActive(true);
    }

    public void ShowTitle()
    {
        titleScreen.SetActive(true);
        TutorialScreen.SetActive(false);
    }

}
