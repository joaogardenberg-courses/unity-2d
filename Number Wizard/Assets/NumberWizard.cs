using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        int min = 1, max = 1000;

        Debug.Log("Welcome to number wizard");
        Debug.Log("Pick a number from " + min + " to " + max + ", and don't tell me what it is...");
        Debug.Log("Is it " + (min + max / 2) + "?");
        Debug.Log("Enter = Correct, Up = Higher, Down = Lower");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Debug.Log("Up arrow key was pressed.");
        }
    }
}
