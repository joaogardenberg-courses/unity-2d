using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] int breakableBlocks;
    SceneLoader sceneLoader;

    public void CountBreakableBlocks() {
        breakableBlocks++;
    }

    void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }


    public void BlockDestroyed() {
        breakableBlocks--;

        if (breakableBlocks <= 0) {
            sceneLoader.LoadNextScene();
        }
    }
}
