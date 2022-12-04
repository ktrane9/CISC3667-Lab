using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Volume : MonoBehaviour {

    [SerializeField] Slider volumeSlider;
    [SerializeField] Text audioLevel;
    float volumeValue;

    void Start() {
        if(!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 1);
            loadValues();
        }

        else
            loadValues();
    }

    public void changeVolume() {
        AudioListener.volume = volumeSlider.value;
        saveVolume();
    }

    private void loadValues() {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        // volumeValue = PersistentData.Instance.getVolume();
        // volumeSlider.value = volumeValue;
        // AudioListener.volume = volumeValue;
    }

    public void saveVolume() {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        // volumeValue = volumeSlider.value;
        // PersistentData.Instance.setVolume(volumeValue);
        // loadValues();
    }

    // public void volumeSlider(float volume) {
    //     audioLevel.text = PersistentData.Instance.getVolume().ToString("0.0");
    //     saveVolume();
    // }
}
