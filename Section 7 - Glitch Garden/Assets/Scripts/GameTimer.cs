using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    [Tooltip("Our level timer in seconds")]
    [SerializeField] float levelTime = 10;

    bool triggeredLevelFinish = false;

    void Update() {
        if (triggeredLevelFinish) {
            return;
        }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        if (Time.timeSinceLevelLoad >= levelTime) {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinish = true;
        }
    }
}
