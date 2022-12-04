using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    [SerializeField] GameObject[] pauseObjects;
    [SerializeField] GameObject[] resumeObjects;

    public GameObject pauseUI;
    public GameObject pauseButton;

    void Start() {
        pauseUI.SetActive(false);
        pauseButton.SetActive(true);
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowWhenPaused");
        resumeObjects = GameObject.FindGameObjectsWithTag("ShowWhenResumed");

        foreach (GameObject g in pauseObjects)
            g.SetActive(false);
    }

    public void pause() {
        pauseUI.SetActive(true);
        pauseButton.SetActive(false);

        Time.timeScale = 0.0f;

        foreach(GameObject g in pauseObjects)
            g.SetActive(true);

        foreach(GameObject g in resumeObjects)
            g.SetActive(false);
    }

    public void resume() {
        pauseUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1.0f;

        foreach (GameObject g in pauseObjects)
            g.SetActive(false);

        foreach (GameObject g in resumeObjects)
            g.SetActive(true);
    }

    public void restart() {
        resume();
        Display.Scoring.hardReset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit() {
        resume();
        Destroy(gameObject);
        SceneManager.LoadScene("Main Menu");
        //Application.Quit();
    }

    
}
