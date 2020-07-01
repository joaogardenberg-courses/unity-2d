using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    float lives;
    Text livesText;

    void Start() {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    public void TakeLife() {
        lives -= damage;
        UpdateDisplay();

        if (lives <= 0) {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

    private void UpdateDisplay() {
        livesText.text = lives.ToString();
    }
}
