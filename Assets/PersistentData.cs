using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour {
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] float gameVolume;

    public static PersistentData Instance;

    public void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    
    void Start() {
        playerName = "";
        playerScore = 0;
        gameVolume = 0.0f;
    }

    public void setName(string name) {
        playerName = name;
    }

    public void setScore (int score) {
        playerScore = score;
    }

    public void setVolume(float vol) {
        gameVolume = vol;
    }

    public string getName() {
        return playerName;
    }

    public int getScore() {
        return playerScore;
    }

    public float getVolume() {
        return gameVolume;
    }
}
