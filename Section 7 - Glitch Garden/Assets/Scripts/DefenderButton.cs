using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour {
    [SerializeField] Defender defender;

    private void Start() {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost() {
        Text costText = GetComponentInChildren<Text>();

        if (costText) {
            costText.text = defender.GetStarCost().ToString();
        } else {
            Debug.LogError(name + " has no cost text, add some!");
        }
    }

    private void OnMouseDown() {
        DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(75, 75, 75, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defender);
    }
}
