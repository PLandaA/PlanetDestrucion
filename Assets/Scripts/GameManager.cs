using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour {

    public GameObject restartPanel;

    public TextMeshProUGUI score;

    private bool hasLost;

    public float timer;

    private void Update () {
        if (hasLost) {
            return;
        }

        score.text = timer.ToString("F0");

        if (timer <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else {
            timer -= Time.deltaTime;
        }
    }
    public void GameOver () {
        hasLost = true;
        Invoke("Delay", 1.5f);
       
    }

    void Delay() {
        restartPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void BackToMenu () {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }




}
