using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [SerializeField] InputField playerName;

    public static MainMenu Menu;

    // public void Awake() {
    //     if (Menu == null) {
    //         DontDestroyOnLoad(this);
    //         Menu = this;
    //     }
    //     else
    //         Destroy(gameObject);
    // }

    void Start() {
    }

    void Update() {
        
    }

    public void startGame() {
        if(playerName.text == "") {
            Debug.Log("Player Name has not been input. Please put in a name.");
        }

        else {
            string name = playerName.text;
            PersistentData.Instance.setName(name);
            SceneManager.LoadScene("Level 1");
        }
    }

    public void instructions() {
        SceneManager.LoadScene("Instructions");
    }

    public void options() {
        SceneManager.LoadScene("Options");
    }

    public void main() {
        SceneManager.LoadScene("Main Menu");
    }

    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void highscores() {
        SceneManager.LoadScene("High Scores");
    }

    public void quit() {
        Application.Quit();
    }
}
