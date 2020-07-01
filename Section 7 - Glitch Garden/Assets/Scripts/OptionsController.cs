using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] float defaultDifficulty = 0f;

    void Start() {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    void Update() {
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();

        if (musicPlayer) {
            musicPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void SaveAndExit() {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults() {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
