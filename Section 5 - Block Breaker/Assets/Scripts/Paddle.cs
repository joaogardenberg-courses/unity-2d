using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    GameSession gameSession;
    Ball ball;

    void Start() {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
        transform.position = new Vector2(8f, 0.25f);
    }

    void Update() {
        transform.position = new Vector2(Mathf.Clamp(GetXPos(), minX, maxX), transform.position.y);
    }

    private float GetXPos() {
        if (gameSession.IsAutoPlayEnabled()) {
            return ball.transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;

        }
    }
}
