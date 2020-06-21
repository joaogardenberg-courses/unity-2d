using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    public void LoadStartMenu() {
        SceneManager.LoadScene(0);
    }

    public void LoadGame() {
        SceneManager.LoadScene("Game");
        GameSession gameSession = FindObjectOfType<GameSession>();

        if (gameSession) {
            gameSession.ResetGame();
        }
    }

    public void LoadGameOver(float delayInSeconds = 0f) {
        if (delayInSeconds <= 0f) {
            SceneManager.LoadScene("Game Over");
        } else {
            StartCoroutine(WaitAndLoad("Game Over", delayInSeconds));
        }
    }

    public void QuitGame() {
        Application.Quit();
    }

    private IEnumerator WaitAndLoad(int sceneIndex, float delayInSeconds) {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(sceneIndex);
    }

    private IEnumerator WaitAndLoad(string sceneString, float delayInSeconds) {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(sceneString);
    }
}
