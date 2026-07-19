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

    private void Awake () {
        // Endless mode: survival time counts up and is the score.
        timer = 0f;
    }

    private void Update () {
        if (hasLost) {
            return;
        }

        timer += Time.deltaTime;
        score.text = timer.ToString("F0");
    }

    public bool HasLost => hasLost;
    public void GameOver () {
        // Both colliding planets report the crash: act only once.
        if (hasLost) {
            return;
        }
        hasLost = true;

        int survived = Mathf.FloorToInt(timer);
        int best = PlayerPrefs.GetInt("HighScore");
        if (survived > best) {
            best = survived;
            PlayerPrefs.SetInt("HighScore", best);
        }
        score.text = survived + "s  |  Best: " + best + "s";

        Invoke(nameof(Delay), 1.5f);
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
