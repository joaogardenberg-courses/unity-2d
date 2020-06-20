using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour {
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int pointsPerBlock = 10;
    [SerializeField] int currentScore = 0;
    [SerializeField] bool isAutoPlayEnabled = false;

    void Awake() {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if (gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() {
        scoreText.text = currentScore.ToString();
    }

    void Update() {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
    }

    public void AddToScore() {
        currentScore += pointsPerBlock;
    }

    public void ResetGame() {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled() {
        return isAutoPlayEnabled;
    }
}
