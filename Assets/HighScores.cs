using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour {
    [SerializeField] Text player0;
    [SerializeField] Text score0;
    [SerializeField] Text player1;
    [SerializeField] Text score1;
    [SerializeField] Text player2;
    [SerializeField] Text score2;
    [SerializeField] Text player3;
    [SerializeField] Text score3;
    [SerializeField] Text player4;
    [SerializeField] Text score4;
    public string[] players;
    public int[] scores;

    void Awake() {
        //DontDestroyOnLoad(this);
    }

    void Start() {
        players = new string[5];
        scores = new int[5];

        setup();

        if(PlayerPrefs.GetString("Player0") == null) {
           setHighScores(); 
        }

        setNewHighScores();
        
        displayScores();
    }

    public void displayScores() {
        player0.text = PlayerPrefs.GetString("Player0");
        player1.text = PlayerPrefs.GetString("Player1");
        player2.text = PlayerPrefs.GetString("Player2"); 
        player3.text = PlayerPrefs.GetString("Player3"); 
        player4.text = PlayerPrefs.GetString("Player4");

        score0.text = PlayerPrefs.GetInt("Score0").ToString();
        score1.text = PlayerPrefs.GetInt("Score1").ToString(); 
        score2.text = PlayerPrefs.GetInt("Score2").ToString(); 
        score3.text = PlayerPrefs.GetInt("Score3").ToString(); 
        score4.text = PlayerPrefs.GetInt("Score4").ToString(); 
    }

    public void setHighScores() {
        for(int i = 0; i < 5; i++) {
            PlayerPrefs.SetString("Player" + i, ("Player" + i).ToString());
            players[i] = PlayerPrefs.GetString("Player" + i);
            PlayerPrefs.SetInt("Score" + i, 0);
            scores[i] =  PlayerPrefs.GetInt("Score" + i);
        }
    }

    public void setup() {
        for(int i = 0; i < 5; i++) {
            players[i] = ("Player" + i).ToString();
            scores[i] = 0;
        }
    }

    public void setNewHighScores() {
        int newScore = PersistentData.Instance.getScore();
        string newName = PersistentData.Instance.getName();
        int k = -1;
        for(int i = 0; i < 5; i++) {
            k = i;
            if(newScore <= scores[i]) {
                PlayerPrefs.SetString(("Player" + i), players[i]);
                PlayerPrefs.SetInt(("Score" + i), scores[i]);
            }

            else {
                PlayerPrefs.SetString(("Player" + i), newName);
                PlayerPrefs.SetInt(("Score" + i), newScore);
                
                for(int j = k + 1; j < 5; j++) {
                    PlayerPrefs.SetString(("Player" + j), players[i]);
                    PlayerPrefs.SetInt(("Score" + j), scores[i]);
                }

                i = 4;
            }
        }
    }
}
