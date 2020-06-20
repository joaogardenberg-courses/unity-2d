using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackrgoundScroller : MonoBehaviour {
    [SerializeField] float backgroundScrollSpeed = 0.5f;

    Material material;
    Vector2 offset;

    void Start() {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0f, backgroundScrollSpeed);
    }

    void Update() {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
