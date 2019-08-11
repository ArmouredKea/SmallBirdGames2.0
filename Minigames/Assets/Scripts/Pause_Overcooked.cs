using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Overcooked : Pause
{
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public override void PauseButton() {

        if (!paused) {
            Component[] childrenCharacterScripts;
            childrenCharacterScripts = GetComponentsInChildren(typeof(PC_Overcooked));

            if (childrenCharacterScripts != null) {
                foreach (PC_Overcooked character in childrenCharacterScripts) {
                    character.paused = true;
                }
            }
            paused = true;
        } else {
            Component[] childrenCharacterScripts;
            childrenCharacterScripts = GetComponentsInChildren(typeof(PC_Overcooked));

            if (childrenCharacterScripts != null) {
                foreach (PC_Overcooked character in childrenCharacterScripts) {
                    character.paused = false;
                }
            }
            paused = false;
        }

    }
}
