using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour {
    [SerializeField] Defender defender;

    private void OnMouseDown() {
        DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(75, 75, 75, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defender);
    }
}
