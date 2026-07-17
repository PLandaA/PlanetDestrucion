using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public GameObject creditsPanel;
    public GameObject MainMenuPanel;

    public void sceneChange (string nextScene) {
        SceneManager.LoadScene(nextScene);
    }

    public void showCredits () {
        creditsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);

    }

    public void returnToMenu() {
        MainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);

    }
}
