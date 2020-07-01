using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour {
    const string MASTER_VOLUME_KEY = "Master Volume";
    const string DIFFICULTY_KEY = "Difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 100f;
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    public static void SetMasterVolume(float volume) {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, Mathf.Clamp(volume, MIN_VOLUME, MAX_VOLUME));
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float difficulty) {
        PlayerPrefs.SetFloat(DIFFICULTY_KEY, Mathf.Clamp(difficulty, MIN_DIFFICULTY, MAX_DIFFICULTY));
    }

    public static float GetDifficulty() {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
