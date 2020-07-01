using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    [SerializeField] int splashScreenDuration = 4;
    int currentSceneIndex;

    void Start() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0) {
            StartCoroutine(WaitForTime());
        }
    }

    private IEnumerator WaitForTime() {
        yield return new WaitForSeconds(splashScreenDuration);
        LoadNextScene();
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsScreen() {  
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadYouLose() {
        SceneManager.LoadScene("Lose Screen");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
