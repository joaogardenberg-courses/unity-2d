using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {
    int min, max, guess;

    // Start is called before the first frame update
    void Start() {
        min = 1;
        max = 1000;
        guess = (min + max / 2);

        Debug.Log("Welcome to number wizard");
        Debug.Log("Pick a number from " + min + " to " + max + ", and don't tell me what it is...");
        Debug.Log("Is it " + guess + "?");
        Debug.Log("Enter = Correct, Up = Higher, Down = Lower");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("Woohoo, jackpot! It's " + guess + "!");
        } else
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
            if (min == max || min == guess || max == guess) {
                Debug.Log("Woohoo, jackpot! It's " + guess + "!");
                return;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                min = guess;
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                max = guess;
            }

            if (min == max) {
                Debug.Log("Woohoo, jackpot! Iiiiiiit's " + guess + "!");
                return;
            }

            guess = (min + max) / 2;
            Debug.Log("Is it " + guess + "?");
            Debug.Log("Enter = Correct, Up = Higher, Down = Lower");
        }
    }
}
