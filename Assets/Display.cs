using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Display : MonoBehaviour {
    [SerializeField] int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text sceneText;
    [SerializeField] int level;
    //public int startScore = 0;
    public bool pop;

    public static Display Scoring;

    public void Awake() {
        Scoring = this;
        // if (Scoring == null) {
        //     DontDestroyOnLoad(this);
        //     Scoring = this;
        // }
        // else
        //     Destroy(gameObject);
    }

    void Start() {
        pop = false;
        level = SceneManager.GetActiveScene().buildIndex;
        if((level - 2) == 1) PersistentData.Instance.setScore(0);
        else score = PersistentData.Instance.getScore();
        //startScore = score;
        displayLevel();
        displayScore();
    }

    public void addPoints(int points) {
        score += points;
        pop = true;
        Debug.Log("Score: " + score);
        displayScore();

        if (pop == true) {
            pop = false;
            PersistentData.Instance.setScore(score);
            advance();
        }
    }

    public void displayScore() {
        scoreText.text = "Score: " + score;
    }

    public void displayLevel() {
        sceneText.text = "Level: " + (level - 2);
    }

    public void advance() {
        if(level == 5) {
            SceneManager.LoadScene("High Scores");
        }
        else SceneManager.LoadScene(level + 1);
    }

    public void reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        score = PersistentData.Instance.getScore();
        displayScore();
    }

    public void hardReset() {
        score = PersistentData.Instance.getScore();
        displayScore();
    }
}
